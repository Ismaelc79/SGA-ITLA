using FluentValidation;
using SGA.Application.DTOs.Ruta;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Trips
{
    public sealed class UpdateRutaDtoValidator : AbstractValidator<UpdateRutaDto>
    {
        public UpdateRutaDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id de la ruta"));

            RuleFor(x => x.Nombre)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre de la ruta"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de la ruta", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.EstadoRuta)
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado de la ruta"));

            RuleFor(x => x.RutaOrigen)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre de la ruta oriden"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de la ruta origen", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.RutaDestino)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre de la ruta destino"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de la ruta destino", ValidationConstants.LongitudTextoCorta));
        }
    }
}
