namespace SFS.Data.Model
{
    public class DbProfile : IAggregateRoot
    {
        public int Id 
        { get; set; }
        public string? Profile
        { get; set; }
    }
}
