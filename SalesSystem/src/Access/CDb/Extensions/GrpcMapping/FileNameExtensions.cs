namespace CDb.Extensions.GrpcMapping
{
    public static class FileNameExtensions
    {
        public static FileNameGrpc FromEntity(this DbFileName entity)
        {

            FileNameGrpc grpc = new FileNameGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.FileTypeId = entity.FileTypeId.ToString();
            grpc.Name = entity.Name;
            grpc.Description = entity.Description;
            return grpc;
        }
        public static DbFileName ToEntity(this FileNameGrpc grpc)
        {
            DbFileName entity = new DbFileName();
            entity.Id = Guid.Parse(grpc.Id);
            entity.FileTypeId = Guid.Parse(grpc.FileTypeId);
            entity.Name = grpc.Name;
            entity.Description = grpc.Description;
            return entity;
        }
    }
}
