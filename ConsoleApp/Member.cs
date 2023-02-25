namespace BookLibrary
{
    public class Member
    {
        private static int _id;
        public int Id { get => _id; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public Member(string firstName, string lastName) : this(firstName, lastName, String.Empty) {}
        public Member(string firstName, string lastName, string phone)
        {
            _id++;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}