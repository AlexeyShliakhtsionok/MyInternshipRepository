﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public RoleModel Role { get; set; }
        public QualificationModel Qualification { get; set; }
        public SpecializationModel Specialization { get; set; }
        public int? ScheduleId { get; set; }
        public virtual ScheduleModel? Schedule { get; set; }
        public int? ProfileId { get; set; }
        public virtual ProfileModel? Profile { get; set; }
        public virtual ICollection<OrderModel>? Orders { get; set; }
    }
}
