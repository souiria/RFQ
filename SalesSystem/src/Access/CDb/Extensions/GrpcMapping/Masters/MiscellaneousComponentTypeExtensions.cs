namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class MiscellaneousComponentTypeExtensions
    {
        public static MiscellaneousComponentTypeGrpc FromEntity(this DbMiscellaneousComponentType entity)
        {

            MiscellaneousComponentTypeGrpc grpc = new MiscellaneousComponentTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbMiscellaneousComponentType ToEntity(this MiscellaneousComponentTypeGrpc grpc)
        {
            DbMiscellaneousComponentType entity = new DbMiscellaneousComponentType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
