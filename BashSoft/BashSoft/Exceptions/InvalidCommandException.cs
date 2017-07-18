using System;

namespace BashSoft.Exceptions
{
    public class InvalidCommandException : Exception
    {
        private const string InvalidCommand = "The command '{0}' is invalid";

        public InvalidCommandException(string message) 
            : base(string.Format(InvalidCommand, message))
        {
        }
    }
}
