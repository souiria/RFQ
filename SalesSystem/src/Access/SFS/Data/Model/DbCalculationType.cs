
namespace SFS.Data.Model
{
    public class DbCalculationType : IAggregateRoot
    {
        public string? Id
        { get; set; }
        public string? DisplayMember 
        { get; set; }
    }
}
