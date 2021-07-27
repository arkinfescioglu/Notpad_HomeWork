using Notepad.Domain.Notes;
using Notepad.EntityFramework.Repository;

namespace Notepad.Repository.EntityFramework.Repositories.Notes
{
    public interface INoteRepository: IEfRepository<Note>
    {
        
    }
}