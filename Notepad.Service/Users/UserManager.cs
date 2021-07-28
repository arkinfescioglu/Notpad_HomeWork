using System;
using System.Threading.Tasks;
using AutoMapper;
using Notepad.Dapper.Repository;
using Notepad.Domain.Users;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Service.Users.Dtos.Inputs;
using Notepad.Service.Users.Dtos.Outputs;
using Notepad.Service.Users.Sql;
using Notepad.Utilities.Exceptions.Api;
using Notepad.Utilities.Result;

namespace Notepad.Service.Users
{
    public class UserManager : IUserService
    {
        #region Variables

        private readonly IEfUnitOfWork _efUnitOfWork;

        private readonly IMapper _mapper;

        private readonly IDapperRepository<UserInfoOutDto> _dapperRepository;

        #endregion

        #region Construct

        public UserManager(IEfUnitOfWork          efUnitOfWork, IMapper mapper,
                IDapperRepository<UserInfoOutDto> dapperRepository)
        {
            _efUnitOfWork     = efUnitOfWork;
            _mapper           = mapper;
            _dapperRepository = dapperRepository;
        }

        #endregion

        #region Create New User

        public async Task<Result> CreateAsync(UserCreateInputDto userCreateInputDto)
        {
            try
            {
                //Helpers.CleanHtml ile mapper'da bütün inputları süzüyorum
                //ki xss açığı meydana gelmesin.
                var userCreateMap = _mapper.Map<User>(userCreateInputDto);

                await _efUnitOfWork.Users
                                   .AddAsync(userCreateMap)
                                   .ContinueWith(t => _efUnitOfWork.SaveAsync());

                return new Result().Success();
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                throw new ApiSystemErrorException();
            }
        }

        #endregion

        #region GetUserById

        public async Task<DataResult<UserInfoOutDto>> GetByIdAsync(Guid id)
        {
            //Metodun içerisinde exception olduğu için burada condition'a sokma gereği duymadım.
            //Zaten userId yoksa exception patlatacak.
            await IsUserIdExist(id);
            
            try
            {
                var getUserInfo = await _dapperRepository.QuerySingleAsync(UserSql.GetById, new
                {
                        Id = id
                });

                return new DataResult<UserInfoOutDto>().Success(getUserInfo);
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                throw new ApiSystemErrorException();
            }
        }

        #endregion

        #region GetUsersNote

        public async Task GetUserNotesAsync(Guid id)
        {
            await IsUserIdExist(id);
            
            try
            {
                
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region IsUserId Exist

        public async Task IsUserIdExist(Guid userId)
        {
            var isExist = await _efUnitOfWork.Users.AnyAsync(u => u.Id.Equals(userId));

            if ( !isExist )
            {
                throw new ApiNotFoundException();
            }
        }

        #endregion
    }
}