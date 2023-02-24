namespace ConsoleApp
{
     public class Person
    {
        public int Counter { get; set; }
        private string _firstName;
        private string _lastName;
        private int _age;
        public string FirstName 
        {
             get 
             {
                return _firstName;
             }
             set
             {
                ++Counter;
                _firstName = value;
             }
        }

        public string LastName 
        {
             get 
             {
                return _lastName;
             }
             set
             {
                ++Counter;
                _lastName = value;
             }
        }
        
        public int Age 
        {
             get 
             {
                return _age;
             }
             set
             {
                ++Counter;
                _age = value;
             }
        }

          public string FullName => $"{FirstName} {LastName}";

        public Person(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public string GetFullInfo()
        {
            return $"First Name: {FirstName}. Last Name: {LastName}. Age: {Age}";
        }
    }
}