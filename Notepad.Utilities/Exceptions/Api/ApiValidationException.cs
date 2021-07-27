using System;
using System.Collections.Generic;

namespace Notepad.Utilities.Exceptions.Api
{
    public class ApiValidationException: Exception
    {
        public Dictionary<string, string> ValidationMessages { get; set; }
        public string                     Message            { get; set; } = "Validasyon Hatası";
        
        public ApiValidationException(Dictionary<string, string> validationMessages,
                string                                           message = "Validasyon Hatası") : base(message)
        {
            ValidationMessages = validationMessages;
        }
        
        public ApiValidationException(string message) : base(message)
        {
            Message = message;
        }

        public ApiValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}