
using FluentValidation;
using SGA.Application.DTOs.Bus;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Trips
{
    public sealed class BusStatusChangeDtoValidator : AbstractValidator<BusStatusChangeDto>
    {
        public BusStatusChangeDtoValidator()
        {
            RuleFor(x => x.EstadoBus)
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El nuevo estado del autobús"));

            RuleFor(x => x.Motivo)
                .MaximumLength(ValidationConstants.LongitudTextoLarga)
                    .WithMessage(ValidationMessages.LongitudMaxima("El motivo", ValidationConstants.LongitudTextoLarga));
        }
    }
}
