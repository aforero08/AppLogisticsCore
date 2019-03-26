using System;

namespace AppLogistics.Common.Exceptions
{
    public abstract class CommonException : Exception
    {
        protected CommonException()
        {
        }

        protected CommonException(string message) : base(message)
        {
        }

        protected CommonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
