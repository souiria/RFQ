namespace CDb.Extensions.GrpcMapping.Components
{
    public static class TerminalExtensions
    {
        public static TerminalGrpc FromDb(this DbTerminal entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            TerminalGrpc grpc = new TerminalGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.TerminalFamilyId = entity.TerminalFamilyId.ToString();
            grpc.TerminalSizeId = entity.TerminalSizeId.ToString();
            grpc.WireTypeId = entity.WireTypeId.ToString();
            grpc.CrimpingIssues = entity.CrimpingIssues;
            grpc.WaterproofTypeId = entity.WaterproofTypeId.ToString();
            grpc.MatingType = (int)entity.MatingType;
            grpc.AdditionalInformation = entity.AdditionalInformation;
            grpc.PlatingType = (int)entity.PlatingType;

            return grpc;
        }
        public static DbTerminal ToDb(this TerminalGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbTerminal entity = new DbTerminal();
            entity.Id = Guid.Parse(grpc.Id);
            entity.TerminalFamilyId = Guid.Parse(grpc.TerminalFamilyId);
            entity.TerminalSizeId = Guid.Parse(grpc.TerminalSizeId);
            entity.WireTypeId = Guid.Parse(grpc.WireTypeId);
            entity.CrimpingIssues = grpc.CrimpingIssues;
            entity.WaterproofTypeId = Guid.Parse(grpc.WaterproofTypeId);
            entity.MatingType = grpc.MatingType is null ? MatingType.Unknown : (MatingType)grpc.MatingType;
            entity.AdditionalInformation = grpc.AdditionalInformation;
            entity.PlatingType = (PlatingType)(grpc.PlatingType ?? 0);
            return entity;
        }
    }
}
