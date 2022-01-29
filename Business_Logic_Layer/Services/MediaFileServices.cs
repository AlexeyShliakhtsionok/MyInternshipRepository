using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;
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
            MediaFileModel mediaFileModel = GenericAutoMapper<MediaFile, MediaFileModel>.Map(mediaFileEntity);
            return mediaFileModel;
        }

        public IEnumerable<MediaFileModel> GetMediaFiles()
        {
            var mediaFiles = _UnitOfWork.MediaFile.GetAll();
            IEnumerable<MediaFileModel> mediaFileModel = GenericAutoMapper<MediaFile, MediaFileModel>.MapEnumerable(mediaFiles);
            return mediaFileModel;
        }

        public void UpdateMediaFile()
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }

        public void AddMediaFile(MediaFileModel mediaFile)
        {
            MediaFile mediafile = GenericAutoMapper<MediaFileModel, MediaFile>.Map(mediaFile);
            _UnitOfWork.MediaFile.Add(mediafile);
            _UnitOfWork.Complete();
        }
    }
}
