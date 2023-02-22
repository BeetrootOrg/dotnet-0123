namespace ConsoleApp
{
    public class Person
    {
        public ChangesTracker Tracker { get; } = new ChangesTracker();

        private string _firstName;
        private string _lastName;
        private int _age;

        public string FirstName
        {
            get => _firstName;
            set
            {
                Tracker.IncChanges();
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                Tracker.IncChanges();
                _lastName = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                Tracker.IncChanges();
                _age = value;
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        public Person() { }

        public Person(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public Person(Person person) : this(person.FirstName, person.LastName, person.Age) { }

        public string GetFullInfo()
        {
            return $"First Name: {FirstName}. Last Name: {LastName}. Age: {Age}";
        }
    }
}