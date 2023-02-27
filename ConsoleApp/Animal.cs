namespace ConsoleApp
{
    public class Animal
    {
        public string Name { get; init; }
        public string Color { get; init; }
        protected int NumOfPaws { get; init; }
        protected string Sound { get; init; }

        public void MakeNoise()
        {
            Console.WriteLine($"{Name} says {Sound}");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Color: {Color}, Paws: {NumOfPaws}");
        }
    }
}