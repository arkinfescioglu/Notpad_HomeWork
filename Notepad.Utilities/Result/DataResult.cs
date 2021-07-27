#nullable enable
using Notepad.Utilities.Messages;

namespace Notepad.Utilities.Result
{
    public class DataResult<T>: Result
    {
        #region Variables

        public T ? Data { get; set; }

        #endregion

        #region Succes DataResult

        public DataResult<T> Success(T data, string message = null)
        {
            return new DataResult<T>
            {
                    Data    = data,
                    Message = message ?? ResultMessages.Success,
            };
        }

        #endregion

        #region Error DataResult

        public DataResult<T?> DataError(string message)
        {
            return new DataResult<T ?>
            {
                    Data    = default,
                    Message = message,
            };
        }

        #endregion
    }
}