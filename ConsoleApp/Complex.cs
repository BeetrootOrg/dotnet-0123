namespace ConsoleApp
{
#pragma warning disable
    public struct Complex : IEquatable<Complex>
#pragma warning restore
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public double this[int i]
        {
            get => i switch
            {
                0 => Real,
                1 => Imaginary,
                _ => throw new ArgumentException("Allowed indices are 0 and 1")
            };
            set
            {
                switch (i)
                {
                    case 0:
                        Real = value;
                        break;
                    case 1:
                        Imaginary = value;
                        break;
                    default:
                        throw new ArgumentException("Allowed indices are 0 and 1");
                }
            }
        }

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

        public static Complex operator +(Complex c1, double d2)
        {
            return new Complex(c1.Real + d2, c1.Imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return c1 + (-c2);
        }

        public static Complex operator -(Complex c1, double d2)
        {
            return c1 + (-d2);
        }

        public static bool operator ==(Complex c1, Complex c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Complex c1, Complex c2)
        {
            return !c1.Equals(c2);
        }

        public static explicit operator double(Complex c)
        {
            return Math.Sqrt((c.Real * c.Real) + (c.Imaginary * c.Imaginary));
        }

        public static implicit operator System.Numerics.Complex(Complex c)
        {
            return new System.Numerics.Complex(c.Real, c.Imaginary);
        }
    }
}