using System;
using Notepad.Domain.Base.Dto;

namespace Notepad.Service.Users.Dtos.Outputs
{
    public class UserInfoOutDto: DtoOutBase
    {
        public string Slug      { get; set; }
        public string Username  { get; set; }
        public string Email     { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public Guid   CityId    { get; set; }
        public string CityName  { get; set; }
    }
}