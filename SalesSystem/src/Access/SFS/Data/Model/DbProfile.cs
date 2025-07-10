namespace SFS.Data.Model
{
    public class DbProfile : IAggregateRoot
    {
        public string? Id 
        { get; set; }
        public string? DisplayMember
        { get; set; }
    }
}
