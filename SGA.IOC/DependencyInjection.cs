using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.DTOs.Auth;
using SGA.Application.DTOs.Notification;
using SGA.Application.DTOs.Role;
using SGA.Application.DTOs.User;
using SGA.Application.Interfaces.Auth;
using SGA.Application.Interfaces.Notification;
using SGA.Application.Interfaces.Role;
using SGA.Application.Interfaces.User;
using SGA.Application.Services.Auth;
using SGA.Application.Services.Notification;
using SGA.Application.Services.Role;
using SGA.Application.Services.User;
using SGA.Application.Validators.Auth;
using SGA.Application.Validators.Notification;
using SGA.Application.Validators.Role;
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
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<INotificationService, NotificationService>();

            //Validators
            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
            services.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();
            services.AddScoped<IValidator<CreateRoleDto>, CreateRoleDtoValidator>();
            services.AddScoped<IValidator<UpdateRoleDto>, UpdateRoleDtoValidator>();
            services.AddScoped<IValidator<CreateNotificationDto>, CreateNotificationDtoValidator>();
            services.AddScoped<IValidator<UpdateNotificationDto>, UpdateNotificationDtoValidator>();

            return services;

        }
    }
}
