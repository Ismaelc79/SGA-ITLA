using FluentValidation;
using SGA.Application.DTOs.User;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.User
{
    public sealed class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        private const int LongitudMinimaUserName = 3;
        private const int LongitudMaximaUserName = 100;
        private const int LongitudMinimaPassword = 6;

        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre de usuario"))
                .MinimumLength(LongitudMinimaUserName)
                    .WithMessage(ValidationMessages.LongitudMinima("El nombre de usuario", LongitudMinimaUserName))
                .MaximumLength(LongitudMaximaUserName)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de usuario", LongitudMaximaUserName));

            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El correo"))
                .EmailAddress()
                    .WithMessage("El correo no tiene un formato válido.");

            RuleFor(x => x.Password)
                .MinimumLength(LongitudMinimaPassword)
                    .WithMessage(ValidationMessages.LongitudMinima("La contraseña", LongitudMinimaPassword))
                .When(x => !string.IsNullOrWhiteSpace(x.Password));
        }
    }
}