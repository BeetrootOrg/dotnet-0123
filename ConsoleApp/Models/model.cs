namespace ConsoleApp.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MenuItemText { get => $"{Id}. {Name}"; }
        public List<Option> Options { get; set; } = new();
    }

    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VoteCounter { get; set; }
    }

}