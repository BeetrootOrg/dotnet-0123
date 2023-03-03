namespace ConsoleApp
{
#pragma warning disable
    public struct Complex : IEquatable<Complex>
#pragma warning restore
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        /// <summary>
        /// Creates a complex number with zero imaginary part.
        /// </summary>
        /// <param name="real">Real part</param>
        /// <returns>Complex number</returns>
        public Complex(double real) : this(real, 0)
        {
        }

        /// <summary>
        /// Creates a complex number with the given real and imaginary parts.
        /// </summary>
        /// <param name="real">Real part</param>
        /// <param name="imaginary">Imaginary part</param>
        /// <returns>Complex number</returns>
        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override string ToString()
        {
            return Imaginary switch
            {
                0 => Real.ToString(),
                > 0 => $"{Real}+{Imaginary}i",
                _ => $"{Real}-{-Imaginary}i"
            };
        }

        public bool Equals(Complex other)
        {
            return Real == other.Real &&
                Imaginary == other.Imaginary;
        }

        public static Complex operator -(Complex c)
        {
            return new Complex(-c.Real, -c.Imaginary);
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return c1 + (-c2);
        }

        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Complex c1, Complex c2)
        {
            return !c1.Equals(c2);
        }
    }
}