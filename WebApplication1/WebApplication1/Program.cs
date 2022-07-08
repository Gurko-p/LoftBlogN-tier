using BisunessLayer;
using BisunessLayer.Implementations;
using BisunessLayer.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EFDBContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IDirectoryRepository, EFDirectoryRepository>();
builder.Services.AddTransient<IMaterialsRepository, EFMaterialsRepository>();
builder.Services.AddScoped<DataManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
