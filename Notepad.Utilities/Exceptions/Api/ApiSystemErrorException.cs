using System;
using Notepad.Utilities.Messages;

namespace Notepad.Utilities.Exceptions.Api
{
    public class ApiSystemErrorException: Exception
    {
        public string Message { get; set; } = ResultMessages.SystemError;

        public ApiSystemErrorException() : base()
        {
        }

        public ApiSystemErrorException(string message) : base(message)
        {
            Message = message;
        }

        public ApiSystemErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}