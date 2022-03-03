using Business_Logic_Layer.DBO.Feedbacks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IFeedbackServices
    {
        public IEnumerable<FeedbackInformationViewModel> GetAllFeedbacks();
        public IEnumerable<FeedbackInformationViewModel> GetAllApprovedFeedbacks();
        public FeedbackViewModel GetFeedbackById(int id);
        public void CreateFeedback(FeedbackViewModel feedback);
        public void UpdateFeedback(FeedbackInformationViewModel feedback);
        public void DeleteFeedback(int id);
    }
}
