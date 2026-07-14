namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListClipTypeGrpc PopulateClipTypeInitData()
        {
            ListClipTypeGrpc clipTypeGrpcs = new ListClipTypeGrpc();
            ClipTypeGrpc doubleClip = new ClipTypeGrpc();
            doubleClip.Id = "CDD0D832-7ED0-4141-953C-2A1909DD5181";
            doubleClip.Code = "DOUBLE";
            doubleClip.Description = "Double";
            doubleClip.IsActive = true;

            ClipTypeGrpc ovalShapedClip = new ClipTypeGrpc();
            ovalShapedClip.Id = "4BE87CE2-2DF7-4286-8AF0-765828CE9248";
            ovalShapedClip.Code = "OVALSHAPED";
            ovalShapedClip.Description = "Oval-Shaped";
            ovalShapedClip.IsActive = true;

            ClipTypeGrpc roundShapedClip = new ClipTypeGrpc();
            roundShapedClip.Id = "33D0F1AB-2430-4A50-838E-6EEB431787E4";
            roundShapedClip.Code = "ROUNDSHAPED";
            roundShapedClip.Description = "Round-Shaped";
            roundShapedClip.IsActive = true;

            ClipTypeGrpc sptClip = new ClipTypeGrpc();
            sptClip.Id = "3CD8B591-A4D3-4591-8024-5A7262DBEF6A";
            sptClip.Code = "SPT";
            sptClip.Description = "SPT";
            sptClip.IsActive = true;

            ClipTypeGrpc inactiveClip = new ClipTypeGrpc();
            inactiveClip.Id = "AE91F78C-654D-47FF-BB66-7F1A7FD700CF";
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
