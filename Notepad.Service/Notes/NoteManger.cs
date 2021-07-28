using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Notepad.Dapper.Repository;
using Notepad.Domain.Notes;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Service.Notes.Dtos.Inputs;
using Notepad.Service.Notes.Dtos.Outputs;
using Notepad.Service.Notes.Sql;
using Notepad.Service.Users;
using Notepad.Service.Users.Sql;
using Notepad.Utilities.Exceptions.Api;
using Notepad.Utilities.Helpers;
using Notepad.Utilities.Messages;
using Notepad.Utilities.Result;

namespace Notepad.Service.Notes
{
    public class NoteManger : INoteService
    {
        #region variables

        private readonly IEfUnitOfWork                     _efUnitOfWork;
        private readonly IDapperRepository<NoteInfoOutDto> _noteDapperRepository;
        private readonly IMapper                           _mapper;
        private readonly IUserService                      _userService;

        #endregion

        #region Construct

        public NoteManger(IEfUnitOfWork efUnitOfWork, IDapperRepository<NoteInfoOutDto> dapperRepository,
                IMapper                 mapper,       IUserService                      userService)
        {
            _efUnitOfWork         = efUnitOfWork;
            _noteDapperRepository = dapperRepository;
            _mapper               = mapper;
            _userService          = userService;
        }

        #endregion

        #region Create New Note

        public async Task<bool> CreateAsync(NoteCreateInputDto noteCreateInputDto, Guid authUserId)
        {
            //TODO: Burası çok önemli bu kontrolü yapmazsam çok büyük güvenlik açığı oluşabilir.
            if ( !authUserId.Equals(noteCreateInputDto.UserId) )
            {
                throw new ApiRoleException();
            }

            //User Servisten User Id Var mı check ediyorum.
            //Condition'a sokmadım çünkü yoksa içeride ApiNotFoundException() döndürüyorum.
            await _userService.IsUserIdExist(authUserId);

            try
            {
                var notCreateMapper = _mapper.Map<Note>(noteCreateInputDto);

                await _efUnitOfWork.Notes.AddAsync(notCreateMapper)
                                   .ContinueWith(t => _efUnitOfWork.SaveAsync());
                return true;
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                throw new ApiSystemErrorException();
            }
        }

        #endregion

        #region Update Note By Id

        public async Task<bool> UpdateByIdAsync(Guid id, NoteUpdateInputDto noteUpdateInputDto, Guid authorId)
        {
            //Condition'a sokmaya gerek yok zaten ıd yoksa exception döndürüyorum.
            await IsNoteIdExist(id);

            //Notu yazan üye auth üye mi kontrol ediyorum ki güvenlik açığı olmasın
            var noteAuthor = await GetNoteAuthorAsync(id, authorId);

            if ( noteAuthor == null )
            {
                throw new ApiRoleException();
            }

            try
            {
                await _noteDapperRepository.ExecuteAsync(NotesSql.updateById, new
                {
                        Id           = id,
                        CategoryId   = noteUpdateInputDto.CategoryId,
                        NoteTitle    = Helpers.CleanHtml(noteUpdateInputDto.NoteTitle),
                        NoteContent  = noteUpdateInputDto.NoteContent,
                        ModifiedDate = DateTime.Now,
                        UserId       = authorId
                });
                return true;
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                throw new ApiSystemErrorException();
            }
        }

        #endregion

        #region Get Note By Id

        public async Task<DataResult<NoteInfoOutDto>> GetByIdAsync(Guid id, Guid authorId)
        {
            //id ve author id değerleri kontrol ediliyor.
            if ( id == null || authorId == null )
            {
                throw new ApiResponseException(ResultMessages.MissingParameter);
            }
            
            await IsNoteIdExist(id);
            
            var noteAuthor = await GetNoteAuthorAsync(id, authorId);

            if ( noteAuthor == null )
            {
                throw new ApiRoleException();
            }
            
            var get = await _noteDapperRepository.QuerySingleAsync(NotesSql.getByIdSql, new
            {
                    Id=id
            });

            // var res = get;
            return new DataResult<NoteInfoOutDto>().Success(get);
        }
        
        #endregion

        #region Get All Author Notes

        public async Task<DataResult<List<NoteInfoOutDto>>> GetAllAuthorNotesAsync(Guid authorId)
        {
            var getAll = await _noteDapperRepository
                                 .QueryAsync(UserSql.GetAllAuthorNotesSql, new
                                 {
                                         UserId=authorId
                                 });

            var map = _mapper.Map<List<NoteInfoOutDto>>(getAll);
            
            return new DataResult<List<NoteInfoOutDto>>().Success(map);
        }

        #endregion

        #region Is Note Id Exist

        public async Task IsNoteIdExist(Guid id)
        {
            var isExist = await _efUnitOfWork.Notes
                                             .AnyAsync(n => n.Id.Equals(id));

            if ( !isExist )
            {
                throw new ApiNotFoundException();
            }
        }

        #endregion

        #region Get Note Author

        public async Task<Note> GetNoteAuthorAsync(Guid noteId, Guid authorId)
        {
            //Notu yazan üye auth üye mi kontrol ediyorum ki güvenlik açığı olmasın
            return await _efUnitOfWork.Notes
                                                .GetAsync(
                                                        n =>
                                                                n.UserId.Equals(authorId) && n.Id.Equals(noteId)
                                                );
        }

        #endregion
    }
}