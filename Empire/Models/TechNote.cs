using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empire.Models
{
    public class TechNote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }

        public ICollection<TicketTechNote> TicketTechNotes { get; set; }
    }
}
