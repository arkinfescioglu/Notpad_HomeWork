using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Service.Users;
using Notepad.Service.Users.Dtos.Inputs;
using Notepad.Service.Users.Dtos.Outputs;
using Notepad.Service.Users.Validations;
using Notepad.Utilities.Result;
using Swashbuckle.AspNetCore.Annotations;

namespace Notepad.API.Controllers.Users
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController: ApiBaseController
    {
        #region Variables

        private readonly IUserService _userService;

        private readonly IEfUnitOfWork _efUnitOfWork;
        
        #endregion

        #region Construct

        public UserController(IUserService userService, IEfUnitOfWork efUnitOfWork)
        {
            _userService       = userService;
            _efUnitOfWork = efUnitOfWork;
        }

        #endregion

        #region Create New User

        [HttpPost("CreateNewUser")]
        [SwaggerOperation(Description = "Yeni Üye Kaydı Oluşturur (Creates new user).")]
        public async Task<Result> CreateNewUser(UserCreateInputDto userCreateInputDto)
        {
            //Fluent Validasyon Çoğu Şey Burada Yapılıyor.
            await (new UserCreateValidation(userCreateInputDto, _efUnitOfWork)).Validate();

            return await _userService.CreateAsync(userCreateInputDto);
        }

        #endregion
        
        #region GetUserById
        [HttpGet("GetUserById")]
        [SwaggerOperation(Description = @"Id'si Verilen Üyenin Profil Bilgilerini Getirir. 
                                          Dapper Repository Kullanılmıştır Çünkü Join Var. 
                                          (Gives UserInfo by Given UserId)")]
        public async Task<DataResult<UserInfoOutDto>> GetUserById(Guid id)
        {
            return await _userService.GetByIdAsync(id);
        }

        #endregion
    }
}