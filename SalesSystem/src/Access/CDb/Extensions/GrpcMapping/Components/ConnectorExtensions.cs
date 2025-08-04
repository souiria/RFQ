namespace CDb.Extensions.GrpcMapping.Components
{
    public static class ConnectorExtensions
    {
        public static ConnectorGrpc FromEntity(this DbConnector entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            ConnectorGrpc grpc = new ConnectorGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.WaterproofTypeId = entity.WaterproofTypeId.ToString();
            grpc.MatingType = (int)entity.MatingType;
            grpc.CavitySize = (int)entity.CavitySize;
            grpc.CavityCount = entity.CavityCount;
            grpc.IsHybrid = entity.IsHybrid;
            grpc.IsModule = entity.IsModule;
            grpc.TerminalFamilyId = entity.TerminalFamilyId.ToString();
            grpc.TerminalSizeId = entity.TerminalSizeId.ToString();
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.Color = (int)entity.Color;

            return grpc;
        }
        public static void ToEntity(this ConnectorGrpc grpc, DbConnector entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.WaterproofTypeId = string.IsNullOrEmpty(grpc.WaterproofTypeId) ? null : Guid.Parse(grpc.WaterproofTypeId);
            entity.MatingType = grpc.MatingType is null ? MatingType.Unknown : (MatingType)grpc.MatingType;
            entity.CavitySize = grpc.CavitySize.ToDecimal();
            entity.CavityCount = grpc.CavityCount ?? 1;
            entity.IsHybrid = grpc.IsHybrid ?? false;
            entity.IsModule = grpc.IsModule ?? false;
            entity.TerminalFamilyId = string.IsNullOrEmpty(grpc.TerminalFamilyId) ? null : Guid.Parse(grpc.TerminalFamilyId);
            entity.TerminalSizeId = string.IsNullOrEmpty(grpc.TerminalSizeId) ? null : Guid.Parse(grpc.TerminalSizeId);
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.Color = (ColorType)(grpc.Color ?? 0);
        }
    }
}
