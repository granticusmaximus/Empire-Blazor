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
        public string? ClientEmail { get; set; }
        public string? ClientPhoneNumber { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime TimeOfCreation { get; set; }
        // Foreign key for ApplicationUser
        public string? ApplicationUserId { get; set; }

        // Navigation property for ApplicationUser
        public ApplicationUser? ApplicationUser { get; set; }

        // Foreign key for AppList
        public int? AppListId { get; set; }

        // Navigation property for AppList
        public AppList? AppList { get; set; }
        [NotMapped]
        public string? TechNotes { get; set; }
    }

    public enum TicketSeverity
    {
        Low,
        Medium,
        High
    }
}
