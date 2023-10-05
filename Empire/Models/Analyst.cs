using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empire.Models
{
    public class Analyst
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BAID { get; set; }
        [DisplayName("First Name:")]
        public string BAFName { get; set; }
        [DisplayName("Last Name:")]
        public string BALName { get; set; }
        [DisplayName("Email:")]
        public string Email { get; set; }
        [DisplayName("Phone:")]
        public string Phone { get; set; }
        [DisplayName("Name:")]
        public string BAFullname
        {
            get { return BAFName + " " + BALName; }
        }
    }

}
