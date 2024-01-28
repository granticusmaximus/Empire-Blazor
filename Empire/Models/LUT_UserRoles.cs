using System.ComponentModel.DataAnnotations;

namespace Empire.Models
{
    public class LUT_UserRoles
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }

        public ApplicationUser User { get; set; }
        public Role Role { get; set; }
    }
}