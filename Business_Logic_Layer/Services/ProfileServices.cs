
using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Business_Logic_Layer.Utilities;
using Data_Access_Layer.Entities;
using Data_Access_Layer.RepositoryWithUOW;

namespace Business_Logic_Layer.Services
{
    public class ProfileServices : IProfileServices
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ProfileServices(IUnitOfWork UnitOfWork )
        {
            _UnitOfWork = UnitOfWork;
        }

        public void CreateProfile(ProfileModel profile)
        {
            ProFile profileEntity = GenericAutoMapper<ProfileModel, ProFile>.Map(profile);
            _UnitOfWork.Profile.Add(profileEntity);
            _UnitOfWork.Complete();
        }

        public void DeleteProfile(int id)
        {
            var profileToDelete = _UnitOfWork.Profile.GetById(id);
            _UnitOfWork.Profile.Delete(profileToDelete);
            _UnitOfWork.Complete();
        }

        public ProfileModel GetProfileById(int id)
        {
            var profile = _UnitOfWork.Profile.GetById(id);
            ProfileModel profileModel = GenericAutoMapper<ProFile, ProfileModel>.Map(profile);
            return profileModel;
        }

        public IEnumerable<ProfileModel> GetProfiles()
        {
            var profiles = _UnitOfWork.Profile.GetAll();
            IEnumerable<ProfileModel> profileModels = GenericAutoMapper<ProFile, ProfileModel>.MapEnumerable(profiles);
            return profileModels;
        }

        public void UpdateProfile()
        {
            _UnitOfWork.Complete();
            throw new NotImplementedException();
        }

    }
}
