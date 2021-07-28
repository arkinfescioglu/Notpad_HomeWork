using System;
using System.Threading.Tasks;
using Notepad.Service.Users.Dtos.Inputs;
using Notepad.Service.Users.Dtos.Outputs;
using Notepad.Utilities.Result;

namespace Notepad.Service.Users
{
    public interface IUserService
    {
        Task<Result> CreateAsync(UserCreateInputDto userCreateInputDto);

        Task<DataResult<UserInfoOutDto>> GetByIdAsync(Guid id);

        Task IsUserIdExist(Guid userId);
    }
}