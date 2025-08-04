namespace CDb.Extensions.GrpcMapping.Components
{
    public static class WireExtensions
    {
        public static WireGrpc FromEntity(this DbWire entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            WireGrpc grpc = new WireGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.WireTypeId = entity.WireTypeId.ToString();
            grpc.WireSection = (double)entity.WireSection;
            grpc.WireCount = entity.WireCount;
            grpc.Flexibility = entity.Flexibility;
            grpc.InsulationThickness = (double)entity.InsulationThickness;
            grpc.BendingDiameter = (double)entity.BendingDiameter;
            grpc.Color = (int)entity.Color;
            grpc.PlatingType = (int)entity.PlatingType;

            return grpc;
        }
        public static void ToEntity(this WireGrpc grpc, DbWire entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.WireTypeId = Guid.Parse(grpc.WireTypeId);
            entity.WireSection = grpc.WireSection.ToDecimal();
            entity.WireCount = grpc.WireCount ?? 1;
            entity.Flexibility = grpc.Flexibility;
            entity.InsulationThickness = grpc.InsulationThickness.ToDecimal();
            entity.BendingDiameter = grpc.BendingDiameter.ToDecimal();
            entity.Color = (ColorType)(grpc.Color ?? 0);
            entity.PlatingType = (PlatingType)(grpc.PlatingType ?? 0);
        }
    }
}
