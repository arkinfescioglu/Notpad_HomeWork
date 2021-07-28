using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Service.Cities.Dtos.Outputs;
using Notepad.Utilities.Exceptions.Api;
using Notepad.Utilities.Messages;
using Notepad.Utilities.Result;

namespace Notepad.Service.Cities
{
    public class CityManager: ICityService
    {
        #region Variables

        private readonly IMapper _mapper;

        private readonly IEfUnitOfWork _efUnitOfWork;
        
        #endregion

        #region Construct

        public CityManager(IMapper mapper, IEfUnitOfWork efUnitOfWork)
        {
            _mapper            = mapper;
            _efUnitOfWork = efUnitOfWork;
        }

        #endregion

        #region GetAll Cities

        public async Task<DataResult<List<CityListOutputDto>>> GetAllAsync()
        {
            try
            {
                var cities = await _efUnitOfWork.Cities.GetAllAsync();

                if ( cities == null )
                {
                    return new DataResult<List<CityListOutputDto>>().DataError(ResultMessages.Empty);
                }

                var citiesMapper = _mapper.Map<List<CityListOutputDto>>(cities);

                return new DataResult<List<CityListOutputDto>>().Success(citiesMapper);
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                throw new ApiSystemErrorException();
            }
        }

        #endregion
    }
}