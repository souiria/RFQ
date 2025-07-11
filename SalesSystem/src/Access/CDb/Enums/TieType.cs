using System.ComponentModel;

namespace CDb.Enums
{
    public enum TieType
    {

        [Description("Unknown")]
        Unknown,
        [Description("BO")]
        BO,
        [Description("BS")]
        BS,
        [Description("DIAM")]
        DIAM,
        [Description("LENGTH")]
        LENGHT,
        [Description("METALLOPLASTIC")]
        METALLOPLASTIC,
        [Description("ON STUD")]
        ON_STUD,
        [Description("PLASTIC CLIP")]
        PLASTIC_CLIP,
        [Description("TO")]
        TO,
        [Description("SPT TUBE")]
        SPT_TUBE,
        [Description("METAL SHEET")]
        METAL_SHEET
    }
}