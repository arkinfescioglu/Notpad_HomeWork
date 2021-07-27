using System;

namespace Notepad.Auth.Api.Dtos.Outputs
{
    public class AuthPayloadOutDto
    {
        public Guid   UserId    { get; set; }
        public string UserName  { get; set; }
        public string Email     { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Exp       { get; set; }
        public string Iss       { get; set; }
        public string Aud       { get; set; }
        public string Sub       { get; set; }
    }
}