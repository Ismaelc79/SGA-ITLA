using FluentValidation;
using SGA.Application.DTOs.Viaje;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Trips
{
    public sealed class ViajeStatusChangeDtoValidator : AbstractValidator<ViajeStatusChangeDto>
    {
        public ViajeStatusChangeDtoValidator()
        {
            RuleFor(x => x.EstadoViaje)
                .NotEqual(Domain.Enums.EstadoViaje.Ninguno)
                    .WithMessage(ValidationMessages.EnumRequerido("estado de viaje"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado de viaje"));

            RuleFor(x => x.Motivo)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El motivo del cambio de estado"))
                .MaximumLength(ValidationConstants.LongitudTextoLarga)
                    .WithMessage(ValidationMessages.LongitudMaxima("La descripción del motivo", ValidationConstants.LongitudTextoLarga));

                

        }
    }
}
