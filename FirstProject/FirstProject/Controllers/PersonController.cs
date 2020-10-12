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
        private readonly IDistributedCache _distributedCache;

        public PersonController(IPersonRepository personRepository, IDistributedCache distributedCache)
        {
            _personRepository = personRepository;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var allPersons = _personRepository.GetAll();
            return new ActionResult<IEnumerable<Person>>(allPersons);
        }

        [HttpGet("redis")]
        public ActionResult<IEnumerable<Person>> GetAllUsingRedisCache()
        {
            const string cacheKey = "personList";
            List<Person> personList;
            var redisPersonList = _distributedCache.GetString(cacheKey);
            if (redisPersonList != null)
            {
                personList = JsonConvert.DeserializeObject<List<Person>>(redisPersonList);
            }
            else
            {
                personList = _personRepository.GetAll().ToList();
                redisPersonList = JsonConvert.SerializeObject(personList);
                _distributedCache.SetString(cacheKey, redisPersonList);
            }

            return Ok(personList);
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
            const string cacheKey = "personList";
            List<Person> personList;
            var redisPersonList = _distributedCache.GetString(cacheKey);
            if (redisPersonList != null)
            {
                personList = JsonConvert.DeserializeObject<List<Person>>(redisPersonList);
            }
            else
            {
                personList = _personRepository.GetAll().ToList();
                redisPersonList = JsonConvert.SerializeObject(personList);
                _distributedCache.SetString(cacheKey, redisPersonList);
            }

            var person = personList.Find(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }

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

            _personRepository.DeletePerson(id);
            _personRepository.Save();
            return Ok(person);
        }
    }
}