using System;


namespace OOPA.IO.Parsing.Exceptions
{
    internal class CircuitFileSyntaxException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitFileSyntaxException"/> and the base class <seealso cref="Exception"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        internal CircuitFileSyntaxException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitFileSyntaxException"/> and the base class <seealso cref="Exception"/>.
        /// </summary>
        /// <param name="classTag">The tag of the class throwing this exception.</param>
        /// <param name="message">The message of the exception.</param>
        internal CircuitFileSyntaxException(string classTag, string message)
            : base(classTag + ": " + message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CircuitFileSyntaxException"/> and the base class <seealso cref="Exception"/>.
        /// </summary>
        /// <param name="classTag">The tag of the class throwing this exception.</param>
        /// <param name="methodTag">The tag of the method throwing this exception.</param>
        /// <param name="message">The message of the exception.</param>
        internal CircuitFileSyntaxException(string classTag, string methodTag, string message)
            : base(classTag + "." + methodTag + ": " + message)
        { }
    }
}
