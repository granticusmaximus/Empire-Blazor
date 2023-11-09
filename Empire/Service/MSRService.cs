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
    public class MSRService
    {
        private readonly ApplicationDbContext _context;

        public MSRService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a new MSR Task
        public async Task<bool> CreateMSRTaskAsync(MSRTask msrTask)
        {
            if (msrTask == null)
                throw new ArgumentNullException(nameof(msrTask));

            _context.Tasks.Add(msrTask);
            return await _context.SaveChangesAsync() > 0;
        }

        // Get an MSR Task by ID
        public async Task<MSRTask> GetMSRTaskByIdAsync(int id)
        {
            return await _context.Tasks
                .Include(t => t.AppUser)
                .Include(t => t.Apps)
                .FirstOrDefaultAsync(t => t.MsrID == id);
        }

        // Get all MSR Tasks
        public async Task<List<MSRTask>> GetAllMSRTasksAsync()
        {
            return await _context.Tasks
                .Include(t => t.AppUser) 
                .Include(t => t.Apps)
                .ToListAsync();
        }

        // Update an existing MSR Task
        public async Task<bool> UpdateMSRTaskAsync(MSRTask msrTask)
        {
            if (msrTask == null)
                throw new ArgumentNullException(nameof(msrTask));

            _context.Tasks.Update(msrTask);
            return await _context.SaveChangesAsync() > 0;
        }

        // Delete an MSR Task
        public async Task<bool> DeleteMSRTaskAsync(int id)
        {
            MSRTask? msrTask = await _context.Tasks.FindAsync(id);
            if (msrTask == null)
                return false;

            _context.Tasks.Remove(msrTask);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
