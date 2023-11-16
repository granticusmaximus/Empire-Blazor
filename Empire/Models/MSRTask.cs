﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Empire.Models
{
    public enum MSRTaskStatus
    {
        Backlog,
        InProgress,
        Done
    }

    public class MSRTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MsrID { get; set; }

        [ForeignKey("ApplicationUser")]
        [DisplayName("User Assigned:")]
        public string? AssignedUserID { get; set; }
        public ApplicationUser? AppUser { get; set; }

        [ForeignKey("AppList")]
        [DisplayName("App Assigned:")]
        public int? AssignedAppID { get; set; }
        public AppList? Apps { get; set; }

        [DisplayName("Task Number/MSR Title:")]
        public string MSRtitle { get; set; }

        [DisplayName("Date Completed:")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [DisplayName("Notes:")]
        public string MSRNote { get; set; }

        [DisplayName("Status")]
        public MSRTaskStatus? Status { get; set; } = MSRTaskStatus.Backlog;

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
