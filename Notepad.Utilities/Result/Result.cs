using System.Collections.Generic;
using Notepad.Utilities.Messages;

namespace Notepad.Utilities.Result
{
    public class Result
    {
        #region Result Variables

        public string Message   { get; set; }
        public bool   IsSuccess { get; set; } = true;

        public bool IsValidationError { get; set; } = false;

        public bool IsAuthError { get; set; } = false;

        public bool IsException { get; set; } = false;

        public Dictionary<string, string> ValidationMessages = new Dictionary<string, string>();

        #endregion Result Variables

        #region Success Result With Data || Message Not Required

        public Result Success(string message = null)
        {
            return new Result
            {
                    Message = message ?? ResultMessages.Success,
            };
        }

        #endregion Success Result With Data || Message Not Required
        
        #region Error Result With Data || Message Not Required

        public Result Error(string message = null)
        {
            return new Result
            {

                    Message = message ?? ResultMessages.Error
            };
        }

        #endregion Error Result With Data || Message Not Required

        #region Validation Error

        public Result ValidError(Dictionary<string, string> validationMessages)
        {
            return new Result
            {
                    ValidationMessages = validationMessages,
                    IsSuccess          = false,
                    IsValidationError  = true,
            };
        }

        #endregion

        #region Auth Error

        public Result AuthError(string message = null)
        {
            return new Result
            {
                    IsSuccess = false,
                    IsAuthError = true,
                    Message = ResultMessages.NoLoginError,
            };
        }

        #endregion

        #region Exception Error

        public Result ExceptionError(string message = null)
        {
            return new Result
            {
                    IsSuccess = false,
                    IsException = true,
                    Message = message ?? ResultMessages.SystemError,
            };
        }

        #endregion
    }
}