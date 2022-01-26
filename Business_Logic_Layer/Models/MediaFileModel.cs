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
        public string FileDescription { get; set; }
        public byte[] File { get; set; }
        public virtual ProfileModel Profile { get; set; }
    }
}
