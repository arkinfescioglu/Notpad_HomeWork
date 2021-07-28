using System;
using Notepad.Domain.Base.Dto;

namespace Notepad.Service.Notes.Dtos.Outputs
{
    public class UserCreateOutDto: DtoOutBase
    {
        public string NoteTitle   { get; set; }
        public string NoteContent { get; set; }
        
    }
}