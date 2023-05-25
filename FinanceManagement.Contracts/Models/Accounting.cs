using System;

namespace FinanceManagement.Contracts.Models
{
    public class Accounting
    {
        public string Id {get; init;}
        public string Title {get; init;}
        public float Value {get; init;}
        public int Iterations {get; init;}
        public DateTime Created_at {get; init;}

    }
}