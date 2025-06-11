namespace Emacs.Data.Model
{
    public class DbPartGroups : IAggregateRoot
    {
        public string? PartGroup
        { get; set; }
        public string? GroupDescription
        { get; set; }
    }
}
