namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class ClipTypeExtensions
    {
        public static ClipTypeGrpc FromEntity(this DbClipType entity)
        {

            ClipTypeGrpc grpc = new ClipTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbClipType ToEntity(this ClipTypeGrpc grpc)
        {
            DbClipType entity = new DbClipType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
