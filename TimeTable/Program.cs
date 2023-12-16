using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TimeTable.Data;
using TimeTable.DatabaseConnection;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Datenbank Service
/*builder.Services.AddDbContext<TimeTableContext>(options =>
	 options.UseMySql(builder.Configuration.GetConnectionString("TimeTables"),
	 MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TimeTables")))
);*/
/*
builder.Services.AddDbContextFactory<TimeTableContext>(opt =>
	opt.UseMySql(builder.Configuration.GetConnectionString("TimdfafeTables"),
	 MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TimeTaafdafbles")
	)));*/
builder.Services.AddDbContextFactory<TimeTableContext>(opt =>
	opt.UseMySql(
		 "server = localhost; database = timetabel; persistsecurityinfo=True;  uid = root; pwd = Luna07wenn!",
		MySqlServerVersion.AutoDetect("server = localhost; database = timetabel; persistsecurityinfo=True;  uid = root; pwd = Luna07wenn!")
	)
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
