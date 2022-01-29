﻿using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialServices _materialServices;

        public MaterialController(IMaterialServices materialServices)
        {
            _materialServices = materialServices;
        }
    }
}