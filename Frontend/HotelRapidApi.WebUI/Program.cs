using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using HotelRapidApi.WebUI.DTOs.GuestDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 MVC
builder.Services.AddControllersWithViews();

// 🔹 FluentValidation (DOĞRU YER)
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Validator registrations
builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();

// 🔹 HttpClient
builder.Services.AddHttpClient();

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

// 🔹 Identity
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// 🔹 AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// 🔹 BUILD
var app = builder.Build();

// 🔹 Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// 🔹 Routes
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
