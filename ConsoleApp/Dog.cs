namespace ConsoleApp
{
    public class Dog : Animal
    {
        public Dog()
        {
            NumOfPaws = 4;
            Sound = "Woof";
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