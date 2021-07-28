using AutoMapper;
using Notepad.Domain.Cities;
using Notepad.Service.Cities.Dtos.Outputs;

namespace Notepad.Service.Cities.Mapper
{
    public class CityListMapper: Profile
    {
        #region Profile Name

        public override string ProfileName
        {
            get { return "CityListMappings"; }
        }

        #endregion

        #region Consturct

        public CityListMapper()
        {
            ConfigureMapper();
        }

        #endregion

        #region Mapper

        private void ConfigureMapper()
        {
            CreateMap<CityListOutputDto, City>();
            CreateMap<City, CityListOutputDto>().ReverseMap();
        }

        #endregion
    }
}