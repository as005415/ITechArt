using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Storage.Models;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;

        public LoginController(IRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserModel userModelInput)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(userModelInput);
            if (user != null)
            {
                var tokenString = GenerateJwtToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user
                });
            }

            return response;
        }

        private UserModel AuthenticateUser(UserModel loginCredentials)
        {
            var user = _repository.GetAllUsersOnlyWithRoles()
                .SingleOrDefault(x => x.Login == loginCredentials.Login
                                      && x.Password == loginCredentials.Password);
            return user;
        }

        private string GenerateJwtToken(UserModel userModelInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            /*var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userModelInfo.Login),
                new Claim("userModelInput", userModelInfo.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };*/

            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userModelInfo.Login));
            claims.Add(new Claim("userModelInput", userModelInfo.Login));
            foreach (var role in _repository.GetUserRolesByUsername(userModelInfo.Login))
            {
                claims.Add(new Claim("role", role));
            }
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}