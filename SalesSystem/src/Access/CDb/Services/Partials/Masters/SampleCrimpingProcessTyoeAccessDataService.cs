namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListCrimpingProcessTypeGrpc PopulateCrimpingProcessTypeInitData()
        {
            ListCrimpingProcessTypeGrpc crimpingProcessTypeGrpcs = new ListCrimpingProcessTypeGrpc();

            CrimpingProcessTypeGrpc unknown = new CrimpingProcessTypeGrpc();
            unknown.Id = "5C427CEA-D05E-42B1-871E-6E2ED2A5ACE9";
            unknown.Code = "Unknown";
            unknown.Description = "Unknown";
            unknown.IsActive = true;

            CrimpingProcessTypeGrpc tubular = new CrimpingProcessTypeGrpc();
            tubular.Id = "9C8B8EDE-AD94-4664-B21C-0DEF2E3946CD";
            tubular.Code = "TubularBarrell";
            tubular.Description = "Tubular Barrell";
            tubular.IsActive = true;

            CrimpingProcessTypeGrpc usw = new CrimpingProcessTypeGrpc();
            usw.Id = "B3E1A548-BFA6-4CF1-9E73-3BD5D6DE704E";
            usw.Code = "Usw";
            usw.Description = "Usw";
            usw.IsActive = true;

            CrimpingProcessTypeGrpc open = new CrimpingProcessTypeGrpc();
            open.Id = "F8975222-8FD4-4FDE-B12B-4A7B28F0E8EC";
            open.Code = "OpenBarrell";
            open.Description = "Open Barrell";
            open.IsActive = true;

            CrimpingProcessTypeGrpc notAvailableCrimpingProcess = new CrimpingProcessTypeGrpc();
            notAvailableCrimpingProcess.Id = "F8975222-8FD4-4FDE-B12B-4A7B28F0E8EC";
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
