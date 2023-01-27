using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using AutoMapper;
using ConsoleApp.Profiles;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using ConsoleApp;

using CancellationTokenSource cts = new();
CancellationToken token = cts.Token;

Console.CancelKeyPress += (_, _) => cts.Cancel();

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();

Configuration config = configuration.Get<Configuration>();

ConfigurationOptions redisConfig = new()
{
    EndPoints =
    {
        config.RedisConnectionString
    }
};

using ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(redisConfig);

IDatabase database = redis.GetDatabase();
MsgPackSerializer serializer = new();

ICacheClient cacheClient = new RedisCacheClient(database, serializer, serializer, config.Ttl);

IMapper mapper = new MapperConfiguration(mapperConfig => mapperConfig.AddProfile(new AppProfile())).CreateMapper();

const string slackUrl = "https://slack.com";
const string tokenType = "Bearer";

using HttpClient httpClient = new()
{
    BaseAddress = new Uri(slackUrl),
};

httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, config.SlackToken);

JsonSerializerSettings settings = new()
{
    ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
    }
};

ISlackApiClient slackClient = new SlackApiClient(httpClient, settings);
IStudentsService studentsService = new StudentsService(cacheClient, slackClient, mapper, config.RedisKey);

ConsoleApp.Models.Domain.User user = await studentsService.GetRandomStudent(token);

Console.WriteLine($"{user.Name} ({user.RealName}), you've killed!");
