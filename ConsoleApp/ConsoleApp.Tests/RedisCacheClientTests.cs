using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bogus;

using ConsoleApp.Services;

using Moq;

using Shouldly;

using StackExchange.Redis;

using Xunit;

namespace ConsoleApp.Tests
{
    public class RedisCacheClientTests
    {
        private readonly Mock<IDatabase> _databaseMock;
        private readonly Mock<ISerializer> _serializerMock;
        private readonly Mock<IDeserializer> _deserializerMock;
        private readonly Faker _faker;

        private readonly TimeSpan? _ttl;
        private readonly RedisCacheClient _cacheClient;

        public RedisCacheClientTests()
        {
            _databaseMock = new Mock<IDatabase>();
            _serializerMock = new Mock<ISerializer>();
            _deserializerMock = new Mock<IDeserializer>();
            _ttl = TimeSpan.FromMinutes(15);

            _cacheClient = new RedisCacheClient(_databaseMock.Object, _serializerMock.Object,
                _deserializerMock.Object, _ttl);

            _faker = new Faker();
        }

        [Fact]
        public async Task SetShouldDoItAlways()
        {
            // Arrange
            const string keyValue = "str1";
            Mock<IKey> key = new();
            _ = key.Setup(x => x.ToKey()).Returns(keyValue);

            var value = new
            {
                some = 1,
                property = "str"
            };

            byte[] bytes = _faker.Random.Bytes(_faker.Random.Int(1, 50));

            _ = _serializerMock.Setup(x => x.Serialize(value, It.IsAny<CancellationToken>()))
                .Returns(() => new ValueTask<MemoryStream>(new MemoryStream(bytes)));

            // Act
            await _cacheClient.Set(key.Object, value);

            // Assert
            _databaseMock.Verify(x => x.StringSetAsync(keyValue,
                It.Is<RedisValue>(redisValue => ((byte[])redisValue).SequenceEqual(bytes)),
                _ttl, When.Always, CommandFlags.None),
                Times.Once);
        }

        [Fact]
        public async Task GetShouldReturnValueIfPresentInCache()
        {
            // Arrange
            const string keyValue = "str1";
            Mock<IKey> key = new();
            _ = key.Setup(x => x.ToKey()).Returns(keyValue);

            TestSerializeModel value = new()
            {
                Value1 = 1,
                Value2 = "str"
            };

            byte[] bytes = _faker.Random.Bytes(_faker.Random.Int(1, 50));

            _ = _deserializerMock.Setup(x => x.Deserialize<TestSerializeModel>(
                    It.Is<MemoryStream>(s => s.ToArray().SequenceEqual(bytes)),
                    It.IsAny<CancellationToken>()))
                .Returns(() => new ValueTask<TestSerializeModel>(value));

            _ = _databaseMock.Setup(x => x.StringGetAsync(key.Object.ToKey(), CommandFlags.None))
                .Returns(() => Task.FromResult<RedisValue>(bytes));

            // Act
            TestSerializeModel result = await _cacheClient.Get<TestSerializeModel>(key.Object);

            // Assert
            result.ShouldBe(value);
        }

        [Fact]
        public async Task GetShouldReturnDefaultIfAbsentInCache()
        {
            // Arrange
            const string keyValue = "str1";
            Mock<IKey> key = new();
            _ = key.Setup(x => x.ToKey()).Returns(keyValue);

            _ = _databaseMock.Setup(x => x.StringGetAsync(key.Object.ToKey(), CommandFlags.None))
                .Returns(() => Task.FromResult(new RedisValue()));

            // Act
            TestSerializeModel result = await _cacheClient.Get<TestSerializeModel>(key.Object);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task GetOrSetShouldNotCallDatabase()
        {
            // Arrange
            const string keyValue = "str1";
            Mock<IKey> key = new();
            _ = key.Setup(x => x.ToKey()).Returns(keyValue);

            TestSerializeModel value = new()
            {
                Value1 = 1,
                Value2 = "str"
            };

            byte[] bytes = _faker.Random.Bytes(_faker.Random.Int(1, 50));

            _ = _deserializerMock.Setup(x => x.Deserialize<TestSerializeModel>(
                    It.Is<MemoryStream>(s => s.ToArray().SequenceEqual(bytes)),
                    It.IsAny<CancellationToken>()))
                .Returns(() => new ValueTask<TestSerializeModel>(value));

            _ = _databaseMock.Setup(x => x.StringGetAsync(key.Object.ToKey(), CommandFlags.None))
                .Returns(() => Task.FromResult<RedisValue>(bytes));

            // Act
            TestSerializeModel result = await _cacheClient.GetOrSet<TestSerializeModel>(key.Object, _ => throw new Exception());

            // Assert
            result.ShouldBe(value);

            _databaseMock.Verify(x => x.StringGetAsync(key.Object.ToKey(),
                CommandFlags.None), Times.Once);

            _databaseMock.Verify(x => x.StringSetAsync(It.IsAny<RedisKey>(),
                It.IsAny<RedisValue>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<When>(),
                It.IsAny<CommandFlags>()), Times.Never);
        }

        [Fact]
        public async Task GetOrSetShouldSetToCacheIfAbsent()
        {
            // Arrange
            const string keyValue = "str1";
            Mock<IKey> key = new();
            _ = key.Setup(x => x.ToKey()).Returns(keyValue);

            TestSerializeModel value = new()
            {
                Value1 = 1,
                Value2 = "str"
            };

            byte[] bytes = _faker.Random.Bytes(_faker.Random.Int(1, 50));

            _ = _databaseMock.Setup(x => x.StringGetAsync(key.Object.ToKey(), CommandFlags.None))
                .Returns(() => Task.FromResult(new RedisValue()));

            _ = _serializerMock.Setup(x => x.Serialize(value, It.IsAny<CancellationToken>()))
                .Returns(() => new ValueTask<MemoryStream>(new MemoryStream(bytes)));

            // Act
            TestSerializeModel result = await _cacheClient.GetOrSet(key.Object, _ => new ValueTask<TestSerializeModel>(value));

            // Assert
            result.ShouldBe(value);

            _databaseMock.Verify(x => x.StringGetAsync(key.Object.ToKey(),
                CommandFlags.None), Times.Once);

            _databaseMock.Verify(x => x.StringSetAsync(key.Object.ToKey(),
                It.Is<RedisValue>(redisValue => ((byte[])redisValue).SequenceEqual(bytes)),
                _ttl,
                When.Always,
                CommandFlags.None), Times.Once);
        }
    }
}