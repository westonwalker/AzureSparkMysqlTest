using Spark.Library.Environment;
using Spark.Library.Config;
using MyAppTestVite.Application.Startup;
using Vite.AspNetCore.Extensions;
using Microsoft.Extensions.Hosting;
using MyAppTestVite.Application.Database;
using Microsoft.EntityFrameworkCore;

EnvManager.LoadConfig();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetupSparkConfig();

// Add all services to the container.
builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
	// Do something only in dev environments
	app.UseViteDevMiddleware();
}

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
	db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Services.RegisterScheduledJobs();
app.Services.RegisterEvents();

app.Run();
