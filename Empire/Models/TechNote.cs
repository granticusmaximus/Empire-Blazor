using System.ComponentModel.DataAnnotations;

namespace Empire.Models
{
    public class TechNote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Notes { get; set; }
        public string? Username { get; set; }

        public ICollection<TicketTechNote>? TicketTechNotes { get; set; }
    }
}
