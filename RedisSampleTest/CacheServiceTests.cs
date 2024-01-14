using System;
using Xunit;
using RedisService.Cache;
using StackExchange.Redis;
using System.Text.Json;

namespace RedisSampleTest
{
    public class CacheServiceTests
    {
        [Fact]
        public void SetAndGetAndRemoveData_Success()
        {
            // Arrange
            var cacheService = new CacheService();
            var key = "testKey";
            var testData = "MyData";

            // Act
            var setResult = cacheService.SetData(key, testData, DateTimeOffset.Now.AddMinutes(1));
            var getResult = cacheService.GetData<string>(key);
            var removeResult = cacheService.RemoveData(key);

            // Assert
            Assert.True(setResult);
            Assert.NotNull(getResult);
            Assert.Equal(testData, getResult);
            Assert.True(removeResult);
        }

        [Fact]
        public void GetData_NonexistentKey_ReturnsDefault()
        {
            // Arrange
            var cacheService = new CacheService();
            var key = "nonexistentKey";

            // Act
            var getResult = cacheService.GetData<string>(key);

            // Assert
            Assert.Equal(default(string), getResult);
        }
    }
}
