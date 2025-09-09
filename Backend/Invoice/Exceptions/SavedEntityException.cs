using System.Runtime.Serialization;

namespace Invoice.Exceptions
{
    [Serializable]
    internal class SavedEntityException : Exception
    {
        public SavedEntityException()
        {
        }

        public SavedEntityException(string? message) : base(message)
        {
        }

        public SavedEntityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SavedEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}