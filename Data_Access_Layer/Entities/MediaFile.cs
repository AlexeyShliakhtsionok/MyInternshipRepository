﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class MediaFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FileId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName {get; set;}
        [Required]
        public byte[] FileData { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ProFile? Profile { get; set; }
    }
}
