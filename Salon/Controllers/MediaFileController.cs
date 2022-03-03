using Business_Logic_Layer.DBO.Mediafiles;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MediaFileController : ControllerBase
    {
        private readonly IMediaFileServices _mediaFileServices;
        private readonly IEmployeeServices _employeeServices;

        public MediaFileController(IMediaFileServices mediaFileServices, IEmployeeServices employeeServices)
        {
            _mediaFileServices = mediaFileServices;
            _employeeServices = employeeServices;
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
            MediafileViewModel imageToShow = _mediaFileServices.GetMediaFileById(id);
            var byteArray = imageToShow.FileData;
            var result = base.File(byteArray, "image/png");
            return result;
        }

        [HttpGet]
        [Route("GetProfilePhotoByEmployeeId")]
        public ActionResult GetProfilePhotoByEmployeeId(int id)
        {
            var employee = _employeeServices.GetEmployeeById(id);
            var profilePhpto = employee.MediaFiles.FirstOrDefault(p => p.IsProfilePhoto == true);
            if(profilePhpto != null)
            {
                var byteArray = profilePhpto.FileData;
                var result = base.File(byteArray, "image/png");
                return result;
            }
            return NoContent();
        }

        [HttpGet]
        [Route("GetAllMediaFiles")]
        public ActionResult GetAllMediaFiles(string type, int employeeId)
        {
            var employeesSelectList = _employeeServices.GetEmployeesSelectList();
            List<MediafileViewModel> allMediaFiles = _mediaFileServices.GetMediaFiles().ToList();
            List<FileContentResult> mediafiles = new List<FileContentResult>();

            if (employeeId != 0) {
                allMediaFiles = _employeeServices.GetEmployeeById(employeeId).MediaFiles.ToList();
            }
            
            if (type == "profile")
            {
                allMediaFiles = allMediaFiles.Where(b => b.IsProfilePhoto == true).ToList();
            }
            else if (type == "employeeGallery")
            {
                allMediaFiles = allMediaFiles.Where(b => b.IsEmployeePhoto).ToList();
            }
            else if(type == "promo")
            {
                allMediaFiles = allMediaFiles.Where(b => b.IsPromoPhoto == true).ToList();
            }

            if (allMediaFiles.Count() != 0)
            {
                for (int i = 0; i < allMediaFiles.Count(); i++)
                {
                    mediafiles.Add(base.File(allMediaFiles[i].FileData, "image/png"));
                }
            }
            return Ok(new { mediafiles, employeesSelectList });
        }

        [HttpPost, Route("UploadMediaFile")]
        public ActionResult UploadImageToDB(IFormFile file)
        {
                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var fileExtension = Path.GetExtension(fileName);
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                        var objFile = new MediafileViewModel()
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


        [HttpPost, Route("UploadProfilePhoto")]
        public ActionResult UploadProfileImageToDB([FromForm]IFormFile profilePhoto, int employeeId)
        {
            if (profilePhoto != null)
            {
                if (profilePhoto.Length > 0)
                {
                    var fileName = Path.GetFileName(profilePhoto.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                    var objFile = new MediafileViewModel()
                    {
                        FileName = newFileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now,
                    };

                    using (var target = new MemoryStream())
                    {
                        profilePhoto.CopyTo(target);
                        objFile.FileData = target.ToArray();
                        target.Close();
                    }

                    var employee = _employeeServices.GetEmployeeById(employeeId);
                    var isProfilePhoto = employee.MediaFiles.FirstOrDefault(m => m.IsProfilePhoto == true);

                    if(isProfilePhoto != null)
                    {
                        _mediaFileServices.UpdateProfilePhoto(objFile, employeeId);
                    }
                    else
                    {
                        _mediaFileServices.AddProfilePhoto(objFile, employeeId);
                    }
                }
                return Ok();
            }
            return NoContent();
        }
    }
}
