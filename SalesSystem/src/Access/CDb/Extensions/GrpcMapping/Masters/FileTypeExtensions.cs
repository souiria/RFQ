namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class FileTypeExtensions
    {
        public static FileTypeGrpc FromEntity(this DbFileType entity)
        {

            FileTypeGrpc grpc = new FileTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Name = entity.Name;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbFileType ToEntity(this FileTypeGrpc grpc)
        {
            DbFileType entity = new DbFileType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Name = grpc.Name;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
