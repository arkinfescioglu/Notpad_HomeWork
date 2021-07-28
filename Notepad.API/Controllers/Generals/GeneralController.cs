using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notepad.Service.Cities;
using Notepad.Service.Cities.Dtos.Outputs;
using Notepad.Utilities.Result;
using Swashbuckle.AspNetCore.Annotations;

namespace Notepad.API.Controllers.Generals
{
    [ApiController]
    [Route("Api/[controller]")]
    public class GeneralController: ControllerBase
    {
        #region Variables

        private readonly ICityService _cityService;
        
        #endregion

        #region Construct

        public GeneralController(ICityService cityService)
        {
            _cityService = cityService;
        }

        #endregion

        #region List All Cities

        [HttpGet("GetAllCities")]
        [SwaggerOperation(Description = "Bütün Şehirleri Listeler (Gives All Cities).")]
        public async Task<DataResult<List<CityListOutputDto>>> GetAllCities()
        {
            return await _cityService.GetAllAsync();
        }

        #endregion
    }
}