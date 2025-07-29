namespace CDb.Extensions.GrpcMapping.Components
{
    public static class SealExtensions
    {
        public static SealGrpc FromDb(this DbSeal entity)
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
        public static DbSeal ToDb(this SealGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbSeal entity = new DbSeal();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.Diameter = grpc.Diameter.ToDecimal();
            entity.Color = (ColorType)(grpc.Color ?? 0);
            return entity;
        }
    }
}
