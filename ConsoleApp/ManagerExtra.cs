namespace Company
{
    public class ManagerExtra : IEmployeeExtra
    {
        public string Promotion()
        {
            return "Boss";
        }

        public string[] Responsibilities()
        {
            return new string[] {"Controlling", "Evaluating", "Planning"};
        }
    }
}