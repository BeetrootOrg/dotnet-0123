using System;

namespace ConsoleApp.Exceptions
{
    internal class OutOfConsoleRangeException : Exception
    {
        public OutOfConsoleRangeException(string message) : base(message)
        {
        }
    }
}