using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notepad.Auth.Api.Dtos.Inputs;
using Notepad.Auth.Api.Dtos.Outputs;
using Notepad.Domain.Users;
using Notepad.Utilities.Result;

namespace Notepad.Auth.Api
{
    public interface IApiAuth
    {
        #region Üye Girişi Yapar (Login Actions)

        Task<DataResult<AuthLoginOutDto>> Login(AuthLoginInputDto authLoginInputDto);

        #endregion

        #region Header'da token var mı, süresi geçmiş mi ve geçerli token mı bakar

        bool Check();

        #endregion

        #region Yeni Token Oluşturur. Ek Claim olmadan

        string CreteToken();

        #endregion

        #region Token'ın Bütün Claimlarını Verir.

        Dictionary<string, string> GetPayloads();

        #endregion

        #region Claim'dan UserId Verir

        Guid GetId(string token = null);

        #endregion

        #region Payload Arar

        string FindPayload(string key, string token = null);

        #endregion

        #region Login Durumda Olan Kullanıcının Verileri Getirir

        Task<User> User();

        #endregion

        #region Header'daki Token'ı Verir

        string GetToken();

        #endregion
    }
}