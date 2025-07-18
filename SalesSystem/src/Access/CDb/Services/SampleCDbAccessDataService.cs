namespace CDb.Services
{
    public static class SampleCDbAccessDataService
    {
        public static ListClipTypeGrpc PopulateClipTypeSampleData()
        {
            ListClipTypeGrpc clipTypeGrpcs = new ListClipTypeGrpc();
            ClipTypeGrpc doubleClip = new ClipTypeGrpc();
            doubleClip.Id = Guid.NewGuid().ToString();
            doubleClip.Code = "DOUBLE";
            doubleClip.Description = "Double";
            doubleClip.IsActive = true;

            ClipTypeGrpc ovalShapedClip = new ClipTypeGrpc();
            ovalShapedClip.Id = Guid.NewGuid().ToString();
            ovalShapedClip.Code = "OVALSHAPED";
            ovalShapedClip.Description = "Oval-Shaped";
            ovalShapedClip.IsActive = true;

            ClipTypeGrpc roundShapedClip = new ClipTypeGrpc();
            roundShapedClip.Id = Guid.NewGuid().ToString();
            roundShapedClip.Code = "ROUNDSHAPED";
            roundShapedClip.Description = "Round-Shaped";
            roundShapedClip.IsActive = true;

            ClipTypeGrpc sptClip = new ClipTypeGrpc();
            sptClip.Id = Guid.NewGuid().ToString();
            sptClip.Code = "SPT";
            sptClip.Description = "SPT";
            sptClip.IsActive = true;

            ClipTypeGrpc inactiveClip = new ClipTypeGrpc();
            inactiveClip.Id = Guid.NewGuid().ToString();
            inactiveClip.Code = "iCLIP";
            inactiveClip.Description = "Inactive Clip";
            inactiveClip.IsActive = false;

            clipTypeGrpcs.ClipTypeGrpcs.Add(doubleClip);
            clipTypeGrpcs.ClipTypeGrpcs.Add(ovalShapedClip);
            clipTypeGrpcs.ClipTypeGrpcs.Add(roundShapedClip);
            clipTypeGrpcs.ClipTypeGrpcs.Add(sptClip);
            clipTypeGrpcs.ClipTypeGrpcs.Add(inactiveClip);

            return clipTypeGrpcs;
        }
    }
}
