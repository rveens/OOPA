using System;


namespace Parser.IO.Parsing.Exceptions
{
    internal class CircuitFileNotFoundException : Exception
    {
        internal CircuitFileNotFoundException(string message)
            : base(message)
        { }

        internal CircuitFileNotFoundException(string classTag, string message)
            : base(classTag + ": " + message)
        { }

        internal CircuitFileNotFoundException(string classTag, string methodTag, string message)
            : base(classTag + "." + methodTag + ": " + message)
        { }
    }
}
