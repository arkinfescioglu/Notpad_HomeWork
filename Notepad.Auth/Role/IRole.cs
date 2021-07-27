using System.Threading.Tasks;
using Notepad.Auth.Role.Dtos.Outputs;

namespace Notepad.Auth.Role
{
    public interface IRole
    {
        Task<bool>           Check(string        needRole);
        Task<UserInfoOutDto> GetUserTitle(string needRole);
    }
}