namespace Rfq.Data.Model
{
    public class DbDsiBranchInsulation : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public string? StartNode
        { get; set; }
        public string? EndNode
        { get; set; }
        public string? EndRoute
        { get; set; }
        public string? PieceCode
        { get; set; }
        public string? InsulationCode
        { get; set; }
        public double Diameter
        { get; set; }
        public Guid CircuitOptionId
        { get; set; }
        public string? InsulationNote
        { get; set; }
        public string? UserModule
        { get; set; }
        public string? AssignedModule
        { get; set; }
        public string? ModuleFrom
        { get; set; }
        public string? CalculationMethod
        { get; set; }
        public double ManualAmount
        { get; set; }
        public string? SplitValue
        { get; set; }
        public double JoinNumber
        { get; set; }
        public double AssemblyItemNumber
        { get; set; }
        public double Layer
        { get; set; }
        public string? InsulationType
        { get; set; }
        public string? PartNumber1
        { get; set; }
        public string? PartNumber2
        { get; set; }
        public string? PartNumber3
        { get; set; }
        public string? Colour
        { get; set; }
        public string? Type
        { get; set; }
        public string? Material
        { get; set; }
        public double WallThickness
        { get; set; }
        public double NumberOfTurns
        { get; set; }
        public double TurnsPerBreakout
        { get; set; }
        public double TurnsPerBranch
        { get; set; }
        public double DistanceBetweenItems
        { get; set; }
        public double LongestDistance
        { get; set; }
        public double DistanceFromConnector
        { get; set; }
        public string? TubeSelectionType
        { get; set; }
        public double TubeSelectionFactor
        { get; set; }
        public double Cutback
        { get; set; }
        public bool IsConvoluted
        { get; set; }
        public bool IsSlit
        { get; set; }
        public string? ModuleSpecificData
        { get; set; }
        public Guid HarnessId
        { get; set; }
        public DateTime CreatedDate
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public Guid CreatedBy
        { get; set; }
        public Guid ModifiedBy
        { get; set; }
    }
}
