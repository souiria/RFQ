namespace CDb.Enums;

public enum PlatingType
{
    [Description("SN")]
    SN, //tin - 125deg.
    [Description("SNAG")]
    SN_AG,  //tin - 85deg.
    [Description("AG")]
    AG,
    [Description("AU")]
    AU, //gold - 125deg.
    [Description("Not applicable")]
    NotApplicable, //not av.
    [Description("None")]
    None, //no color
    [Description("Undefined")]
    Undefined, //no color
    [Description("HI")]
    HI,
    [Description("CUZN")]
    CuZn,
    [Description("BUSBAR-2W-SN")]
    BUSBAR2WSN,
    [Description("BUSBAR-4W-SN")]
    BUSBAR4WSN
}
