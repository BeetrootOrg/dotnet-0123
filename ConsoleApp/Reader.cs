namespace BookLibrary
{
    public class Reader
    {
        private static int _id;
        public int Id { get => _id; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public Reader(string firstName, string lastName) : this(firstName, lastName, String.Empty) {}
        public Reader(string firstName, string lastName, string phone)
        {
            _id++;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}