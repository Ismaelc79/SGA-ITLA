
using FluentValidation;
using SGA.Application.DTOs.Pago;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Configuration
{
    public sealed class UpdatePagoDtoValidator : AbstractValidator<UpdatePagoDto>
    {
        public UpdatePagoDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id"));

            RuleFor(x => x.EstudianteId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id del estudiante"));

            RuleFor(x => x.MontoPago)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El monto del pago"))
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
                    .WithMessage(ValidationMessages.EnumRequerido("El estado de pago"));

            RuleFor(x => x.FechaHora)
                .NotEqual(DateTime.Now)
                    .WithMessage(ValidationMessages.Requerido("La fecha y hora del pago"));

            RuleFor(x => x.FechaHora)
                .LessThanOrEqualTo(DateTime.Now)
                    .WithMessage("La fecha y hora del pago no pueden ser en el futuro");
     
        }
    }
}
