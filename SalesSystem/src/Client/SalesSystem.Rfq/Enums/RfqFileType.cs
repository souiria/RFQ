using System.ComponentModel;

namespace SalesSystem.Rfq.Enums
{
    public enum RfqFileType
    {
        [Description("Unknown")]
        UNK = 0,
        [Description("DSI")]
        DSI,
        [Description("Csv")]
        CSV,
        [Description("Xls")]
        XLS,
        [Description("Xml")]
        XML,
        [Description("Mtf")]
        MTF,
        [Description("txt")]
        TXT,
    }
}
