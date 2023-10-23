using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empire.Models
{
    public class AppList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppID { get; set; }
        [DisplayName("Application Name:")]
        public string AppName { get; set; }

        [ForeignKey("Analyst")]
        [DisplayName("BA Assigned:")]
        public int AssignedBA { get; set; }

        [ForeignKey("Developer")]
        [DisplayName("Dev Assigned:")]
        public int AssignedDev { get; set; }

        [DisplayName("Purpose:")]
        public string AppNotes { get; set; }

        [DisplayName("POC/Owner:")]
        public string POC { get; set; }

        [DisplayName("POC #:")]
        public string Telephone { get; set; }

        [DisplayName("POC Email:")]
        public string POCEmail { get; set; }

    }
}
