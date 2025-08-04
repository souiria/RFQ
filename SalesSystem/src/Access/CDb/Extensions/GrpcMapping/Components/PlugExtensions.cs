namespace CDb.Extensions.GrpcMapping.Components
{
    public static class PlugExtensions
    {
        public static PlugGrpc FromEntity(this DbPlug entity)
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
        public static void ToEntity(this PlugGrpc grpc, DbPlug entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.Diameter = grpc.Diameter.ToDecimal();
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
