using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Bogus;

using ConsoleApp.Models.Domain;
using ConsoleApp.Models.Slack;
using ConsoleApp.Services;

using Moq;

using Shouldly;

using Xunit;

namespace ConsoleApp.Tests
{
    public class StudentsServiceTests
    {
        private readonly Mock<ICacheClient> _cacheClientMock;
        private readonly Mock<ISlackApiClient> _slackApiClientMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly Faker _faker;
        private readonly Faker<User> _userFaker;

        private readonly string _key;
        private readonly StudentsService _studentsService;

        public StudentsServiceTests()
        {
            _cacheClientMock = new Mock<ICacheClient>();
            _slackApiClientMock = new Mock<ISlackApiClient>();
            _mapperMock = new Mock<IMapper>();

            _faker = new Faker();

            _userFaker = new Faker<User>()
                .RuleFor(x => x.Name, f => f.Person.UserName)
                .RuleFor(x => x.RealName, f => f.Name.FullName())
                .RuleFor(x => x.IsAdmin, f => f.Random.Bool())
                .RuleFor(x => x.IsPrimaryOwner, f => f.Random.Bool())
                .RuleFor(x => x.IsBot, f => f.Random.Bool())
                .RuleFor(x => x.IsAppUser, f => f.Random.Bool())
                .RuleFor(x => x.IsOwner, f => f.Random.Bool());

            _key = _faker.Random.Utf16String();
            _studentsService = new StudentsService(_cacheClientMock.Object, _slackApiClientMock.Object, _mapperMock.Object, _key);
        }

        [Fact]
        public async Task GetRandomStudentShouldGetItWithoutApi()
        {
            // Arrange
            StringKey key = new(_key);
            User[] users = _userFaker.GenerateBetween(0, 20).Append(new User
            {
                Name = _faker.Person.UserName,
                RealName = _faker.Name.FullName()
            }).ToArray();

            _ = _cacheClientMock.Setup(x => x.GetOrSet(key, It.IsAny<Func<CancellationToken, ValueTask<IEnumerable<User>>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult<IEnumerable<User>>(users));

            // Act
            User result = await _studentsService.GetRandomStudent();

            // Arrange
            result.ShouldBeOneOf(users, new UserEqualityComparer());
        }

        [Fact]
        public async Task GetRandomStudentShouldUseSlackApi()
        {
            // Arrange
            StringKey key = new(_key);
            User[] users = _userFaker.GenerateBetween(0, 20).Append(new User
            {
                Name = _faker.Person.UserName,
                RealName = _faker.Name.FullName()
            }).ToArray();

            UsersResponse response = new()
            {
                Members = Enumerable.Range(0, _faker.Random.Byte()).Select(x => new Member()),
                Ok = true,
            };

            _ = _slackApiClientMock.Setup(x => x.GetMembers(It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(response));

            _ = _mapperMock.Setup(x => x.Map<IEnumerable<User>>(response.Members))
                .Returns(() => users);

            _ = _cacheClientMock.Setup(x => x.GetOrSet(key, It.IsAny<Func<CancellationToken, ValueTask<IEnumerable<User>>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns((IKey k, Func<CancellationToken, ValueTask<IEnumerable<User>>> func, CancellationToken token) => func(token).AsTask());

            // Act
            User result = await _studentsService.GetRandomStudent();

            // Arrange
            result.ShouldBeOneOf(users, new UserEqualityComparer());
        }


        [Fact]
        public async Task GetRandomStudentShouldThrowIfNotOk()
        {
            // Arrange
            StringKey key = new(_key);
            UsersResponse response = new()
            {
                Members = null,
                Ok = false,
            };

            _ = _slackApiClientMock.Setup(x => x.GetMembers(It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(response));

            _ = _cacheClientMock.Setup(x => x.GetOrSet(key, It.IsAny<Func<CancellationToken, ValueTask<IEnumerable<User>>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns((IKey k, Func<CancellationToken, ValueTask<IEnumerable<User>>> func, CancellationToken token) => func(token).AsTask());

            // Act
            Func<Task<User>> result = () => _studentsService.GetRandomStudent();

            // Arrange
            _ = await result.ShouldThrowAsync<Exception>();
        }


        [Fact]
        public async Task GetRandomStudentShouldThrowIfNoStudents()
        {
            // Arrange
            StringKey key = new(_key);

            UsersResponse response = new()
            {
                Members = Enumerable.Empty<Member>(),
                Ok = true
            };

            _ = _slackApiClientMock.Setup(x => x.GetMembers(It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(response));

            _ = _mapperMock.Setup(x => x.Map<IEnumerable<User>>(response.Members))
                .Returns(Enumerable.Empty<User>);

            _ = _cacheClientMock.Setup(x => x.GetOrSet(key, It.IsAny<Func<CancellationToken, ValueTask<IEnumerable<User>>>>(),
                    It.IsAny<CancellationToken>()))
                .Returns((IKey k, Func<CancellationToken, ValueTask<IEnumerable<User>>> func, CancellationToken token) => func(token).AsTask());

            // Act
            Func<Task<User>> result = () => _studentsService.GetRandomStudent();

            // Arrange
            _ = await result.ShouldThrowAsync<Exception>();
        }
    }
}