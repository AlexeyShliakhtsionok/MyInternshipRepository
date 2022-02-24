using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IMediaFileServices
    {
        public IEnumerable<MediaFileModel> GetMediaFiles();
        public MediaFileModel GetMediaFileById(int id);
        public MediaFileModel GetProfilePhotoByEmployeeId(int id);
        public void AddMediaFile(MediaFileModel mediaFile);
        public void AddProfilePhoto(MediaFileModel mediaFile, int id);
        public void UpdateProfilePhoto(MediaFileModel mediaFile, int id);
        public void UpdateMediaFile();
        public void DeleteMediaFile(int id);


    }
}
