using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using HotelRapidApi.WebUI.DTOs.GuestDtos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IValidator<CreateGuestDto>,CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>,UpdateGuestValidator>();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
// Replace the obsolete AddFluentValidation() call with the recommended methods
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
app.UseAuthorization();

  app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
