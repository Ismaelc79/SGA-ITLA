using FluentValidation;
using SGA.Application.DTOs.Auth;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Auth
{
    public sealed class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Correo)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El correo"))
                .EmailAddress()
                    .WithMessage("El correo no tiene un formato válido.")
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El correo", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("La contraseña"));
        }
    }
}
