using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupermarketDB.Data;

var builder = WebApplication.CreateBuilder(args);

// Load connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register EF Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add MVC controllers and views
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddScoped<SupermarketDB.Services.EmailService>();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages().WithStaticAssets();

app.Run();
