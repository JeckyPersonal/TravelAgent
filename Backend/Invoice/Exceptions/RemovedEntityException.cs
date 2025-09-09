using System.Runtime.Serialization;

namespace Invoice.Exceptions
{
    [Serializable]
    internal class RemovedEntityException : Exception
    {
        public RemovedEntityException()
        {
        }

        public RemovedEntityException(string? message) : base(message)
        {
        }

        public RemovedEntityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RemovedEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}