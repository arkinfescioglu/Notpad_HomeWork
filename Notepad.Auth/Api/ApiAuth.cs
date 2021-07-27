using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Notepad.Auth.Api.Dtos.Inputs;
using Notepad.Auth.Api.Dtos.Outputs;
using Notepad.Auth.Api.Sql;
using Notepad.Auth.Jwt;
using Notepad.Dapper.Repository;
using Notepad.Domain.Users;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Utilities.Exceptions.Api;
using Notepad.Utilities.Helpers;
using Notepad.Utilities.Messages;
using Notepad.Utilities.Result;

namespace Notepad.Auth.Api
{
    public class ApiAuth : IApiAuth
    {
        #region ApiAuth Variables

        private readonly JwtToken _jwtToken = new JwtToken();

        private readonly IHttpContextAccessor _httpContext;

        private readonly IEfUnitOfWork _efUnit;

        private readonly IDapperRepository<User> _UserDapperRepository;

        private Dictionary<string, string> Payload { get; set; }

        #endregion ApiAuth Variables

        #region Constructor

        public ApiAuth(IHttpContextAccessor httpContext, IEfUnitOfWork efUnit, IDapperRepository<User> userDapperRepository)
        {
            _httpContext               = httpContext;
            _efUnit                    = efUnit;
            _UserDapperRepository = userDapperRepository;
        }

        #endregion

        #region Üye Girişi Yapar (Login Actions)

        public async Task<DataResult<AuthLoginOutDto>> Login(AuthLoginInputDto authLoginInputDto)
        {
            var getUser = await GetUserDataAsync(authLoginInputDto);

            if ( getUser == null )
            {
                throw new ApiResponseException(ResultMessages.UserPassError);
            }

            var checkPass = Hash.CheckConstraint(authLoginInputDto.Password, getUser.Password);

            if ( !checkPass )
            {
                throw new ApiResponseException(ResultMessages.UserPassError);
            }

            var token = MakeToken(getUser);

            var resultData = new AuthLoginOutDto
            {
                    Token     = token,
                    TokenType = "Bearer"
            };

            return new DataResult<AuthLoginOutDto>().Success(resultData);
        }

        #endregion

        #region Header'da token var mı, süresi geçmiş mi ve geçerli token mı bakar

        public bool Check()
        {
            _jwtToken.Decode(GetToken());
            return true;
        }

        #endregion

        #region Yeni Token Oluşturur. Ek Claim olmadan

        public string CreteToken()
        {
            return _jwtToken.Create();
        }

        #endregion

        #region Token'ın Bütün Claimlarını Verir.

        public Dictionary<string, string> GetPayloads()
        {
            var token    = GetToken();
            var payloads = _jwtToken.DecodeToObject(token);
            return payloads;
        }
        
        #endregion

        #region Claim'dan UserId Verir

        public Guid GetId(string token = null)
        {
            return Guid.Parse(FindPayload("userId"));
        }

        #endregion

        #region Payload Arar

        public string FindPayload(string key, string token = null)
        {
            Dictionary<string, string> payloads;
            
            if ( token == null )
            {
                payloads = _jwtToken.DecodeToObject(token);
            }
            else
            {
                payloads = GetPayloads();
            }

            if ( !payloads.ContainsKey(key) )
            {
                throw new ApiResponseException("İstediğiniz Jwt Claim Bulunamadı");
            }

            return payloads[key];
        }

        #endregion

        #region Header'daki Token'ı Verir

        public string GetToken()
        {
            var tokenHeader = GetAuthHeader();
            tokenHeader = CleanTokenHeader(tokenHeader);
            return tokenHeader;
        }

        #endregion

        #region Login Durumda Olan Kullanıcının Verileri Getirir

        public async Task<User> User()
        {
            var userId = GetId();

            return await _efUnit.Users.GetAsync(u => u.Id == userId);
        }

        #endregion

        #region Şifre Doğru mu kontrol eder

        private async Task<User> GetUserDataAsync(AuthLoginInputDto authLoginInputDto)
        {
            var sqlParams = new
            {
                    username = authLoginInputDto.Username,
                    password = authLoginInputDto.Password
            };
            
            return await _UserDapperRepository.QueryFirstAsync(AutSql.getUserByUsernameOrEmailQuery, sqlParams);
        }

        #endregion

        #region Claimlar ile beraber Token oluşturur

        private string MakeToken(User user)
        {
            var payload = new Dictionary<string, string>
            {
                    {"userId", user.Id.ToString()},
                    {"userName", user.Username},
                    {"email", user.Email},
                    {"firstname", user.FirstName},
                    {"lastname", user.LastName},
            };
            var token = _jwtToken.Create(payload);
            Payload = _jwtToken.DecodeToObject(token);
            return token;
        }

        #endregion

        #region Request Header'da Authorization Objesindeki Bearer'ı Siler Sadece Token'ı Döndürür.

        private string CleanTokenHeader(string input)
        {
            if ( input == null )
            {
                throw new ApiAuthException();
            }

            input = Regex.Replace(input, "Bearer", "");
            input = Regex.Replace(input, "bearer", "");
            input = Regex.Replace(input, " ", "");
            return input;
        }

        #endregion

        #region Request Header'da Authorization Objesini Yakalar

        private string GetAuthHeader()
        {
            if ( _httpContext.HttpContext == null )
                throw new ApiAuthException("Lütfen Üye Girişi Yapınız");

            return _httpContext.HttpContext.Request.Headers["Authorization"];
        }

        #endregion
    }
}