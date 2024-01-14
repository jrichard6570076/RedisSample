using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisService.Cache;

namespace RedisSample.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly ILogger<RedisController> _logger;
        private readonly ICacheService _cacheService;
        public RedisController(ILogger<RedisController> logger,ICacheService cacheService) { 
            _logger = logger;
            _cacheService = cacheService;
        }

        [HttpGet(Name = "AddKey")]
        public bool AddKey(string Key,string Data)
        {
           
            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            return _cacheService.SetData<string>(Key,Data, expirationTime);
        }

        [HttpGet(Name = "AddKey")]
        public string GetKey(string Key)
        {
            return _cacheService.GetData<string>(Key);
        }

        [HttpGet(Name = "AddKey")]
        public bool RemoveKey(string Key)
        {
            return _cacheService.RemoveData(Key);
        }
    }
}
