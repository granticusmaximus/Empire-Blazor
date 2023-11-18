using Empire.Data;
using Empire.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empire.Service
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetAllTasksAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetTaskByIdAsync(string ticketId)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        public async Task CreateNewTaskAsync(Ticket ticket)
        {
            ticket.TimeOfCreation = DateTime.Now; // Set creation time
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(string ticketId)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketId == ticketId);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
    }
}
