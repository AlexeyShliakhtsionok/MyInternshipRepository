using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IMaterialManufacturerServices
    {
        public IEnumerable<MaterialManufacturerModel> GetAllMaterialManufacturers();
        public MaterialManufacturerModel GetMaterialManufacturerById(int id);
        public void CreateMaterialManufacturer(MaterialManufacturerModel materialManufacturer);
        public void UpdateMaterialManufacturer();
        public void DeleteMaterialManufacturer(int id);
        public SelectList GetManufacturersSelectList(List<MaterialManufacturerModel> list);
    }
}
