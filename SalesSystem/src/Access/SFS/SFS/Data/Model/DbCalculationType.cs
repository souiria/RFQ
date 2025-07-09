
namespace SFS.Data.Model
{
    public class DbCalculationType : IAggregateRoot
    {
        public int? Id
        { get; set; }
        public string? DisplayMember 
        { get; set; }
    }
}
