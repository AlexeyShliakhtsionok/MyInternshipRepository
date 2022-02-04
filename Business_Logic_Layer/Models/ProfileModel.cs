using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class ProfileModel
    {
        public int ProfileId { get; set; }
        public string ProfileTitle { get; set; }
        public virtual EmployeeModel Employee { get; set; }
        public virtual ICollection<MediaFileModel> MediaFiles { get; set; }
    }
}
