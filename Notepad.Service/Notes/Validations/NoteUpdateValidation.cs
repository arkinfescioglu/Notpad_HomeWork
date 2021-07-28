using System;
using System.Threading.Tasks;
using FluentValidation;
using Notepad.Domain.Notes.Consts;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Service.Notes.Dtos.Inputs;
using Notepad.Utilities.Messages;
using Notepad.Utilities.Validator.FluentValidation.Api;

namespace Notepad.Service.Notes.Validations
{
    public class NoteUpdateValidation: FluentValidationBase<NoteUpdateInputDto>
    {
        #region Variables

        private readonly IEfUnitOfWork _efUnitOfWork;
        
        #endregion
        
        public NoteUpdateValidation(NoteUpdateInputDto dto, IEfUnitOfWork efUnitOfWork) : base(dto)
        {
            _efUnitOfWork = efUnitOfWork;
            
            #region Validation Rules
            
            #region NoteTitle Rules

            var noteTitleRequiredMessage = ValidationMessages.ParamRequired("Not Başlığı");
            int noteTitleMaxLength       = NoteLength.MaxTitle;

            RuleFor(n => n.NoteTitle)
                    .NotEmpty()
                    .WithMessage(noteTitleRequiredMessage)
                    .NotNull()
                    .WithMessage(noteTitleRequiredMessage)
                    .MaximumLength(noteTitleMaxLength)
                    .WithMessage(ValidationMessages.MaxCanBe("Not Başlığı", noteTitleMaxLength));

            #endregion

            #region Note Content Rules

            var noteContentRequiredMessage = ValidationMessages.ParamRequired("Not İçeriği");

            RuleFor(n => n.NoteContent)
                    .NotEmpty()
                    .WithMessage(noteContentRequiredMessage)
                    .NotNull()
                    .WithMessage(noteContentRequiredMessage);

            #endregion

            #region CategoryId Rules

            var categoryIdRequiredMessage = ValidationMessages.ParamRequired("Not İçeriği");

            RuleFor(n => n.CategoryId)
                    .NotEmpty()
                    .WithMessage(categoryIdRequiredMessage)
                    .NotNull()
                    .WithMessage(categoryIdRequiredMessage)
                    .MustAsync(
                            async (categoryId, cancelation) =>
                                    await CategoryExist(categoryId)
                    ).WithMessage(ValidationMessages.ParamFormat("Note Kategorisi"));

            #endregion
            
            #endregion
        }
        
        #region Validation Rules Methods

        async Task<bool> CategoryExist(Guid categoryId)
        {
            return await _efUnitOfWork.NoteCategories.AnyAsync(c => c.Id.Equals(categoryId));
        }

        #endregion
    }
}