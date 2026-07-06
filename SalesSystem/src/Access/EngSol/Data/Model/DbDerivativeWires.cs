namespace EngSol.Data.Model
{
    public class DbDerivativeWires : IAggregateRoot
    {
        public int? DerivativeId
        { get; set; }
        public string? EndA
        { get; set; }
        public string? EndB
        { get; set; }
        public string? WireType
        { get; set; }
        public string? WireSize
        { get; set; }
        public string? WireFlex
        { get; set; }
        public string? WireColour
        { get; set; }
        public double? WireLength
        { get; set; }
        public double? WDrgLength
        { get; set; }
        public double? WChgLength
        { get; set; }
        public string? WireGroupType
        { get; set; }
        public string? WireGroupSize
        { get; set; }
        public int? WireGroupNumber
        { get; set; }
        public string? TerminalNumberA
        { get; set; }
        public string? SealnumberA
        { get; set; }
        public string? AttPartNumber1A
        { get; set; }
        public string? AttPartNumber2A
        { get; set; }
        public double? StripLengthA
        { get; set; }
        public string? ConnectorNumberA
        { get; set; }
        public string? ConnectorNameA
        { get; set; }
        public int? CavityNumberA
        { get; set; }
        public string? DoubleCrimpA
        { get; set; }
        public string? TerminalNumberB
        { get; set; }
        public string? SealNumberB
        { get; set; }
        public string? AttPartNumber1B
        { get; set; }
        public string? AttPartNumber2B
        { get; set; }
        public double? StripLengthB
        { get; set; }
        public string? ConnectorNumberB
        { get; set; }
        public string? ConnectorNameB
        { get; set; }
        public int? CavityNumberB
        { get; set; }
        public string? DoubleCrimpB
        { get; set; }
        public string? SolderA
        { get; set; }
        public string? SolderB
        { get; set; }
        public string? WeldA
        { get; set; }
        public string? WeldB
        { get; set; }
        public double? WireLengthPlus
        { get; set; }
        public double? WireLengthMinus
        { get; set; }
        public string? WICFlag
        { get; set; }
        public decimal? UTurnLen
        { get; set; }
    }
}
