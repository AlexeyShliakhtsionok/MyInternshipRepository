using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class ProcedureModel
    {
        public int ProcedureId { get; set; }
        public string ProcedureName { get; set; }
        public DateTime TimeAmount { get; set; }
        public float ProcedurePrice { get; set; }
        public ProcedureTypeModel ProcedureType { get; set; }
        public virtual ICollection<MaterialModel> Materials { get; set; }
        public virtual SpecializationModel Specialization { get; set; }
    }
}
