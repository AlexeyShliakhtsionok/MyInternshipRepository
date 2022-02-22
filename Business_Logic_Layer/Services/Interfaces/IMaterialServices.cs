﻿using Business_Logic_Layer.Models;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IMaterialServices
    {
        public IEnumerable<MaterialModel> GetAllMaterials();
        public MaterialModel GetMaterialById(int id);
        public void CreateMaterial(MaterialModel material);
        public void UpdateMaterial(MaterialModel material);
        public void DeleteMaterial(int id);
        public SelectList GetMaterialsSelectList(List<MaterialModel> list);
    }
}
