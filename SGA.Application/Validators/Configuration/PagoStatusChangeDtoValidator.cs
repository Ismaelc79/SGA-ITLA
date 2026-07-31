using FluentValidation;
using SGA.Application.DTOs.Pago;
using SGA.Application.Validators.Common;
namespace SGA.Application.Validators.Configuration
{
    public sealed class PagoStatusChangeDtoValidator : AbstractValidator<PagoStatusChangeDto>
    {
        public PagoStatusChangeDtoValidator()
        {
            RuleFor(x => x.EstadoPago)
                .NotEqual(Domain.Enums.EstadoPago.Ninguno)
                    .WithMessage(ValidationMessages.EnumRequerido("el estado de pago"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado de pago"));

        }
    }
}
