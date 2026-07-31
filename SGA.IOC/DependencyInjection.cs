using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.DTOs.Auth;
using SGA.Application.DTOs.Authorization;
using SGA.Application.DTOs.Bus;
using SGA.Application.DTOs.Horario;
using SGA.Application.DTOs.Notification;
using SGA.Application.DTOs.Pago;
using SGA.Application.DTOs.Parada;
using SGA.Application.DTOs.Role;
using SGA.Application.DTOs.Ruta;
using SGA.Application.DTOs.TarjetaRecargable;
using SGA.Application.DTOs.Ticket;
using SGA.Application.DTOs.User;
using SGA.Application.DTOs.Viaje;
using SGA.Application.Interfaces.Auth;
using SGA.Application.Interfaces.Authorization;
using SGA.Application.Interfaces.Configuration;
using SGA.Application.Interfaces.Notification;
using SGA.Application.Interfaces.Role;
using SGA.Application.Interfaces.Trip;
using SGA.Application.Interfaces.Trips;
using SGA.Application.Interfaces.User;
using SGA.Application.Services.Auth;
using SGA.Application.Services.Authorization;
using SGA.Application.Services.Configuration;
using SGA.Application.Services.Notification;
using SGA.Application.Services.Role;
using SGA.Application.Services.Trips;
using SGA.Application.Services.User;
using SGA.Application.Validators.Auth;
using SGA.Application.Validators.Authorization;
using SGA.Application.Validators.Configuration;
using SGA.Application.Validators.Notification;
using SGA.Application.Validators.Role;
using SGA.Application.Validators.Trips;
using SGA.Application.Validators.User;


namespace SGA.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services)
           
        {
            //Servicios e interfaces de servicios
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IRutaService, RutaService>();
            services.AddScoped<IParadaService, ParadaService>();
            services.AddScoped<IHorarioService, HorarioService>();
            services.AddScoped<IViajeService, ViajeService>();
            services.AddScoped<IPagoService, PagoService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITarjetaRecargableService, TarjetaRecargableService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAuthorizationsService, AuthorizationService>();

            //Validators
            services.AddScoped<IValidator<CreateBusDto>, CreateBusDtoValidator>();
            services.AddScoped<IValidator<UpdateBusDto>, UpdateBusDtoValidator>();
            services.AddScoped<IValidator<BusStatusChangeDto>, BusStatusChangeDtoValidator>();
            services.AddScoped<IValidator<CreateRutaDto> , CreateRutaDtoValidator>();
            services.AddScoped<IValidator<UpdateRutaDto>, UpdateRutaDtoValidator>();
            services.AddScoped<IValidator<CreateParadaDto> , CreateParadaDtoValidator>();
            services.AddScoped<IValidator<UpdateParadaDto>, UpdateParadaDtoValidator>();
            services.AddScoped<IValidator<CreateHorarioDto> , CreateHorarioDtoValidator>();
            services.AddScoped<IValidator<UpdateHorarioDto>, UpdateHorarioDtoValidator>();
            services.AddScoped<IValidator<CreateViajeDto>, CreateViajeDtoValidator>();
            services.AddScoped<IValidator<UpdateViajeDto>, UpdateViajeDtoValidator>();
            services.AddScoped<IValidator<ViajeStatusChangeDto>, ViajeStatusChangeDtoValidator>();
            services.AddScoped<IValidator<CreatePagoDto>, CreatePagoDtoValidator>();
            services.AddScoped<IValidator<UpdatePagoDto>, UpdatePagoDtoValidator>();
            services.AddScoped<IValidator<PagoStatusChangeDto>, PagoStatusChangeDtoValidator>();
            services.AddScoped<IValidator<CreateTicketDto>, CreateTicketDtoValidator>();
            services.AddScoped<IValidator<UpdateTicketDto>, UpdateTicketDtoValidator>();
            services.AddScoped<IValidator<CreateTarjetaRecargableDto>, CreateTarjetaRecargableDtoValidator>();
            services.AddScoped<IValidator<UpdateTarjetaRecargableDto>, UpdateTarjetaRecargableDtoValidator>();
            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
            services.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();
            services.AddScoped<IValidator<CreateRoleDto>, CreateRoleDtoValidator>();
            services.AddScoped<IValidator<UpdateRoleDto>, UpdateRoleDtoValidator>();
            services.AddScoped<IValidator<CreateNotificationDto>, CreateNotificationDtoValidator>();
            services.AddScoped<IValidator<UpdateNotificationDto>, UpdateNotificationDtoValidator>();
            services.AddScoped<IValidator<CreateAutorizacionDto>, CreateAutorizacionDtoValidator>();
            services.AddScoped<IValidator<UpdateAutorizacionDto>, UpdateAutorizacionDtoValidator>();
            services.AddScoped<IValidator<AutorizacionStatusChangeDto>, AutorizacionStatusChangeDtoValidator>();
            return services;

        }
    }
}
