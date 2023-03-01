namespace Geometry
{
    public class Shape
    {
        protected int _sides { get; init; }   
        
        public string Type
        { 
            get => this.GetType().ToString().Split('.')[^1];
        }

        public virtual double Perimeter { get; }
        public virtual double Area { get; }
        public virtual int SidesNumber
        { 
            get => _sides; 
        }
        
    }
}