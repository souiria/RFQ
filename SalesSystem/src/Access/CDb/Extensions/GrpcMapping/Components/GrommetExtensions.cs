namespace CDb.Extensions.GrpcMapping.Components
{
    public static class GrommetExtensions
    {
        public static GrommetGrpc FromDb(this DbGrommet entity)
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
        public static DbGrommet ToDb(this GrommetGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbGrommet entity = new DbGrommet();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Location = grpc.Location;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
            return entity;
        }
    }
}
