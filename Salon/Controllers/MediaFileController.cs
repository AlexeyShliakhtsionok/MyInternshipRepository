using Business_Logic_Layer.Models;
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

        [HttpPost]
        public ActionResult UploadImageToDB(IFormFile file)
        {
            if (file != null)
            {
                if(file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                    var objFile = new MediaFileModel()
                    {
                        FileName = newFileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now,
                    };

                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        objFile.FileData = target.ToArray();
                        target.Close();
                    }
                    _mediaFileServices.AddMediaFile(objFile);
                }
                return Ok();
            }
            return NoContent();
        }

        [HttpGet]
        public ActionResult GetImageFromDB(int id)
        {
            MediaFileModel imageToShow = _mediaFileServices.GetMediaFileById(id);
            var byteArray = imageToShow.FileData;
            return File(byteArray, "image/png");
        }
    }
}
