using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface ISpecializationServices
    {
        public IEnumerable<SpecializationModel> GetAllSpecializations();
        public SpecializationModel GetSpecializationById(int id);
        public void CreateSpecialization(SpecializationModel specialization);
        public void UpdateSpecialization();
        public void DeleteSpecialization(int id);
    }
}
