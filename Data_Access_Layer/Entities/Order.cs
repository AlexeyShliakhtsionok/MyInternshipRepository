using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime DateOfService { get; set; }
        [Required]
        public double OrderPrice { get; set; }
        public bool IsCompleted { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Procedure> Procedures { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
