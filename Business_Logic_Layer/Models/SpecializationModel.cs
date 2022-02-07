using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Business_Logic_Layer.Models
{
    public enum SpecializationModel
    {
        [Description("Mans haircut")]
        MansHaircut = 0,
        [Description("Womens haircut")]
        WomensHaircut = 1,
        [Description("Childrens haircut")]
        ChildrensHaircut = 2,
        [Description("Nail master")]
        NailMaster = 3,
        [Description("Tatoo master")]
        TatooMaster = 4,
        [Description("Eyelashes master")]
        EyelashesMaster = 5,
    }
}
