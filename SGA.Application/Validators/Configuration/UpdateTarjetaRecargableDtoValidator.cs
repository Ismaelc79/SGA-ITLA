
using FluentValidation;
using SGA.Application.DTOs.TarjetaRecargable;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Configuration
{
    public sealed class UpdateTarjetaRecargableDtoValidator : AbstractValidator<UpdateTarjetaRecargableDto>
    {
        public UpdateTarjetaRecargableDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.Requerido("El Id"));

            RuleFor(x => x.EstudianteId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.Requerido("El Id del estudiante"));

            RuleFor(x => x.PagoId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.Requerido("El Id del pago"));

            RuleFor(x => x.MontoTarjeta)
                .NotEqual(0)
                    .WithMessage("El monto no puede ser igual a 0")
                .GreaterThan(0)
                    .WithMessage("El monto debe ser mayor a 0")
                .LessThanOrEqualTo(10000)
                    .WithMessage("El monto excede el límite permitido");

            RuleFor(x => x.EstadoTarjeta)
                .NotEqual(Domain.Enums.EstadoTarjeta.Ninguno)
                    .WithMessage(ValidationMessages.EnumRequerido("el estado de la tarjeta"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado de la tarjeta"));

            RuleFor(x => x.FechaVigenteInicio)
                .NotEqual(default(DateTime))
                    .WithMessage(ValidationMessages.Requerido("La fecha de inicio de vigencia"))
                .LessThan(x => x.FechaVigenteFin)
                    .WithMessage("La fecha de inicio no puede ser posterior a la de fin de vigencia");

            RuleFor(x => x.FechaVigenteFin)
                .NotEqual(default(DateTime))
                    .WithMessage(ValidationMessages.Requerido("La fecha de fin de vigencia"))
                .GreaterThan(x => x.FechaVigenteInicio)
                    .WithMessage("La fecha de fin de vigencia debe ser posterior a la fecha de inicio")
                .NotEqual(DateTime.Now)
                    .WithMessage("La fecha de fin de vigencia no puede ser la fecha actual");
        }
    }
}
