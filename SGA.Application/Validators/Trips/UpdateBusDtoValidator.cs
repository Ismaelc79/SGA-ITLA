using FluentValidation;
using SGA.Application.DTOs.Bus;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Trips
{
    public sealed class UpdateBusDtoValidator : AbstractValidator<UpdateBusDto>
    {
        private const int CapacidadMaximaPermitida = 45;

        public UpdateBusDtoValidator()
        {
            RuleFor(x => x.ConductorId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.Requerido("El conductor asignado"));

            RuleFor(x => x.Placa)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("La placa"))
                .Matches(ValidationConstants.PatronPlaca)
                    .WithMessage($"La placa debe contener el formato institucional Dominicano 'A123456'.");

            RuleFor(x => x.Capacidad)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("La capacidad del autobús"))
                .LessThanOrEqualTo(CapacidadMaximaPermitida)
                    .WithMessage($"La capacidad del autobús no puede exceder {CapacidadMaximaPermitida} pasajeros.");

            RuleFor(x => x.EstadoBus)
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado del autobús"));
        }

    }
}
