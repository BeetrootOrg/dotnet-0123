using System;

namespace ConsoleApp.Exceptions
{
    internal class InvalidBorderSizeException : Exception
    {
        public InvalidBorderSizeException(string message) : base(message)
        {
        }
    }
}