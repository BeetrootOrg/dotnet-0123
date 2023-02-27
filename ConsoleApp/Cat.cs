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

        public new void PrintAge()
        {
            Console.WriteLine($"{Name} is {Age} years old and is lazy: {IsLazy}");
        }

        protected override Animal ExtendWithSpecificAttributes(Animal animal)
        {
            return new Cat
            {
                Name = animal.Name,
                Color = animal.Color,
                Age = animal.Age,
                IsLazy = IsLazy
            };
        }

        public override string ToString()
        {
            return $"Name: {Name}, Color: {Color}, Paws: {NumOfPaws}, Lazy: {IsLazy}";
        }

        public override bool Equals(object obj)
        {
            return obj is Cat cat &&
                base.Equals(obj) &&
                IsLazy == cat.IsLazy;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), IsLazy);
        }
    }
}