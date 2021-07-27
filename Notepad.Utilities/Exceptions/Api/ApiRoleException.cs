using System;
using Notepad.Utilities.Messages;

namespace Notepad.Utilities.Exceptions.Api
{
    public class ApiRoleException: Exception
    {
        public string Message { get; set; }
        
        public ApiRoleException(): base()
        {
            Message = ResultMessages.RolePermissionsError;
        }
        
        public ApiRoleException(string message = null): base(message)
        {
            Message = message ?? ResultMessages.RolePermissionsError;
        }
    }
}