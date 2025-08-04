namespace CDb.Extensions.GrpcMapping.Components
{
    public static class SupportExtensions
    {
        public static SupportGrpc FromEntity(this DbSupport entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            SupportGrpc grpc = new SupportGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Description = entity.Description;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static void ToEntity(this SupportGrpc grpc, DbSupport entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
