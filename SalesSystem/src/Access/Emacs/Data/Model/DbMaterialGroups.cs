namespace Emacs.Data.Model
{
    public class DbMaterialGroups : IAggregateRoot
    {
        public string? MaterialGroup
        { get; set; }
        public string? GroupDescription
        { get; set; }
    }
}
