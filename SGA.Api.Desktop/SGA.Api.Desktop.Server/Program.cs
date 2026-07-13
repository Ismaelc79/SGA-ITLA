using SGA.Application.Interfaces;
using SGA.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using SGA.Persistence.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IAuthorizationService, AuthorizationService>();

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SGA.Api v1");
         
    });
}

app.MapControllers();
app.MapDefaultEndpoints();

app.Run();