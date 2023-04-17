using BikeRental.Validators;
using BikeRental.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore; 
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//FluentValidation
builder.Services.AddFluentValidation();
builder.Services.AddScoped <IValidator<VehicleDetailViewModel>, VehicleDetailVmValidator>();
builder.Services.AddScoped<IValidator<ReservationViewModel>, ReservationVmValidator>();





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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
