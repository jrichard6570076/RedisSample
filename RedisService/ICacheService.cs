
namespace RedisService.Cache
{
    public interface ICacheService
    {
        T GetData<T>(string key);
        bool RemoveData(string key);
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
    }
}