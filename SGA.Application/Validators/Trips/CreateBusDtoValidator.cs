using FluentValidation;
using SGA.Application.DTOs.Bus;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Trips
{
    public  sealed class CreateBusDtoValidator : AbstractValidator<CreateBusDto>
    {

        public const int CapacidadMaximaPermitida = 45;

        public CreateBusDtoValidator()
        {
            RuleFor(x => x.ConductorId)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.MayorACero("El conductor asignado"));

            RuleFor(x => x.Marca)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("La marca"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                .WithMessage(ValidationMessages.LongitudMaxima("La marca", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.Modelo)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El modelo"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                .WithMessage(ValidationMessages.LongitudMaxima("El modelo", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.Placa)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("La placa"))
                .Matches(ValidationConstants.PatronPlaca)
                .WithMessage("La placa debe contener el formato institucional Dominicano 'A123456'.");

            RuleFor(x => x.Capacidad)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("La capacidad del autobús"))
                .LessThanOrEqualTo(CapacidadMaximaPermitida)
                    .WithMessage($"La capacidad del autobús no puede excer {CapacidadMaximaPermitida} pasajeros.");

        }
    }
}
