using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.DTOs.Auth;
using SGA.Application.DTOs.User;
using SGA.Application.Interfaces.Auth;
using SGA.Application.Interfaces.User;
using SGA.Application.Services.Auth;
using SGA.Application.Services.User;
using SGA.Application.Validators.Auth;
using SGA.Application.Validators.User;

namespace SGA.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services)

        {
            //Servicios e interfaces de servicios
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            //Validators
            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
            services.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();

            return services;

        }
    }
}
