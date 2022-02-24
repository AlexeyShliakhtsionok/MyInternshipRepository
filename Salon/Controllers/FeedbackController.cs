using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackServices _feedbackServices;
        private readonly IClientServices _clientServices;

        public FeedbackController(IFeedbackServices feedbackServices, IClientServices clientServices)
        {
            _feedbackServices = feedbackServices;
            _clientServices = clientServices;
        }

        [HttpGet]
        [Route("GetFeedbackById")]
        public ActionResult<FeedbackModel> GetFeedbackById(int id)
        {
            var feedback = _feedbackServices.GetFeedbackById(id);
            return Ok(feedback);
        }

        [HttpGet]
        [Route("GetAllFeedbacks")]
        public ActionResult<IEnumerable<FeedbackModel>> GetAllFeedbacks() {
            var feedbacks = _feedbackServices.GetAllFeedbacks();
            var clients = _clientServices.GetAllClients();
            return Ok(new { feedbacks, clients });
        }

        [HttpGet]
        [Route("GetAllApprovedFeedbacks")]
        public ActionResult<IEnumerable<FeedbackModel>> GetAllApprovedFeedbacks()
        {
            var feedbacks = _feedbackServices.GetAllFeedbacks();
            var clients = _clientServices.GetAllClients();
            return Ok(new { feedbacks, clients });
        }

        [HttpPost, Route("CreateFeedback")]
        public void CreateFeedback(FeedbackModel feedback)
        {
            _feedbackServices.CreateFeedback(feedback);
        }

        [HttpPost, Route("UpdateFeedback")]
        public void UpdateFeedback([FromBody]FeedbackModel feedback)
        {
            _feedbackServices.UpdateFeedback(feedback);
        }

        [HttpPost, Route("DeleteFeedbackById")]
        public void DeleteFeedbackById(int id)
        {
            _feedbackServices.DeleteFeedback(id);
        }


    }
}
