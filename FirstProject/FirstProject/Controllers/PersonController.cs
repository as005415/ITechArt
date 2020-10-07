using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private PersonContext db;

        public PersonController(PersonContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await db.Persons.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await db.Persons.FindAsync(id);
            if (person==null)
            {
                return NotFound();
            }
            return person;
        }
        
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            db.Persons.Add(person);
            await db.SaveChangesAsync();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await db.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.Persons.Remove(person);
            await db.SaveChangesAsync();
            return Ok(person);
        }
    }
}