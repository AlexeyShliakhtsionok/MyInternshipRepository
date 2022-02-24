using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class MediaFileModel
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsProfilePhoto { get; set; }

        public virtual EmployeeModel? Employee { get; set; }
    }
}
