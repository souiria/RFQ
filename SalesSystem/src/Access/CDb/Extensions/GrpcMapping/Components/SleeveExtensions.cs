namespace CDb.Extensions.GrpcMapping.Components
{
    public static class SleeveExtensions
    {
        public static SleeveGrpc FromDb(this DbSleeve entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            SleeveGrpc grpc = new SleeveGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Description = entity.Description;
            grpc.Diameter = (double)entity.Diameter;
            grpc.Length = (double)entity.Length;
            grpc.WaterproofTypeId = entity.WaterproofTypeId.ToString();
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static DbSleeve ToDb(this SleeveGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbSleeve entity = new DbSleeve();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.Diameter = grpc.Diameter.ToDecimal();
            entity.Length = grpc.Length.ToDecimal();
            entity.WaterproofTypeId = Guid.Parse(grpc.WaterproofTypeId);
            entity.Color = (ColorType)(grpc.Color ?? 0);
            return entity;
        }
    }
}
