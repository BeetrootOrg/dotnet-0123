using System;

namespace TestingNamespace
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void SayHello()
        {
            Console.WriteLine($"Hello, my name is {FirstName} {LastName}.");
        }
        public void AddAge(int age)
        {
            Age += age;
        }
    }

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public void Start()
        {
            Console.WriteLine($"Starting the {Year} {Make} {Model}.");
        }
    }

}