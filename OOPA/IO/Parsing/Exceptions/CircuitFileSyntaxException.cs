using System;


namespace OOPA.IO.Parsing.Exceptions
{
    internal class CircuitFileSyntaxException : Exception
    {
        internal CircuitFileSyntaxException(string message)
            : base(message)
        { }

        internal CircuitFileSyntaxException(string classTag, string message)
            : base(classTag + ": " + message)
        { }

        internal CircuitFileSyntaxException(string classTag, string methodTag, string message)
            : base(classTag + "." + methodTag + ": " + message)
        { }
    }
}
