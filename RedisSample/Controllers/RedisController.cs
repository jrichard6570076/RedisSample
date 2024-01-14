using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedisSample.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly ILogger<RedisController> _logger;
        public RedisController(ILogger<RedisController> logger) { 
            _logger = logger;
        }

        [HttpGet(Name = "AddKey")]
        public bool AddKey()
        {
            return true;
        }
    }
}
