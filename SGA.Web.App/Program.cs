using SGA.Application.Interfaces.Trip;
using SGA.Application.Services.Trips;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress =
        new Uri("https://localhost:7001/api/");
});

var app = builder.Build();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();
builder.Services.AddScoped<IBusService, BusService>();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
