namespace ConsoleApp
{
#pragma warning disable
    public struct Complex
#pragma warning restore
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real) : this(real, 0)
        {
        }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override string ToString()
        {
            return $"{Real}+{Imaginary}i";
        }
    }
}