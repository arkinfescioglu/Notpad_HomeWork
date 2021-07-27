using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Notepad.Utilities.Exceptions.Api;

namespace Notepad.Utilities.Validator.FluentValidation.Api
{
    public class FluentValidationBase<T>: AbstractValidator<T>
    {
        #region Variables

        protected T _dto;

        #endregion

        #region Construct

        public FluentValidationBase(T dto)
        {
            _dto = dto;
        }

        #endregion
        
        #region Is Guid Validation

        public bool IsGuid(string guid)
        {
            return Guid.TryParse(guid, out var result);
        }
        

        #endregion

        #region Validate Action

        public async Task Validate()
        {
            var validationResult = await ValidateAsync(_dto);
            if ( !validationResult.IsValid )
            {
                throw new ApiValidationException(
                        FluentValidationFailure.ValidationFailures(
                                validationResult.Errors.ToList()
                        )
                );
            }
        }

        #endregion
    }
}