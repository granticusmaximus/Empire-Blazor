using Empire.Data;
using Empire.Models;
using Microsoft.AspNetCore.Identity;

using System.Linq;

public class DataSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;

    public DataSeeder(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _roleManager = roleManager;
    }

    public void SeedRoles()
    {
        if (!_roleManager.Roles.Any())
        {
            _roleManager.CreateAsync(new IdentityRole("Business Analyst")).Wait();
            _roleManager.CreateAsync(new IdentityRole("Developer")).Wait();
        }
    }

}
