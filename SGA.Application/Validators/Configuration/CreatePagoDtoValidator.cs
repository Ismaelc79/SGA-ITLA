using FluentValidation;
using SGA.Application.DTOs.Pago;
using SGA.Application.Validators.Common;
using SGA.Domain.Enums;

namespace SGA.Application.Validators.Configuration
{
    public sealed class CreatePagoDtoValidator : AbstractValidator<CreatePagoDto>
    {
        public CreatePagoDtoValidator()
        {
            RuleFor(x => x.EstudianteId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id del estudiante"));

            RuleFor(x => x.MontoPago)
                .NotEqual(0)
                    .WithMessage("El monto no puede ser igual a 0")
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El monto de pago"))
                .LessThanOrEqualTo(10000)
                    .WithMessage("El monto excede el máximo permitido");

            RuleFor(x => x.MetodoPago)
                .NotEqual(Domain.Enums.MetodoPago.Ninguno)
                    .WithMessage(ValidationMessages.EnumRequerido("el método de pago"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El método de pago"));

            RuleFor(x => x.EstadoPago)
                .NotEqual(Domain.Enums.EstadoPago.Ninguno)
                    .WithMessage(ValidationMessages.EnumRequerido("el estado de pago"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado de pago"));

            RuleFor(x => x.FechaHora)
                .NotEqual(default(DateTime))
                    .WithMessage(ValidationMessages.Requerido("La fecha y hora del pago"));

            RuleFor(x => x.FechaHora)
                .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("La fecha y hora del pago no puede ser en el futuro");
        }
    }
}
