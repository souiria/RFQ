namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListCoverTypeGrpc PopulateCoverTypeInitData()
        {
            ListCoverTypeGrpc coverTypeGrpcs = new ListCoverTypeGrpc();
            CoverTypeGrpc unknownCover = new CoverTypeGrpc();
            unknownCover.Id = "3a15c6ae-3b7f-4f55-b566-01cd29630901";
            unknownCover.Code = "Unknown";
            unknownCover.Description = "Unknown";
            unknownCover.IsActive = true;

            CoverTypeGrpc type0Cover = new CoverTypeGrpc();
            type0Cover.Id = "f0d1d4d1-a3ca-4275-a059-b8785df5a3c9";
            type0Cover.Code = "Type0";
            type0Cover.Description = "Type 0";
            type0Cover.IsActive = true;

            CoverTypeGrpc type1Cover = new CoverTypeGrpc();
            type1Cover.Id = "37c995eb-8556-4ff9-b2b9-a2bcd7de234b";
            type1Cover.Code = "Type1";
            type1Cover.Description = "Type 1";
            type1Cover.IsActive = true;

            CoverTypeGrpc type2Cover = new CoverTypeGrpc();
            type2Cover.Id = "e1f2f51a-eb67-4f54-a03a-dec367a28c0a";
            type2Cover.Code = "Type2";
            type2Cover.Description = "Type 2";
            type2Cover.IsActive = true;


            CoverTypeGrpc inactiveCover = new CoverTypeGrpc();
            inactiveCover.Id = "e1f2f51a-eb67-4f54-a03a-dec367a28c0a";
            inactiveCover.Code = "Type3";
            inactiveCover.Description = "Type 3";
            inactiveCover.IsActive = false;

            coverTypeGrpcs.CoverTypeGrpcs.Add(unknownCover);
            coverTypeGrpcs.CoverTypeGrpcs.Add(type0Cover);
            coverTypeGrpcs.CoverTypeGrpcs.Add(type1Cover);
            coverTypeGrpcs.CoverTypeGrpcs.Add(type2Cover);
            coverTypeGrpcs.CoverTypeGrpcs.Add(inactiveCover);

            return coverTypeGrpcs;
        }
    }
}
