namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListFileTypeGrpc PopulateFileTypeInitData() 
        { 
            ListFileTypeGrpc fileTypeGrpcs = new ListFileTypeGrpc();

            FileTypeGrpc unknown = new FileTypeGrpc();
            unknown.Id = "B481C105-2C10-49F6-912F-5EDF771BAD1C";
            unknown.Name = "Unknown";
            unknown.Description = "Unknown";
            unknown.IsActive = true;

            FileTypeGrpc tubular = new FileTypeGrpc();
            tubular.Id = "5CA19CBF-24E2-4EBC-94C1-C02DA3BCF951";
            tubular.Name = "Tubular";
            tubular.Description = "Tubular";
            tubular.IsActive = true;

            FileTypeGrpc usw = new FileTypeGrpc();
            usw.Id = "41FFC842-7266-40A1-B710-2F8B2B48EA58";
            usw.Name = "Usw";
            usw.Description = "Usw";
            usw.IsActive = true;

            FileTypeGrpc open = new FileTypeGrpc();
            open.Id = "33D1DD29-1DA8-434B-A249-75F87607D73E";
            open.Name = "Open";
            open.Description = "Open";
            open.IsActive = true;

            fileTypeGrpcs.FileTypeGrpcs.Add(unknown);
            fileTypeGrpcs.FileTypeGrpcs.Add(tubular);
            fileTypeGrpcs.FileTypeGrpcs.Add(usw);
            fileTypeGrpcs.FileTypeGrpcs.Add(open);

            return fileTypeGrpcs;
        }
    }
}
