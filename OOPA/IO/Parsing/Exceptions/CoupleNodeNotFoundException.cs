using System;


namespace OOPA.IO.Parsing.Exceptions
{
    internal class CoupleNodeNotFoundException : Exception
    {
        internal CoupleNodeNotFoundException(string message)
            : base(message)
        { }

        internal CoupleNodeNotFoundException(string classTag, string message)
            : base(classTag + ": " + message)
        { }

        internal CoupleNodeNotFoundException(string classTag, string methodTag, string message)
            : base(classTag + "." + methodTag + ": " + message)
        { }
    }
}
