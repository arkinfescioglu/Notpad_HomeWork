using Microsoft.EntityFrameworkCore;
using Notepad.Domain.Notes;
using Notepad.EntityFramework.Repository;

namespace Notepad.Repository.EntityFramework.Repositories.Notes
{
    public class NoteEfRepository: EfRepositoryBase<Note>, INoteRepository
    {
        public NoteEfRepository(DbContext context) : base(context)
        {
        }
    }
}