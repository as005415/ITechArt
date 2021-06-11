using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.DTOModels;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    [Route("/api/[controller]")]
    //[Authorize]
    [AllowAnonymous]
    public class AddRequestController : Controller
    {
        private readonly IRepository _repository;

        public AddRequestController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(AddRequestViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            return Ok(await _repository.AddPersonRequestWithData(viewModel));
        }
    }
}