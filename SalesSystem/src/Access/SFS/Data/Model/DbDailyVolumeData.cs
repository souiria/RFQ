
namespace SFS.Data.Model
{
    public class DbDailyVolumeData : IAggregateRoot
    {
        public int Id
        { get; set; }
        public string? Profile
        { get; set; }
        public string? ModelCode
        { get; set; }
        public int Volume 
        { get; set; }
        public DateTime VolDate 
        { get; set; }
        public DateTime UpdatedDate
        { get; set; }
        public string? UpdatedBy
        { get; set; }
    }
}
