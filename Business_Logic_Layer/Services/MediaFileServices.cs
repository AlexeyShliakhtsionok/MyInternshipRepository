using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net.Mime;

namespace Business_Logic_Layer.Services
{
    public class MediaFileServices : IMediaFileServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public MediaFileServices(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public void DeleteMediaFile(int id)
        {
            var mediaFileToDelete = _UnitOfWork.MediaFile.GetById(id);
            _UnitOfWork.MediaFile.Delete(mediaFileToDelete);
            _UnitOfWork.Complete();
        }

        public MediaFileModel GetMediaFileById(int id)
        {
            var mediaFileEntity = _UnitOfWork.MediaFile.GetById(id);
            MediaFileModel mediaFileModel = AutoMappers<MediaFile, MediaFileModel>.Map(mediaFileEntity);
            return mediaFileModel;
        }


        public MediaFileModel GetProfilePhotoByEmployeeId(int id)
        {
            var employee = _UnitOfWork.Employee.GetAll().Include(m => m.MediaFiles).FirstOrDefault(e => e.EmployeeId == id);
            var mediaFile = employee.MediaFiles.FirstOrDefault(m => m.IsProfilePhoto == true);
            var mediaFileEntity = _UnitOfWork.MediaFile.GetById(id);
            MediaFileModel mediaFileModel = AutoMappers<MediaFile, MediaFileModel>.Map(mediaFileEntity);

                return mediaFileModel;
  
        }

        
        public IEnumerable<MediaFileModel> GetMediaFiles()
        {
            var mediaFiles = _UnitOfWork.MediaFile.GetAll();
            IEnumerable<MediaFileModel> mediaFileModel = AutoMappers<MediaFile, MediaFileModel>.MapIQueryable(mediaFiles);
            return mediaFileModel;
        }


        public void UpdateMediaFile()
        {
            throw new NotImplementedException();
        }

        public void UpdateProfilePhoto(MediaFileModel mediaFileModel, int id)
        {
            MediaFile mediaFileEntity = AutoMappers<MediaFileModel, MediaFile>.Map(mediaFileModel);
            mediaFileEntity.IsProfilePhoto = true;
            var employee = _UnitOfWork.Employee.GetById(id);
            var profilePhoto = employee.MediaFiles.FirstOrDefault(p => p.IsProfilePhoto == true);
            _UnitOfWork.MediaFile.Delete(profilePhoto);
            employee.MediaFiles.Add(mediaFileEntity);
            _UnitOfWork.Employee.Update(employee);
            _UnitOfWork.Complete();
        }

        public void AddMediaFile(MediaFileModel mediaFile)
        {
            MediaFile mediafile = AutoMappers<MediaFileModel, MediaFile>.Map(mediaFile);
            _UnitOfWork.MediaFile.Add(mediafile);
            _UnitOfWork.Complete();
        }
        
        public void AddProfilePhoto(MediaFileModel mediaFile, int id)
        {
            MediaFile mediafileEntity = AutoMappers<MediaFileModel, MediaFile>.Map(mediaFile);
            mediafileEntity.IsProfilePhoto = true;
            Employee employee = _UnitOfWork.Employee.GetById(id);
            employee.MediaFiles.Add(mediafileEntity);
            _UnitOfWork.Employee.Update(employee);
            _UnitOfWork.Complete();
        }
    }
}
