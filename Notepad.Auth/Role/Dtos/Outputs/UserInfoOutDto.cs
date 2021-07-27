using System;

namespace Notepad.Auth.Role.Dtos.Outputs
{
    public class UserInfoOutDto
    {
        public Guid   Id          { get; set; }
        public Guid   UserTitleId { get; set; }
        public string ShortTitle  { get; set; }
    }
}