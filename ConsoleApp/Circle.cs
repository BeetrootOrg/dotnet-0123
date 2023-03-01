namespace Geometry
{
    public class Circle : Shape
    {
        private double _r;

        public override double Perimeter
        {
            get => 2 * Math.PI * _r;
        }

        public override double Area
        {
            get => Math.PI * _r * _r;
        }

        public override int SidesNumber
        {
            get => _sides;
        } 
        
        public Circle(double r)
        {
            if (r <= 0)
            {
                throw new Exception(); 
            }
            _r = r;
            _sides = -1;
        }

        public override string ToString()
        {
            return $"Type: {Type}; " +
                $"Radius: {_r}; " +
                $"Perimeter: {Perimeter}; " +
                $"Area: {Area}; " + 
                $"SidesNumber: {_sides}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Circle circle && _r == circle._r; 
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        
    }
}