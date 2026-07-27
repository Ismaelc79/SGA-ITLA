using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.DTOs.Auth;
using SGA.Application.Interfaces.Auth;
using SGA.Application.Services.Auth;
using SGA.Application.Validators.Auth;

namespace SGA.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services)

        {
            //Servicios e interfaces de servicios
            services.AddScoped<IAuthService, AuthService>();

            //Validators
            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();

            return services;

        }
    }
}
