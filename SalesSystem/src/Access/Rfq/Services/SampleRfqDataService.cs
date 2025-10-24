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

        #region DsiBranchInsulations
        public static ListDsiBranchInsulationGrpc PopulateDsiBranchInsulationGrpc()
        {
            ListDsiBranchInsulationGrpc listDsiBranchInsulationGrpc = new ListDsiBranchInsulationGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiBranchInsulationGrpc dsiBranchInsulationGrpc = new DsiBranchInsulationGrpc();
                dsiBranchInsulationGrpc.RowId = i;
                dsiBranchInsulationGrpc.StartNode = "StartNode" + i;
                dsiBranchInsulationGrpc.EndNode = "EndNode" + i;
                dsiBranchInsulationGrpc.EndRoute = "EndRoute" + i;
                dsiBranchInsulationGrpc.PieceCode = "PieceCode" + i;
                dsiBranchInsulationGrpc.InsulationCode = "InsulationCode" + i;
                dsiBranchInsulationGrpc.Diameter = i;
                dsiBranchInsulationGrpc.CircuitOptionId = Guid.NewGuid().ToString();
                dsiBranchInsulationGrpc.InsulationNote = "InsulationNote" + i;
                dsiBranchInsulationGrpc.UserModule = "UserModule" + i;
                dsiBranchInsulationGrpc.AssignedModule = "AssignedModule" + i;
                dsiBranchInsulationGrpc.ModuleFrom = "ModuleFrom" + i;
                dsiBranchInsulationGrpc.CalculationMethod = "CalculationMethod" + i;
                dsiBranchInsulationGrpc.ManualAmount = i;
                dsiBranchInsulationGrpc.SplitValue = "SplitValue" + i;
                dsiBranchInsulationGrpc.JoinNumber = i;
                dsiBranchInsulationGrpc.AssemblyItemNumber = i;
                dsiBranchInsulationGrpc.Layer = i;
                dsiBranchInsulationGrpc.InsulationType = "InsulationType" + i;
                dsiBranchInsulationGrpc.PartNumber1 = "PartNumber1" + i;
                dsiBranchInsulationGrpc.PartNumber2 = "PartNumber2" + i;
                dsiBranchInsulationGrpc.PartNumber3 = "PartNumber3" + i;
                dsiBranchInsulationGrpc.Colour = "Colour" + i;
                dsiBranchInsulationGrpc.Type = "Type" + i;
                dsiBranchInsulationGrpc.Material = "Material" + i;
                dsiBranchInsulationGrpc.Material = "Material" + i;
                dsiBranchInsulationGrpc.WallThickness = i;
                dsiBranchInsulationGrpc.NumberOfTurns = i;
                dsiBranchInsulationGrpc.TurnsPerBreakout = i;
                dsiBranchInsulationGrpc.TurnsPerBranch = i;
                dsiBranchInsulationGrpc.DistanceBetweenItems = i;
                dsiBranchInsulationGrpc.LongestDistance = i;
                dsiBranchInsulationGrpc.DistanceFromConnector = i;
                dsiBranchInsulationGrpc.TubeSelectionType = "TubeSelectionType" + i;
                dsiBranchInsulationGrpc.TubeSelectionFactor = i;
                dsiBranchInsulationGrpc.Cutback = i;
                dsiBranchInsulationGrpc.IsConvoluted = false;
                dsiBranchInsulationGrpc.IsSlit = false;
                dsiBranchInsulationGrpc.ModuleSpecificData = "ModuleSpecificData" + i;
                dsiBranchInsulationGrpc.HarnessId = Guid.NewGuid().ToString();
                dsiBranchInsulationGrpc.CreatedBy = Guid.NewGuid().ToString();
                dsiBranchInsulationGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
                listDsiBranchInsulationGrpc.DsiBranchInsulations.Add(dsiBranchInsulationGrpc);
            }

            DsiBranchInsulationGrpc fixedDsiBranchInsulationGrpc = new DsiBranchInsulationGrpc();
            fixedDsiBranchInsulationGrpc.RowId = 6;
            fixedDsiBranchInsulationGrpc.StartNode = "FixedStartNode";
            fixedDsiBranchInsulationGrpc.EndNode = "FixedEndNode";
            fixedDsiBranchInsulationGrpc.EndRoute = "FixedEndRoute";
            fixedDsiBranchInsulationGrpc.PieceCode = "FixedPieceCode";
            fixedDsiBranchInsulationGrpc.InsulationCode = "FixedInsulationCode";
            fixedDsiBranchInsulationGrpc.Diameter = 1;
            fixedDsiBranchInsulationGrpc.CircuitOptionId = Guid.NewGuid().ToString();
            fixedDsiBranchInsulationGrpc.InsulationNote = "FixedInsulationNote";
            fixedDsiBranchInsulationGrpc.UserModule = "FixedUserModule";
            fixedDsiBranchInsulationGrpc.AssignedModule = "FixedAssignedModule";
            fixedDsiBranchInsulationGrpc.ModuleFrom = "FixedModuleFrom";
            fixedDsiBranchInsulationGrpc.CalculationMethod = "FixedCalculationMethod";
            fixedDsiBranchInsulationGrpc.ManualAmount = 1;
            fixedDsiBranchInsulationGrpc.SplitValue = "FixedSplitValue";
            fixedDsiBranchInsulationGrpc.JoinNumber = 1;
            fixedDsiBranchInsulationGrpc.AssemblyItemNumber = 1;
            fixedDsiBranchInsulationGrpc.Layer = 1;
            fixedDsiBranchInsulationGrpc.InsulationType = "InsulationType";
            fixedDsiBranchInsulationGrpc.PartNumber1 = "FixedPartNumber1";
            fixedDsiBranchInsulationGrpc.PartNumber2 = "FixedPartNumber2";
            fixedDsiBranchInsulationGrpc.PartNumber3 = "FixedPartNumber3";
            fixedDsiBranchInsulationGrpc.Colour = "FixedColour";
            fixedDsiBranchInsulationGrpc.Type = "FixedType";
            fixedDsiBranchInsulationGrpc.Material = "FixedMaterial";
            fixedDsiBranchInsulationGrpc.WallThickness = 1;
            fixedDsiBranchInsulationGrpc.NumberOfTurns = 1;
            fixedDsiBranchInsulationGrpc.TurnsPerBreakout = 1;
            fixedDsiBranchInsulationGrpc.TurnsPerBranch = 1;
            fixedDsiBranchInsulationGrpc.DistanceBetweenItems = 1;
            fixedDsiBranchInsulationGrpc.LongestDistance = 1;
            fixedDsiBranchInsulationGrpc.DistanceFromConnector = 1;
            fixedDsiBranchInsulationGrpc.TubeSelectionType = "FixedTubeSelectionType";
            fixedDsiBranchInsulationGrpc.TubeSelectionFactor = 1;
            fixedDsiBranchInsulationGrpc.Cutback = 1;
            fixedDsiBranchInsulationGrpc.IsConvoluted = false;
            fixedDsiBranchInsulationGrpc.IsSlit = false;
            fixedDsiBranchInsulationGrpc.ModuleSpecificData = "FixedModuleSpecificData";
            fixedDsiBranchInsulationGrpc.HarnessId = Guid.NewGuid().ToString();
            fixedDsiBranchInsulationGrpc.CreatedBy = Guid.NewGuid().ToString();
            fixedDsiBranchInsulationGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
            listDsiBranchInsulationGrpc.DsiBranchInsulations.Add(fixedDsiBranchInsulationGrpc);
            return listDsiBranchInsulationGrpc;
        }
        #endregion

        #region DsiBranchInsulationThroughNodes
        public static ListDsiBranchInsulationThroughNodeGrpc PopulateDsiBranchInsulationThroughNodeGrpc()
        {
            ListDsiBranchInsulationThroughNodeGrpc listDsiBranchInsulationThroughNodeGrpc = new ListDsiBranchInsulationThroughNodeGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiBranchInsulationThroughNodeGrpc dsiBranchInsulationThroughNodeGrpc = new DsiBranchInsulationThroughNodeGrpc();
                dsiBranchInsulationThroughNodeGrpc.RowId = i;
                dsiBranchInsulationThroughNodeGrpc.PieceCode = "PieceCode" + i;
                dsiBranchInsulationThroughNodeGrpc.ThroughOrder = i;
                dsiBranchInsulationThroughNodeGrpc.ThroughNode = "ThroughNode" + i;
                dsiBranchInsulationThroughNodeGrpc.ThroughRoute = "ThroughRoute" + i;
                dsiBranchInsulationThroughNodeGrpc.IsThroughFlag = false;
                dsiBranchInsulationThroughNodeGrpc.HarnessId = Guid.NewGuid().ToString();
                dsiBranchInsulationThroughNodeGrpc.CreatedBy = Guid.NewGuid().ToString();
                dsiBranchInsulationThroughNodeGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
                listDsiBranchInsulationThroughNodeGrpc.DsiBranchInsulationThroughNodes.Add(dsiBranchInsulationThroughNodeGrpc);
            }

            DsiBranchInsulationThroughNodeGrpc fixedDsiBranchInsulationThroughNodeGrpc = new DsiBranchInsulationThroughNodeGrpc();
            fixedDsiBranchInsulationThroughNodeGrpc.RowId = 6;
            fixedDsiBranchInsulationThroughNodeGrpc.PieceCode = "FixedPieceCode";
            fixedDsiBranchInsulationThroughNodeGrpc.ThroughOrder = 1;
            fixedDsiBranchInsulationThroughNodeGrpc.ThroughNode = "FixedThroughNode";
            fixedDsiBranchInsulationThroughNodeGrpc.ThroughRoute = "FixedThroughRoute";
            fixedDsiBranchInsulationThroughNodeGrpc.IsThroughFlag = false;
            fixedDsiBranchInsulationThroughNodeGrpc.HarnessId = Guid.NewGuid().ToString();
            fixedDsiBranchInsulationThroughNodeGrpc.CreatedBy = Guid.NewGuid().ToString();
            fixedDsiBranchInsulationThroughNodeGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
            listDsiBranchInsulationThroughNodeGrpc.DsiBranchInsulationThroughNodes.Add(fixedDsiBranchInsulationThroughNodeGrpc);
            return listDsiBranchInsulationThroughNodeGrpc;
        }
        #endregion

        #region DsiCavityMappings
        public static ListDsiCavityMappingGrpc PopulateDsiCavityMappingGrpc()
        {
            ListDsiCavityMappingGrpc listDsiCavityMappingGrpc = new ListDsiCavityMappingGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiCavityMappingGrpc dsiCavityMappingGrpc = new DsiCavityMappingGrpc();
                dsiCavityMappingGrpc.RowId = i;
                dsiCavityMappingGrpc.CavityMappingId = Guid.NewGuid().ToString();
                dsiCavityMappingGrpc.CavityMapping = $"CavityMapping{i}";
                dsiCavityMappingGrpc.CreatedBy = Guid.NewGuid().ToString();
                dsiCavityMappingGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
                listDsiCavityMappingGrpc.DsiCavityMappingGrpcs.Add(dsiCavityMappingGrpc);
            }

            DsiCavityMappingGrpc fixedDsiCavityMappingGrpc = new DsiCavityMappingGrpc();
            fixedDsiCavityMappingGrpc.RowId = 6;
            fixedDsiCavityMappingGrpc.CavityMappingId = Guid.NewGuid().ToString();
            fixedDsiCavityMappingGrpc.CavityMapping = $"FixedCavityMapping";
            fixedDsiCavityMappingGrpc.CreatedBy = Guid.NewGuid().ToString();
            fixedDsiCavityMappingGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
            listDsiCavityMappingGrpc.DsiCavityMappingGrpcs.Add(fixedDsiCavityMappingGrpc);
            return listDsiCavityMappingGrpc;
        }
        #endregion

        #region DsiCentreStrip
        public static ListDsiCentreStripGrpc PopulateDsiCentreStripGrpc()
        {
            ListDsiCentreStripGrpc list = new ListDsiCentreStripGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiCentreStripGrpc item = new DsiCentreStripGrpc();
                item.RowId = i;
                item.NodeName = $"Node{i}";
                item.Route = $"Route{i}";
                item.WireName = $"Wire{i}";
                item.StripLength = 10.5 + i;
                item.LengthChangeType = "Increase";
                item.LengthChangeValue = 1.5 * i;
                item.Option = $"Option{i}";
                item.ThroughOrder = i + 0.1;
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiCentreStripGrpcs.Add(item);
            }

            DsiCentreStripGrpc fixedItem = new DsiCentreStripGrpc();
            fixedItem.RowId = 6;
            fixedItem.NodeName = "FixedNode";
            fixedItem.Route = "FixedRoute";
            fixedItem.WireName = "FixedWire";
            fixedItem.StripLength = 99.9;
            fixedItem.LengthChangeType = "FixedChange";
            fixedItem.LengthChangeValue = 9.9;
            fixedItem.Option = "FixedOption";
            fixedItem.ThroughOrder = 6.6;
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiCentreStripGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiCircuitOptions
        public static ListDsiCircuitOptionGrpc PopulateDsiCircuitOptionGrpc()
        {
            ListDsiCircuitOptionGrpc listDsiCircuitOptionGrpc = new ListDsiCircuitOptionGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiCircuitOptionGrpc dsiCircuitOptionGrpc = new DsiCircuitOptionGrpc();
                dsiCircuitOptionGrpc.RowId = i;
                dsiCircuitOptionGrpc.CircuitOptionId = Guid.NewGuid().ToString();
                dsiCircuitOptionGrpc.OptionName = $"CircuitOption{i}";
                dsiCircuitOptionGrpc.CreatedBy = Guid.NewGuid().ToString();
                dsiCircuitOptionGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
                listDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.Add(dsiCircuitOptionGrpc);
            }

            DsiCircuitOptionGrpc fixedDsiCircuitOptionGrpc = new DsiCircuitOptionGrpc();
            fixedDsiCircuitOptionGrpc.RowId = 6;
            fixedDsiCircuitOptionGrpc.CircuitOptionId = Guid.NewGuid().ToString();
            fixedDsiCircuitOptionGrpc.OptionName = $"FixedCircuitOption";
            fixedDsiCircuitOptionGrpc.CreatedBy = Guid.NewGuid().ToString();
            fixedDsiCircuitOptionGrpc.CreatedDate = DateTime.UtcNow.ToTimestamp();
            listDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.Add(fixedDsiCircuitOptionGrpc);

            return listDsiCircuitOptionGrpc;
        }
        #endregion

        #region DsiComponent
        public static ListDsiComponentGrpc PopulateDsiComponentGrpc()
        {
            ListDsiComponentGrpc list = new ListDsiComponentGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiComponentGrpc item = new DsiComponentGrpc();
                item.RowId = i;
                item.NodeName = $"Node{i}";
                item.CavityName = $"Cavity{i}";
                item.WireName = $"Wire{i}";
                item.SequenceNumber = $"Seq{i}";
                item.ComponentTypeCode1 = $"CTC1-{i}";
                item.ComponentOption = $"Option{i}";
                item.ServiceFunction = $"Function{i}";
                item.Route = $"Route{i}";
                item.PartNumber1 = $"PN1-{i}";
                item.PartNumber2 = $"PN2-{i}";
                item.PartNumber3 = $"PN3-{i}";
                item.Quantity = 1.0 + i;
                item.CrossSectionalArea = 0.5 + i;
                item.IsSelectTerminal = i % 2 == 0;
                item.IsSeal = i % 2 != 0;
                item.IsPlugged = i % 3 == 0;
                item.BlockNumber = $"Block{i}";
                item.TerminationMethod = $"TermMethod{i}";
                item.MaterialCode = $"MatCode{i}";
                item.ComponentTypeCode2 = $"CTC2-{i}";
                item.InsulationType = $"Insulation{i}";
                item.UserModule = $"UserMod{i}";
                item.AssignedModule = $"AssignedMod{i}";
                item.ModuleFrom = $"ModFrom{i}";
                item.SplitValue = $"Split{i}";
                item.Datum = $"Datum{i}";
                item.AssemblyItemNumber = 1000 + i;
                item.ColourCode = $"Color{i}";
                item.NumberOfCavities = 2.0 + i;
                item.IsBackshell = i % 2 == 0;
                item.WireOption = $"WireOpt{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiComponentGrpcs.Add(item);
            }

            DsiComponentGrpc fixedItem = new DsiComponentGrpc();
            fixedItem.RowId = 6;
            fixedItem.NodeName = "FixedNode";
            fixedItem.CavityName = "FixedCavity";
            fixedItem.WireName = "FixedWire";
            fixedItem.SequenceNumber = "FixedSeq";
            fixedItem.ComponentTypeCode1 = "FixedCTC1";
            fixedItem.ComponentOption = "FixedOption";
            fixedItem.ServiceFunction = "FixedFunction";
            fixedItem.Route = "FixedRoute";
            fixedItem.PartNumber1 = "FixedPN1";
            fixedItem.PartNumber2 = "FixedPN2";
            fixedItem.PartNumber3 = "FixedPN3";
            fixedItem.Quantity = 9.99;
            fixedItem.CrossSectionalArea = 3.33;
            fixedItem.IsSelectTerminal = true;
            fixedItem.IsSeal = true;
            fixedItem.IsPlugged = false;
            fixedItem.BlockNumber = "FixedBlock";
            fixedItem.TerminationMethod = "FixedTermMethod";
            fixedItem.MaterialCode = "FixedMatCode";
            fixedItem.ComponentTypeCode2 = "FixedCTC2";
            fixedItem.InsulationType = "FixedInsulation";
            fixedItem.UserModule = "FixedUserMod";
            fixedItem.AssignedModule = "FixedAssignedMod";
            fixedItem.ModuleFrom = "FixedModFrom";
            fixedItem.SplitValue = "FixedSplit";
            fixedItem.Datum = "FixedDatum";
            fixedItem.AssemblyItemNumber = 9999;
            fixedItem.ColourCode = "FixedColor";
            fixedItem.NumberOfCavities = 6.6;
            fixedItem.IsBackshell = true;
            fixedItem.WireOption = "FixedWireOpt";
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiComponentGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiCompositeDetail
        public static ListDsiCompositeDetailGrpc PopulateDsiCompositeDetailGrpc()
        {
            ListDsiCompositeDetailGrpc list = new ListDsiCompositeDetailGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiCompositeDetailGrpc item = new DsiCompositeDetailGrpc();
                item.RowId = i;
                item.CompositeDetailId = Guid.NewGuid().ToString();
                item.HarnessName1 = $"HarnessA{i}";
                item.SimilarHarnessName1 = $"SimilarA{i}";
                item.HarnessIssue1 = $"IssueA{i}";
                item.SimilarHarnessIssue1 = $"SimilarIssueA{i}";
                item.HarnessDate1 = DateTime.UtcNow.AddDays(-i).ToTimestamp();
                item.HarnessName2 = $"HarnessB{i}";
                item.SimilarHarnessName2 = $"SimilarB{i}";
                item.HarnessIssue2 = $"IssueB{i}";
                item.SimilarHarnessIssue2 = $"SimilarIssueB{i}";
                item.HarnessDate2 = DateTime.UtcNow.AddDays(-i - 1).ToTimestamp();
                item.Customer = $"Customer{i}";
                item.Site = $"Site{i}";
                item.Range = $"Range{i}";
                item.BoardLength = 100 + i;
                item.BoardWidth = 50 + i;
                item.Datum = $"Datum{i}";
                item.UserField1 = $"UF1-{i}";
                item.UserField2 = $"UF2-{i}";
                item.UserField3 = $"UF3-{i}";
                item.UserField4 = $"UF4-{i}";
                item.UserField5 = $"UF5-{i}";
                item.Checker = $"Checker{i}";
                item.Inputter = $"Inputter{i}";
                item.DraftedBy = $"DraftedBy{i}";
                item.PreparedBy = $"PreparedBy{i}";
                item.Type = $"Type{i}";
                item.Title = $"Title{i}";
                item.EngineSize = $"Engine{i}";
                item.ManufacturingCell = $"Cell{i}";
                item.Trim = $"Trim{i}";
                item.HandDrive = i % 2 == 0 ? "Left" : "Right";
                item.TubeAddOnType = $"TubeType{i}";
                item.TubeAddOnFactor = 1.5 + i;
                item.IsManualTerminal = i % 2 == 0;
                item.IsAllConnectorsSealed = i % 2 != 0;
                item.AlphaCode = $"Alpha{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CircuitOption = $"CircuitOpt{i}";
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiCompositeDetailGrpcs.Add(item);
            }

            DsiCompositeDetailGrpc fixedItem = new DsiCompositeDetailGrpc();
            fixedItem.RowId = 6;
            fixedItem.CompositeDetailId = Guid.NewGuid().ToString();
            fixedItem.HarnessName1 = "FixedHarnessA";
            fixedItem.SimilarHarnessName1 = "FixedSimilarA";
            fixedItem.HarnessIssue1 = "FixedIssueA";
            fixedItem.SimilarHarnessIssue1 = "FixedSimilarIssueA";
            fixedItem.HarnessDate1 = DateTime.UtcNow.AddDays(-10).ToTimestamp();
            fixedItem.HarnessName2 = "FixedHarnessB";
            fixedItem.SimilarHarnessName2 = "FixedSimilarB";
            fixedItem.HarnessIssue2 = "FixedIssueB";
            fixedItem.SimilarHarnessIssue2 = "FixedSimilarIssueB";
            fixedItem.HarnessDate2 = DateTime.UtcNow.AddDays(-11).ToTimestamp();
            fixedItem.Customer = "FixedCustomer";
            fixedItem.Site = "FixedSite";
            fixedItem.Range = "FixedRange";
            fixedItem.BoardLength = 999.9;
            fixedItem.BoardWidth = 888.8;
            fixedItem.Datum = "FixedDatum";
            fixedItem.UserField1 = "FixedUF1";
            fixedItem.UserField2 = "FixedUF2";
            fixedItem.UserField3 = "FixedUF3";
            fixedItem.UserField4 = "FixedUF4";
            fixedItem.UserField5 = "FixedUF5";
            fixedItem.Checker = "FixedChecker";
            fixedItem.Inputter = "FixedInputter";
            fixedItem.DraftedBy = "FixedDraftedBy";
            fixedItem.PreparedBy = "FixedPreparedBy";
            fixedItem.Type = "FixedType";
            fixedItem.Title = "FixedTitle";
            fixedItem.EngineSize = "FixedEngine";
            fixedItem.ManufacturingCell = "FixedCell";
            fixedItem.Trim = "FixedTrim";
            fixedItem.HandDrive = "Left";
            fixedItem.TubeAddOnType = "FixedTubeType";
            fixedItem.TubeAddOnFactor = 9.99;
            fixedItem.IsManualTerminal = true;
            fixedItem.IsAllConnectorsSealed = true;
            fixedItem.AlphaCode = "FixedAlpha";
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CircuitOption = "FixedCircuitOpt";
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiCompositeDetailGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation
        public static ListDsiCompositeDetailCircuitOptionAssociationGrpc PopulateDsiCompositeDetailCircuitOptionAssociationGrpc()
        {
            ListDsiCompositeDetailCircuitOptionAssociationGrpc list = new ListDsiCompositeDetailCircuitOptionAssociationGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiCompositeDetailCircuitOptionAssociationGrpc item = new DsiCompositeDetailCircuitOptionAssociationGrpc();
                item.RowId = i;
                item.CompositeDetailId = Guid.NewGuid().ToString();
                item.CircuitOptionId = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiCompositeDetailCircuitOptionAssociationGrpcs.Add(item);
            }

            DsiCompositeDetailCircuitOptionAssociationGrpc fixedItem = new DsiCompositeDetailCircuitOptionAssociationGrpc();
            fixedItem.RowId = 6;
            fixedItem.CompositeDetailId = Guid.NewGuid().ToString();
            fixedItem.CircuitOptionId = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiCompositeDetailCircuitOptionAssociationGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiCompositeOption
        public static ListDsiCompositeOptionGrpc PopulateDsiCompositeOptionGrpc()
        {
            ListDsiCompositeOptionGrpc list = new ListDsiCompositeOptionGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiCompositeOptionGrpc item = new DsiCompositeOptionGrpc();
                item.RowId = i;
                item.CompositeOptionId = Guid.NewGuid().ToString();
                item.OptionName = $"CompositeOption{i}";
                item.Description = $"Description for option {i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiCompositeOptionGrpcs.Add(item);
            }

            DsiCompositeOptionGrpc fixedItem = new DsiCompositeOptionGrpc();
            fixedItem.RowId = 6;
            fixedItem.CompositeOptionId = Guid.NewGuid().ToString();
            fixedItem.OptionName = "FixedCompositeOption";
            fixedItem.Description = "Fixed description for composite option";
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiCompositeOptionGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiHarness
        public static ListDsiHarnessGrpc PopulateDsiHarnessGrpc()
        {
            ListDsiHarnessGrpc list = new ListDsiHarnessGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiHarnessGrpc item = new DsiHarnessGrpc();
                item.RowId = i;
                item.HarnessId = Guid.NewGuid().ToString();
                item.HarnessName1 = $"HarnessA{i}";
                item.SimilarHarnessName1 = $"SimilarA{i}";
                item.HarnessIssue1 = $"IssueA{i}";
                item.SimilarHarnessIssue1 = $"SimilarIssueA{i}";
                item.HarnessDate1 = DateTime.UtcNow.AddDays(-i).ToTimestamp();
                item.HarnessName2 = $"HarnessB{i}";
                item.SimilarHarnessName2 = $"SimilarB{i}";
                item.HarnessIssue2 = $"IssueB{i}";
                item.SimilarHarnessIssue2 = $"SimilarIssueB{i}";
                item.HarnessDate2 = DateTime.UtcNow.AddDays(-i - 1).ToTimestamp();
                item.FileVersion = 1.0 + i;
                item.Customer = $"Customer{i}";
                item.Site = $"Site{i}";
                item.Range = $"Range{i}";
                item.BoardLength = 100 + i;
                item.BoardWidth = 50 + i;
                item.Datum = $"Datum{i}";
                item.UserField1 = $"UF1-{i}";
                item.UserField2 = $"UF2-{i}";
                item.UserField3 = $"UF3-{i}";
                item.UserField4 = $"UF4-{i}";
                item.UserField5 = $"UF5-{i}";
                item.Checker = $"Checker{i}";
                item.Inputter = $"Inputter{i}";
                item.DraftedBy = $"DraftedBy{i}";
                item.PreparedBy = $"PreparedBy{i}";
                item.Type = $"Type{i}";
                item.Title = $"Title{i}";
                item.EngineSize = $"Engine{i}";
                item.ManufacturingCell = $"Cell{i}";
                item.Trim = $"Trim{i}";
                item.HandDrive = i % 2 == 0 ? "Left" : "Right";
                item.TubeAddOnType = $"TubeType{i}";
                item.TubeAddOnFactor = 1.5 + i;
                item.IsManualTerminal = i % 2 == 0;
                item.IsAllConnectorsSealed = i % 2 != 0;
                item.DatumNode = $"DatumNode{i}";
                item.DatumRoute = $"DatumRoute{i}";
                item.IsModule = i % 2 == 0;
                item.AlphaCode = $"Alpha{i}";
                item.IsPitchTableUsed = i % 2 != 0;
                item.AdditionalComments = $"Comment{i}";
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiHarnessGrpcs.Add(item);
            }

            DsiHarnessGrpc fixedItem = new DsiHarnessGrpc();
            fixedItem.RowId = 6;
            fixedItem.HarnessId = Guid.NewGuid().ToString();
            fixedItem.HarnessName1 = "FixedHarnessA";
            fixedItem.SimilarHarnessName1 = "FixedSimilarA";
            fixedItem.HarnessIssue1 = "FixedIssueA";
            fixedItem.SimilarHarnessIssue1 = "FixedSimilarIssueA";
            fixedItem.HarnessDate1 = DateTime.UtcNow.AddDays(-10).ToTimestamp();
            fixedItem.HarnessName2 = "FixedHarnessB";
            fixedItem.SimilarHarnessName2 = "FixedSimilarB";
            fixedItem.HarnessIssue2 = "FixedIssueB";
            fixedItem.SimilarHarnessIssue2 = "FixedSimilarIssueB";
            fixedItem.HarnessDate2 = DateTime.UtcNow.AddDays(-11).ToTimestamp();
            fixedItem.FileVersion = 9.99;
            fixedItem.Customer = "FixedCustomer";
            fixedItem.Site = "FixedSite";
            fixedItem.Range = "FixedRange";
            fixedItem.BoardLength = 999.9;
            fixedItem.BoardWidth = 888.8;
            fixedItem.Datum = "FixedDatum";
            fixedItem.UserField1 = "FixedUF1";
            fixedItem.UserField2 = "FixedUF2";
            fixedItem.UserField3 = "FixedUF3";
            fixedItem.UserField4 = "FixedUF4";
            fixedItem.UserField5 = "FixedUF5";
            fixedItem.Checker = "FixedChecker";
            fixedItem.Inputter = "FixedInputter";
            fixedItem.DraftedBy = "FixedDraftedBy";
            fixedItem.PreparedBy = "FixedPreparedBy";
            fixedItem.Type = "FixedType";
            fixedItem.Title = "FixedTitle";
            fixedItem.EngineSize = "FixedEngine";
            fixedItem.ManufacturingCell = "FixedCell";
            fixedItem.Trim = "FixedTrim";
            fixedItem.HandDrive = "Left";
            fixedItem.TubeAddOnType = "FixedTubeType";
            fixedItem.TubeAddOnFactor = 9.99;
            fixedItem.IsManualTerminal = true;
            fixedItem.IsAllConnectorsSealed = true;
            fixedItem.DatumNode = "FixedDatumNode";
            fixedItem.DatumRoute = "FixedDatumRoute";
            fixedItem.IsModule = true;
            fixedItem.AlphaCode = "FixedAlpha";
            fixedItem.IsPitchTableUsed = true;
            fixedItem.AdditionalComments = "FixedComment";
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiHarnessGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiHarnessScope
        public static ListDsiHarnessScopeGrpc PopulateDsiHarnessScopeGrpc()
        {
            ListDsiHarnessScopeGrpc list = new ListDsiHarnessScopeGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiHarnessScopeGrpc item = new DsiHarnessScopeGrpc();
                item.RowId = i;
                item.HarnessScopeId = Guid.NewGuid().ToString();
                item.HarnessName1 = $"HarnessA{i}";
                item.HarnessIssue1 = $"IssueA{i}";
                item.HarnessName2 = $"HarnessB{i}";
                item.HarnessIssue2 = $"IssueB{i}";
                item.ScopeCategory = $"Category{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiHarnessScopeGrpcs.Add(item);
            }

            DsiHarnessScopeGrpc fixedItem = new DsiHarnessScopeGrpc();
            fixedItem.RowId = 6;
            fixedItem.HarnessScopeId = Guid.NewGuid().ToString();
            fixedItem.HarnessName1 = "FixedHarnessA";
            fixedItem.HarnessIssue1 = "FixedIssueA";
            fixedItem.HarnessName2 = "FixedHarnessB";
            fixedItem.HarnessIssue2 = "FixedIssueB";
            fixedItem.ScopeCategory = "FixedCategory";
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiHarnessScopeGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiHarnessScopeScopeAssociation
        public static ListDsiHarnessScopeScopeAssociationGrpc PopulateDsiHarnessScopeScopeAssociationGrpc()
        {
            ListDsiHarnessScopeScopeAssociationGrpc list = new ListDsiHarnessScopeScopeAssociationGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiHarnessScopeScopeAssociationGrpc item = new DsiHarnessScopeScopeAssociationGrpc();
                item.RowId = i;
                item.HarnessScopeID = Guid.NewGuid().ToString();
                item.ScopeID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiHarnessScopeScopeAssociationGrpcs.Add(item);
            }

            DsiHarnessScopeScopeAssociationGrpc fixedItem = new DsiHarnessScopeScopeAssociationGrpc();
            fixedItem.RowId = 6;
            fixedItem.HarnessScopeID = Guid.NewGuid().ToString();
            fixedItem.ScopeID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiHarnessScopeScopeAssociationGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiManualBomQuantity
        public static ListDsiManualBomQuantityGrpc PopulateDsiManualBomQuantityGrpc()
        {
            ListDsiManualBomQuantityGrpc list = new ListDsiManualBomQuantityGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiManualBomQuantityGrpc item = new DsiManualBomQuantityGrpc();
                item.RowId = i;
                item.SplitValue = $"Split{i}";
                item.ModuleCode = $"Module{i}";
                item.Percentage = 10.0 + i;
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiManualBomQuantityGrpcs.Add(item);
            }

            DsiManualBomQuantityGrpc fixedItem = new DsiManualBomQuantityGrpc();
            fixedItem.RowId = 6;
            fixedItem.SplitValue = "FixedSplit";
            fixedItem.ModuleCode = "FixedModule";
            fixedItem.Percentage = 99.9;
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiManualBomQuantityGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiMidWireComponent
        public static ListDsiMidWireComponentGrpc PopulateDsiMidWireComponentGrpc()
        {
            ListDsiMidWireComponentGrpc list = new ListDsiMidWireComponentGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiMidWireComponentGrpc item = new DsiMidWireComponentGrpc();
                item.RowId = i;
                item.NodeName = $"Node{i}";
                item.Route = $"Route{i}";
                item.WireName = $"Wire{i}";
                item.Option = $"Option{i}";
                item.MidWireOption = $"MidWireOpt{i}";
                item.Cavity = $"Cavity{i}";
                item.ThroughOrder = i + 0.5;
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiMidWireComponentGrpcs.Add(item);
            }

            DsiMidWireComponentGrpc fixedItem = new DsiMidWireComponentGrpc();
            fixedItem.RowId = 6;
            fixedItem.NodeName = "FixedNode";
            fixedItem.Route = "FixedRoute";
            fixedItem.WireName = "FixedWire";
            fixedItem.Option = "FixedOption";
            fixedItem.MidWireOption = "FixedMidWireOpt";
            fixedItem.Cavity = "FixedCavity";
            fixedItem.ThroughOrder = 6.6;
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiMidWireComponentGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiModuleChildDetail
        public static ListDsiModuleChildDetailGrpc PopulateDsiModuleChildDetailGrpc()
        {
            ListDsiModuleChildDetailGrpc list = new ListDsiModuleChildDetailGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiModuleChildDetailGrpc item = new DsiModuleChildDetailGrpc();
                item.RowId = i;
                item.ModuleCode = $"Module{i}";
                item.IsCoreModule = i % 2 == 0;
                item.HarnessName1 = $"HarnessA{i}";
                item.SimilarHarnessName1 = $"SimilarA{i}";
                item.HarnessIssue1 = $"IssueA{i}";
                item.SimilarHarnessIssue1 = $"SimilarIssueA{i}";
                item.HarnessDate1 = DateTime.UtcNow.AddDays(-i).ToTimestamp();
                item.HarnessName2 = $"HarnessB{i}";
                item.SimilarHarnessName2 = $"SimilarB{i}";
                item.HarnessIssue2 = $"IssueB{i}";
                item.SimilarHarnessIssue2 = $"SimilarIssueB{i}";
                item.HarnessDate2 = DateTime.UtcNow.AddDays(-i - 1).ToTimestamp();
                item.Customer = $"Customer{i}";
                item.Site = $"Site{i}";
                item.Range = $"Range{i}";
                item.BoardLength = 100 + i;
                item.BoardWidth = 50 + i;
                item.Datum = $"Datum{i}";
                item.UserField1 = $"UF1-{i}";
                item.UserField2 = $"UF2-{i}";
                item.UserField3 = $"UF3-{i}";
                item.UserField4 = $"UF4-{i}";
                item.UserField5 = $"UF5-{i}";
                item.Checker = $"Checker{i}";
                item.Inputter = $"Inputter{i}";
                item.DraftedBy = $"DraftedBy{i}";
                item.PreparedBy = $"PreparedBy{i}";
                item.Type = $"Type{i}";
                item.Title = $"Title{i}";
                item.EngineSize = $"Engine{i}";
                item.ManufacturingCell = $"Cell{i}";
                item.Trim = $"Trim{i}";
                item.HandDrive = i % 2 == 0 ? "Left" : "Right";
                item.TubeAddOnType = $"TubeType{i}";
                item.TubeAddOnFactor = 1.5 + i;
                item.IsManualTerminal = i % 2 == 0;
                item.IsAllConnectorSealed = i % 2 != 0;
                item.AlphaCode = $"Alpha{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiModuleChildDetailGrpcs.Add(item);
            }

            DsiModuleChildDetailGrpc fixedItem = new DsiModuleChildDetailGrpc();
            fixedItem.RowId = 6;
            fixedItem.ModuleCode = "FixedModule";
            fixedItem.IsCoreModule = true;
            fixedItem.HarnessName1 = "FixedHarnessA";
            fixedItem.SimilarHarnessName1 = "FixedSimilarA";
            fixedItem.HarnessIssue1 = "FixedIssueA";
            fixedItem.SimilarHarnessIssue1 = "FixedSimilarIssueA";
            fixedItem.HarnessDate1 = DateTime.UtcNow.AddDays(-10).ToTimestamp();
            fixedItem.HarnessName2 = "FixedHarnessB";
            fixedItem.SimilarHarnessName2 = "FixedSimilarB";
            fixedItem.HarnessIssue2 = "FixedIssueB";
            fixedItem.SimilarHarnessIssue2 = "FixedSimilarIssueB";
            fixedItem.HarnessDate2 = DateTime.UtcNow.AddDays(-11).ToTimestamp();
            fixedItem.Customer = "FixedCustomer";
            fixedItem.Site = "FixedSite";
            fixedItem.Range = "FixedRange";
            fixedItem.BoardLength = 999.9;
            fixedItem.BoardWidth = 888.8;
            fixedItem.Datum = "FixedDatum";
            fixedItem.UserField1 = "FixedUF1";
            fixedItem.UserField2 = "FixedUF2";
            fixedItem.UserField3 = "FixedUF3";
            fixedItem.UserField4 = "FixedUF4";
            fixedItem.UserField5 = "FixedUF5";
            fixedItem.Checker = "FixedChecker";
            fixedItem.Inputter = "FixedInputter";
            fixedItem.DraftedBy = "FixedDraftedBy";
            fixedItem.PreparedBy = "FixedPreparedBy";
            fixedItem.Type = "FixedType";
            fixedItem.Title = "FixedTitle";
            fixedItem.EngineSize = "FixedEngine";
            fixedItem.ManufacturingCell = "FixedCell";
            fixedItem.Trim = "FixedTrim";
            fixedItem.HandDrive = "Left";
            fixedItem.TubeAddOnType = "FixedTubeType";
            fixedItem.TubeAddOnFactor = 9.99;
            fixedItem.IsManualTerminal = true;
            fixedItem.IsAllConnectorSealed = true;
            fixedItem.AlphaCode = "FixedAlpha";
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiModuleChildDetailGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiModuleCompatibility
        public static ListDsiModuleCompatibilityGrpc PopulateDsiModuleCompatibilityGrpc()
        {
            ListDsiModuleCompatibilityGrpc list = new ListDsiModuleCompatibilityGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiModuleCompatibilityGrpc item = new DsiModuleCompatibilityGrpc();
                item.RowId = i;
                item.ModuleCode1 = $"ModuleA{i}";
                item.ModuleCode2 = $"ModuleB{i}";
                item.Relationship = $"Compatible{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiModuleCompatibilityGrpcs.Add(item);
            }

            DsiModuleCompatibilityGrpc fixedItem = new DsiModuleCompatibilityGrpc();
            fixedItem.RowId = 6;
            fixedItem.ModuleCode1 = "FixedModuleA";
            fixedItem.ModuleCode2 = "FixedModuleB";
            fixedItem.Relationship = "FixedRelationship";
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiModuleCompatibilityGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiMulticoreSpecification
        public static ListDsiMulticoreSpecificationGrpc PopulateDsiMulticoreSpecificationGrpc()
        {
            ListDsiMulticoreSpecificationGrpc list = new ListDsiMulticoreSpecificationGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiMulticoreSpecificationGrpc item = new DsiMulticoreSpecificationGrpc();
                item.RowId = i;
                item.MulticoreName = $"Multicore{i}";
                item.IsIncludedOnBom = i % 2 == 0;
                item.IsIncludedOnChart = i % 2 != 0;
                item.Tag = $"Tag{i}";
                item.Note = $"Note{i}";
                item.LengthChangeType = $"ChangeType{i}";
                item.LengthChangeValue = 1.5 + i;
                item.OuterSheathCutBackAtEnd1Type = $"CutBack1Type{i}";
                item.OuterSheathCutBackAtEnd1Value = 2.0 + i;
                item.OuterSheathCutBackAtEnd2Type = $"CutBack2Type{i}";
                item.OuterSheathCutBackAtEnd2Value = 3.0 + i;
                item.Colour = $"Colour{i}";
                item.Material = $"Material{i}";
                item.Specification = $"Spec{i}";
                item.IsSheathed = i % 2 == 0;
                item.UserModule = $"UserMod{i}";
                item.AssemblyItemNumber = 1000 + i;
                item.ParentMulticoreName = $"ParentCore{i}";
                item.MulticoreOption = $"Option{i}";
                item.ParentMulticoreOption = $"ParentOption{i}";
                item.UnmodifiedMulticoreLength = 10.0 + i;
                item.ModifiedMulticoreLength = 9.5 + i;
                item.PartNumber1 = $"PN1-{i}";
                item.PartNumber2 = $"PN2-{i}";
                item.PartNumber3 = $"PN3-{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiMulticoreSpecificationGrpcs.Add(item);
            }

            DsiMulticoreSpecificationGrpc fixedItem = new DsiMulticoreSpecificationGrpc();
            fixedItem.RowId = 6;
            fixedItem.MulticoreName = "FixedMulticore";
            fixedItem.IsIncludedOnBom = true;
            fixedItem.IsIncludedOnChart = true;
            fixedItem.Tag = "FixedTag";
            fixedItem.Note = "FixedNote";
            fixedItem.LengthChangeType = "FixedChangeType";
            fixedItem.LengthChangeValue = 9.99;
            fixedItem.OuterSheathCutBackAtEnd1Type = "FixedCutBack1Type";
            fixedItem.OuterSheathCutBackAtEnd1Value = 8.88;
            fixedItem.OuterSheathCutBackAtEnd2Type = "FixedCutBack2Type";
            fixedItem.OuterSheathCutBackAtEnd2Value = 7.77;
            fixedItem.Colour = "FixedColour";
            fixedItem.Material = "FixedMaterial";
            fixedItem.Specification = "FixedSpec";
            fixedItem.IsSheathed = true;
            fixedItem.UserModule = "FixedUserMod";
            fixedItem.AssemblyItemNumber = 9999;
            fixedItem.ParentMulticoreName = "FixedParentCore";
            fixedItem.MulticoreOption = "FixedOption";
            fixedItem.ParentMulticoreOption = "FixedParentOption";
            fixedItem.UnmodifiedMulticoreLength = 100.0;
            fixedItem.ModifiedMulticoreLength = 95.5;
            fixedItem.PartNumber1 = "FixedPN1";
            fixedItem.PartNumber2 = "FixedPN2";
            fixedItem.PartNumber3 = "FixedPN3";
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiMulticoreSpecificationGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiPinMapping
        public static ListDsiPinMappingGrpc PopulateDsiPinMappingGrpc()
        {
            ListDsiPinMappingGrpc list = new ListDsiPinMappingGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiPinMappingGrpc item = new DsiPinMappingGrpc();
                item.RowId = i;
                item.PinMappingId = Guid.NewGuid().ToString();
                item.Node1 = $"NodeA{i}";
                item.Node2 = $"NodeB{i}";
                item.HarnessName1 = $"HarnessA{i}";
                item.HarnessIssue1 = $"IssueA{i}";
                item.HarnessName2 = $"HarnessB{i}";
                item.HarnessIssue2 = $"IssueB{i}";
                item.Separator = $"Sep{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiPinMappingGrpcs.Add(item);
            }

            DsiPinMappingGrpc fixedItem = new DsiPinMappingGrpc();
            fixedItem.RowId = 6;
            fixedItem.PinMappingId = Guid.NewGuid().ToString();
            fixedItem.Node1 = "FixedNodeA";
            fixedItem.Node2 = "FixedNodeB";
            fixedItem.HarnessName1 = "FixedHarnessA";
            fixedItem.HarnessIssue1 = "FixedIssueA";
            fixedItem.HarnessName2 = "FixedHarnessB";
            fixedItem.HarnessIssue2 = "FixedIssueB";
            fixedItem.Separator = "FixedSep";
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            list.DsiPinMappingGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiPinMappingCavityMappingAssociation
        public static ListDsiPinMappingCavityMappingAssociationGrpc PopulateDsiPinMappingCavityMappingAssociationGrpc()
        {
            ListDsiPinMappingCavityMappingAssociationGrpc list = new ListDsiPinMappingCavityMappingAssociationGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiPinMappingCavityMappingAssociationGrpc item = new DsiPinMappingCavityMappingAssociationGrpc();
                item.RowId = i;
                item.PinMappingID = Guid.NewGuid().ToString();
                item.CavityMappingID = Guid.NewGuid().ToString();
                item.MappingNumber = 100 + i;
                item.CreatedDate = DateTime.UtcNow.ToString("o");
                item.ModifiedDate = DateTime.UtcNow.ToString("o");
                item.CreatedBy = Guid.NewGuid().ToString();
                item.ModifiedBy = Guid.NewGuid().ToString();
                list.DsiPinMappingCavityMappingAssociationGrpcs.Add(item);
            }

            DsiPinMappingCavityMappingAssociationGrpc fixedItem = new DsiPinMappingCavityMappingAssociationGrpc();
            fixedItem.RowId = 6;
            fixedItem.PinMappingID = Guid.NewGuid().ToString();
            fixedItem.CavityMappingID = Guid.NewGuid().ToString();
            fixedItem.MappingNumber = 999;
            fixedItem.CreatedDate = DateTime.UtcNow.ToString("o");
            fixedItem.ModifiedDate = DateTime.UtcNow.ToString("o");
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            list.DsiPinMappingCavityMappingAssociationGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiScope
        public static ListDsiScopeGrpc PopulateDsiScopeGrpc()
        {
            ListDsiScopeGrpc list = new ListDsiScopeGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiScopeGrpc item = new DsiScopeGrpc();
                item.RowId = i;
                item.Scope = $"Scope{i}";
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.ModifiedBy = Guid.NewGuid().ToString();
                list.DsiScopeGrpcs.Add(item);
            }

            DsiScopeGrpc fixedItem = new DsiScopeGrpc();
            fixedItem.RowId = 6;
            fixedItem.Scope = "FixedScope";
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            list.DsiScopeGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiSupplier
        public static ListDsiSupplierGrpc PopulateDsiSupplierGrpc()
        {
            ListDsiSupplierGrpc list = new ListDsiSupplierGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiSupplierGrpc item = new DsiSupplierGrpc();
                item.RowId = i;
                item.Code = $"SUP{i:000}";
                item.Name = $"Supplier{i}";
                item.SubsidiaryId = 1000 + i;
                item.BuyerId = 2000 + i;
                item.Address = $"Address {i}";
                item.Phone = $"555-010{i}";
                item.Email = $"supplier{i}@example.com";
                item.Contact = $"Contact{i}";
                item.AlternateContact = $"AltContact{i}";
                item.Active = i % 2 == 0;
                item.JSupplier = i % 2 != 0;
                list.DsiSupplierGrpcs.Add(item);
            }

            DsiSupplierGrpc fixedItem = new DsiSupplierGrpc();
            fixedItem.RowId = 6;
            fixedItem.Code = "SUP999";
            fixedItem.Name = "FixedSupplier";
            fixedItem.SubsidiaryId = 9999;
            fixedItem.BuyerId = 8888;
            fixedItem.Address = "Fixed Address";
            fixedItem.Phone = "555-9999";
            fixedItem.Email = "fixed@supplier.com";
            fixedItem.Contact = "FixedContact";
            fixedItem.AlternateContact = "FixedAltContact";
            fixedItem.Active = true;
            fixedItem.JSupplier = true;
            list.DsiSupplierGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiTransformedCompositeDetail
        public static ListDsiTransformedCompositeDetailGrpc PopulateDsiTransformedCompositeDetailGrpc()
        {
            ListDsiTransformedCompositeDetailGrpc list = new ListDsiTransformedCompositeDetailGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiTransformedCompositeDetailGrpc item = new DsiTransformedCompositeDetailGrpc();
                item.RowId = i;
                item.HarnessName1 = $"HarnessA{i}";
                item.SimilarHarnessName1 = $"SimilarA{i}";
                item.HarnessIssue1 = $"IssueA{i}";
                item.SimilarHarnessIssue1 = $"SimilarIssueA{i}";
                item.HarnessDate1 = DateTime.UtcNow.AddDays(-i).ToTimestamp();
                item.HarnessName2 = $"HarnessB{i}";
                item.SimilarHarnessName2 = $"SimilarB{i}";
                item.HarnessIssue2 = $"IssueB{i}";
                item.SimilarHarnessIssue2 = $"SimilarIssueB{i}";
                item.HarnessDate2 = DateTime.UtcNow.AddDays(-i - 1).ToTimestamp();
                item.Customer = $"Customer{i}";
                item.Site = $"Site{i}";
                item.Range = $"Range{i}";
                item.BoardLength = 100 + i;
                item.BoardWidth = 50 + i;
                item.Datum = $"Datum{i}";
                item.UserField1 = $"UF1-{i}";
                item.UserField2 = $"UF2-{i}";
                item.UserField3 = $"UF3-{i}";
                item.UserField4 = $"UF4-{i}";
                item.UserField5 = $"UF5-{i}";
                item.Checker = $"Checker{i}";
                item.Inputter = $"Inputter{i}";
                item.DraftedBy = $"DraftedBy{i}";
                item.PreparedBy = $"PreparedBy{i}";
                item.Type = $"Type{i}";
                item.Title = $"Title{i}";
                item.EngineSize = $"Engine{i}";
                item.ManufacturingCell = $"Cell{i}";
                item.Trim = $"Trim{i}";
                item.HandDrive = i % 2 == 0 ? "Left" : "Right";
                item.TubeAddOnType = $"TubeType{i}";
                item.TubeAddOnFactor = 1.5 + i;
                item.IsManualTerminal = i % 2 == 0;
                item.IsAllConnectorsSealed = i % 2 != 0;
                item.AlphaCode = $"Alpha{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CircuitOption = $"CircuitOpt{i}";
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiTransformedCompositeDetailGrpcs.Add(item);
            }

            return list;
        }
        #endregion

        #region DsiTransformedHarness
        public static ListDsiTransformedHarnessGrpc PopulateDsiTransformedHarnessGrpc()
        {
            ListDsiTransformedHarnessGrpc list = new ListDsiTransformedHarnessGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiTransformedHarnessGrpc item = new DsiTransformedHarnessGrpc();
                item.RowId = i;
                item.HarnessName1 = $"HarnessA{i}";
                item.SimilarHarnessName1 = $"SimilarA{i}";
                item.HarnessIssue1 = $"IssueA{i}";
                item.SimilarHarnessIssue1 = $"SimilarIssueA{i}";
                item.HarnessDate1 = DateTime.UtcNow.AddDays(-i).ToTimestamp();
                item.HarnessName2 = $"HarnessB{i}";
                item.SimilarHarnessName2 = $"SimilarB{i}";
                item.HarnessIssue2 = $"IssueB{i}";
                item.SimilarHarnessIssue2 = $"SimilarIssueB{i}";
                item.HarnessDate2 = DateTime.UtcNow.AddDays(-i - 1).ToTimestamp();
                item.FileVersion = 1.0 + i;
                item.Customer = $"Customer{i}";
                item.Site = $"Site{i}";
                item.Range = $"Range{i}";
                item.BoardLength = 100 + i;
                item.BoardWidth = 50 + i;
                item.Datum = $"Datum{i}";
                item.UserField1 = $"UF1-{i}";
                item.UserField2 = $"UF2-{i}";
                item.UserField3 = $"UF3-{i}";
                item.UserField4 = $"UF4-{i}";
                item.UserField5 = $"UF5-{i}";
                item.Checker = $"Checker{i}";
                item.Inputter = $"Inputter{i}";
                item.DraftedBy = $"DraftedBy{i}";
                item.PreparedBy = $"PreparedBy{i}";
                item.Type = $"Type{i}";
                item.Title = $"Title{i}";
                item.EngineSize = $"Engine{i}";
                item.ManufacturingCell = $"Cell{i}";
                item.Trim = $"Trim{i}";
                item.HandDrive = i % 2 == 0 ? "Left" : "Right";
                item.TubeAddOnType = $"TubeType{i}";
                item.TubeAddOnFactor = 1.5 + i;
                item.IsManualTerminal = i % 2 == 0;
                item.IsAllConnectorsSealed = i % 2 != 0;
                item.DatumNode = $"DatumNode{i}";
                item.DatumRoute = $"DatumRoute{i}";
                item.IsModule = i % 2 == 0;
                item.AlphaCode = $"Alpha{i}";
                item.IsPitchTableUsed = i % 2 != 0;
                item.AdditionalComments = $"Comment{i}";
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiTransformedHarnessGrpcs.Add(item);
            }

            return list;
        }
        #endregion

        #region DsiTransformedModuleChildDetail
        public static ListDsiTransformedModuleChildDetailGrpc PopulateDsiTransformedModuleChildDetailGrpc()
        {
            ListDsiTransformedModuleChildDetailGrpc list = new ListDsiTransformedModuleChildDetailGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiTransformedModuleChildDetailGrpc item = new DsiTransformedModuleChildDetailGrpc();
                item.RowId = i;
                item.ModuleCode = $"Module{i}";
                item.IsCoreModule = i % 2 == 0;
                item.HarnessName1 = $"HarnessA{i}";
                item.SimilarHarnessName1 = $"SimilarA{i}";
                item.HarnessIssue1 = $"IssueA{i}";
                item.SimilarHarnessIssue1 = $"SimilarIssueA{i}";
                item.HarnessDate1 = DateTime.UtcNow.AddDays(-i).ToTimestamp();
                item.HarnessName2 = $"HarnessB{i}";
                item.SimilarHarnessName2 = $"SimilarB{i}";
                item.HarnessIssue2 = $"IssueB{i}";
                item.SimilarHarnessIssue2 = $"SimilarIssueB{i}";
                item.HarnessDate2 = DateTime.UtcNow.AddDays(-i - 1).ToTimestamp();
                item.Customer = $"Customer{i}";
                item.Site = $"Site{i}";
                item.Range = $"Range{i}";
                item.BoardLength = 100 + i;
                item.BoardWidth = 50 + i;
                item.Datum = $"Datum{i}";
                item.UserField1 = $"UF1-{i}";
                item.UserField2 = $"UF2-{i}";
                item.UserField3 = $"UF3-{i}";
                item.UserField4 = $"UF4-{i}";
                item.UserField5 = $"UF5-{i}";
                item.Checker = $"Checker{i}";
                item.Inputter = $"Inputter{i}";
                item.DraftedBy = $"DraftedBy{i}";
                item.PreparedBy = $"PreparedBy{i}";
                item.Type = $"Type{i}";
                item.Title = $"Title{i}";
                item.EngineSize = $"Engine{i}";
                item.ManufacturingCell = $"Cell{i}";
                item.Trim = $"Trim{i}";
                item.HandDrive = i % 2 == 0 ? "Left" : "Right";
                item.TubeAddOnType = $"TubeType{i}";
                item.TubeAddOnFactor = 1.5 + i;
                item.IsManualTerminal = i % 2 == 0;
                item.IsAllConnectorSealed = i % 2 != 0;
                item.AlphaCode = $"Alpha{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiTransformedModuleChildDetailGrpcs.Add(item);
            }

            return list;
        }
        #endregion

        #region DsiUnitOfMeasure
        public static ListDsiUnitOfMeasureGrpc PopulateDsiUnitOfMeasureGrpc()
        {
            ListDsiUnitOfMeasureGrpc list = new ListDsiUnitOfMeasureGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiUnitOfMeasureGrpc item = new DsiUnitOfMeasureGrpc();
                item.RowId = i;
                item.Abbreviation = $"UOM{i}";
                item.Description = $"Unit of Measure {i}";
                item.SubsidiaryId = 1000 + i;
                list.DsiUnitOfMeasureGrpcs.Add(item);
            }

            DsiUnitOfMeasureGrpc fixedItem = new DsiUnitOfMeasureGrpc();
            fixedItem.RowId = 6;
            fixedItem.Abbreviation = "FIX";
            fixedItem.Description = "Fixed Unit of Measure";
            fixedItem.SubsidiaryId = 9999;
            list.DsiUnitOfMeasureGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiWireMulticoreMarker
        public static ListDsiWireMulticoreMarkerGrpc PopulateDsiWireMulticoreMarkerGrpc()
        {
            ListDsiWireMulticoreMarkerGrpc list = new ListDsiWireMulticoreMarkerGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiWireMulticoreMarkerGrpc item = new DsiWireMulticoreMarkerGrpc();
                item.RowId = i;
                item.ItemType = $"Type{i}";
                item.ItemName = $"Item{i}";
                item.Option = $"Option{i}";
                item.Location = $"Location{i}";
                item.Text = $"Text{i}";
                item.ColourCode = $"Color{i}";
                item.Spacing = 1.0 + i;
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.ModifiedBy = Guid.NewGuid().ToString();
                list.DsiWireMulticoreMarkerGrpcs.Add(item);
            }

            DsiWireMulticoreMarkerGrpc fixedItem = new DsiWireMulticoreMarkerGrpc();
            fixedItem.RowId = 6;
            fixedItem.ItemType = "FixedType";
            fixedItem.ItemName = "FixedItem";
            fixedItem.Option = "FixedOption";
            fixedItem.Location = "FixedLocation";
            fixedItem.Text = "FixedText";
            fixedItem.ColourCode = "FixedColor";
            fixedItem.Spacing = 9.99;
            fixedItem.HarnessID = Guid.NewGuid().ToString();
            fixedItem.CreatedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.ModifiedDate = DateTime.UtcNow.ToTimestamp();
            fixedItem.CreatedBy = Guid.NewGuid().ToString();
            fixedItem.ModifiedBy = Guid.NewGuid().ToString();
            list.DsiWireMulticoreMarkerGrpcs.Add(fixedItem);

            return list;
        }
        #endregion

        #region DsiWireSpecification
        public static ListDsiWireSpecificationGrpc PopulateDsiWireSpecificationGrpc()
        {
            ListDsiWireSpecificationGrpc list = new ListDsiWireSpecificationGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiWireSpecificationGrpc item = new DsiWireSpecificationGrpc();
                item.RowId = i;
                item.WireName = $"Wire{i}";
                item.CompositeOptionString = $"OptionStr{i}";
                item.WireType = $"Type{i}";
                item.Colour = $"Color{i}";
                item.CrossSectionalArea = 0.5 + i;
                item.Material = $"Material{i}";
                item.UserModule = $"UserMod{i}";
                item.MulticoreName = $"Multicore{i}";
                item.End1NodeName = $"Node1-{i}";
                item.End1Route = $"Route1-{i}";
                item.End1Cavity = $"Cavity1-{i}";
                item.End1MaterialCode = $"MatCode1-{i}";
                item.End2NodeName = $"Node2-{i}";
                item.End2Route = $"Route2-{i}";
                item.End2Cavity = $"Cavity2-{i}";
                item.End2MaterialCode = $"MatCode2-{i}";
                item.IsIncludedOnBom = i % 2 == 0;
                item.IsIncludedOnChart = i % 2 != 0;
                item.WireTag = $"Tag{i}";
                item.WireNote = $"Note{i}";
                item.WireLengthChangeType = $"ChangeType{i}";
                item.WireLengthChangeValue = 1.1 + i;
                item.AssemblyItemNumber = 1000 + i;
                item.MulticoreOption = $"Option{i}";
                item.UnmodifiedWireLength = 10.0 + i;
                item.ModifiedWireLength = 9.5 + i;
                item.CutbackAtEnd1 = 0.5 + i;
                item.CutbackAtEnd2 = 0.3 + i;
                item.PartNumber1 = $"PN1-{i}";
                item.PartNumber2 = $"PN2-{i}";
                item.PartNumber3 = $"PN3-{i}";
                item.Signal = $"Signal{i}";
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiWireSpecificationGrpcs.Add(item);
            }

            return list;
        }
        #endregion

        #region DsiWireThroughNode
        public static ListDsiWireThroughNodeGrpc PopulateDsiWireThroughNodeGrpc()
        {
            ListDsiWireThroughNodeGrpc list = new ListDsiWireThroughNodeGrpc();
            for (int i = 0; i < 5; i++)
            {
                DsiWireThroughNodeGrpc item = new DsiWireThroughNodeGrpc();
                item.RowId = i;
                item.WireName = $"Wire{i}";
                item.Option = $"Option{i}";
                item.ThroughOrder = i + 0.5;
                item.ThroughNode = $"Node{i}";
                item.ThroughRoute = $"Route{i}";
                item.IsThroughFlag = i % 2 == 0;
                item.HarnessID = Guid.NewGuid().ToString();
                item.CreatedBy = Guid.NewGuid().ToString();
                item.CreatedDate = DateTime.UtcNow.ToTimestamp();
                item.ModifiedBy = Guid.NewGuid().ToString();
                item.ModifiedDate = DateTime.UtcNow.ToTimestamp();
                list.DsiWireThroughNodeGrpcs.Add(item);
            }

            return list;
        }
        #endregion

    }
}
