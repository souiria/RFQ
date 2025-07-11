using CDb.Enums;

namespace CDb.Data.Model.Masters
{
    public class DbPartner
    {
        public Guid Id 
        { get; set; }
        public PartnerType PartnerType 
        { get; set; }
        public string Code
        { get; set; }
        public string Name 
        { get; set; }
        public string? Description 
        { get; set; }
        public Guid? ContactPersonId 
        { get; set; }
        public DbPerson? ContactPerson 
        { get; set; }
        public Guid? RespPersonId 
        { get; set; }
        public DbPerson? RespPerson 
        { get; set; }
        public ICollection<DbComponent> Components 
        { get; init; }
        public bool IsDeleted 
        { get; set; }

        public DbPartner()
        {
            Id = Guid.NewGuid();
            PartnerType = PartnerType.Supplier;
            Code = string.Empty;
            Name = string.Empty;

            Components = new HashSet<DbComponent>();
            IsDeleted = false;
        }
    }
}
