using System.ComponentModel.DataAnnotations.Schema;
using CDb.Data.Model.Masters;
using CDb.Enums;

namespace CDb.Data.Model.Components
{
    public class DbTerminal :DbComponent
    {
        public Guid TerminalFamilyId 
        { get; set; }
        public DbTerminalFamily TerminalFamily 
        { get; set; }
        public Guid TerminalSizeId 
        { get; set; }
        public DbTerminalSize TerminalSize 
        { get; set; }
        public Guid WireTypeId 
        { get; set; }   
        public DbWireType WireType 
        { get; set; }
        public string CrimpingIssues 
        { get; set; }
        public DbWaterproofType WaterproofType 
        { get; set; }
        public MatingType MatingType 
        { get; set; }
        public string AdditionalInformation 
        { get; set; }
        public PlatingType PlatingType 
        { get; set; }

        public DbTerminal()
        {
            TerminalFamily = null!;
            TerminalFamilyId = Guid.Empty;
            TerminalSize = null!;
            TerminalSizeId = Guid.Empty;
            WireType = null!;
            WireTypeId = Guid.Empty;
            CrimpingIssues = string.Empty;
            WaterproofType = null!;
            MatingType = MatingType.Unknown;
            AdditionalInformation = string.Empty;
            PlatingType = PlatingType.None;
        }
    }
}
