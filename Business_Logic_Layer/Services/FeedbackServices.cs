using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic_Layer.Services
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public FeedbackServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateFeedback(FeedbackModel feedback)
        {
            Feedback feedbackEntity = AutoMappers<FeedbackModel, Feedback>.Map(feedback);
            feedbackEntity.Client = _UnitOfWork.Client.GetById(feedback.Client.ClientId);
             _UnitOfWork.Feedback.Add(feedbackEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteFeedback(int id)
        {
            var feedbackToDelete = _UnitOfWork.Feedback.GetById(id);
             _UnitOfWork.Feedback.Delete(feedbackToDelete);
            _UnitOfWork.Complete();
        }


        public IEnumerable<FeedbackModel> GetAllApprovedFeedbacks()
        {
            var feedbacks = _UnitOfWork.Feedback.GetAll()
                .Include(c => c.Client).Where(v => v.IsVerify == true);
            IEnumerable<FeedbackModel> feedbacksModel = AutoMappers<Feedback, FeedbackModel>.MapIQueryable(feedbacks);
            return feedbacksModel;
        }

        public IEnumerable<FeedbackModel> GetAllFeedbacks()
        {
            var feedbacks = _UnitOfWork.Feedback.GetAll()
                .Include(c => c.Client);
            IEnumerable<FeedbackModel> feedbacksModel = AutoMappers<Feedback, FeedbackModel>.MapIQueryable(feedbacks);
            return feedbacksModel;
        }

        public FeedbackModel GetFeedbackById(int id)
        {
            var feedback = _UnitOfWork.Feedback.GetAll()
                .Include(c => c.Client)
                .FirstOrDefault(c => c.Client.ClientId == id);
            FeedbackModel feedbackModel = AutoMappers<Feedback, FeedbackModel>.Map(feedback);
            return feedbackModel;
        }

        public void UpdateFeedback(FeedbackModel feedback)
        {
            Feedback feedbackEntity = AutoMappers<FeedbackModel, Feedback>.Map(feedback);
            feedbackEntity.IsVerify = true;
            feedbackEntity.Client = _UnitOfWork.Client.GetById(feedback.Client.ClientId);
            _UnitOfWork.Feedback.Update(feedbackEntity);
            _UnitOfWork.Complete();
        }
    }
}
