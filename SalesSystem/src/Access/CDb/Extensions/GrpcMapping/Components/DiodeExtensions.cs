namespace CDb.Extensions.GrpcMapping.Components
{
    public static class DiodeExtensions
    {
        public static DiodeGrpc FromDb(this DbDiode entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            DiodeGrpc grpc = new DiodeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Amperage = (double)entity.Amperage;
            grpc.Description = entity.Description;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static DbDiode ToDb(this DiodeGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbDiode entity = new DbDiode();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Amperage = grpc.Amperage.ToDecimal();
            entity.Description = grpc.Description;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
            return entity;
        }
    }
}
