namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class TerminalFamilyExtensions
    {
        public static TerminalFamilyGrpc FromEntity(this DbTerminalFamily entity)
        {
            TerminalFamilyGrpc grpc = new TerminalFamilyGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Name = entity.Name;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbTerminalFamily ToEntity(this TerminalFamilyGrpc grpc)
        {
            DbTerminalFamily entity = new DbTerminalFamily();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Name = grpc.Name;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
