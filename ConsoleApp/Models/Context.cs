namespace ConsoleApp.Models
{
    public class Context
    {
        private List<Record> Records = new List<Record>();
        public decimal Balance { get { return Records.Sum(x => x.Summ); } }
        public List<string> Operations { get { return Records.Select(x => x.ToString()).ToList(); } }

        public void Deposit(decimal summ)
        {
            Records.Add(new Record() { Summ = summ, Id = Records.Count });
        }

        public void Withdraw(decimal summ)
        {
            Records.Add(new Record() { Summ = -summ, Id = Records.Count });
        }
        public Context()
        {
        }
        // summ - сума початкового депозита
        public Context(decimal summ)
        {
            Deposit(summ);
        }

        private class Record
        {
            public int Id { get; set; } = 0;
            public DateTime DateTime { get; set; } = DateTime.Now;
            public decimal Summ { get; set; } = 0;

            public override string ToString()
            {
                return $"{Id}| {DateTime}| {Summ}";
            }
        }
    }
}