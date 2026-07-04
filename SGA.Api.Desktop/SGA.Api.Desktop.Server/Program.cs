var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Services.AddControllers();


builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();


app.MapDefaultEndpoints();
app.UseFileServer();

app.Run();