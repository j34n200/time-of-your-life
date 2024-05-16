using Microsoft.EntityFrameworkCore;
using time_of_your_life.Data;
using time_of_your_life.Interfaces;
using time_of_your_life.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPresetRepository, PresetRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<DataContext>(
    opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
