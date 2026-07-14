using FluentValidation;
using SGA.Application.DTOs.Parada;
using SGA.Application.Validators.Common;
namespace SGA.Application.Validators.Trips
{
    public sealed class UpdateParadaDtoValidator : AbstractValidator<UpdateParadaDto>
    {
        public UpdateParadaDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id de la parada"));

            RuleFor(x => x.RutaId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El Id de la ruta"));

            RuleFor(x => x.Nombre)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre de la parada"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre de la parada", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.Ubicacion)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("La ubicación de la parada"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("La ubicación de la parada", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.OrdenParada)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El orden de la parada"))
                 .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El orden de la parada", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.Estado)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El estado de la parada"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El estado de la parada", ValidationConstants.LongitudTextoCorta));

        }

    }
}
