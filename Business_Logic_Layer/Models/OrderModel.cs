using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime DateOfService { get; set; }
        public double OrderPrice { get; set; }
        public bool IsCompleted { get; set; }
        public virtual ClientModel Client { get; set; }
        public virtual ICollection<EmployeeModel> Employees { get; set; }
        public virtual ICollection<ProcedureModel> Procedures { get; set; }
    }
}
