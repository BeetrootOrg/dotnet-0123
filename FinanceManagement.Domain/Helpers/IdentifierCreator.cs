using System;

namespace FinanceManagement.Domain.Helpers
{
    public interface IIdentifierGenerator
    {
        Guid Generate();
    }

    public class IdentifierGenerator : IIdentifierGenerator
    {
        public Guid Generate()
        {
            return Guid.NewGuid();
        }
    }
}