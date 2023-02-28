namespace ConsoleApp.Models
{

    public class Figure
    {
        public string Type { get; init; }
        public virtual double Square { get; }
        public virtual double Perimeter { get; }
        public int SidesNumber { get; init; }
        public Figure()
        {
            throw new Exception("You must pass parameters");
        }
        public virtual bool Check()
        {
            return true;
        }

        public override bool Equals(object? obj)
        {
           return obj==null &&  GetType()==obj?.GetType();
        }
    }
}