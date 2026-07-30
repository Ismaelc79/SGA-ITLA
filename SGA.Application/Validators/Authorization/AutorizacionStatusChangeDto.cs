using FluentValidation;
using SGA.Application.DTOs.Authorization;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Authorization
{
    public sealed class AutorizacionStatusChangeDtoValidator : AbstractValidator<AutorizacionStatusChangeDto>
    {
        public AutorizacionStatusChangeDtoValidator()
        {
            RuleFor(x => x.Estado)
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El nuevo estado de la autorización"));

            RuleFor(x => x.Motivo)
                .MaximumLength(ValidationConstants.LongitudTextoLarga)
                    .WithMessage(ValidationMessages.LongitudMaxima("El motivo", ValidationConstants.LongitudTextoLarga));
        }
    }
}