namespace ConsoleApp
{
     public class Person
    {
        public ChangesTracker Tracker { get; set; } = new ChangesTracker();
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
                Tracker.IncChanges();
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
                Tracker.IncChanges();
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
                Tracker.IncChanges();
                _age = value;
             }
        }

          public string FullName => $"{FirstName} {LastName}";

        public Person(string firstName, string lastName, int age)
        {
            Tracker = new ChangesTracker();
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