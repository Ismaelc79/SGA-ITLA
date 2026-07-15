using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.DTOs.Bus;
using SGA.Application.DTOs.Horario;
using SGA.Application.DTOs.Pago;
using SGA.Application.DTOs.Parada;
using SGA.Application.DTOs.Ruta;
using SGA.Application.DTOs.TarjetaRecargable;
using SGA.Application.DTOs.Ticket;
using SGA.Application.DTOs.Viaje;
using SGA.Application.Interfaces.Configuration;
using SGA.Application.Interfaces.Trip;
using SGA.Application.Interfaces.Trips;
using SGA.Application.Services.Configuration;
using SGA.Application.Services.Trips;
using SGA.Application.Validators.Configuration;
using SGA.Application.Validators.Trips;


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
            return services;

        }
    }
}
