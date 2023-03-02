namespace Company
{
    public class BossExtra : IEmployeeExtra
    {
        public string NextPosition()
        {
            return "Boss cannot be promoted";
        }

        public string[] Responsibilities()
        {
            return new string[] {"Honesty", "Integrity", "Professionalism"};
        }
    }
}