namespace ConsoleApp.Models
{
    public class Record
    {
        public Guid Id { get; set; } = new Guid();
        public User User { get; set; }
        public Boock Boock { get; set; }
        public DateTime Take { get; set; }
        public DateTime Return { get; set; }
    }
}