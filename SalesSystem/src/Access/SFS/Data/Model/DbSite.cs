namespace SFS.Data.Model
{
    public class DbSite : IAggregateRoot
    {
        public int Id 
        { get; set; }
        public string? Profile 
        { get; set; }
        public string? SiteCode
        { get; set; }
        public string? SiteName 
        { get; set; }
        public string? SiteActive 
        { get; set; }
        public DateTime UpdatedDate 
        { get; set; }
        public string? UpdatedBy 
        { get; set; }
    }
}
