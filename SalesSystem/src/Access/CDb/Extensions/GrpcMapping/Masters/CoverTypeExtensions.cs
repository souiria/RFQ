namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class CoverTypeExtensions
    {
        public static CoverTypeGrpc FromEntity(this DbCoverType entity)
        {

            CoverTypeGrpc grpc = new CoverTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbCoverType ToEntity(this CoverTypeGrpc grpc)
        {
            DbCoverType entity = new DbCoverType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
