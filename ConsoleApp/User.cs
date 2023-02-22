namespace ConsoleApp
{
    public class User
    {
        public int Id { get; init; }
        public string Username { get; init; }

        public User() { }

        public User(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}