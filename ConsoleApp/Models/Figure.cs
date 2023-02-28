namespace ConsoleApp.Models
{

    public class Figure
    {
        public virtual string Type { get; init; }
        public virtual double Square { get; }
        public virtual double Perimeter { get; }
        public virtual int SidesNumber { get; init; }
        public Figure()
        {
            throw new Exception("You must pass parameters");
        }
        public virtual bool Check()
        {
            return true;
        }
    }
}