using System;
using System.Collections.Generic;

namespace Business_Logic_Layer.Models
{
    public class SpecializationModel
    {
        public int SpecializationId { get; set; }
        public ProcedureTypeModel ProcedureType { get; set; }
        public virtual ICollection<EmployeeModel> Employees { get; set; }
    }
}
