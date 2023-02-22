namespace ConsoleApp
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

        public string GetFullInfo()
        {
            return $"First Name: {FirstName}. Last Name: {LastName}. Age: {Age}";
        }
    }
}