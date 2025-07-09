

namespace SFS.Data.DTOs
{
    public class CustomerNonWorkingDaysDto
    {
        public string? Profile
        { get; set; }
        public int Year
        { get; set; }
        public string? DelPoint
        { get; set; }
        public DateTime NonWorkingDay
        { get; set; }
        public DateTime UpdatedDate
        { get; set; }
        public string? UpdatedBy
        { get; set; }
        public int State
        { get; set; }
    }
}
