namespace Emacs.Data.Model
{
    public class DbColourCode : IAggregateRoot
    {
        public string? ClMk
        { get; set; }
        public string? ClCode
        { get; set; }
        public string? ColorName
        { get; set; }
        public int WireUnitsFlag
        { get; set; }
        public int PartUnitsFlag
        { get; set; }
    }
}
