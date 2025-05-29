using System.Diagnostics.CodeAnalysis;

namespace Master.Data.DTOs
{
    public class CustomerBusinessHierarchyDto
    {
        public string? CustomerBusinessGroupCode
        { get; set; }
        public string? CustomerBusinessGroupName
        { get; set; }
        public Guid? Id
        { get; set; }
        public string? SEWSEBusinessTeam
        { get; set; }
        public bool? IsActive
        { get; set; }
    }
}
