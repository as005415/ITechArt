using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstProject.Models;
using FirstProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace FirstProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IRedisPersonRepository _redisPersonRepository;

        public PersonController(IPersonRepository personRepository, IRedisPersonRepository redisPersonRepository)
        {
            _personRepository = personRepository;
            _redisPersonRepository = redisPersonRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var allPersons = _personRepository.GetAll();
            if (allPersons == null) return NotFound();
            return Ok(allPersons);
        }

        [HttpGet("redis")]
        public ActionResult<IEnumerable<Person>> GetAllUsingRedisCache()
        {
            var allPersons = _redisPersonRepository.GetAll();
            if (allPersons != null) return Ok(allPersons);
            
            allPersons = _personRepository.GetAll();
            
            if (allPersons == null) return NotFound();
            _redisPersonRepository.UpdateAll(allPersons);
            
            return Ok(allPersons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = _personRepository.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet("redis/{id}")]
        public ActionResult<Person> GetUsingRedisCache(int id)
        {
            var person = _redisPersonRepository.Get(id);
            if (person != null) return Ok(person);

            person = _personRepository.Get(id);

            if (person == null) return NotFound();
            _redisPersonRepository.AddOrUpdate(person);

            return Ok(person);
        }

        [HttpPost]
        public ActionResult<Person> AddPerson(Person person)
        {
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

            _redisPersonRepository.RemovePerson(person);
            _personRepository.DeletePerson(id);
            _personRepository.Save();
            return Ok(person);
        }
    }
}