using System;


namespace OOPA.IO.Parsing.Exceptions
{
    internal class CurrentNodeNotFoundException : Exception
    {
        internal CurrentNodeNotFoundException(string message)
            : base (message)
        { }

        internal CurrentNodeNotFoundException(string classTag, string message)
            : base(classTag + ": " + message)
        { }

        internal CurrentNodeNotFoundException(string classTag, string methodTag, string message)
            : base(classTag + "." + methodTag + ": " + message)
        { }
    }
}
