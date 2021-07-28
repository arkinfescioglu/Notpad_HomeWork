﻿using System;

namespace Notepad.Service.Notes.Dtos.Inputs
{
    public class NoteUpdateInputDto
    {
        public string NoteTitle { get; set; }
        
        public string NoteContent { get; set; }
        
        public Guid CategoryId { get; set; }
    }
}