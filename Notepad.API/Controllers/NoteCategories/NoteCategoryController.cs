using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notepad.Service.NoteCategories;
using Notepad.Service.NoteCategories.Dtos.Outputs;
using Notepad.Utilities.Result;
using Swashbuckle.AspNetCore.Annotations;

namespace Notepad.API.Controllers.NoteCategories
{
    [ApiController]
    [Route("Api/[controller]")]
    public class NoteCategoryController: ApiBaseController
    {
        #region Variables

        private readonly INoteCategoryService _noteCategoryService;
        
        #endregion

        #region Construct

        public NoteCategoryController(INoteCategoryService noteCategoryService)
        {
            _noteCategoryService = noteCategoryService;
        }

        #endregion

        #region Get All Note Category

        [HttpGet("GetAllCategories")]
        [SwaggerOperation(Description = "Bütün not kategorilerini listeler (Gives All Note Categories).")]
        public async Task<DataResult<List<NoteCategoryListOutDto>>> GetAllCategory()
        {
            return await _noteCategoryService.GetAllAsync();
        }

        #endregion
    }
}