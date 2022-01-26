using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Specialization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SpecializationId { get; set; }
        public ProcedureType ProcedureType { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

