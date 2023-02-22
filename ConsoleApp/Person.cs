namespace ConsoleApp
{
    public class Person
    {
        public int Changes { get; set; }

        private string _firstName;
        private string _lastName;
        private int _age;

        public string FirstName
        {
            get => _firstName;
            set
            {
                ++Changes;
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                ++Changes;
                _lastName = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                ++Changes;
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

        public Person(Person person)
        {
            _firstName = person.FirstName;
            _lastName = person.LastName;
            _age = person.Age;
        }


        public string GetFullInfo()
        {
            return $"First Name: {FirstName}. Last Name: {LastName}. Age: {Age}";
        }
    }
}