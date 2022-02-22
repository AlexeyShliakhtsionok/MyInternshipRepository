using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

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
        [Route("DeleteMediaFileById")]
        public void DeleteMediaFile(int id)
        {
            _mediaFileServices.DeleteMediaFile(id);
        }

        [HttpGet]
        [Route("GetFileById")]
        public ActionResult GetImageFromDB(int id)
        {
            MediaFileModel imageToShow = _mediaFileServices.GetMediaFileById(id);
            var byteArray = imageToShow.FileData;
            var result = base.File(byteArray, "image/png");
            return result;
        }


        [HttpGet]
        [Route("GetAllMediaFiles")]
        public ActionResult GetAllMediaFiles()
        {
            List<MediaFileModel> models = _mediaFileServices.GetMediaFiles().ToList();

            List<FileContentResult> result = new();

            foreach (var file in models)
            {
                result.Add(base.File(file.FileData, "image/png"));
            }
            return Ok(result);
        }

        [HttpPost]
        public ActionResult UploadImageToDB(IFormFile file)
        {
                if (file != null)
                {
                    if (file.Length > 0)
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
    }
}






//[HttpPost]
//public ActionResult UploadImageToDB(IFormFile file)
//{
//    if (file != null)
//    {
//        if (file.Length > 0)
//        {
//            var fileName = Path.GetFileName(file.FileName);
//            var fileExtension = Path.GetExtension(fileName);
//            var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
//            var objFile = new MediaFileModel()
//            {
//                FileName = newFileName,
//                FileType = fileExtension,
//                CreatedOn = DateTime.Now,
//            };

//            using (var target = new MemoryStream())
//            {
//                file.CopyTo(target);
//                objFile.FileData = target.ToArray();
//                target.Close();
//            }
//            _mediaFileServices.AddMediaFile(objFile);
//        }
//        return Ok();
//    }
//    return NoContent();
//}