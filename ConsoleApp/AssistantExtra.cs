namespace Company
{
    public class AssistantExtra : IEmployeeExtra
    {
        public string Promotion()
        {
            return "Manager";
        }

        public string[] Responsibilities()
        {
            return new string[] {"Conduct employee performance reviews", "Develop good customer relationships"};
        }
    }
}