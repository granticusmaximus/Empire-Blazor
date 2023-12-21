using Empire.Data;
using Empire.Models;
using Microsoft.EntityFrameworkCore;

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
                query = query.Include(t => t.Notes);
            }

            return await query.FirstOrDefaultAsync(t => t.TicketId == ticketId);
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

        public async Task AddTechNoteToTicketAsync(string ticketId, TechNote techNote)
        {
            var ticket = await _context.Tickets.Include(t => t.Notes)
                                               .FirstOrDefaultAsync(t => t.TicketId == ticketId);

            if (ticket != null)
            {
                if (ticket.Notes == null)
                {
                    ticket.Notes = new List<TechNote>();
                }

                ticket.Notes.Add(techNote);
                await _context.SaveChangesAsync();
            }
        }


        public async Task UpdateTechNoteAsync(TechNote note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTechNoteAsync(int noteID)
        {
            TechNote? techNote = await _context.Notes.FirstOrDefaultAsync(t => t.Id == noteID);
            if (techNote != null)
            {
                _context.Notes.Remove(techNote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
