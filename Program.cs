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

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>();
    

// Add services to the container.
builder.Services.AddControllersWithViews();

//Automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//FluentValidation
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
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

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Administrator", "Operator", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    string email = "admin@admin.com";
    string password = "Admin123!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new User();
        user.UserName = email;
        user.Email = email;
   
        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Administrator");
    }
}
//creating object which fills InMemoryDatabase with some data for testing purposes ;)
DbInitializer testData = new DbInitializer();
//testing user
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    string email = "jkowalski@test.com";
    string password = "Haslo123!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new User();
        user.UserName = email;
        user.Email = email;
        user.FirstName = "Jan";
        user.LastName = "Kowalski";

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "User");
    }
}

app.MapRazorPages();
app.Run();
