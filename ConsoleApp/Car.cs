using System;
using System.Reflection.Metadata.Ecma335;

namespace CarExample
{
    public class Car
    {
        public string Brand {get; set;}
        public string Model {get; set;}
        public int Year {get;set;}
        public int Speed {get;set;}

        public Car(string brand, string model, int year)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Speed = 0;
        }

        public int Accelerate(int accelerate)
        {
            Speed += accelerate;
            return Speed;
        }

        public int Brake(int brake)
        {
            Speed -= brake;
            return Speed;
        }
        public void Stop()
        {
            Speed = 0;
        }

        public string PrintInfo()
        {
            return $"{Brand} {Model} {Year} {Speed}";
        }
    }

    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Car car = new("Ford", "Mustang", 1999);
    //         Console.WriteLine(car.PrintInfo());
    //         car.Accelerate(20);
    //         Console.WriteLine(car.PrintInfo());
    //         car.Brake(10);
    //         Console.WriteLine(car.PrintInfo());
    //         car.Stop();
    //         Console.WriteLine(car.PrintInfo());
    //     }
    // }
}