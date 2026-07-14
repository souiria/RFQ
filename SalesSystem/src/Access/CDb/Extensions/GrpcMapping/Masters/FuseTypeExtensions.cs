namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class FuseTypeExtensions
    {
        public static FuseTypeGrpc FromEntity(this DbFuseType entity)
        {

            FuseTypeGrpc grpc = new FuseTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbFuseType ToEntity(this FuseTypeGrpc grpc)
        {
            DbFuseType entity = new DbFuseType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
