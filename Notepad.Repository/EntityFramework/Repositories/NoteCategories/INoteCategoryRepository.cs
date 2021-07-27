using Notepad.Domain.NoteCategories;
using Notepad.EntityFramework.Repository;

namespace Notepad.Repository.EntityFramework.Repositories.NoteCategories
{
    public interface INoteCategoryRepository: IEfRepository<NoteCategory>
    {
        
    }
}