using System.Runtime.Serialization;

namespace Invoice.Exceptions
{
    public class DeleteConflictException : Exception
    {
        public DeleteConflictException()
        {
        }

        public DeleteConflictException(string? message) : base(message)
        {
        }

        public DeleteConflictException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DeleteConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
