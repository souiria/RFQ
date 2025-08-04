namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListCrimpingProcessTypeGrpc PopulateCrimpingProcessTypeInitData()
        {
            ListCrimpingProcessTypeGrpc crimpingProcessTypeGrpcs = new ListCrimpingProcessTypeGrpc();

            CrimpingProcessTypeGrpc unknown = new CrimpingProcessTypeGrpc();
            unknown.Id = "5c427cea-d05e-42b1-871e-6e2ed2a5ace9";
            unknown.Code = "Unknown";
            unknown.Description = "Unknown";
            unknown.IsActive = true;

            CrimpingProcessTypeGrpc tubular = new CrimpingProcessTypeGrpc();
            tubular.Id = "9c8b8ede-ad94-4664-b21c-0def2e3946cd";
            tubular.Code = "TubularBarrell";
            tubular.Description = "Tubular Barrell";
            tubular.IsActive = true;

            CrimpingProcessTypeGrpc usw = new CrimpingProcessTypeGrpc();
            usw.Id = "b3e1a548-bfa6-4cf1-9e73-3bd5d6de704e";
            usw.Code = "Usw";
            usw.Description = "Usw";
            usw.IsActive = true;

            CrimpingProcessTypeGrpc open = new CrimpingProcessTypeGrpc();
            open.Id = "f8975222-8fd4-4fde-b12b-4a7b28f0e8ec";
            open.Code = "OpenBarrell";
            open.Description = "Open Barrell";
            open.IsActive = true;

            CrimpingProcessTypeGrpc notAvailableCrimpingProcess = new CrimpingProcessTypeGrpc();
            notAvailableCrimpingProcess.Id = "f8975222-8fd4-4fde-b12b-4a7b28f0e8ec";
            notAvailableCrimpingProcess.Code = "OpenBarrell";
            notAvailableCrimpingProcess.Description = "Open Barrell";
            notAvailableCrimpingProcess.IsActive = false;

            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(unknown);
            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(tubular);
            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(usw);
            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(open);
            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(notAvailableCrimpingProcess);

            return crimpingProcessTypeGrpcs;
        }
    }
}
