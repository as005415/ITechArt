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
    public class PersonRequestController : Controller
    {
        private readonly IRepository _repository;

        public PersonRequestController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonRequests()
        {
            return Ok(await _repository.GetAllPersonRequestInProgress());
        }

        [HttpPost]
        public async Task<IActionResult> ApproveOrDenyPersonRequest(PersonsRequestsViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(await _repository.EditPersonRequestState(viewModel));
        }
    }
}