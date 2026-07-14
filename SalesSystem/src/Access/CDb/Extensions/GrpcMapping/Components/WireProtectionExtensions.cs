namespace CDb.Extensions.GrpcMapping.Components
{
    public static class WireProtectionExtensions
    {
        public static WireProtectionGrpc FromEntity(this DbWireProtection entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            WireProtectionGrpc grpc = new WireProtectionGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.WireProtectionTypeId = entity.WireProtectionTypeId.ToString();
            grpc.Description = entity.Description;
            grpc.TapeWidth = (double)entity.TapeWidth;
            grpc.TubeDiameter = (double)entity.TubeDiameter;
            grpc.Specification = entity.Specification;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static void ToEntity(this WireProtectionGrpc grpc, DbWireProtection entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.WireProtectionTypeId = Guid.Parse(grpc.WireProtectionTypeId);
            entity.Description = grpc.Description;
            entity.TapeWidth = grpc.TapeWidth.ToDecimal();
            entity.TubeDiameter = grpc.TubeDiameter.ToDecimal();
            entity.Specification = grpc.Specification;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
