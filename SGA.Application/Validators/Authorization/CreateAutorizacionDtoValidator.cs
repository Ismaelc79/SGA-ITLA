using FluentValidation;
using SGA.Application.DTOs.Authorization;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Authorization
{
    public sealed class CreateAutorizacionDtoValidator : AbstractValidator<CreateAutorizacionDto>
    {
        public CreateAutorizacionDtoValidator()
        {
            RuleFor(x => x.UsuarioId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El usuario"));

            RuleFor(x => x.Tipo)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El tipo de autorización"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El tipo de autorización", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.FechaCierre)
                .GreaterThan(x => x.FechaInicio)
                    .WithMessage("La fecha de cierre debe ser posterior a la fecha de inicio.");
        }
    }
}