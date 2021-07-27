using System.Threading.Tasks;
using Notepad.Repository.EntityFramework.Repositories.Cities;
using Notepad.Repository.EntityFramework.Repositories.NoteCategories;
using Notepad.Repository.EntityFramework.Repositories.Notes;
using Notepad.Repository.EntityFramework.Repositories.Users;

namespace Notepad.Repository.EntityFramework.UnitOfWork
{
    public interface IEfUnitOfWork
    {
        IUserRepository         Users          { get; }
        ICityRepository         Cities         { get; }
        INoteRepository         Notes          { get; }
        INoteCategoryRepository NoteCategories { get; }
        Task                    SaveAsync();
    }
}