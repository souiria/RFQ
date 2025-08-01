namespace EDI.Data.Model
{
    public class DbEdiGlobalParameter : IAggregateRoot
    {
        public string? ParameterName
        { get; set; }
        public string? ParameterDescription
        { get; set; }
        public string? ParameterValue
        { get; set; }
    }
}
