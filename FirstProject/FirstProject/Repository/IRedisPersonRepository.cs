using System.Collections.Generic;
using FirstProject.Models;
using StackExchange.Redis;

namespace FirstProject.Repository
{
    public interface IRedisPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        void UpdateAll(IEnumerable<Person> persons);
        void AddOrUpdate(Person person);
        void RemovePerson(Person person);
    }
}