namespace CDb.Extensions.GrpcMapping.Components
{
    public static class RelayExtensions
    {
        public static RelayGrpc FromEntity(this DbRelay entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            RelayGrpc grpc = new RelayGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Amperage = (double)entity.Amperage;
            grpc.Description = entity.Description;
            grpc.Specification = entity.Specification;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static void ToEntity(this RelayGrpc grpc, DbRelay entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.Amperage = grpc.Amperage.ToDecimal();
            entity.Description = grpc.Description;
            entity.Specification = grpc.Specification;
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
