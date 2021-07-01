using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.DTOModels;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    [Route("/api/[controller]")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> GetNumberInQueue(PersonNumberViewModel personCredential)
        {
            return Ok(await _repository.GetPersonNumberByCredential(personCredential));
        }
    }
}