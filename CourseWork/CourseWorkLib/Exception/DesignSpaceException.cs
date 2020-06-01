using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkLib.Exception
{
    class DesignSpaceException : System.Exception
    {
        public string Value { get; }
        public DesignSpaceException() : base() { }
        public DesignSpaceException(string message) : base(message) { }
        public DesignSpaceException(string message, System.Exception inner) : base(message, inner) { }
        public DesignSpaceException(string message, string val) : base(message)
        {
            Value = val;
        }

        protected DesignSpaceException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
