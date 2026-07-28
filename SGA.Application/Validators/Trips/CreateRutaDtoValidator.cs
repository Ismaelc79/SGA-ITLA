using FluentValidation;
using SGA.Application.DTOs.Ruta;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Trips
{
    public sealed class CreateRutaDtoValidator : AbstractValidator<CreateRutaDto>
    {
        public CreateRutaDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre de la ruta"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de la ruta", ValidationConstants.LongitudTextoCorta));
        
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("La descripción de la ruta"))
                .MaximumLength(ValidationConstants.LongitudTextoLarga)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de la ruta",ValidationConstants.LongitudTextoLarga));

            RuleFor(x => x.EstadoRuta)
                .NotEqual(Domain.Enums.EstadoRuta.Ninguno)
                    .WithMessage(ValidationMessages.EnumRequerido("estado de la ruta"))
                .IsInEnum()
                    .WithMessage(ValidationMessages.EnumInvalido("El estado de la ruta"));

            RuleFor(x => x.RutaOrigen)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre de la ruta de origen"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de la ruta de origen", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.RutaDestino)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre de la ruta destino"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de la ruta de destino", ValidationConstants.LongitudTextoCorta));
        }
    }
}
