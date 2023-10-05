using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Empire.Models
{
    public class MSRTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MsrID { get; set; }

        [ForeignKey("Employee")]
        [DisplayName("Employee Assigned:")]
        public int AssignedEmpID { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("AppList")]
        [DisplayName("App Assigned:")]
        public int AssignedAppID { get; set; }
        public AppList Apps { get; set; }
        //public string Employee { get; set; }
        //public string AppTitle { get; set; }

        [DisplayName("Task Number/MSR Title:")]
        public string MSRtitle { get; set; }

        [DisplayName("Date Completed:")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [DisplayName("Notes:")]
        public string MSRNote { get; set; }

    }
}
