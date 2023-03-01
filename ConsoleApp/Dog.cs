namespace ConsoleApp
{
    public class Dog : Animal
    {
        public Dog()
        {
            NumOfPaws = 4;
            Sound = "Woof";
        }

        protected override Animal ExtendWithSpecificAttributes(string name)
        {
            return new Dog
            {
                Name = name,
                Color = Color,
                Age = Age
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