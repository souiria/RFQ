namespace CDb.Extensions.GrpcMapping.Components
{
    public static class MiscellaneousComponentExtensions
    {
        public static MiscellaneousComponentGrpc FromEntity(this DbMiscellaneousComponent entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            MiscellaneousComponentGrpc grpc = new MiscellaneousComponentGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.MiscellaneousComponentTypeId = entity.MiscellaneousComponentTypeId.ToString();
            grpc.Dimension = entity.Dimension;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static void ToEntity(this MiscellaneousComponentGrpc grpc, DbMiscellaneousComponent entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.MiscellaneousComponentTypeId = Guid.Parse(grpc.MiscellaneousComponentTypeId);
            entity.Dimension = grpc.Dimension;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
