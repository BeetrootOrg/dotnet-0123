namespace Company
{
    public class AssistantExtra : IEmployeeExtra
    {
        public string NextPosition()
        {
            return "Manager";
        }

        public string[] Responsibilities()
        {
            return new string[] {"Conduct employee performance reviews", "Develop good customer relationships"};
        }
    }
}