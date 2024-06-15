using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Restaurant_Reservation;
using Restaurant_Reservation.Service; 
using Restaurant_Reservation.Datenbank;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<DatabaseHelper>();
builder.Services.AddScoped<ReservationService>(); 

await builder.Build().RunAsync();
