using Empire.Data;
using Empire.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Ticket> GetTaskByIdAsync(string ticketId, bool includeTechNotes = false)
        {
            IQueryable<Ticket> query = _context.Tickets;

            if (includeTechNotes)
            {
                query = query.Include(t => t.TicketTechNotes)
                             .ThenInclude(ttn => ttn.TechNote);
            }

            return await query.FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        public async Task CreateNewTaskAsync(Ticket ticket)
        {
            ticket.TimeOfCreation = DateTime.Now;
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

        public async Task AddTechNoteToTicketAsync(string ticketId, TechNote techNote)
        {
            if (techNote.Id == 0)
            {
                _context.Notes.Add(techNote);
                await _context.SaveChangesAsync();
            }

            var ticketTechNote = new TicketTechNote
            {
                TicketId = ticketId,
                TechNoteId = techNote.Id
            };

            _context.Add(ticketTechNote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTechNoteAsync(int techNoteId)
        {
            // Remove relationships in the junction table
            var ticketTechNotes = await _context.TicketTechNotes
                .Where(ttn => ttn.TechNoteId == techNoteId)
                .ToListAsync();

            _context.TicketTechNotes.RemoveRange(ticketTechNotes);

            // Remove the TechNote itself
            var techNote = await _context.Notes.FindAsync(techNoteId);
            if (techNote != null)
            {
                _context.Notes.Remove(techNote);
            }

            await _context.SaveChangesAsync();
        }
    }
}
