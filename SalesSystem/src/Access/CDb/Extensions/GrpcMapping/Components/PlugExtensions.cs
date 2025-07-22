namespace CDb.Extensions.GrpcMapping.Components
{
    public static class PlugExtensions
    {
        public static PlugGrpc FromDb(this DbPlug entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            PlugGrpc grpc = new PlugGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Description = entity.Description;
            grpc.Diameter = (double)entity.Diameter;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static DbPlug ToDb(this PlugGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbPlug entity = new DbPlug();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.Diameter = grpc.Diameter.ToDecimal();
            entity.Color = (ColorType)(grpc.Color ?? 0);
            return entity;
        }
    }
}
