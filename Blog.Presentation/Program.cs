using Blog.Core.Repositories;
using Blog.Core.Service;
using Blog.Core.UnitOfWorks;
using Blog.Repository;
using Blog.Repository.Repositories;
using Blog.Repository.UnitOfWorks;
using Blog.Service.Mapping;
using Blog.Service.Service;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region ORM Design Patterns
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositories<>));
builder.Services.AddScoped(typeof(IService<>), typeof(GenericRepositories<>));

builder.Services.AddScoped<IUserCredentialsRepository, UserCredentialsRepository>();
builder.Services.AddTransient<IUserCredentialsService, UserCredentialsService>();

#endregion

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", opt =>
{
    opt.Cookie.Name = "MyCookieAuth";
    opt.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    opt.LoginPath = "/Auth/Authentication/AccessDenied";
});

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("Admin",
        policy => policy.RequireClaim("Admin"));
});


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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
           name: "Admin",
           areaName: "Admin",
           pattern: "Admin/{controller=Home}/{action=Index}"
       );

    endpoints.MapAreaControllerRoute(
           name: "User",
           areaName: "User",
           pattern: "User/{controller=Home}/{action=Index}"
       );

    endpoints.MapAreaControllerRoute(
       name: "Auth",
       areaName: "Auth",
       pattern: "Auth/{controller=Home}/{action=Index}"
   );


    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "Admin/{controller}/{action}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
