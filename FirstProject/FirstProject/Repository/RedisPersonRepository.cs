using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace FirstProject.Repository
{
    public class RedisPersonRepository : IRedisPersonRepository
    {
        private readonly IDistributedCache _distributedCache;

        public RedisPersonRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public string GetString(string key)
        {
            return _distributedCache.GetString(key);
        }

        public void SetString(string key, string value)
        {
            _distributedCache.SetString(key, value);
        }
    }
}