using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empire.Models
{
    public class TicketTechNote
    {
        public string TicketId { get; set; }
        public int TechNoteId { get; set; }

        public Ticket Ticket { get; set; }
        public TechNote TechNote { get; set; }
    }
}