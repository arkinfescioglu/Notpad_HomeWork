using System;
using Notepad.Utilities.Messages;

namespace Notepad.Utilities.Exceptions.Api
{
    public class ApiAuthException: Exception
    {
        public string Message { get; set; }

        public ApiAuthException() : base()
        {
            Message = ResultMessages.AuthError;
        }

        public ApiAuthException(string message = null) : base(message)
        {
            Message = message ?? ResultMessages.AuthError;
        }

        public ApiAuthException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}