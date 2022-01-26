using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class ScheduleModel
    {
        public int ScheduleId { get; set; }
        public string ScheduleTitle { get; set; }
        public DateTime ScheduleDate { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
        public virtual ICollection<EmployeeModel>? Employees { get; set; }
    }
}
