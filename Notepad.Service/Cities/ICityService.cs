using System.Collections.Generic;
using System.Threading.Tasks;
using Notepad.Service.Cities.Dtos.Outputs;
using Notepad.Utilities.Result;

namespace Notepad.Service.Cities
{
    public interface ICityService
    {
        Task<DataResult<List<CityListOutputDto>>> GetAllAsync();
    }
}