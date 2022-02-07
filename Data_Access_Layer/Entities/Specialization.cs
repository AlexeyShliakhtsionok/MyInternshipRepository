using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data_Access_Layer.Entities
{
    public enum Specialization
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

