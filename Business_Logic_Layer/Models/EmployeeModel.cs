namespace Business_Logic_Layer.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime HireDate { get; set; }
        public RoleModel Role { get; set; }
        public QualificationModel Qualification { get; set; }
        public ProcedureTypeModel? ProcedureType { get; set; }
        public virtual ICollection<MediaFileModel>? MediaFiles { get; set; }
        public ICollection<OrderModel>? Orders { get; set; }
    }
}
