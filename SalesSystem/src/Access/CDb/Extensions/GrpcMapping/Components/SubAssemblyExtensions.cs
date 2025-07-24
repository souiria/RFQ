namespace CDb.Extensions.GrpcMapping.Components
{
    public static class SubAssemblyExtensions
    {
        public static SubAssemblyGrpc FromDb(this DbSubAssembly entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            SubAssemblyGrpc grpc = new SubAssemblyGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Content = entity.Content;
            grpc.Function = entity.Function;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.TerminalFamilyId = entity.TerminalFamilyId.ToString();
            grpc.TerminalSizeId = entity.TerminalSizeId.ToString();
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static DbSubAssembly ToDb(this SubAssemblyGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbSubAssembly entity = new DbSubAssembly();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Content = grpc.Content;
            entity.Function = grpc.Function;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.TerminalFamilyId = string.IsNullOrEmpty(grpc.TerminalFamilyId) ? null : Guid.Parse(grpc.TerminalFamilyId);
            entity.TerminalSizeId = string.IsNullOrEmpty(grpc.TerminalSizeId) ? null : Guid.Parse(grpc.TerminalSizeId);
            entity.Color = (ColorType)(grpc.Color ?? 0);
            return entity;
        }
    }
}
