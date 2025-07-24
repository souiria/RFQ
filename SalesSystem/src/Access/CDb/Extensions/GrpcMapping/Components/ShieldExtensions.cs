namespace CDb.Extensions.GrpcMapping.Components
{
    public static class ShieldExtensions
    {
        public static ShieldGrpc FromDb(this DbShield entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            ShieldGrpc grpc = new ShieldGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Description = entity.Description;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static DbShield ToDb(this ShieldGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbShield entity = new DbShield();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
            return entity;
        }
    }
}
