using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using ConsoleApp.Extensions;
using ConsoleApp.Models.Domain;
using ConsoleApp.Models.Slack;

namespace ConsoleApp.Services
{
    internal interface IStudentsService
    {
        Task<User> GetRandomStudent(CancellationToken cancellationToken = default);
    }

    internal class StudentsService : IStudentsService
    {
        private readonly ICacheClient _cacheClient;
        private readonly ISlackApiClient _slackApiClient;
        private readonly IMapper _mapper;
        private readonly IKey _key;

        public StudentsService(ICacheClient cacheClient, ISlackApiClient slackApiClient, IMapper mapper, string key = "users")
            : this(cacheClient, slackApiClient, mapper, new StringKey(key))
        {
        }

        private StudentsService(ICacheClient cacheClient, ISlackApiClient slackApiClient, IMapper mapper, IKey key)
        {
            _cacheClient = cacheClient;
            _slackApiClient = slackApiClient;
            _mapper = mapper;
            _key = key;
        }

        public async Task<User> GetRandomStudent(CancellationToken cancellationToken = default)
        {
            IEnumerable<User> users = await _cacheClient.GetOrSet(_key,
                async token => await GetUsersFromSlack(token), cancellationToken);

            User[] students = users.Where(UserExtensions.IsStudent).ToArray();

            if (!students.Any())
            {
                throw new Exception("No students in workspace");
            }

            Random random = new((int)DateTime.Now.Ticks);
            return students[random.Next(0, students.Length)];
        }

        private async Task<IEnumerable<User>> GetUsersFromSlack(CancellationToken cancellationToken = default)
        {
            UsersResponse result = await _slackApiClient.GetMembers(cancellationToken);

            return !result.Ok
                ? throw new Exception("Slack API returned not OK")
                : _mapper.Map<IEnumerable<User>>(result.Members);
        }
    }
}