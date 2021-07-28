using System.Collections.Generic;
using System.Threading.Tasks;
using Notepad.Service.NoteCategories.Dtos.Outputs;
using Notepad.Utilities.Result;

namespace Notepad.Service.NoteCategories
{
    public interface INoteCategoryService
    {
        Task<DataResult<List<NoteCategoryListOutDto>>> GetAllAsync();
    }
}