using System;
using System.Runtime.Serialization;

namespace ConsoleGame.Engine.Exceptions
{
    public class DuplicateComponentException : Exception
    {
        public DuplicateComponentException()
        {
        }
        public DuplicateComponentException(string message) : base(message)
        {
        }
        public DuplicateComponentException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected DuplicateComponentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}