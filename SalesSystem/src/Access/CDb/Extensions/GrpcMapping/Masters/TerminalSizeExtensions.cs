namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class TerminalSizeExtensions
    {
        public static TerminalSizeGrpc FromEntity(this DbTerminalSize entity)
        {
            TerminalSizeGrpc grpc = new TerminalSizeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Name = entity.Name;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbTerminalSize ToEntity(this TerminalSizeGrpc grpc)
        {
            DbTerminalSize entity = new DbTerminalSize();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Name = grpc.Name;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
