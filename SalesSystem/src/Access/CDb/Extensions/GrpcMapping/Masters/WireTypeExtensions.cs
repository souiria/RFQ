namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class WireTypeExtensions
    {
        public static WireTypeGrpc FromEntity(this DbWireType entity)
        {

            WireTypeGrpc grpc = new WireTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbWireType ToEntity(this WireTypeGrpc grpc)
        {
            DbWireType entity = new DbWireType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
