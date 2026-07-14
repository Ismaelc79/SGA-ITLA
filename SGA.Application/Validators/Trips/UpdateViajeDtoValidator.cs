using FluentValidation;
using SGA.Application.DTOs.Viaje;
using SGA.Application.Validators.Common;
namespace SGA.Application.Validators.Trips
{
    public sealed class UpdateViajeDtoValidator : AbstractValidator<UpdateViajeDto>
    {
        public UpdateViajeDtoValidator()
        {
            RuleFor(x => x.IncidenciaId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id de la incidencia"));

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
                    .WithMessage("Debe especificar la hora de llegada estimada");

            RuleFor(x => x.HoraLlegadaEstimada)
                .GreaterThan(x => x.HoraSalidaEstimada)
                    .WithMessage("La hora de llegada debe ser posterior a la hora de salida");
        }
    }
}
