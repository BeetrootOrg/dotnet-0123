namespace ConsoleApp
{
    public class Dog : Animal
    {
        public Dog()
        {
            NumOfPaws = 4;
            Sound = "Woof";
        }

        protected override Animal ExtendWithSpecificAttributes(Animal animal)
        {
            return new Dog
            {
                Name = animal.Name,
                Color = animal.Color,
                Age = animal.Age
            };
        }

        public override bool Equals(object obj)
        {
            return obj is Dog && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}