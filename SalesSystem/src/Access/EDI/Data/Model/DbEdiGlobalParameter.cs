namespace EDI.Data.Model
{
    public class DbEdiGlobalParameter : IAggregateRoot
    {
        public required string ParameterName
        { get; set; }
        public required string ParameterDescription
        { get; set; }
        public required string ParameterValue
        { get; set; }
    }
}
