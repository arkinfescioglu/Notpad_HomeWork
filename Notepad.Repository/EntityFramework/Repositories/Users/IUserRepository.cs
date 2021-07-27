using Notepad.EntityFramework.Repository;

namespace Notepad.Repository.EntityFramework.Repositories.Users
{
    public interface IUserRepository: IEfRepository<Domain.Users.User>
    {
        
    }
}