using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    public class User
    {
        public required int Id { get; init; }
        public required string Username { get; init; }

        public User() { }

        [SetsRequiredMembers]
        public User(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}