namespace Company
{
    public class ManagerExtra : IEmployeeExtra
    {
        public string NextPosition()
        {
            return "Boss";
        }

        public string[] Responsibilities()
        {
            return new string[] {"Controlling", "Evaluating", "Planning"};
        }
    }
}