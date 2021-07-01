using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    //[Authorize]
    [AllowAnonymous]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("GetUserData")]
        public IActionResult GetUserData()
        {
            return Ok("This is a response from user method");
        }
    }
}