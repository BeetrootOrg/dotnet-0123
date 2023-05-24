using System;

namespace FinanceManagement.Domain.Exceptions
{
    public enum FinanceManagementError
    {
        AccountingNotFound,
        AccountingValueCannotBeChanged,
    }

    public class FinanceManagementException : Exception
    {
        public FinanceManagementError Error { get; }

        public FinanceManagementException(FinanceManagementError error, string message) : base(message)
        {
            Error = error;
        }
    }
}