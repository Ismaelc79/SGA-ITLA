using FluentValidation;
using SGA.Application.DTOs.Notification;
using SGA.Application.Validators.Common;

namespace SGA.Application.Validators.Notification
{
    public sealed class CreateNotificationDtoValidator : AbstractValidator<CreateNotificationDto>
    {
        private const int LongitudMinimaMensaje = 3;
        private const int LongitudMaximaMensaje = 200;

        public CreateNotificationDtoValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty()
                    .WithMessage(ValidationMessages.Requerido("El mensaje"))
                .MinimumLength(LongitudMinimaMensaje)
                    .WithMessage(ValidationMessages.LongitudMinima("El mensaje", LongitudMinimaMensaje))
                .MaximumLength(LongitudMaximaMensaje)
                    .WithMessage(ValidationMessages.LongitudMaxima("El mensaje", LongitudMaximaMensaje));

            RuleFor(x => x.UserId)
                .GreaterThan(0)
                    .WithMessage(ValidationMessages.MayorACero("El usuario"));
        }
    }
}
