namespace CDb.Extensions.GrpcMapping.Components
{
    public static class DiodeExtensions
    {
        public static DiodeGrpc FromEntity(this DbDiode entity)
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
        public static void ToEntity(this DiodeGrpc grpc, DbDiode entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.Amperage = grpc.Amperage.ToDecimal();
            entity.Description = grpc.Description;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
