namespace ConsolApp
{
    public abstract class Animal
    {
        protected int NumOfPaws {get; init;}
        public string Name {get; init;}
        public string Color {get; init;}
        public int Age {get; init;}
        protected string Sound {get; init;}

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

         public Animal Multiply(Animal animal, string name)
        {
            return GetType() != animal.GetType()
                ? throw new ArgumentException("Animals must be of the same type")
                : ExtendWithSpecificAttributes(name);
        }

        protected abstract Animal ExtendWithSpecificAttributes(string name);

        public override string ToString()
        {
            return $"Name: {Name}, Color: {Color}, Paws: {NumOfPaws}";  
        }

        public override bool Equals(object obj)
        {
                return obj is Animal animal &&
                Name == animal.Name &&
                Color == animal.Color &&
                Age == animal.Age &&
                NumOfPaws == animal.NumOfPaws &&
                Sound == animal.Sound; 
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Color, Age, NumOfPaws, Sound);
        }
    }
} 