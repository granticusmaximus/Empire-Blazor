using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empire.Models
{
    public class Employee : ApplicationUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string? Gender { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Cellnumber { get; set; }
        public string? Designation { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public ICollection<MSRTask> MSRTasks { get; set; }
    }

}
