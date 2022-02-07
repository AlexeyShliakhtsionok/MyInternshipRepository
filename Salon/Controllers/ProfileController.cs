using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileServices _profileServices;

        public ProfileController(IProfileServices profileServices)
        {
            _profileServices = profileServices;
        }

        [HttpPost]
        [Route("DeleteProfileById")]
        public void DeleteProfile(int id)
        {
            _profileServices.DeleteProfile(id);
        }

        [HttpGet]
        [Route("GetAllProfiles")]
        public ActionResult<IEnumerable<ProfileModel>> GetAllProfiles()
        {
            var profiles = _profileServices.GetProfiles();
            return Ok(profiles);
        }
    }
}
