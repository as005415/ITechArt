using System;
using System.Collections.Generic;
using FirstProject.Models;

namespace FirstProject.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
        Person GetPerson(int id);
        void AddPerson(Person person);
        void DeletePerson(int id);
        void Save();
    }
}