using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using HMS.Data;
using HMS.Data.Models;
using HMS.Infrastructure.AutoMapper;
using HMS.Infrastructure.Services;
using HMS.Infrastructure.Services.Auth;
using HMS.Infrastructure.Services.DashBoard;
using HMS.Infrastructure.Services.Doctors;
using HMS.Infrastructure.Services.Nurses;
using HMS.Infrastructure.Services.Patients;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HMSDbContext>(options =>
    options.UseSqlServer(connectionString));


//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User,IdentityRole>(
    config => {
        config.SignIn.RequireConfirmedAccount = false;
        config.User.RequireUniqueEmail = true;
        config.Password.RequireDigit = false;
        config.Password.RequiredLength = 6;
        config.Password.RequireLowercase = false;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireUppercase = false;
        config.SignIn.RequireConfirmedEmail = false;

    }
    
    )
    .AddEntityFrameworkStores<HMSDbContext>().AddDefaultTokenProviders().AddDefaultUI();

builder.Services.AddRazorPages();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<INurseService, NurseService>();
builder.Services.AddTransient<IDashboardService, DashboardService>();

builder.Services.AddHttpContextAccessor();





builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddControllersWithViews();

var app = builder.Build();

DBseeding.seed(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
