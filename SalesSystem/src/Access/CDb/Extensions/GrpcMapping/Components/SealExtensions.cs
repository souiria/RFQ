namespace CDb.Extensions.GrpcMapping.Components
{
    public static class SealExtensions
    {
        public static SealGrpc FromEntity(this DbSeal entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            SealGrpc grpc = new SealGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Description = entity.Description;
            grpc.Diameter = (double)entity.Diameter;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static void ToEntity(this SealGrpc grpc, DbSeal entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.Diameter = grpc.Diameter.ToDecimal();
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
