using MedManager.Models;
using Microsoft.EntityFrameworkCore;
using MedManager.Repositories;
using Microsoft.AspNetCore.Identity;
using MedManager.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("MedManagerDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MedManagerDbContextConnection' not found.");
var connectionString = builder.Configuration.GetConnectionString("MedManagerDatabase") ?? throw new InvalidOperationException("Connection string 'MedManagerDatabase' not found.");

builder.Services.AddDbContext<MedManagerContext>(options =>
    options.UseSqlServer(connectionString)); ;

builder.Services.AddDefaultIdentity<MedManagerUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MedManagerContext>(); ;


//builder.Services.AddDbContext<MedManagerContext>(options =>
//    options.UseSqlServer(connectionString));;

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<MedManagerContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<MedManagerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedManagerDatabase")));
builder.Services.AddTransient<IMedRepository, MedTakeRepository>();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=MedTake}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();