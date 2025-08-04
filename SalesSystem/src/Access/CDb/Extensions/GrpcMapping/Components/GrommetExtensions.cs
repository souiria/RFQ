namespace CDb.Extensions.GrpcMapping.Components
{
    public static class GrommetExtensions
    {
        public static GrommetGrpc FromEntity(this DbGrommet entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            GrommetGrpc grpc = new GrommetGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Location = entity.Location;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static void ToEntity(this GrommetGrpc grpc, DbGrommet entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.Location = grpc.Location;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
