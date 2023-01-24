using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;
using CRUDInventoryQuick.Repositorio;
using CRUDInventoryQuick.Contracts;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

builder.Services.AddDbContext<ApplicationDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

builder.Services.AddScoped<IRepository<CATEGORIum>, CategoriaRepository>();
builder.Services.AddScoped<IRepository<MARCA>, MarcaRepository>();
builder.Services.AddScoped<IRepository<PRODUCTO>, ProductoRepository>();
builder.Services.AddScoped<IRepository<ASPNETROLES>, RolRepository>();
builder.Services.AddScoped<IRepository<PRECIO>, PrecioRepository>();
builder.Services.AddScoped<IRepository<SUBCATEGORIum>, SubcategoriaRepository>();





//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

////Email Sender
//builder.Services.AddTransient<IEmailSender, EmailSender>();
//builder.Services.Configure<EmailOptions>(builder.Configuration);

////Sms Sender
//builder.Services.AddTransient<ISmsSender, SmsSender>();
//builder.Services.Configure<SmsOptions>(builder.Configuration);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
