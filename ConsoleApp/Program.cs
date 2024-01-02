using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata;

namespace ConsoleApp
{
    public interface IElectronicDevice
    {
        void TurnOn();
        void TurnOff();
        string GetInfo();
    }

    public class Television : IElectronicDevice
    {
        public string Brand { get; set; }
        public Television(string brand)
        {
            Brand = brand;
        }
        public void ChangeChannel(){}
        public void TurnOff(){}
        public void TurnOn(){}
        public string GetInfo()
        {
            return Brand;
        }
    }

    public class Smartphone : IElectronicDevice
    {
        public string Manufacturer { get; set; }
        public Smartphone(string manufacturer)
        {
            Manufacturer = manufacturer;
        }
        public void MakeCall(){}
        public void TurnOff(){}
        public void TurnOn(){}
        public string GetInfo()
        {
            return Manufacturer;
        }

    }
}


namespace Name
{
    public interface IShape
    {
        double CalculateArea();
    }

    public interface IVolume
    {
        double CalculateVolume();
    }

    public class ShapeCalculator
    {
        public void PrintArea(IShape shape)
        {
            double area = shape.CalculateArea();
            Console.WriteLine($"Area: {area}");
        }

        public void PrintVolume(IVolume volume)
        {
            double number = volume.CalculateVolume();
            Console.WriteLine($"Volume: {number}");
        }
    }

    public class Circle : IShape, IVolume
    {
        public double Radius {get;set;}
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double CalculateVolume()
        {
            return 0;
        }
    }

    public class Rectangle : IShape, IVolume
    {
        public double Width {get;set;}
        public double Height {get;set;}

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculateVolume()
        {
            return 0;
        }
    }

    public class Triangle : IShape, IVolume
    {
        public double A {get;set;}
        public double B {get;set;}
        public double C {get;set;}
        public double H {get;set;}

        public Triangle(double a, double b, double c, double h)
        {
            A = a;
            B = b;
            C = c;
            H = h;
        }

        public double CalculateArea()
        {
            double P = (A + B + C)/2;
            return Math.Sqrt(P * (P - A) * (P - B) * (P - C));
        }

        public double CalculateVolume()
        {
            return 0;
        }
    }

    public class Cuboid : IVolume
    {
        public double Width {get;set;}
        public double Height {get;set;}
        public double Length {get;set;}

        public Cuboid(double width, double height, double length)
        {
            Width = width;
            Height = height;
            Length = length;
        }
        public double CalculateVolume()
        {
            return Width * Height * Length;
        }
    }
}

namespace Name
{
    public interface IDocument
    {
        void Type();
    }

    public class PDF : IDocument
    {
        public void Type()
        {
            Console.WriteLine("Type of document - PDF");
        }
    }

    public class Word : IDocument
    {
        public void Type()
        {
            Console.WriteLine("Type of document - Word");
        }
    }
    public class Excel : IDocument
    {
        public void Type()
        {
            Console.WriteLine("Type of document - Excel");
        }
    }

    abstract class DocumentProcessor
    {
        public void PlanDocument()
        {
            IDocument document = CreateDocument();
            document.Type();
        }
        
        protected abstract IDocument CreateDocument();
    }

    class PagePDF : DocumentProcessor
    {
        protected override IDocument CreateDocument()
        {
            return new PDF();
        }
    }

    class PageWord : DocumentProcessor
    {
        protected override IDocument CreateDocument()
        {
            return new Word();
        }
    }
    class PageExcel : DocumentProcessor
    {
        protected override IDocument CreateDocument()
        {
            return new Excel();
        }
    }
}

namespace Name
{
    // Абстрактний клас для гарячого напою
    public abstract class HotDrink
    {
    public abstract void Prepare();
    }

    // Конкретний продукт - чай
    public class Tea : HotDrink
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare Tea");
        }
    }

    // Конкретний продукт - кава
    public class Coffee : HotDrink
    {
        public override void Prepare()
        {
            Console.WriteLine("Prepare Coffee");
        }
    }

    // Абстрактний клас для холодного напою
    public abstract class ColdDrink
    {
        public abstract void Serve();
    }

    // Конкретний продукт - сік
    public class Juice : ColdDrink
    {
        public override void Serve()
        {
            Console.WriteLine("Serve Juice");
        }
    }

    public class Lemonade : ColdDrink
    {
        public override void Serve()
        {
            Console.WriteLine("Serve Lemonade");
        }
    }

    public abstract class AbstractFactory
    {
        public abstract HotDrink CreateHotDrink();
        public abstract ColdDrink CreateColdDrink();
    }

    public class MenuDrink1 : AbstractFactory
    {
        public override HotDrink CreateHotDrink()
        {
            return new Tea();
        }
        public override ColdDrink CreateColdDrink()
        {
            return new Lemonade();
        }
    }

    public class MenuDrink2 : AbstractFactory
    {
        public override HotDrink CreateHotDrink()
        {
            return new Coffee();
        }

        public override ColdDrink CreateColdDrink()
        {
            return new Juice();
        }
    }
    
}

class Program 
{
    static void Main()
    {
        int i = 42;       // значимий тип
        object obj = i;   // boxing: int перетворено в object
        int j = (int)obj; // unboxing: object перетворено в int
    }
}

