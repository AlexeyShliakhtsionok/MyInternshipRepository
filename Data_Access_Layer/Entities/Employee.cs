using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public virtual Qualification Qualification { get; set; }

        public virtual ProFile ProFile { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<Specialization> Specializations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
