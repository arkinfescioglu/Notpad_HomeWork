using Microsoft.EntityFrameworkCore;
using Notepad.Domain.NoteCategories;
using Notepad.EntityFramework.Repository;

namespace Notepad.Repository.EntityFramework.Repositories.NoteCategories
{
    public class NoteCategoryEfRepository: EfRepositoryBase<NoteCategory>, INoteCategoryRepository
    {
        public NoteCategoryEfRepository(DbContext context) : base(context)
        {
        }
    }
}