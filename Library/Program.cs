using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<LibraryUser>(options => options.SignIn.RequireConfirmedEmail = false).AddEntityFrameworkStores<LibraryDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    

builder.Services.AddControllersWithViews();

// API controllers toevoegen
builder.Services.AddControllers();

// Swagger API testing toevoegen
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library API", Version = "v1" }); });

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    LibraryDbContext context = services.GetRequiredService<LibraryDbContext>();
    UserManager<LibraryUser> userManager = services.GetRequiredService<UserManager<LibraryUser>>();
    await context.Seeder(userManager);
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Gebruik Swagger in de requestafhandeling
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1"));
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Definieer API endpoints
app.UseEndpoints(e => { e.MapControllers(); });

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
