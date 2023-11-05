using Empire.Data;
using Empire.Models;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empire.Service
{
    public class AppService
    {
        private readonly ApplicationDbContext _context;

        public AppService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateNewAppAsync(AppList app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            _context.Apps.Add(app);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AppList> GetAppByIdAsync(int id)
        {
            return await _context.Apps.FindAsync(id);
        }

        public async Task<List<AppList>> GetAllAppsAsync()
        {
            return await _context.Apps.ToListAsync();
        }

        public async Task<bool> UpdateAppAsync(AppList app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            _context.Apps.Update(app);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAppAsync(int id)
        {
            AppList? app = await _context.Apps.FindAsync(id);

            if (app == null)
                return false;

            _context.Apps.Remove(app);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
