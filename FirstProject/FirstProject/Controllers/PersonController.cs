using System.Collections.Generic;
using FirstProject.Models;
using FirstProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var allPersons = _personRepository.GetAll();
            return new ActionResult<IEnumerable<Person>>(allPersons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = _personRepository.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public ActionResult<Person> AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _personRepository.AddPerson(person);
            _personRepository.Save();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> DeletePerson(int id)
        {
            var person = _personRepository.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            _personRepository.DeletePerson(id);
            _personRepository.Save();
            return Ok(person);
        }
    }
}