using Business_Logic_Layer.DBO.Materials;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IMaterialServices
    {
        public IEnumerable<MaterialsInformationViewModel> GetAllMaterials();
        public MaterialViewModel GetMaterialById(int id);
        public void CreateMaterial(MaterialViewModel material);
        public void UpdateMaterialAmount(int id, int amount);
        public void UpdateMaterial(MaterialViewModel material);
        public void DeleteMaterial(int id);
        public SelectList GetMaterialsSelectList();
    }
}
