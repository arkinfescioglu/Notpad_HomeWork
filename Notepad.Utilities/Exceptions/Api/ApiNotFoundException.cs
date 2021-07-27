using System;
using Notepad.Utilities.Messages;

namespace Notepad.Utilities.Exceptions.Api
{
    public class ApiNotFoundException: Exception
    {
        public string Message { get; set; }
        
        public ApiNotFoundException() : base()
        {
            Message = ResultMessages.NotFound;
        }
        
        public ApiNotFoundException(string message = null) : base(message)
        {
            Message = message ?? ResultMessages.AuthError;
        }
        
        public ApiNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}