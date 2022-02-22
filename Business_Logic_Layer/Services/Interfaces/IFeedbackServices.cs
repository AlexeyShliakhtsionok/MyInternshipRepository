using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IFeedbackServices
    {
        public IEnumerable<FeedbackModel> GetAllFeedbacks();
        public IEnumerable<FeedbackModel> GetAllApprovedFeedbacks();
        public FeedbackModel GetFeedbackById(int id);
        public void CreateFeedback(FeedbackModel feedback);
        public void UpdateFeedback(FeedbackModel feedback);
        public void DeleteFeedback(int id);
    }
}
