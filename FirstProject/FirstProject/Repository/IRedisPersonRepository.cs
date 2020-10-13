using System.Collections.Generic;
using FirstProject.Models;
using StackExchange.Redis;

namespace FirstProject.Repository
{
    public interface IRedisPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        void SaveAll(IEnumerable<Person> persons);
        void SavePerson(Person person);
    }
}