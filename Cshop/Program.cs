using Microsoft.EntityFrameworkCore;
using Cshop.Data;
using Cshop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<IServiceCollection>(options => options.AddRazorPages());

// Creating a database connection string
var ConnectionString = builder.Configuration.GetConnectionString("DatabaseContextSqlite");
// Add servcie to the container for database connection
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(ConnectionString));

// If you are using Sql Server
//
// var ConnectionString = builder.Configuration.GetConnectionString("DatabaseContextSqlserver");
// builder.Services.AddDbContext<MyWebSiteContext>(options => options.UseSqlServer(ConnectionString));

//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
///*    .AddRoles<Role>()*/
//    .AddEntityFrameworkStores<DatabaseContext>();
// Add services to the container.

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>();


/*builder.Services.AddIdentity<User, IdentityRole>(options => options.SignUp.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>();*/



builder.Services.AddControllersWithViews();



builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "Cshop";
    options.AccessDeniedPath = "/AccessDenied";
    options.LoginPath = "/login";
});




var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        Cshop.SeedData.Initialize(services).Wait();
    }
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        Cshop.SeedData.Initialize(services).Wait();
    }

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseAuthentication();;
app.UseAuthentication();



app.UseAuthorization();





app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});







app.Run();
