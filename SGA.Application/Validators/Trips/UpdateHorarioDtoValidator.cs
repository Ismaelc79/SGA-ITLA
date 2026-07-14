using FluentValidation;
using SGA.Application.DTOs.Horario;
using SGA.Application.Validators.Common;
using SGA.Domain.Enums;

namespace SGA.Application.Validators.Trips
{
    public sealed class UpdateHorarioDtoValidator : AbstractValidator<UpdateHorarioDto>
    {
        public UpdateHorarioDtoValidator()
        {
            RuleFor(x => x.RutaId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("La ruta asignada"));

            RuleFor(x => x.DiasOperacion)
                .Must(dias => dias != DiasOperacion.Ninguno)
                    .WithMessage("Debe seleccionar al menos un día de operación")
                .Must(dias =>
                {
                    var todosLosDias =
                    DiasOperacion.Lunes |
                    DiasOperacion.Martes |
                    DiasOperacion.Miercoles |
                    DiasOperacion.Jueves |
                    DiasOperacion.Viernes |
                    DiasOperacion.Sabados;
                    return (dias & ~todosLosDias) == 0;

                })
                    .WithMessage("Los dias seleccionado no son válidos");

            RuleFor(x => x.HoraInicio)
                .NotEqual(default(TimeOnly))
                    .WithMessage("Debe especificar una hora de inicio");

            RuleFor(x => x.HoraFin)
                .NotEqual(default(TimeOnly))
                    .WithMessage("Debe especificar una hora de finalización");

            RuleFor(x => x.HoraFin)
                .GreaterThan(x => x.HoraInicio)
                    .WithMessage("La hora de finalización debe ser mayor a la hora de inicio");
                
        }
    }
}
