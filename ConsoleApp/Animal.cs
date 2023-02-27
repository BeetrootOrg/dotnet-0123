namespace ConsoleApp
{
    public class Animal
    {
        public string Name { get; init; }
        public string Color { get; init; }
        public int Age { get; init; }
        protected int NumOfPaws { get; init; }
        protected string Sound { get; init; }

        public void MakeNoise()
        {
            Console.WriteLine($"{Name} says {Sound}");
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public void PrintAge()
        {
            Console.WriteLine($"{Name} is {Age} years old");
        }

        public override string ToString()
        {
            return $"Name: {Name}, Color: {Color}, Paws: {NumOfPaws}";
        }
    }
}