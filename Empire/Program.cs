using Empire.Areas.Identity;
using Empire.Data;
using Empire.Models;
using Empire.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer((builder.Configuration.GetConnectionString("DefaultConnection"))));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ApplicationUserService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<AppService>();
builder.Services.AddScoped<MSRService>();
builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<TicketService>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IEmailService>(new SendGridEmailService("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"));
var apiBaseAddress = builder.Configuration["ApiSettings:BaseAddress"];
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
