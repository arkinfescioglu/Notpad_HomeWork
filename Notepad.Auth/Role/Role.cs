using System;
using System.Threading.Tasks;
using Notepad.Auth.Api;
using Notepad.Auth.Role.Dtos.Outputs;
using Notepad.Auth.Role.Sql;
using Notepad.Dapper.Repository;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Utilities.Exceptions.Api;

namespace Notepad.Auth.Role
{
    public class Role : IRole
    {
        #region Variables

        private readonly IEfUnitOfWork _efUnitOfWork;

        private readonly IDapperRepository<UserInfoOutDto> _dapperRepository;

        private readonly IApiAuth _apiAuth;

        #endregion

        #region Construct

        public Role(IEfUnitOfWork efUnitOfWork, IApiAuth apiAuth, IDapperRepository<UserInfoOutDto> dapperRepository)
        {
            _efUnitOfWork     = efUnitOfWork;
            _apiAuth          = apiAuth;
            _dapperRepository = dapperRepository;
        }

        #endregion

        #region Check Role

        public async Task<bool> Check(string needRole)
        {
            //Is User Login
            _apiAuth.Check();
            await GetUserInfo(needRole);
            return true;
        }

        #endregion

        #region Get User Title

        public async Task<UserInfoOutDto> GetUserTitle(string needRole)
        {
            return await GetUserInfo(needRole);
        }

        #endregion

        #region Get User Id From _apiAuth

        private Guid GetUserId()
        {
            return _apiAuth.GetId();
        }

        #endregion

        #region Get UserInfo

        private async Task<UserInfoOutDto> GetUserInfo(string needRole)
        {
            var userId = GetUserId();

            var getUserInfo = await _dapperRepository
                                      .QuerySingleAsync(RoleSql.getUserInfoSql, new
                                      {
                                              Id = userId
                                      });

            if ( getUserInfo.ShortTitle != needRole )
            {
                throw new ApiRoleException();
            }

            return getUserInfo;
        }

        #endregion
    }
}