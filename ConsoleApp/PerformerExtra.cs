namespace Company
{
    public class PerformerExtra : IEmployeeExtra
    {
        public string Promotion()
        {
            return "Assistant";
        }

        public string[] Responsibilities()
        {
            return new string[] {"Flexibility", "Resilience", "Teamwork"};
        }
    }
}