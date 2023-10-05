using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empire.Models
{
    public class Developer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DevID { get; set; }
        [DisplayName("First Name:")]
        public string DevFName { get; set; }
        [DisplayName("Last Name:")]
        public string DevLName { get; set; }
        [DisplayName("Email:")]
        public string Email { get; set; }
        [DisplayName("Phone:")]
        public string Phone { get; set; }
        [DisplayName("Name:")]
        public string DevFullname
        {
            get { return DevFName + " " + DevLName; }
        }
    }
}
