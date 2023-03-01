namespace Library
{
    public class Client
    {
        public static int _clientId = 1;
        public int ClientId { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; }
        public bool Subscription { get; set; }

        public Client (string name, string surname, bool subscription)
        {
            ClientId = _clientId++;
            Name = name;
            Surname = surname;
            FullName = $"{Name} {Surname}";
            Subscription = subscription;
        }
    }
}