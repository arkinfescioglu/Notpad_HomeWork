using System;
using Notepad.Utilities.Messages;

namespace Notepad.Utilities.Exceptions.Api
{
    public class ApiResponseException: Exception
    {
        public string Message { get; set; }
        
        public ApiResponseException(): base()
        {
            
        }

        public ApiResponseException(string message = null): base(message)
        {
            Message = message ?? ResultMessages.SystemError;
        }

        public ApiResponseException(string message, Exception innerException): base(message, innerException)
        {
            
        }
    }
}