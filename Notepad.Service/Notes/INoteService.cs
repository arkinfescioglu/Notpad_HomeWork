using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notepad.Domain.Notes;
using Notepad.Service.Notes.Dtos.Inputs;
using Notepad.Service.Notes.Dtos.Outputs;
using Notepad.Utilities.Result;

namespace Notepad.Service.Notes
{
    public interface INoteService
    {
        Task<bool> CreateAsync(NoteCreateInputDto noteCreateInputDto, Guid authUserId);

        Task<bool> UpdateByIdAsync(Guid id, NoteUpdateInputDto noteUpdateInputDto, Guid authorId);

        Task<DataResult<NoteInfoOutDto>> GetByIdAsync(Guid id, Guid authorId);

        Task<Note> GetNoteAuthorAsync(Guid noteId, Guid authorId);

        Task<DataResult<List<NoteInfoOutDto>>> GetAllAuthorNotesAsync(Guid authorId);
        
        Task                                   IsNoteIdExist(Guid          id);
    }
}