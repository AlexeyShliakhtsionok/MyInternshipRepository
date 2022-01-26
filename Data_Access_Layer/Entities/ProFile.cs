using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data_Access_Layer.Entities
{
    public class ProFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProfileId { get; set; }
        [Required]
        [MaxLength(15)]
        public string ProfileTitle { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<MediaFile> MediaFiles { get; set; }
    }
}
