using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notepad.Auth.Api;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Service.Notes;
using Notepad.Service.Notes.Dtos.Inputs;
using Notepad.Service.Notes.Dtos.Outputs;
using Notepad.Service.Notes.Validations;
using Notepad.Utilities.Result;
using Swashbuckle.AspNetCore.Annotations;

namespace Notepad.API.Controllers.Notes
{
    [ApiController]
    [Route("Api/[controller]")]
    public class NoteController: ApiBaseController
    {
        #region Variables

        private readonly INoteService  _noteService;
        private readonly IApiAuth      _apiAuth;
        private readonly IEfUnitOfWork _efUnitOfWork;
        
        #endregion

        #region Construct

        public NoteController(INoteService noteService, IApiAuth apiAuth, IEfUnitOfWork efUnitOfWork)
        {
            _noteService       = noteService;
            _apiAuth           = apiAuth;
            _efUnitOfWork = efUnitOfWork;
        }

        #endregion

        #region Create New Note

        [HttpPost("CreateNewNote")]
        [SwaggerOperation(Description = "Yeni Not Ekleme İşlemi (Creates New Note).")]
        public async Task<Result> CreateNewNote(NoteCreateInputDto noteCreateInputDto)
        {
            //Auth Olmuş mu kontrol ediyorum.
            //Condition'a gerek yok auth olmamışsa içeride exception döndürüyorum
            _apiAuth.Check();

            await (new NoteCreateValidation(noteCreateInputDto, _efUnitOfWork)).Validate();
            
            //Auth olmuş kullnıcının Id'sini alıyorum
            var authUserId = _apiAuth.GetId();

            noteCreateInputDto.UserId = authUserId;
            
            await _noteService.CreateAsync(noteCreateInputDto, authUserId);

            return new Result().Success();
        }

        #endregion

        #region Update Note By Id

        [HttpPut("UpdateNoteById")]
        [SwaggerOperation(Description = "Varilen Not Id'ye Göre Notu Günceller.")]
        public async Task<Result> UpdateNoteById(Guid id, NoteUpdateInputDto noteUpdateInputDto)
        {
            _apiAuth.Check();
            
            await (new NoteUpdateValidation(noteUpdateInputDto, _efUnitOfWork)).Validate();

            var getAuthorId = _apiAuth.GetId();

            await _noteService
                    .UpdateByIdAsync(id, noteUpdateInputDto, getAuthorId);

            return new Result().Success();
        }

        #endregion

        #region Get Note By Id

        [HttpGet("GetNoteById")]
        [SwaggerOperation(Description = "Note Id'ye göre notun detayını verir. (Gives Note Info by Given NoteId)")]
        public async Task<DataResult<NoteInfoOutDto>> GetNoteById(Guid id)
        {
            _apiAuth.Check();
            
            var authorId = _apiAuth.GetId();

            return await _noteService.GetByIdAsync(id, authorId);
        }

        #endregion

        #region List Author All Notes

        [HttpGet("GetAllAuthorNotes")]
        [SwaggerOperation(Description = "Kullanıcı Girişi Yapmış Üyenin Bütün Notlarını Verir.")]
        public async Task<DataResult<List<NoteInfoOutDto>>> GetAllAuthorNotes()
        {
            _apiAuth.Check();

            var authorId = _apiAuth.GetId();
            
            return await _noteService.GetAllAuthorNotesAsync(authorId);
        }

        #endregion
    }
}