namespace CommercialService2.Api.Common.Base;

public class MasterDataEntityBase : EntityBase<Guid>
{
    public bool IsActive { get; set; }
}
