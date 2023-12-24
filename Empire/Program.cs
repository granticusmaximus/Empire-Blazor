using Empire.Data;
using Empire.Models;
using Empire.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static EmailService;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ApplicationUserService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddHttpClient();
<<<<<<< HEAD
=======
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();
>>>>>>> 816666bd8a9a1c5616a8e5b1dc8e0a577b5e6083
var apiBaseAddress = builder.Configuration["ApiSettings:BaseAddress"];

builder.Services.AddSignalR(e =>
{
    e.MaximumReceiveMessageSize = 90002400;
});

builder.Services.AddHttpClient("LocalApiClient", client =>
{
    client.BaseAddress = new Uri(apiBaseAddress);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins(apiBaseAddress)
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
