using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Business_Logic_Layer.Models
{
    public class ProcedureTypeModel
    {
        public int ProcedureTypeId { get; set; }
        public string ProcedureTypeName { get; set; }
        public ICollection<ProcedureModel>? Procedures { get; set; }
        public ICollection<EmployeeModel>? Employees { get; set; }
    }
}
