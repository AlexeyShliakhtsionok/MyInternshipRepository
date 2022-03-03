using Business_Logic_Layer.DBO.Employees;
using Business_Logic_Layer.DBO.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DBO.ProcedureTypes
{
    public class ProcedureTypeViewModel
    {
        public int ProcedureTypeId { get; set; }
        public string ProcedureTypeName { get; set; }
    }
}
