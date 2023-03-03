namespace ConsoleApp
{
    public enum AnimalType
    {
        Dog,
        Cat,
        Bird,
        Elephant
    }

    public class AnimalBad
    {
        public AnimalType Type { get; init; }

        public void MakeNoise()
        {
            switch (Type)
            {
                case AnimalType.Dog:
                    Console.WriteLine("Woof");
                    break;
                case AnimalType.Cat:
                    Console.WriteLine("Meow");
                    break;
                case AnimalType.Bird:
                    Console.WriteLine("Chirp");
                    break;
                case AnimalType.Elephant:
                    Console.WriteLine("Trumpet");
                    break;
                default:
                    break;
            }
        }
    }

    public abstract class AnimalGood
    {
        public abstract void MakeNoise();
    }

    public class Dog : AnimalGood
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Woof");
        }
    }

    public class Cat : AnimalGood
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Meow");
        }
    }

    public class Bird : AnimalGood
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Chirp");
        }
    }

    public class Elephant : AnimalGood
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Trumpet");
        }
    }
}