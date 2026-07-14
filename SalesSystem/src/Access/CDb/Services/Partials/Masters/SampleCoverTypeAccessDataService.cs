namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListCoverTypeGrpc PopulateCoverTypeInitData()
        {
            ListCoverTypeGrpc coverTypeGrpcs = new ListCoverTypeGrpc();
            CoverTypeGrpc unknownCover = new CoverTypeGrpc();
            unknownCover.Id = "3A15C6AE-3B7F-4F55-B566-01CD29630901";
            unknownCover.Code = "Unknown";
            unknownCover.Description = "Unknown";
            unknownCover.IsActive = true;

            CoverTypeGrpc type0Cover = new CoverTypeGrpc();
            type0Cover.Id = "F0D1D4D1-A3CA-4275-A059-B8785DF5A3C9";
            type0Cover.Code = "Type0";
            type0Cover.Description = "Type 0";
            type0Cover.IsActive = true;

            CoverTypeGrpc type1Cover = new CoverTypeGrpc();
            type1Cover.Id = "37C995EB-8556-4FF9-B2B9-A2BCD7DE234B";
            type1Cover.Code = "Type1";
            type1Cover.Description = "Type 1";
            type1Cover.IsActive = true;

            CoverTypeGrpc type2Cover = new CoverTypeGrpc();
            type2Cover.Id = "E1F2F51A-EB67-4F54-A03A-DEC367A28C0A";
            type2Cover.Code = "Type2";
            type2Cover.Description = "Type 2";
            type2Cover.IsActive = true;

            CoverTypeGrpc inactiveCover = new CoverTypeGrpc();
            inactiveCover.Id = "E1F2F51A-EB67-4F54-A03A-DEC367A28C0A";
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
