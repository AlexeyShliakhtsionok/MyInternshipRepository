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

        public FeedbackController(IFeedbackServices feedbackServices)
        {
            _feedbackServices = feedbackServices;
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
            return Ok(feedbacks);
        }

        [HttpPost, Route("CreateFeedback")]
        public void CreateFeedback(FeedbackModel feedback)
        {
            _feedbackServices.CreateFeedback(feedback);
        }

        [HttpPost, Route("DeleteFeedbackById")]
        public void DeleteFeedbackById(int id)
        {
            _feedbackServices.DeleteFeedback(id);
        }


    }
}
