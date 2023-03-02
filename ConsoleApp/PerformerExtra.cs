namespace Company
{
    public class PerformerExtra : IEmployeeExtra
    {
        public string NextPosition()
        {
            return "Assistant";
        }

        public string[] Responsibilities()
        {
            return new string[] {"Flexibility", "Resilience", "Teamwork"};
        }
    }
}