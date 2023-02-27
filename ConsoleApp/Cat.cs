namespace ConsoleApp
{
    public class Cat : Animal
    {
        public bool IsLazy { get; init; }

        public Cat()
        {
            NumOfPaws = 4;
            Sound = "Meow";
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Color: {Color}, Paws: {NumOfPaws}, Lazy: {IsLazy}");
        }

        public new void PrintAge()
        {
            Console.WriteLine($"{Name} is {Age} years old and is lazy: {IsLazy}");
        }
    }
}