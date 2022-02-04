using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class MaterialManufacturerModel
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string MadeIn { get; set; }
        
        public virtual ICollection<MaterialModel> Materials { get; set; }
    }
}
