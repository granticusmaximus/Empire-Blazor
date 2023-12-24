using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empire.Models
{
    public class Ticket
    {
        [Key]
        public string TicketId { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public TicketSeverity Severity { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime TimeOfCreation { get; set; }

        public virtual ICollection<TicketTechNote> TicketTechNotes { get; set; }

    }

    public enum TicketSeverity
    {
        Low,
        Medium,
        High
    }

}
