using Microsoft.EntityFrameworkCore;
using Notepad.EntityFramework.Repository;

namespace Notepad.Repository.EntityFramework.Repositories.Users
{
    public class UserEfRepository: EfRepositoryBase<Domain.Users.User>, IUserRepository
    {
        public UserEfRepository(DbContext context) : base(context)
        {
        }
    }
}