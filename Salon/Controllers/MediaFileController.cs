using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MediaFileController : ControllerBase
    {
        private readonly IMediaFileServices _mediaFileServices;

        public MediaFileController(IMediaFileServices mediaFileServices)
        {
            _mediaFileServices = mediaFileServices;
        }
    }
}
