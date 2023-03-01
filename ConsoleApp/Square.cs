namespace Geometry
{
    public class Square : Shape
    {
        private double _a;
        
        public override double Perimeter
        {
            get => _a * 4;
        }

        public override double Area
        {
            get => _a * _a;
        }  

        public Square(double a)
        {
            if (a <= 0)
            {
                throw new Exception(); 
            }
            _a = a;
            _sides = 4;
        } 

        public override string ToString()
        {
            return $"Type: {Type}; " +
                $"Side A: {_a}; " +
                $"Perimeter: {Perimeter}; " +
                $"Area: {Area}; " + 
                $"SidesNumber: {_sides}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Square square && _a == square._a;  
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

    }
}