using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Service.NoteCategories.Dtos.Outputs;
using Notepad.Utilities.Messages;
using Notepad.Utilities.Result;

namespace Notepad.Service.NoteCategories
{
    public class NoteCategoryManager: INoteCategoryService
    {
        #region Variables

        private readonly IEfUnitOfWork _efUnitOfWork;
        private readonly IMapper       _mapper;
        
        #endregion

        #region Construct

        public NoteCategoryManager(IEfUnitOfWork efUnitOfWork, IMapper mapper)
        {
            _efUnitOfWork = efUnitOfWork;
            _mapper  = mapper;
        }

        #endregion

        #region Get All Note Categories

        public async Task<DataResult<List<NoteCategoryListOutDto>>> GetAllAsync()
        {
            var categories         = await _efUnitOfWork.NoteCategories.GetAllAsync();

            if ( categories == null )
            {
                return new DataResult<List<NoteCategoryListOutDto>>().DataError(ResultMessages.Empty);
            }
            
            var noteCategoryMapper = _mapper.Map<List<NoteCategoryListOutDto>>(categories);

            return new DataResult<List<NoteCategoryListOutDto>>().Success(noteCategoryMapper);
        }

        #endregion
    }
}