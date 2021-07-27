using System.Threading.Tasks;
using Notepad.EntityFramework.EntityFrameworkCore.Contexts;
using Notepad.Repository.EntityFramework.Repositories.Cities;
using Notepad.Repository.EntityFramework.Repositories.NoteCategories;
using Notepad.Repository.EntityFramework.Repositories.Notes;
using Notepad.Repository.EntityFramework.Repositories.Users;

namespace Notepad.Repository.EntityFramework.UnitOfWork
{
    public class EfUnitOfWork: IEfUnitOfWork
    {
        #region Variables

        private readonly EfContext       _context;
        
        private          IUserRepository _userRepository;

        private ICityRepository _cityRepository;

        private INoteRepository _noteRepository;

        private INoteCategoryRepository _noteCategoryRepository;
        
        #endregion

        #region Repositories

        public IUserRepository Users => _userRepository ??= new UserEfRepository(_context);

        public ICityRepository Cities => _cityRepository ??= new CityEfRepository(_context);

        public INoteRepository Notes => _noteRepository ??= new NoteEfRepository(_context);

        public INoteCategoryRepository NoteCategories =>
                _noteCategoryRepository ??= new NoteCategoryEfRepository(_context);
        
        #endregion

        #region Construct

        public EfUnitOfWork(EfContext context)
        {
            _context = context;
        }

        #endregion
        
        #region Methods

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}