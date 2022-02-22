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
        public bool IsCompleted { get; set; }

        public ClientModel? Client { get; set; }
        public ProcedureModel? Procedure { get; set; }
        public EmployeeModel? Employee { get; set; }
    }
}
