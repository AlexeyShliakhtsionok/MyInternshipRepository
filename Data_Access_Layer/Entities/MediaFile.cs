using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class MediaFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FileId { get; set; }
        [Required]
        [MaxLength(30)]
        public string FileDescription {get; set;}
        [Required]
        public byte[] File { get; set; }

        public virtual ProFile Profile { get; set; }
    }
}
