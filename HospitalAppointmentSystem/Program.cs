using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Authentication and authorization settings
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/SignIn";
        options.AccessDeniedPath = "/Login/SignIn";
        options.LogoutPath = "/Login/Logout";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("admin"));
    options.AddPolicy("DoctorPolicy", policy => policy.RequireRole("doctor"));
    options.AddPolicy("PatientPolicy", policy => policy.RequireRole("patient"));
});

// Add session management
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDoctorDal, EfDoctorDal>();
builder.Services.AddScoped<IDoctorService, DoctorManager>();

builder.Services.AddScoped<IClinicDal, EfClinicDal>();
builder.Services.AddScoped<IClinicService, ClinicManager>();

builder.Services.AddScoped<IPatientDal, EfPatientDal>();
builder.Services.AddScoped<IPatientService, PatientManager>();

builder.Services.AddScoped<IAdminDal, EfAdminDal>();
builder.Services.AddScoped<IAdminService, AdminManager>();

builder.Services.AddScoped<IAppointmentDal, EfAppointmentDal>();
builder.Services.AddScoped<IAppointmentService, AppointmentManager>();

builder.Services.AddScoped<ICheckupDal, EfCheckupDal>();
builder.Services.AddScoped<ICheckupService, CheckupManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Use session
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
