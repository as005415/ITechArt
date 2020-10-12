using System;
using System.Collections.Generic;
using FirstProject.Models;

namespace FirstProject.Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        void AddPerson(Person person);
        void DeletePerson(int id);
        void Save();
    }
}