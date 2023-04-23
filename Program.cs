using BikeRental.Validators;
using BikeRental.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BikeRental.DAL;
using BikeRental.Models;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DatabaseContextConnection") ?? throw new InvalidOperationException("Connection string 'DatabaseContextConnection' not found.");

//builder.Services.AddDbContext<DatabaseContext>(options =>
//    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DatabaseContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//FluentValidation
builder.Services.AddFluentValidation();
builder.Services.AddScoped <IValidator<VehicleDetailViewModel>, VehicleDetailVmValidator>();
builder.Services.AddScoped<IValidator<ReservationViewModel>, ReservationVmValidator>();
builder.Services.AddScoped<IValidator<RentalPointViewModel>, RentalPointVmValidator>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
