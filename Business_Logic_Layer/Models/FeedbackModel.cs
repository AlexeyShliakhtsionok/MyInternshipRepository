using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class FeedbackModel
    {
        public int FeedbackId { get; set; }
        public string FeedbackTitle { get; set; }
        public string FeedbackText { get; set; }
        public bool IsVerify { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual ClientModel Client { get; set; }
    }
}
