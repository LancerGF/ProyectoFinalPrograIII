using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Microsoft.AspNetCore.Identity;
using ProyectoFinal.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BDContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db1")));

var connectionStringone = builder.Configuration.GetConnectionString("LoginContextConnection");
builder.Services.AddDbContext<LoginContext>(options =>options.UseSqlServer(connectionStringone));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LoginContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints => endpoints.MapRazorPages());

app.Run();
