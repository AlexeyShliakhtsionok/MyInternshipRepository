﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Layer.Entities
{
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FeedbackId { get; set; }
        [Required]
        [MaxLength(15)]
        public string FeedbackTitle { get; set; }
        [Required]
        [MaxLength(255)]
        public string FeedbackText { get; set; }
        public bool IsVerify { get; set; }

        public virtual Client Client { get; set; }
    }
}