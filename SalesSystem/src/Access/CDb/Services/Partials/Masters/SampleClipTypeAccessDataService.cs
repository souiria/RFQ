namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListClipTypeGrpc PopulateClipTypeInitData()
        {
            ListClipTypeGrpc clipTypeGrpcs = new ListClipTypeGrpc();
            ClipTypeGrpc doubleClip = new ClipTypeGrpc();
            doubleClip.Id = "cdd0d832-7ed0-4141-953c-2a1909dd5181";
            doubleClip.Code = "DOUBLE";
            doubleClip.Description = "Double";
            doubleClip.IsActive = true;

            ClipTypeGrpc ovalShapedClip = new ClipTypeGrpc();
            ovalShapedClip.Id = "4be87ce2-2df7-4286-8af0-765828ce9248";
            ovalShapedClip.Code = "OVALSHAPED";
            ovalShapedClip.Description = "Oval-Shaped";
            ovalShapedClip.IsActive = true;

            ClipTypeGrpc roundShapedClip = new ClipTypeGrpc();
            roundShapedClip.Id = "33d0f1ab-2430-4a50-838e-6eeb431787e4";
            roundShapedClip.Code = "ROUNDSHAPED";
            roundShapedClip.Description = "Round-Shaped";
            roundShapedClip.IsActive = true;

            ClipTypeGrpc sptClip = new ClipTypeGrpc();
            sptClip.Id = "3cd8b591-a4d3-4591-8024-5a7262dbef6a";
            sptClip.Code = "SPT";
            sptClip.Description = "SPT";
            sptClip.IsActive = true;

            ClipTypeGrpc inactiveClip = new ClipTypeGrpc();
            inactiveClip.Id = "ae91f78c-654d-47ff-bb66-7f1a7fd700cf";
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
