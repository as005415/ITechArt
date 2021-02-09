using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
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
                                      && VerifyHashedPassword(x.Password, loginCredentials.Password));
            return user;
        }

        private bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null || password == null)
            {
                return false;
            }
            
            var src = Convert.FromBase64String(hashedPassword);
            if (src.Length != 0x31 || src[0] != 0)
            {
                return false;
            }
            var dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            
            var buff2 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buff2, 0, 0x20);
            
            using var bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8);
            var buff = bytes.GetBytes(0x20);
            
            return buff.SequenceEqual(buff2);
        }
        
        private string GenerateJwtToken(UserModel userModelInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

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