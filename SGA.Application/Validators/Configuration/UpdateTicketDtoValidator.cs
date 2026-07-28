using SGA.Application.Validators.Common;
using FluentValidation;
using SGA.Application.DTOs.Ticket;

namespace SGA.Application.Validators.Configuration
{
    public sealed class UpdateTicketDtoValidator : AbstractValidator<UpdateTicketDto>
    {
        public UpdateTicketDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage(ValidationMessages.Requerido("El Id del ticket"));

            RuleFor(x => x.EstudianteId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.Requerido("El Id del estudiante"));

            RuleFor(x => x.RutaId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.Requerido("El Id de la ruta"));

            RuleFor(x => x.ParadaId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.Requerido("El Id de la parada"));

            RuleFor(x => x.PagoId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.Requerido("El Id del pago"));

            RuleFor(x => x.Tipo)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El tipo de ticket"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("La descripción del tipo de ticker", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.EstadoTicket)
                .NotEqual(Domain.Enums.EstadoTicket.Ninguno)
                    .WithMessage(ValidationMessages.EnumInvalido("el estado del ticket"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumRequerido("El estado del ticket"));

            RuleFor(x => x.FechaInicio)
                .NotEqual(default(DateTime))
                    .WithMessage(ValidationMessages.Requerido("La fecha y hora de disponibilidad"));

            RuleFor(x => x.FechaInicio)
                .LessThan(x => x.FechaCierre)
                    .WithMessage("La fecha de inicio no puede ser posterior a la fecha de cierre");

            RuleFor(x => x.FechaCierre)
                .NotEqual(default(DateTime))
                    .WithMessage(ValidationMessages.Requerido("La fecha y hora de vencimiento"));

            RuleFor(x => x.FechaCierre)
                .GreaterThan(x => x.FechaInicio)
                    .WithMessage("La fecha de cierre debe ser posterior a la fecha de inicio");

        
        }
    }
}
