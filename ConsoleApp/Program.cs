using ConsoleApp;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using GenericContainer;

// namespace ConsoleApp
// {
//     public interface IElectronicDevice
//     {
//         void TurnOn();
//         void TurnOff();
//         string GetInfo();
//     }

//     public class Television : IElectronicDevice
//     {
//         public string Brand { get; set; }
//         public Television(string brand)
//         {
//             Brand = brand;
//         }
//         public void ChangeChannel(){}
//         public void TurnOff(){}
//         public void TurnOn(){}
//         public string GetInfo()
//         {
//             return Brand;
//         }
//     }

//     public class Smartphone : IElectronicDevice
//     {
//         public string Manufacturer { get; set; }
//         public Smartphone(string manufacturer)
//         {
//             Manufacturer = manufacturer;
//         }
//         public void MakeCall(){}
//         public void TurnOff(){}
//         public void TurnOn(){}
//         public string GetInfo()
//         {
//             return Manufacturer;
//         }

//     }
// }


// namespace Name
// {
//     public interface IShape
//     {
//         double CalculateArea();
//     }

//     public interface IVolume
//     {
//         double CalculateVolume();
//     }

//     public class ShapeCalculator
//     {
//         public void PrintArea(IShape shape)
//         {
//             double area = shape.CalculateArea();
//             Console.WriteLine($"Area: {area}");
//         }

//         public void PrintVolume(IVolume volume)
//         {
//             double number = volume.CalculateVolume();
//             Console.WriteLine($"Volume: {number}");
//         }
//     }

//     public class Circle : IShape, IVolume
//     {
//         public double Radius {get;set;}
//         public Circle(double radius)
//         {
//             Radius = radius;
//         }

//         public double CalculateArea()
//         {
//             return Math.PI * Math.Pow(Radius, 2);
//         }

//         public double CalculateVolume()
//         {
//             return 0;
//         }
//     }

//     public class Rectangle : IShape, IVolume
//     {
//         public double Width {get;set;}
//         public double Height {get;set;}

//         public Rectangle(double width, double height)
//         {
//             Width = width;
//             Height = height;
//         }

//         public double CalculateArea()
//         {
//             return Width * Height;
//         }

//         public double CalculateVolume()
//         {
//             return 0;
//         }
//     }

//     public class Triangle : IShape, IVolume
//     {
//         public double A {get;set;}
//         public double B {get;set;}
//         public double C {get;set;}
//         public double H {get;set;}

//         public Triangle(double a, double b, double c, double h)
//         {
//             A = a;
//             B = b;
//             C = c;
//             H = h;
//         }

//         public double CalculateArea()
//         {
//             double P = (A + B + C)/2;
//             return Math.Sqrt(P * (P - A) * (P - B) * (P - C));
//         }

//         public double CalculateVolume()
//         {
//             return 0;
//         }
//     }

//     public class Cuboid : IVolume
//     {
//         public double Width {get;set;}
//         public double Height {get;set;}
//         public double Length {get;set;}

//         public Cuboid(double width, double height, double length)
//         {
//             Width = width;
//             Height = height;
//             Length = length;
//         }
//         public double CalculateVolume()
//         {
//             return Width * Height * Length;
//         }
//     }
// }

// namespace Name
// {
//     public interface IDocument
//     {
//         void Type();
//     }

//     public class PDF : IDocument
//     {
//         public void Type()
//         {
//             Console.WriteLine("Type of document - PDF");
//         }
//     }

//     public class Word : IDocument
//     {
//         public void Type()
//         {
//             Console.WriteLine("Type of document - Word");
//         }
//     }
//     public class Excel : IDocument
//     {
//         public void Type()
//         {
//             Console.WriteLine("Type of document - Excel");
//         }
//     }

//     abstract class DocumentProcessor
//     {
//         public void PlanDocument()
//         {
//             IDocument document = CreateDocument();
//             document.Type();
//         }

//         protected abstract IDocument CreateDocument();
//     }

//     class PagePDF : DocumentProcessor
//     {
//         protected override IDocument CreateDocument()
//         {
//             return new PDF();
//         }
//     }

//     class PageWord : DocumentProcessor
//     {
//         protected override IDocument CreateDocument()
//         {
//             return new Word();
//         }
//     }
//     class PageExcel : DocumentProcessor
//     {
//         protected override IDocument CreateDocument()
//         {
//             return new Excel();
//         }
//     }
// }

// namespace Name
// {
//     // Абстрактний клас для гарячого напою
//     public abstract class HotDrink
//     {
//     public abstract void Prepare();
//     }

//     // Конкретний продукт - чай
//     public class Tea : HotDrink
//     {
//         public override void Prepare()
//         {
//             Console.WriteLine("Prepare Tea");
//         }
//     }

//     // Конкретний продукт - кава
//     public class Coffee : HotDrink
//     {
//         public override void Prepare()
//         {
//             Console.WriteLine("Prepare Coffee");
//         }
//     }

//     // Абстрактний клас для холодного напою
//     public abstract class ColdDrink
//     {
//         public abstract void Serve();
//     }

//     // Конкретний продукт - сік
//     public class Juice : ColdDrink
//     {
//         public override void Serve()
//         {
//             Console.WriteLine("Serve Juice");
//         }
//     }

//     public class Lemonade : ColdDrink
//     {
//         public override void Serve()
//         {
//             Console.WriteLine("Serve Lemonade");
//         }
//     }

//     public abstract class AbstractFactory
//     {
//         public abstract HotDrink CreateHotDrink();
//         public abstract ColdDrink CreateColdDrink();
//     }

//     public class MenuDrink1 : AbstractFactory
//     {
//         public override HotDrink CreateHotDrink()
//         {
//             return new Tea();
//         }
//         public override ColdDrink CreateColdDrink()
//         {
//             return new Lemonade();
//         }
//     }

//     public class MenuDrink2 : AbstractFactory
//     {
//         public override HotDrink CreateHotDrink()
//         {
//             return new Coffee();
//         }

//         public override ColdDrink CreateColdDrink()
//         {
//             return new Juice();
//         }
//     }

// }

// // class Program 
// // {
// //     static void Main()
// //     {
// //         int i = 42;       // значимий тип
// //         object obj = i;   // boxing: int перетворено в object
// //         int j = (int)obj; // unboxing: object перетворено в int
// //     }
// // }


// // Generic

// namespace Name
// {
//     public class Pair<T>
//     {
//         public T Item1 { get; set; }
//         public T Item2 { get; set; }

//         public Pair(T item1, T item2)
//         {
//             Item1 = item1;
//             Item2 = item2;
//         }
//     }

// class Program
// {
//     static void Main()
//     {
//         Pair<int> intPair = new Pair<int>(10, 20);
//         Pair<string> stringPair = new Pair<string>("Hello", "World");
//     }
// }
//}

// namespace Generics
// {
//     public class Container<T>
//     {
//         public T Value1 {get; set;}

//         public void Add(T item)
//         {
//             Value1 = item;
//         }
//         public void Remove()
//         {

//         }
//         public T Get()
//         {
//             return Value1;
//         }
//     }
// }


// // namespace Generics
// // {
// //     public class Pair<T1, T2>
// //     {
// //         private T1 _item1;
// //         private T2 _item2;

// //         public Pair(T1 item1, T2 item2)
// //         {
// //             _item1 = item1;
// //             _item2 = item2;
// //         }
// //         public void Swap(Pair<T1, T2> otherPair)
// //         {
// //             (this._item1, this._item2, otherPair._item1, otherPair._item2) =
// //                 (otherPair._item1, otherPair._item2, this._item1, this._item2);
// //         }

// //         public override string ToString()
// //         {
// //             return $"{_item1}, {_item2}";
// //         }
// //     }

// //     class Program
// //     {
// //         static void Main()
// //         {
// //             Pair<int, string> pair1 = new Pair<int, string>(42, "hello");
// //             Pair<int, string> pair2 = new Pair<int, string>(100, "world");

// //             pair1.Swap(pair2);

// //             Console.WriteLine(pair1.ToString()); // виведе "100, world"
// //             Console.WriteLine(pair2.ToString()); // виведе "42, hello"

// //             // int i = 0;
// //             // while (i <= 100) 
// //             // {
// //             //     Console.WriteLine(i);
// //             //     i++;
// //             // }
// //         }
// //     }

// // }

// namespace Generics1
// {
//     public class Box<T>
//     {
//         private T _content;

//         public Box(T content)
//         {
//             _content = content;
//         }

//         public T GetContent()
//         {
//             return _content;
//         }

//         public void SetContent(T content)
//         {
//             _content = content;
//         }

//         public void DisplayInfo()
//         {
//             Console.WriteLine($"Box content: {_content}");
//         }

//         public override string ToString()
//         {
//             return _content.ToString();
//         }
//     }

//     class Program
//     {
//         static void Main()
//         {
//             Box<string> box1 = new("Hello");
//             Console.WriteLine($"{box1} world!");

//             Box<int> box2 = new(42);
//             box2.DisplayInfo();
//         }
//     }
// }

// namespace Name1
// {
//     public class Pair<T>
//     {
//         public void Swap(ref T int1, ref T int2)
//         {
//             (int1, int2) = (int2, int1);
//         }     
//     }
//     class Program
//     {
//         static void Main()
//         {
//             int i1 = 15;
//             int i2 = 20;
//             Pair<int> pair = new();
//             pair.Swap(ref i1, ref i2);
//             Console.WriteLine((i1, i2)); 
//         }
//     }
// }

// Stack<int> intStack = new Stack<int>();
// intStack.Push(1);
// intStack.Push(2);
// intStack.Push(3);
// intStack.Pop();

// Console.WriteLine("Current Stack:");

// while (intStack.Count > 0)
// {
//     Console.WriteLine($"Peek: {intStack.Peek()}");
//     Console.WriteLine($"Pop: {intStack.Pop()}");
// }

// Stack<string> stringStack = new Stack<string>();
// stringStack.Push("Hello");
// stringStack.Push("World");
// stringStack.Push("!");

// Console.WriteLine("\nCurrent Stack:");

// while (stringStack.Count > 0)
// {
//     Console.WriteLine($"Peek: {stringStack.Peek()}");
//     Console.WriteLine($"Pop: {stringStack.Pop()}");
// }


// namespace Math
// {
//     public class MinMaxFinder<T>
//     {
//         public void FindMin(T[] array)
//         {
//             T min = array.Min();
//         }

//         public void FindMax(T[] array)
//         {
//             T max = array.Max();
//         }
//     }
// }


// static void WriteLineElements<T>(IEnumerable<T> collection)
// {
//     Console.WriteLine(string.Join(",", collection));
// }

// public class StudentEnumerable : IEnumerable<int>
//     {
//         private readonly IEnumerable<int> _collection;

//         public StudentEnumerable(IEnumerable<int> collection)
//         {
//             _collection = collection;
//         }

//         private class StudentEnumerator : IEnumerator<int>
//         {
//             private readonly IEnumerator<int> _enumerator;

//             public StudentEnumerator(IEnumerator<int> enumerator)
//             {
//                 _enumerator = enumerator;
//             }

//             public int Current { get; private set; }

//             object IEnumerator.Current => Current;

//             public void Dispose()
//             {
//                 _enumerator.Dispose();
//             }

//             public bool MoveNext()
//             {
//                 return _enumerator.MoveNext();
//             }

//         public void Reset()
//             {
//                 _enumerator.Reset();
//             }
//         }

//         public IEnumerator<int> GetEnumerator()
//         {
//             return new StudentEnumerator(_collection.GetEnumerator());
//         }

//         IEnumerator IEnumerable.GetEnumerator()
//         {
//             return GetEnumerator();
//         }
//     }
// public class Student : IEnumerable<int>
// {
//     public List<int> Grades { get; set; }

//     public Student(List<int> grades)
//     {
//         Grades = grades;
//     }

//     public IEnumerator<int> GetEnumerator()
//     {
//         return Grades.GetEnumerator();
//     }

//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
//}



