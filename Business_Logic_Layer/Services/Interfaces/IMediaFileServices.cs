using Business_Logic_Layer.DBO.Mediafiles;


namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IMediaFileServices
    {
        public IEnumerable<MediafileViewModel> GetMediaFiles();
        public MediafileViewModel GetMediaFileById(int id);
        public MediafileViewModel GetProfilePhotoByEmployeeId(int id);
        public void AddMediaFile(MediafileViewModel mediaFile);
        public void AddProfilePhoto(MediafileViewModel mediaFile, int id);
        public void UpdateProfilePhoto(MediafileViewModel mediaFile, int id);
        public void UpdateMediaFile();
        public void DeleteMediaFile(int id);


    }
}
