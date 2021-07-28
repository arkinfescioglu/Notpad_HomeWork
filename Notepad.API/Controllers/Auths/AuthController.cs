using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notepad.Auth.Api;
using Notepad.Auth.Api.Dtos.Inputs;
using Notepad.Auth.Api.Dtos.Outputs;
using Notepad.Utilities.Result;
using Swashbuckle.AspNetCore.Annotations;

namespace Notepad.API.Controllers.Auths
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AuthController: ControllerBase
    {
        #region Variables

        private readonly IApiAuth _apiAuth;
        
        #endregion

        #region Construct

        public AuthController(IApiAuth apiAuth)
        {
            _apiAuth = apiAuth;
        }

        #endregion

        #region Login Action

        [HttpPost("Login")]
        [SwaggerOperation(Description = "Kullanıcı Girişi İşlemi. (Login Action)")]
        public async Task<DataResult<AuthLoginOutDto>> Login(AuthLoginInputDto authLoginInputDto)
        {
            return await _apiAuth.Login(authLoginInputDto);
        }

        #endregion
    }
}