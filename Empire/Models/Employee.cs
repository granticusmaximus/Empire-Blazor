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
        public string? Gender { get; set; }
        public string? City { get; set; }
        public string? Designation { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
    }

}
