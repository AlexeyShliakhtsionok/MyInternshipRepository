using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IProfileServices
    {
        public IEnumerable<ProfileModel> GetProfiles();
        public ProfileModel GetProfileById(int id);
        public void CreateProfile(ProfileModel profile);
        public void UpdateProfile();
        public void DeleteProfile(int id);
    }
}
