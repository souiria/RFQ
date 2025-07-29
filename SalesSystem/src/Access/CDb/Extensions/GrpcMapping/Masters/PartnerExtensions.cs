namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class PartnerExtensions
    {
        public static PartnerGrpc FromEntity(this DbPartner entity)
        {

            PartnerGrpc grpc = new PartnerGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.PartnerType = (int)entity.PartnerType;
            grpc.Code = entity.Code;
            grpc.Name = entity.Name;
            grpc.Description = entity.Description;
            grpc.ContactPersonId = entity.ContactPersonId?.ToString();
            grpc.SupervisorPersonId = entity.SupervisorPersonId?.ToString();
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbPartner ToEntity(this PartnerGrpc grpc)
        {
            DbPartner entity = new DbPartner();
            entity.Id = Guid.Parse(grpc.Id);
            entity.PartnerType = grpc.PartnerType is null ? PartnerType.Unknown : (PartnerType)grpc.PartnerType;
            entity.Code = grpc.Code;
            entity.Name = grpc.Name;
            entity.Description = grpc.Description;
            entity.ContactPersonId = grpc.ContactPersonId != null ? Guid.Parse(grpc.ContactPersonId) : (Guid?)null;
            entity.SupervisorPersonId = grpc.SupervisorPersonId != null ? Guid.Parse(grpc.SupervisorPersonId) : (Guid?)null;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
