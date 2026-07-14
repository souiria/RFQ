namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class WireProtectionTypeExtensions
    {
        public static WireProtectionTypeGrpc FromEntity(this DbWireProtectionType entity)
        {

            WireProtectionTypeGrpc grpc = new WireProtectionTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbWireProtectionType ToEntity(this WireProtectionTypeGrpc grpc)
        {
            DbWireProtectionType entity = new DbWireProtectionType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
