using System;

namespace BashSoft.Exceptions
{
    public class InvalidNumberOfScoresException : Exception
    {
        private const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible.";

        public InvalidNumberOfScoresException()
            : base(InvalidNumberOfScores)
        {
        }

        public InvalidNumberOfScoresException(string message)
            : base(message)
        {
        }
    }
}
