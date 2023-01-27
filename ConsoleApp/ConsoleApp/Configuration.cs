using System;

namespace ConsoleApp
{
    internal class Configuration
    {
        public string SlackToken { get; init; }
        public string RedisConnectionString { get; init; }
        public TimeSpan? Ttl { get; init; }
        public string RedisKey { get; init; } = "users";
    }
}