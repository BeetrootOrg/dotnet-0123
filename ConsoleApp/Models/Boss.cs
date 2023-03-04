namespace ConsoleApp.Models
{
    public class Boss : Employee, CanBoost
    {
        public Boss(string firstName, string lastName) : base(firstName, lastName)
        {
            Position = Positions.Performer;
        }

        public Employee Promote(Employee? applicant)
        {
            if (applicant == null) throw new ArgumentNullException("applicant ArgumentNullException");
            return applicant.Position switch
            {
                Positions.Assistant => new Performer(applicant.FirstName, applicant.LastName),
                Positions.Performer => new Manager(applicant.FirstName, applicant.LastName),
                Positions.Manager => new Boss(applicant.FirstName, applicant.LastName),
                Positions.Boss => throw new IndexOutOfRangeException("There is no one better than a boss"),
                _ => throw new  ArgumentOutOfRangeException("Who are you man?"),
            };
        }
    }
}