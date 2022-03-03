using Business_Logic_Layer.DBO.MaterialManufacturers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IMaterialManufacturerServices
    {
        public IEnumerable<MaterialManufacturerViewModel> GetAllMaterialManufacturers();
        public MaterialManufacturerViewModel GetMaterialManufacturerById(int id);
        public void CreateMaterialManufacturer(MaterialManufacturerViewModel materialManufacturer);
        public void UpdateMaterialManufacturer();
        public void DeleteMaterialManufacturer(int id);
        public SelectList GetManufacturersSelectList();
    }
}
