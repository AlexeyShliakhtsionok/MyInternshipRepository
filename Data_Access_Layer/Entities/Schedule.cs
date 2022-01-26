using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Schedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        [MaxLength(10)]
        public string ScheduleTitle { get; set; }
        [Required]
        public DateTime ScheduleDate { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
