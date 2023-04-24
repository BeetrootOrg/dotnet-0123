using System;

namespace TaskManagement.Domain.Helpers
{
    internal interface IIdentifierGenerator
    {
        Guid Generate();
    }

    internal class IdentifierGenerator : IIdentifierGenerator
    {
        public Guid Generate()
        {
            return Guid.NewGuid();
        }
    }
}