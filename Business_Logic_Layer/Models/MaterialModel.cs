using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class MaterialModel
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public double MaterialAmount { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime BestBeforeDate { get; set; }
        public virtual MaterialManufacturerModel MaterialManufacturer { get; set; }
        public virtual ICollection<ProcedureModel>? Procedures { get; set; }
    }
}
