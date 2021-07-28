using System;
using Notepad.Domain.Base.Dto;

namespace Notepad.Service.Cities.Dtos.Outputs
{
    public class CityListOutputDto: DtoOutBase
    {
        public string CityName { get; set; }
    }
}