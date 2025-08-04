namespace CDb.Extensions.GrpcMapping.Components
{
    public static class FuseExtensions
    {
        public static FuseGrpc FromEntity(this DbFuse entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            FuseGrpc grpc = new FuseGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.FuseTypeId = entity.FuseTypeId.ToString();
            grpc.Amperage = (double)entity.Amperage;
            grpc.Description = entity.Description;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static void ToEntity(this FuseGrpc grpc, DbFuse entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.FuseTypeId = Guid.Parse(grpc.FuseTypeId);
            entity.Amperage = grpc.Amperage.ToDecimal();
            entity.Description = grpc.Description;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
