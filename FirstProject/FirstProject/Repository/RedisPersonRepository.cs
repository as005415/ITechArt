using System.Collections.Generic;
using System.Linq;
using FirstProject.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace FirstProject.Repository
{
    public class RedisPersonRepository : IRedisPersonRepository
    {
        private readonly IDistributedCache _distributedCache;
        private const string CacheKey = "personList";

        public string GetCacheKey(int id)
        {
            return $"{CacheKey}-{id}";
        } 
            
        public RedisPersonRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public IEnumerable<Person> GetAll()
        {
            var redisPersonList = _distributedCache.GetString(CacheKey);
            if (redisPersonList == null) return null;
            
            IEnumerable<Person> personList = JsonConvert.DeserializeObject<List<Person>>(redisPersonList);
            
            return personList;
        }

        public Person Get(int id)
        {
            var cacheKeyId = GetCacheKey(id);
            var redisPerson = _distributedCache.GetString(cacheKeyId);
            if (redisPerson == null) return null;
            
            var person = JsonConvert.DeserializeObject<Person>(redisPerson);
            
            return person;
        }

        public void UpdateAll(IEnumerable<Person> persons)
        {
            var redisPersonList = JsonConvert.SerializeObject(persons);
            _distributedCache.SetString(CacheKey, redisPersonList);
        }

        public void AddOrUpdate(Person person)
        {
            var cacheKeyId = GetCacheKey(person.Id);
            var redisPerson = JsonConvert.SerializeObject(person);
            _distributedCache.SetString(cacheKeyId, redisPerson);
        }

        public void RemovePerson(Person person)
        {
            var cacheKeyId = GetCacheKey(person.Id);
            _distributedCache.Remove(cacheKeyId);
        }
    }
}