﻿using System;

namespace Notepad.Service.Users.Dtos.Inputs
{
    public class UserCreateInputDto
    {
        public string FirstName { get; set; } 
        public string LastName  { get; set; } 
        public string Email     { get; set; } 
        public string Username  { get; set; } 
        public string Password  { get; set; } 
        public Guid   CityId    { get; set; }
    }
}