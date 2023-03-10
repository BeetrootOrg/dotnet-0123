namespace ConsoleApp
{
    public abstract class Employee
    {
        public string FirstName {get; init;}
        public string LastName {get; init;}
        protected float Salary {get; init;}
        protected string[] Responsibilities {get; init;}
        protected TimeSpan Start {get; init;}
        protected TimeSpan End {get; init;}

        public void Promotion()
        {
            if (this is Boss)
            {
                Console.WriteLine("There is no one higher than boss");
            }
            else if (this is Performer)
            {
                Console.WriteLine("Manager");
            }
            else if (this is Manager)
            {
                Console.WriteLine("Assistant");
            }
            else if (this is Assistant)
            {
                Console.WriteLine("Boss");
            }
        }
        public abstract Employee Promote();
    }
}