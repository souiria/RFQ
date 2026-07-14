namespace Emacs.Data.Model
{
    public class DbMaterialTypes : IAggregateRoot
    {
        public string? MaterialGroup
        { get; set; }
        public string? MaterialType
        { get; set; }
        public string? TypeDescription
        { get; set; }
    }
}
