namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListWireTypeGrpc PopulateSampleWireTypeInitData()
        {
            ListWireTypeGrpc wireTypeGrpcs = new ListWireTypeGrpc();

            WireTypeGrpc unknown = new WireTypeGrpc();
            unknown.Id = "A1B2C3D4-E5F6-4711-8910-111213141516";
            unknown.Code = "Unknown";
            unknown.Description = "Unknown";
            unknown.IsActive = true;

            WireTypeGrpc solid = new WireTypeGrpc();
            solid.Id = "B1C2D3E4-F5A6-4711-8910-121314151617";
            solid.Code = "Solid";
            solid.Description = "Solid";
            solid.IsActive = true;

            WireTypeGrpc stranded = new WireTypeGrpc();
            stranded.Id = "C1D2E3F4-A5B6-4711-8910-131415161718";
            stranded.Code = "Stranded";
            stranded.Description = "Stranded";
            stranded.IsActive = true;

            wireTypeGrpcs.WireTypeGrpcs.Add(unknown);
            wireTypeGrpcs.WireTypeGrpcs.Add(solid);
            wireTypeGrpcs.WireTypeGrpcs.Add(stranded);

            return wireTypeGrpcs;
        }
    }
}
