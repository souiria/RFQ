namespace Rfq.Services
{
    public static class SampleRfqDataService
    {
        #region RfqDrawingPartNumber
        public static ListRfqDrawingPartNumbersGrpc PopulateRfqDrawingPartNumbersGrpc()
        {
            ListRfqDrawingPartNumbersGrpc listRfqDrawingPartNumbersGrpc = new ListRfqDrawingPartNumbersGrpc();
            for (int i = 0; i < 5; i++)
            {
                RfqDrawingPartNumbersGrpc rfqDrawingPartNumbersGrpc = new RfqDrawingPartNumbersGrpc();
                rfqDrawingPartNumbersGrpc.RowId = i;
                rfqDrawingPartNumbersGrpc.RfqId = i;
                rfqDrawingPartNumbersGrpc.OriginalPartNumber = $"OriginalPartNumber{i}";
                rfqDrawingPartNumbersGrpc.OriginalPartNumberPrice = 30;
                rfqDrawingPartNumbersGrpc.SwappedPartNumber = $"SwappedPartNumber{i}";
                rfqDrawingPartNumbersGrpc.SwappedPartNumberPrice = 35;
                rfqDrawingPartNumbersGrpc.PriceSource = $"PriceSource{i}";
                rfqDrawingPartNumbersGrpc.IsExactMatch = false;
                rfqDrawingPartNumbersGrpc.IsSwapped = true;
                rfqDrawingPartNumbersGrpc.Comments = $"Comments{i}";
                listRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Add(rfqDrawingPartNumbersGrpc);
            }

            RfqDrawingPartNumbersGrpc fixedrfqDrawingPartNumbersGrpc = new RfqDrawingPartNumbersGrpc();
            fixedrfqDrawingPartNumbersGrpc.RowId = 6;
            fixedrfqDrawingPartNumbersGrpc.RfqId = 6;
            fixedrfqDrawingPartNumbersGrpc.OriginalPartNumber = $"TestOriginalPartNumber";
            fixedrfqDrawingPartNumbersGrpc.OriginalPartNumberPrice = 10;
            fixedrfqDrawingPartNumbersGrpc.SwappedPartNumber = $"TestSwappedPartNumber";
            fixedrfqDrawingPartNumbersGrpc.SwappedPartNumberPrice = 20;
            fixedrfqDrawingPartNumbersGrpc.PriceSource = $"TestPriceSource";
            fixedrfqDrawingPartNumbersGrpc.IsExactMatch = false;
            fixedrfqDrawingPartNumbersGrpc.IsSwapped = true;
            fixedrfqDrawingPartNumbersGrpc.Comments = $"TestComments";
            listRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Add(fixedrfqDrawingPartNumbersGrpc);
            return listRfqDrawingPartNumbersGrpc;
        }
        #endregion

        #region RfqProject
        public static ListRfqProjectGrpc PopulateRfqProjectGrpc()
        {
            ListRfqProjectGrpc listRfqProjectGrpc = new ListRfqProjectGrpc();
            for (int i = 0; i < 5; i++)
            {
                RfqProjectGrpc rfqProjectGrpc = new RfqProjectGrpc();
                rfqProjectGrpc.RowId = i;
                rfqProjectGrpc.RfqNumber = $"RfqNumber{i}";
                rfqProjectGrpc.CustomerBusinessUnitGuid = $"CustomerBuisnessUnitGuid{i}";
                rfqProjectGrpc.ProjectGuid = $"ProjectGuid{i}";
                rfqProjectGrpc.RfqReasonId = i;
                rfqProjectGrpc.RfqResponseDeadline = DateTime.UtcNow.ToTimestamp();
                rfqProjectGrpc.CarModelGuid = $"CarModelGuid{i}";
                rfqProjectGrpc.VehicleVolume = i;
                listRfqProjectGrpc.RfqProjects.Add(rfqProjectGrpc);
            }

            RfqProjectGrpc fixedRfqProjectGrpc = new RfqProjectGrpc();
            fixedRfqProjectGrpc.RowId = 6;
            fixedRfqProjectGrpc.RfqNumber = $"TestRfqNumber";
            fixedRfqProjectGrpc.CustomerBusinessUnitGuid = $"TestCustomerBuisnessUnitGuid";
            fixedRfqProjectGrpc.ProjectGuid = $"TestProjectGuid";
            fixedRfqProjectGrpc.RfqReasonId = 6;
            fixedRfqProjectGrpc.RfqResponseDeadline = DateTime.UtcNow.ToTimestamp();
            fixedRfqProjectGrpc.CarModelGuid = $"TetstCarModelGuid";
            fixedRfqProjectGrpc.VehicleVolume = 6;
            listRfqProjectGrpc.RfqProjects.Add(fixedRfqProjectGrpc);
            return listRfqProjectGrpc;
        }
        #endregion

        #region RfqNotes
        public static ListRfqNotesGrpc PopulateRfqNotesGrpc()
        {
            ListRfqNotesGrpc listRfqNotesGrpc = new ListRfqNotesGrpc();
            for (int i = 0; i < 5; i++)
            {
                RfqNotesGrpc rfqNotesGrpc = new RfqNotesGrpc();
                rfqNotesGrpc.RowId = i;
                rfqNotesGrpc.RfqId = i;
                rfqNotesGrpc.Note = $"Note{i}";
                rfqNotesGrpc.UserGuid = $"UserGuid{i}";
                rfqNotesGrpc.LastModifiedOn = DateTime.UtcNow.ToTimestamp();
                listRfqNotesGrpc.RfqNotes.Add(rfqNotesGrpc);
            }

            RfqNotesGrpc fixedRfqNotesGrpc = new RfqNotesGrpc();
            fixedRfqNotesGrpc.RowId = 6;
            fixedRfqNotesGrpc.RfqId = 6;
            fixedRfqNotesGrpc.Note = $"TestNote";
            fixedRfqNotesGrpc.UserGuid = $"TestUserGuid";
            fixedRfqNotesGrpc.LastModifiedOn = DateTime.UtcNow.ToTimestamp();
            listRfqNotesGrpc.RfqNotes.Add(fixedRfqNotesGrpc);
            return listRfqNotesGrpc;
        }
        #endregion

        #region RfqReason
        public static ListRfqReasonGrpc PopulateRfqReasonGrpc()
        {
            ListRfqReasonGrpc listRfqReasonGrpc = new ListRfqReasonGrpc();
            for (int i = 0; i < 5; i++)
            {
                RfqReasonGrpc rfqReasonGrpc = new RfqReasonGrpc();
                rfqReasonGrpc.RowId = i;
                rfqReasonGrpc.ReasonTitle = $"ReasonTitle{i}";
                listRfqReasonGrpc.RfqReasons.Add(rfqReasonGrpc);
            }

            RfqReasonGrpc fixedRfqReasonGrpc = new RfqReasonGrpc();
            fixedRfqReasonGrpc.RowId = 6;
            fixedRfqReasonGrpc.ReasonTitle = $"TestReasonTitle";
            listRfqReasonGrpc.RfqReasons.Add(fixedRfqReasonGrpc);
            return listRfqReasonGrpc;
        }
        #endregion

        #region DsiBends
        public static ListDsiBendGrpc PopulateDsiBendGrpc()
        {
            ListDsiBendGrpc listDsiBendGrpc = new ListDsiBendGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiBendGrpc dsiBendGrpc = new DsiBendGrpc();
                dsiBendGrpc.RowId = i;
                dsiBendGrpc.BendId = Guid.NewGuid().ToString();
                dsiBendGrpc.Bend = $"Bend{i}";
                dsiBendGrpc.CreatedBy = Guid.NewGuid().ToString();
                dsiBendGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
                listDsiBendGrpc.DsiBends.Add(dsiBendGrpc);
            }

            DsiBendGrpc fixedDsiBendGrpc = new DsiBendGrpc();
            fixedDsiBendGrpc.RowId = 6;
            fixedDsiBendGrpc.BendId = Guid.NewGuid().ToString();
            fixedDsiBendGrpc.Bend = $"FixedBend";
            fixedDsiBendGrpc.CreatedBy = Guid.NewGuid().ToString();
            fixedDsiBendGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
            listDsiBendGrpc.DsiBends.Add(fixedDsiBendGrpc);
            return listDsiBendGrpc;
        }
        #endregion

        #region DsiBranchConfigurations
        public static ListDsiBranchConfigurationGrpc PopulateDsiBranchConfigurationGrpc()
        {
            ListDsiBranchConfigurationGrpc listDsiBranchConfigurationGrpc = new ListDsiBranchConfigurationGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiBranchConfigurationGrpc dsiBranchConfigurationGrpc = new DsiBranchConfigurationGrpc();
                dsiBranchConfigurationGrpc.RowId = i;
                dsiBranchConfigurationGrpc.BranchConfigurationId = Guid.NewGuid().ToString();
                dsiBranchConfigurationGrpc.StartNode = $"StartNode{i}";
                dsiBranchConfigurationGrpc.StartRoute = $"StartRoute{i}";
                dsiBranchConfigurationGrpc.StartCoordinates = $"StartCoordinates{i}";
                dsiBranchConfigurationGrpc.EndNode = $"EndNode{i}";
                dsiBranchConfigurationGrpc.EndRoute = $"EndRoute{i}";
                dsiBranchConfigurationGrpc.EndCoordinates = $"EndCoordinates{i}";
                dsiBranchConfigurationGrpc.Length = i;
                dsiBranchConfigurationGrpc.CircuitOptionId = Guid.NewGuid().ToString();
                dsiBranchConfigurationGrpc.BundleDiameter = i;
                dsiBranchConfigurationGrpc.UserModule = $"UserModule{i}";
                dsiBranchConfigurationGrpc.AssignedModule = $"AssignedModule{i}";
                dsiBranchConfigurationGrpc.ModuleFrom = $"ModuleFrom{i}";
                dsiBranchConfigurationGrpc.BendString = $"BendString{i}";
                dsiBranchConfigurationGrpc.HarnessId = Guid.NewGuid().ToString();
                dsiBranchConfigurationGrpc.CreatedBy = Guid.NewGuid().ToString();
                dsiBranchConfigurationGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
                listDsiBranchConfigurationGrpc.DsiBranchConfigurations.Add(dsiBranchConfigurationGrpc);
            }

            DsiBranchConfigurationGrpc fixedDsiBranchConfigurationGrpc = new DsiBranchConfigurationGrpc();
            fixedDsiBranchConfigurationGrpc.RowId = 6;
            fixedDsiBranchConfigurationGrpc.BranchConfigurationId = Guid.NewGuid().ToString();
            fixedDsiBranchConfigurationGrpc.StartNode = $"TestStartNode";
            fixedDsiBranchConfigurationGrpc.StartRoute = $"TestStartRoute";
            fixedDsiBranchConfigurationGrpc.StartCoordinates = $"TestStartCoordinates";
            fixedDsiBranchConfigurationGrpc.EndNode = $"TestEndNode";
            fixedDsiBranchConfigurationGrpc.EndRoute = $"TestEndRoute";
            fixedDsiBranchConfigurationGrpc.EndCoordinates = $"TestEndCoordinates";
            fixedDsiBranchConfigurationGrpc.Length = 6;
            fixedDsiBranchConfigurationGrpc.CircuitOptionId = Guid.NewGuid().ToString();
            fixedDsiBranchConfigurationGrpc.BundleDiameter = 6;
            fixedDsiBranchConfigurationGrpc.UserModule = $"TestUserModule";
            fixedDsiBranchConfigurationGrpc.AssignedModule = $"TestAssignedModule";
            fixedDsiBranchConfigurationGrpc.ModuleFrom = $"TestModuleFrom";
            fixedDsiBranchConfigurationGrpc.BendString = $"TestBendString";
            fixedDsiBranchConfigurationGrpc.HarnessId = Guid.NewGuid().ToString();
            fixedDsiBranchConfigurationGrpc.CreatedBy = Guid.NewGuid().ToString();
            fixedDsiBranchConfigurationGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
            listDsiBranchConfigurationGrpc.DsiBranchConfigurations.Add(fixedDsiBranchConfigurationGrpc);
            return listDsiBranchConfigurationGrpc;
        }
        #endregion

        #region DsiBranchConfigurationBendAssociations
        public static ListDsiBranchConfigurationBendAssociationGrpc PopulateDsiBranchConfigurationBendAssociationGrpc()
        {
            ListDsiBranchConfigurationBendAssociationGrpc listDsiBranchConfigurationBendAssociationGrpc = new ListDsiBranchConfigurationBendAssociationGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiBranchConfigurationBendAssociationGrpc dsiBranchConfigurationBendAssociationGrpc = new DsiBranchConfigurationBendAssociationGrpc();
                dsiBranchConfigurationBendAssociationGrpc.RowId = i;
                dsiBranchConfigurationBendAssociationGrpc.BendId = Guid.NewGuid().ToString();
                dsiBranchConfigurationBendAssociationGrpc.BranchConfigurationId = Guid.NewGuid().ToString();
                dsiBranchConfigurationBendAssociationGrpc.CreatedBy = Guid.NewGuid().ToString();
                dsiBranchConfigurationBendAssociationGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
                listDsiBranchConfigurationBendAssociationGrpc.DsiBranchConfigurationBendAssociations.Add(dsiBranchConfigurationBendAssociationGrpc);
            }

            DsiBranchConfigurationBendAssociationGrpc fixedDsiBranchConfigurationBendAssociationGrpc = new DsiBranchConfigurationBendAssociationGrpc();
            fixedDsiBranchConfigurationBendAssociationGrpc.RowId = 6;
            fixedDsiBranchConfigurationBendAssociationGrpc.BendId = "664c3151-c7fc-4e0e-971c-f1712a6342e1";
            fixedDsiBranchConfigurationBendAssociationGrpc.BranchConfigurationId = Guid.NewGuid().ToString();
            fixedDsiBranchConfigurationBendAssociationGrpc.CreatedBy = Guid.NewGuid().ToString();
            fixedDsiBranchConfigurationBendAssociationGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
            listDsiBranchConfigurationBendAssociationGrpc.DsiBranchConfigurationBendAssociations.Add(fixedDsiBranchConfigurationBendAssociationGrpc);
            return listDsiBranchConfigurationBendAssociationGrpc;
        }
        #endregion
    }
}
