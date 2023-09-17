using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using BlogApp.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TransportContext>(options =>
{
    var version = new MySqlServerVersion(new Version(8, 1, 0));
    options.UseMySql(builder.Configuration["ConnectionStrings:mysql_connection"], version);
    //options.UseNpgsql(builder.Configuration.GetConnectionString("mysql_connection"));
});

builder.Services.AddScoped<ICompanyRepository, EfCompanyRepository>();
builder.Services.AddScoped<IVehicleRepository, EfVehicleRepository>();
builder.Services.AddScoped<IWorkerRepository, EfWorkerRepository>();
builder.Services.AddScoped<IJobRepository, EfJobRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IDemandRepository, EfDemandRepository>();

builder.Services.AddSignalR();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = "/Users/Login";
});

var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "company_details",
    pattern: "company/details/{url}",
    defaults: new {controller = "Companies", action = "Details" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Companies}/{action=Index}/{id?}"
);
app.MapHub<ChatHub>("/chatHub");
app.Run();
