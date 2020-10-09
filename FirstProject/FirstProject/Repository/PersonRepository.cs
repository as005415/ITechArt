using System.Collections.Generic;
using System.Linq;
using FirstProject.Models;

namespace FirstProject.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _context;

        public PersonRepository(PersonContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetPersons()
        {
            return _context.Persons.ToList();
        }

        public Person GetPerson(int id)
        {
            return _context.Persons.Find(id);
        }

        public void AddPerson(Person person)
        {
            if (person != null)
            {
                _context.Persons.Add(person);
            }
        }

        public void DeletePerson(int id)
        {
            var person = _context.Persons.Find(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}