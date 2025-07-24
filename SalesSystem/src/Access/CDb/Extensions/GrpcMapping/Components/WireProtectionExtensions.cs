namespace CDb.Extensions.GrpcMapping.Components
{
    public static class WireProtectionExtensions
    {
        public static WireProtectionGrpc FromDb(this DbWireProtection entity)
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
        public static DbWireProtection ToDb(this WireProtectionGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbWireProtection entity = new DbWireProtection();
            entity.Id = Guid.Parse(grpc.Id);
            entity.WireProtectionTypeId = Guid.Parse(grpc.WireProtectionTypeId);
            entity.Description = grpc.Description;
            entity.TapeWidth = grpc.TapeWidth.ToDecimal();
            entity.TubeDiameter = grpc.TubeDiameter.ToDecimal();
            entity.Specification = grpc.Specification;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);

            return entity;
        }
    }
}
