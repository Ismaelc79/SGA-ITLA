
using FluentValidation;
using SGA.Application.DTOs.Viaje;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Trips
{
    public sealed class CreateViajeDtoValidator : AbstractValidator<CreateViajeDto>
    {
        public CreateViajeDtoValidator()
        {
            RuleFor(x => x.RutaId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("La ruta asignada"));

            RuleFor(x => x.AutobusId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El autobús asignado"));

            RuleFor(x => x.ConductorId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El conductor asignado"));

            RuleFor(x => x.HorarioId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El horario asignado"));

            RuleFor(x => x.EstadoViaje)
                .NotEqual(Domain.Enums.EstadoViaje.Ninguno)
                    .WithMessage(ValidationMessages.EnumRequerido("estado de viaje"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado de viaje"));

            RuleFor(x => x.HoraSalidaEstimada)
                    .NotEmpty()
                        .WithMessage(ValidationMessages.Requerido("Estimar la hora de salida"))
                .NotEqual(default(DateTime))
                    .WithMessage("Debe especificar una hora de salida estimada");

            RuleFor(x => x.HoraLlegadaEstimada)
                    .NotEmpty()
                        .WithMessage(ValidationMessages.Requerido("Estimar la hora de llegada"))
                .NotEqual(default(DateTime))
                    .WithMessage("Debe especificar una hora de llegada estimada");

            RuleFor(x => x.HoraLlegadaEstimada)
                .GreaterThan(x => x.HoraSalidaEstimada)
                    .WithMessage("La hora de llegada debe ser posterior a la hora de salida");


        }
    }
}
