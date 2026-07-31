
using FluentValidation;
using SGA.Application.DTOs.Ticket;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Configuration
{
    public sealed class CreateTicketDtoValidator : AbstractValidator<CreateTicketDto>
    {
        public CreateTicketDtoValidator()
        {
            RuleFor(x => x.EstudianteId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id del estudiante"));

            RuleFor(x => x.RutaId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id de ruta"));

            RuleFor(x => x.ParadaId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id de parada"));

            RuleFor(x => x.PagoId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id del pago"));

            RuleFor(x => x.Tipo)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El tipo de ticket"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("La descripción del tipo de ticket", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.EstadoTicket)
                .NotEqual(Domain.Enums.EstadoTicket.Ninguno)
                    .WithMessage(ValidationMessages.EnumRequerido("el estado del ticket"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado del ticket"));

            RuleFor(x => x.FechaInicio)
                .NotEqual(default(DateTime))
                    .WithMessage(ValidationMessages.Requerido("La fecha y hora de disponibilidad"))
                .LessThan(x => x.FechaCierre)
                   .WithMessage("La fecha de inicio no puede ser posterior a la fecha de cierre");

            RuleFor(x => x.FechaCierre)
                .NotEqual(default(DateTime))
                    .WithMessage(ValidationMessages.Requerido("La fecha y hora de vencimiento"))
                .GreaterThan(x => x.FechaInicio)
                    .WithMessage("La fecha de vencimiento debe ser posterior a la fecha de disponibilidad");
        
        }
    }
}
