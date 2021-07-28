using System;
using System.Threading.Tasks;
using FluentValidation;
using Notepad.Domain.Users.Consts;
using Notepad.Repository.EntityFramework.UnitOfWork;
using Notepad.Service.Users.Dtos.Inputs;
using Notepad.Utilities.Messages;
using Notepad.Utilities.Validator.FluentValidation.Api;

namespace Notepad.Service.Users.Validations
{
    public class UserCreateValidation: FluentValidationBase<UserCreateInputDto>
    {
        private readonly IEfUnitOfWork _efUnitOfWork;
        
        public UserCreateValidation(UserCreateInputDto dto, IEfUnitOfWork efUnitOfWork) : base(dto)
        {
            _efUnitOfWork = efUnitOfWork;

            #region Validation Rules

            #region Email Address Validation

            int maxEmail             = UserLength.MaxEmail;
            var emailRequiredMessage = ValidationMessages.ParamRequired("Eposta");
            
            RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage(emailRequiredMessage)
                    .NotNull()
                    .WithMessage(emailRequiredMessage)
                    .EmailAddress()
                    .WithMessage(ValidationMessages.ParamFormat("Eposta"))
                    .MaximumLength(maxEmail)
                    .WithMessage(ValidationMessages.MaxCanBe("Eposta", maxEmail))
                    .MustAsync(
                            async (email, cancellation) => await IsEmailExist(email)
                    )
                    .WithMessage("Girdiğiniz Eposta Adresi Daha Önce Kayıt Edilmiş.");

            #endregion
            
            #region Username Validation

            int maxUsername             = UserLength.MaxUsername;
            var usernameRequiredMessage = ValidationMessages.ParamRequired("Kullanıcı Adı");
            
            RuleFor(x => x.Username)
                    .NotEmpty()
                    .WithMessage(usernameRequiredMessage)
                    .NotNull()
                    .WithMessage(usernameRequiredMessage)
                    .MaximumLength(maxUsername)
                    .WithMessage(ValidationMessages.MaxCanBe("Kullanıcı Adı", maxUsername))
                    .MustAsync(
                            async (userName, cancellation) => await IsUsernameExist(userName)
                    )
                    .WithMessage("Girdiğiniz Kullanıcı Adı Daha Önce Kayıt Edilmiş.");

            #endregion
            
            #region Password Validation

            int minPassword             = UserLength.MinPassword;
            var passwordRequiredMessage = ValidationMessages.ParamRequired("Şifre");
            
            RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage(passwordRequiredMessage)
                    .NotNull()
                    .WithMessage(passwordRequiredMessage)
                    .MinimumLength(minPassword)
                    .WithMessage(ValidationMessages.MinCanBe("Şifre", minPassword));

            #endregion

            #region Firstname Validation

            int maxFirstname             = UserLength.MaxFirstName;
            var firstNameRequiredMessage = ValidationMessages.ParamRequired("Ad");
            
            RuleFor(x => x.FirstName)
                    .NotEmpty()
                    .WithMessage(firstNameRequiredMessage)
                    .NotNull()
                    .WithMessage(firstNameRequiredMessage)
                    .MaximumLength(maxFirstname)
                    .WithMessage(ValidationMessages.MaxCanBe("Ad", maxFirstname));

            #endregion
            
            #region Lastname Validation

            int maxLastname             = UserLength.MaxLastName;
            var lastNameRequiredMessage = ValidationMessages.ParamRequired("Soyadı");
            
            RuleFor(x => x.LastName)
                    .NotEmpty()
                    .WithMessage(lastNameRequiredMessage)
                    .NotNull()
                    .WithMessage(lastNameRequiredMessage)
                    .MaximumLength(maxLastname)
                    .WithMessage(ValidationMessages.MaxCanBe("Soyadı", maxLastname));

            #endregion
            
            #region City Id Validation

            var cityIdRequiredMessage = ValidationMessages.ParamRequired("Şehir");
            
            RuleFor(x => x.CityId)
                    .NotEmpty()
                    .WithMessage(cityIdRequiredMessage)
                    .NotNull()
                    .WithMessage(cityIdRequiredMessage)
                    .MustAsync(async (cityId, cancellation) => await CityExist(cityId))
                    .WithMessage(ValidationMessages.ParamFormat("Şehir"));

            #endregion
            
            #endregion
        }
        
        #region Validation Rules Methods
        
        async Task<bool> IsEmailExist(string email)
        {
            return !await _efUnitOfWork.Users.AnyAsync(u => u.Email == email);
        }

        async Task<bool> IsUsernameExist(string userName)
        {
            return !await _efUnitOfWork.Users.AnyAsync(u => u.Username == userName);
        }

        async Task<bool> CityExist(Guid cityId)
        {
            return await _efUnitOfWork.Cities.AnyAsync(c => c.Id.Equals(cityId));
        }

        #endregion
    }
}