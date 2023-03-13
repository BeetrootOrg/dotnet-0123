namespace ConsoleApp.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}