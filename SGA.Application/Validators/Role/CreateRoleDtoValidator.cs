using FluentValidation;
using SGA.Application.DTOs.Role;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Role
{
    public sealed class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El nombre del rol"))
                .MaximumLength(ValidationConstants.LongitudTextoCorta)
                    .WithMessage(ValidationMessages.LongitudMaxima("El nombre del rol", ValidationConstants.LongitudTextoCorta));

            RuleFor(x => x.Descripcion)
                .MaximumLength(ValidationConstants.LongitudTextoLarga)
                    .WithMessage(ValidationMessages.LongitudMaxima("La descripción", ValidationConstants.LongitudTextoLarga));
        }
    }
}
