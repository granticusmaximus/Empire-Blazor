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

        // Create a new msr
        public async Task<bool> CreateMSRAsync(MSRTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            _context.Tasks.Add(task);
            return await _context.SaveChangesAsync() > 0;
        }

        // Retrieve a task by ID
        public async Task<MSRTask> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        // Retrieve all tasks
        public async Task<List<MSRTask>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        // Update an existing task
        public async Task<bool> UpdateTaskAsync(MSRTask task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            _context.Tasks.Update(task);
            return await _context.SaveChangesAsync() > 0;
        }

        // Delete a task by ID
        public async Task<bool> DeleteTaskAsync(int id)
        {
            MSRTask? task = await _context.Tasks.FindAsync(id);

            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
