namespace CDb.Enums
{
    public enum ComponentType
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("CLIP")]
        Clip = 1,
        [Description("CONN")]
        Connector = 2,
        [Description("COV")]
        Cover = 3,
        [Description("EYE")]
        Eyelet = 4,
        [Description("FUSE")]
        Fuse = 5,
        [Description("HSG")]
        Housing = 6,
        [Description("TERM")]
        Terminal = 7,
        [Description("WIRE")]
        Wire = 8,
        [Description("CMPT")]
        MiscellaneousComponent = 9,
        [Description("REL")]
        Relay = 10,
        [Description("DIOD")]
        Diode = 11,
        [Description("GROM")]
        Grommet = 12,
        [Description("PLUG")]
        Plug = 13,
        [Description("CVG")]
        WireProtection = 14,
        [Description("SEAL")]
        Seal = 15,
        [Description("HSHS")]
        Sleeve = 16,
        [Description("PRT")]
        Shield = 17,
        [Description("SBAY")]
        SubAssembly = 18,
        [Description("SPT")]
        Support = 19,
        [Description("JCAB")]
        Cable = 20,
    }
}
