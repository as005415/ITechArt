using StackExchange.Redis;

namespace FirstProject.Repository
{
    public interface IRedisPersonRepository
    {
        string GetString(string key);
        void SetString(string key, string value);
    }
}