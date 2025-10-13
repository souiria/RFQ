using SharedModels.DocumentConverter.DSI.Aggregates;
using SharedModels.DocumentConverter.DSI.DTOs;
using Transformation;

namespace DocumentConverterEngine.Tests
{
    public class DocumentConversionIntegrationTests
    {
        byte[] _File;
        DsiAggregate _Model;
        [SetUp]
        public void Setup()
        {
            _File = File.ReadAllBytes("../../../TestData.dsi");
            _Model = DocumentConverter.ConvertDsiFile(_File);
        }

        [Test]
        public void TestGetHarnessNameInformation()
        {
            Assert.That(_Model.Harness, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo("T2L2-14A005-ZC");
            Assert.That(_Model.Harness.HarnessName1, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.SimilarHarnessName1, equalConstraint);
            equalConstraint = Is.EqualTo("171");
            Assert.That(_Model.Harness.HarnessIssue1, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.SimilarHarnessIssue1, equalConstraint);
            DateTime harnessDate1 = new DateTime(2023, 05, 12);
            equalConstraint = Is.EqualTo(harnessDate1);
            Assert.That(_Model.Harness.HarnessDate1, equalConstraint);
            equalConstraint = Is.EqualTo("T2L2-14A005-ZC");
            Assert.That(_Model.Harness.HarnessName2, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.SimilarHarnessName2, equalConstraint);
            equalConstraint = Is.EqualTo("171");
            Assert.That(_Model.Harness.HarnessIssue2, equalConstraint);
            DateTime harnessDate2 = new DateTime(2023, 05, 12);
            equalConstraint = Is.EqualTo(harnessDate2);
            Assert.That(_Model.Harness.HarnessDate2, equalConstraint);
            equalConstraint = Is.EqualTo(12);
            Assert.That(_Model.Harness.FileVersion, equalConstraint);
            equalConstraint = Is.EqualTo("Landrover");
            Assert.That(_Model.Harness.Customer, equalConstraint);
            equalConstraint = Is.EqualTo("Default site");
            Assert.That(_Model.Harness.Site, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.Range, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.Harness.BoardLength, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.Harness.BoardWidth, equalConstraint);
            equalConstraint = Is.EqualTo("back");
            Assert.That(_Model.Harness.Datum, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.UserField1, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.UserField2, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.UserField3, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.UserField4, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.UserField5, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.Checker, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.Inputter, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.DraftedBy, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.PreparedBy, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.Type, equalConstraint);
            equalConstraint = Is.EqualTo("TT_Release");
            Assert.That(_Model.Harness.Title, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.EngineSize, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.ManufacturingCell, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.Trim, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.HandDrive, equalConstraint);
            equalConstraint = Is.EqualTo("Percentage");
            Assert.That(_Model.Harness.TubeAddOnType, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.Harness.TubeAddOnFactor, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(_Model.Harness.IsManualTerminal, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(_Model.Harness.IsAllConnectorsSealed, equalConstraint);
            equalConstraint = Is.EqualTo("C2FG01B");
            Assert.That(_Model.Harness.DatumNode, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(_Model.Harness.IsModule, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(_Model.Harness.AlphaCode, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(_Model.Harness.IsPitchTableUsed, equalConstraint);
        }

        [Test]
        public void TestGetHarnessNoteInformation()
        {
            Assert.That(_Model.Harness, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(null);
            Assert.That(_Model.Harness.AdditionalComments, equalConstraint);
        }

        [Test]
        public void TestGetHarnessCircuitInformantion()
        {
            Assert.That(_Model.CompositeDetailList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(48);
            Assert.That(_Model.CompositeDetailList.Count, equalConstraint);
            CompositeDetailDto model = _Model.CompositeDetailList.Last();
            equalConstraint = Is.EqualTo(48);
            Assert.That(_Model.CompositeDetailList.Count, equalConstraint);
            equalConstraint = Is.EqualTo("T2L2-14A005-WC");
            Assert.That(model.HarnessName1, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.SimilarHarnessName1, equalConstraint);
            equalConstraint = Is.EqualTo("171");
            Assert.That(model.HarnessIssue1, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.SimilarHarnessIssue1, equalConstraint);
            DateTime harnessDate1 = new DateTime(2023, 05, 12);
            equalConstraint = Is.EqualTo(harnessDate1);
            Assert.That(model.HarnessDate1, equalConstraint);
            equalConstraint = Is.EqualTo("T2L2-14A005-WC");
            Assert.That(model.HarnessName2, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.SimilarHarnessName2, equalConstraint);
            equalConstraint = Is.EqualTo("171");
            Assert.That(model.HarnessIssue2, equalConstraint);
            DateTime harnessDate2 = new DateTime(2023, 05, 12);
            equalConstraint = Is.EqualTo(harnessDate2);
            Assert.That(model.HarnessDate2, equalConstraint);
            equalConstraint = Is.EqualTo("Landrover");
            Assert.That(model.Customer, equalConstraint);
            equalConstraint = Is.EqualTo("Default site");
            Assert.That(model.Site, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Range, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.BoardLength, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.BoardWidth, equalConstraint);
            equalConstraint = Is.EqualTo("back");
            Assert.That(model.Datum, equalConstraint);
            equalConstraint = Is.EqualTo(" ");
            Assert.That(model.UserField1, equalConstraint);
            equalConstraint = Is.EqualTo(" ");
            Assert.That(model.UserField2, equalConstraint);
            equalConstraint = Is.EqualTo(" ");
            Assert.That(model.UserField3, equalConstraint);
            equalConstraint = Is.EqualTo(" ");
            Assert.That(model.UserField4, equalConstraint);
            equalConstraint = Is.EqualTo(" ");
            Assert.That(model.UserField5, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Checker, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Inputter, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.DraftedBy, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.PreparedBy, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Type, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Title, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.EngineSize, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ManufacturingCell, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Trim, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.HandDrive, equalConstraint);
            equalConstraint = Is.EqualTo("Percentage");
            Assert.That(model.TubeAddOnType, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.TubeAddOnFactor, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(model.IsManualTerminal, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(model.IsAllConnectorsSealed, equalConstraint);
            equalConstraint = Is.EqualTo("C2FG01B");
            equalConstraint = Is.EqualTo("");
            Assert.That(model.AlphaCode, equalConstraint);
            equalConstraint = Is.EqualTo("G3AAK, IDABH, JBBBQ, AGLAC, GREAB, G1VAA, G1WAA, DWABP, JZXAC, IBYAJ, JASAB, DWMAC, A1PBA, CA#WL, B5WAL, CP5AC, C1NAR, IEHAG, JBBBP, IEKAK, DR--F, CPXAC, BZFAC, GPDAA, DAYAQ, BLHAC, BWCBD, EN-AE, BSBA8, J1EAB, HTXAW, A1GAU, BZGAC, HNHAB, A6ZAF, CWPAE, HKCAB, ATVAB, G2AAV, BWNAB, A3BAE, A7AAE, ATWAC, DAYAT, B3MAB, C1NA4, J3EAR");
            Assert.That(model.CircuitOption, equalConstraint);
        }

        [Test]
        public void TestGetHarnessBranchConfiguration()
        {
            Assert.That(_Model.BranchConfigurationList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1502);
            Assert.That(_Model.BranchConfigurationList.Count, equalConstraint);
            BranchConfigurationDto model = _Model.BranchConfigurationList.Last();
            equalConstraint = Is.EqualTo("N-350");
            Assert.That(model.StartNode, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.StartRoute, equalConstraint);
            equalConstraint = Is.EqualTo("x25997.50y333.47z0.00");
            Assert.That(model.StartCoordinates, equalConstraint);
            equalConstraint = Is.EqualTo("N-26");
            Assert.That(model.EndNode, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.EndRoute, equalConstraint);
            equalConstraint = Is.EqualTo("x25997.50y333.47z0.00");
            Assert.That(model.EndCoordinates, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.Length, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.CircuitOption, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.BundleDiameter, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.UserModule, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.AssignedModule, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ModuleFrom, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.BendString, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Bend, equalConstraint);
        }

        [Test]
        public void TestGetHarnessWireSpecification()
        {
            Assert.That(_Model.WireSpecificationList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1200);
            Assert.That(_Model.WireSpecificationList.Count, equalConstraint);
            WireSpecificationDto model = _Model.WireSpecificationList.Last();
            equalConstraint = Is.EqualTo("CYE05B");
            Assert.That(model.WireName, equalConstraint);
            equalConstraint = Is.EqualTo("CA#WL");
            Assert.That(model.CompositeOptionString, equalConstraint);
            equalConstraint = Is.EqualTo("1.5");
            Assert.That(model.WireType, equalConstraint);
            equalConstraint = Is.EqualTo("WH");
            Assert.That(model.Colour, equalConstraint);
            equalConstraint = Is.EqualTo(1.5);
            Assert.That(model.CrossSectionalArea, equalConstraint);
            equalConstraint = Is.EqualTo("WA");
            Assert.That(model.Material, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.UserModule, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.MulticoreName, equalConstraint);
            equalConstraint = Is.EqualTo("C1YE65A");
            Assert.That(model.End1NodeName, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.End1Route, equalConstraint);
            equalConstraint = Is.EqualTo("4");
            Assert.That(model.End1Cavity, equalConstraint);
            equalConstraint = Is.EqualTo("TIN");
            Assert.That(model.End1MaterialCode, equalConstraint);
            equalConstraint = Is.EqualTo("C4YE05A");
            Assert.That(model.End2NodeName, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.End2Route, equalConstraint);
            equalConstraint = Is.EqualTo("11");
            Assert.That(model.End2Cavity, equalConstraint);
            equalConstraint = Is.EqualTo("TIN");
            Assert.That(model.End2MaterialCode, equalConstraint);
            equalConstraint = Is.EqualTo(true);
            Assert.That(model.IsIncludedOnBom, equalConstraint);
            equalConstraint = Is.EqualTo(true);
            Assert.That(model.IsIncludedOnChart, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.WireTag, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.WireNote, equalConstraint);
            equalConstraint = Is.EqualTo("Neither");
            Assert.That(model.WireLengthChangeType, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.WireLengthChangeValue, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.AssemblyItemNumber, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.MulticoreOption, equalConstraint);
            equalConstraint = Is.EqualTo(7720);
            Assert.That(model.UnmodifiedWireLength, equalConstraint);
            equalConstraint = Is.EqualTo(7720);
            Assert.That(model.ModifiedWireLength, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.CutbackAtEnd1, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.CutbackAtEnd2, equalConstraint);
            equalConstraint = Is.EqualTo("WIRE_WH_1.5_WA");
            Assert.That(model.PartNumber1, equalConstraint);
            equalConstraint = Is.EqualTo("WIRE_WH_1.5_WA");
            Assert.That(model.PartNumber2, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.PartNumber3, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Signal, equalConstraint);
        }

        [Test]
        public void TestGetHarnessMainNodeComponents()
        {
            Assert.That(_Model.ComponentList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(5189);
            Assert.That(_Model.ComponentList.Count, equalConstraint);
            ComponentDto model = _Model.ComponentList.Last();
            equalConstraint = Is.EqualTo("");
            Assert.That(model.NodeName, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.CavityName, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.WireName, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.SequenceNumber, equalConstraint);
            equalConstraint = Is.EqualTo("ASSEMBLYITEM");
            Assert.That(model.ComponentTypeCode1, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ComponentOption, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ServiceFunction, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Route, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.PartNumber1, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.PartNumber2, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.PartNumber3, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.Quantity, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.CrossSectionalArea, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(model.IsSelectTerminal, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(model.IsSeal, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(model.IsPlugged, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.BlockNumber, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.TerminationMethod, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.MaterialCode, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ComponentTypeCode2, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.InsulationType, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.UserModule, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.AssignedModule, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ModuleFrom, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.SplitValue, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Datum, equalConstraint);
            equalConstraint = Is.EqualTo(34);
            Assert.That(model.AssemblyItemNumber, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ColourCode, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.NumberOfCavities, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(model.IsBackshell, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.WireOption, equalConstraint);
        }

        [Test]
        public void TestGetHarnessBranchInsulations()
        {
            Assert.That(_Model.BranchInsulationList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1076);
            Assert.That(_Model.BranchInsulationList.Count, equalConstraint);
            BranchInsulationDto model = _Model.BranchInsulationList.Last();
            equalConstraint = Is.EqualTo("N-636");
            Assert.That(model.StartNode, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.StartRoute, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.EndNode, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.EndRoute, equalConstraint);
            equalConstraint = Is.EqualTo("1076");
            Assert.That(model.PieceCode, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.InsulationCode, equalConstraint);
            equalConstraint = Is.EqualTo(19);
            Assert.That(model.Diameter, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.CircuitOption, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.InsulationNote, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.UserModule, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.AssignedModule, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ModuleFrom, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.CalculationMethod, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.ManualAmount, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.SplitValue, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.JoinNumber, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.AssemblyItemNumber, equalConstraint);
            equalConstraint = Is.EqualTo(20);
            Assert.That(model.Layer, equalConstraint);
            equalConstraint = Is.EqualTo("Spot Tape");
            Assert.That(model.InsulationType, equalConstraint);
            equalConstraint = Is.EqualTo("CHCT-98176-EA");
            Assert.That(model.PartNumber1, equalConstraint);
            equalConstraint = Is.EqualTo("CHCT-98176-EA");
            Assert.That(model.PartNumber2, equalConstraint);
            equalConstraint = Is.EqualTo("4323 19MMX50M WH");
            Assert.That(model.PartNumber3, equalConstraint);
            equalConstraint = Is.EqualTo("WHIT");
            Assert.That(model.Colour, equalConstraint);
            equalConstraint = Is.EqualTo("TAPE");
            Assert.That(model.Type, equalConstraint);
            equalConstraint = Is.EqualTo("PAPR");
            Assert.That(model.Material, equalConstraint);
            equalConstraint = Is.EqualTo(0.12);
            Assert.That(model.WallThickness, equalConstraint);
            equalConstraint = Is.EqualTo(2);
            Assert.That(model.NumberOfTurns, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.TurnsPerBreakout, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.TurnsPerBranch, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.DistanceBetweenItems, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.LongestDistance, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.DistanceFromConnector, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.TubeSelectionType, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.TubeSelectionFactor, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.CutBack, equalConstraint);
            equalConstraint = Is.EqualTo(true);
            Assert.That(model.IsConvoluted, equalConstraint);
            equalConstraint = Is.EqualTo(true);
            Assert.That(model.IsSlit, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ModuleSpecificData, equalConstraint);
        }

        [Test]
        public void TestGetHarnessCenterStrips()
        {
            Assert.That(_Model.CentreStripList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.CentreStripList.Count, equalConstraint);
        }

        [Test]
        public void TestGetHarnessMulticores()
        {
            Assert.That(_Model.MulticoreSpecificationList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(228);
            Assert.That(_Model.MulticoreSpecificationList.Count, equalConstraint);
            MulticoreSpecificationDto model = _Model.MulticoreSpecificationList.Last();
            equalConstraint = Is.EqualTo("T2-VDB31W");
            Assert.That(model.MulticoreName, equalConstraint);
            equalConstraint = Is.EqualTo(true);
            Assert.That(model.IsIncludedOnBom, equalConstraint);
            equalConstraint = Is.EqualTo(true);
            Assert.That(model.IsIncludedOnChart, equalConstraint);
            equalConstraint = Is.EqualTo(" ");
            Assert.That(model.Tag, equalConstraint);
            equalConstraint = Is.EqualTo(" ");
            Assert.That(model.Note, equalConstraint);
            equalConstraint = Is.EqualTo("Neither");
            Assert.That(model.LengthChangeType, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.LengthChangeValue, equalConstraint);
            equalConstraint = Is.EqualTo("Neither");
            Assert.That(model.OuterSheathCutBackAtEnd1Type, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.OuterSheathCutBackAtEnd1Value, equalConstraint);
            equalConstraint = Is.EqualTo("Neither");
            Assert.That(model.OuterSheathCutBackAtEnd2Type, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.OuterSheathCutBackAtEnd2Value, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Colour, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.Material, equalConstraint);
            equalConstraint = Is.EqualTo("50");
            Assert.That(model.Specification, equalConstraint);
            equalConstraint = Is.EqualTo(false);
            Assert.That(model.IsSheathed, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.UserModule, equalConstraint);
            equalConstraint = Is.EqualTo(0);
            Assert.That(model.AssemblyItemNumber, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ParentMulticoreName, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.MulticoreOption, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ParentMulticoreOption, equalConstraint);
            equalConstraint = Is.EqualTo(730);
            Assert.That(model.UnmodifiedMulticoreLength, equalConstraint);
            equalConstraint = Is.EqualTo(730);
            Assert.That(model.ModifiedMulticoreLength, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.PartNumber1, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.PartNumber2, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.PartNumber3, equalConstraint);
        }

        [Test]
        public void TestGetModuleChildDetails()
        {
            Assert.That(_Model.ModuleChildDetailList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.ModuleChildDetailList.Count, equalConstraint);
        }

        [Test]
        public void TestGetModuleCompatibilityDetails()
        {
            Assert.That(_Model.ModuleCompatibilityList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.ModuleCompatibilityList.Count, equalConstraint);
        }

        [Test]
        public void TestGetManualBOMQuantities()
        {
            Assert.That(_Model.ManualBomQuantityList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.ManualBomQuantityList.Count, equalConstraint);
        }

        [Test]
        public void TestGetCompositeOptionCodes()
        {
            Assert.That(_Model.CompositeOptionList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(120);
            Assert.That(_Model.CompositeOptionList.Count, equalConstraint);
            CompositeOptionDto model = _Model.CompositeOptionList.Last();
            equalConstraint = Is.EqualTo("A3BAC");
            Assert.That(model.OptionName, equalConstraint);
            equalConstraint = Is.EqualTo("HEADLAMP OPERATION LHD RIGHT J");
            Assert.That(model.Description, equalConstraint);
        }

        [Test]
        public void TestGetHarnessWireThroughNodes()
        {
            Assert.That(_Model.WireThroughNodeList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(8);
            Assert.That(_Model.WireThroughNodeList.Count, equalConstraint);
            WireThroughNodeDto model = _Model.WireThroughNodeList.Last();
            equalConstraint = Is.EqualTo("CYE05B");
            Assert.That(model.WireName, equalConstraint);
            equalConstraint = Is.EqualTo("CA#WL");
            Assert.That(model.Option, equalConstraint);
            equalConstraint = Is.EqualTo(4);
            Assert.That(model.ThroughOrder, equalConstraint);
            equalConstraint = Is.EqualTo("Node.147");
            Assert.That(model.ThroughNode, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ThroughRoute, equalConstraint);
            equalConstraint = Is.EqualTo(true);
            Assert.That(model.IsThroughFlag, equalConstraint);
        }

        [Test]
        public void TestGetHarnessBranchInsulationThroughNodes()
        {
            Assert.That(_Model.BranchInsulationThroughNodeList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1);
            Assert.That(_Model.BranchInsulationThroughNodeList.Count, equalConstraint);
            BranchInsulationThroughNodeDto model = _Model.BranchInsulationThroughNodeList.Last();
            equalConstraint = Is.EqualTo("237");
            Assert.That(model.PieceCode, equalConstraint);
            equalConstraint = Is.EqualTo(1);
            Assert.That(model.ThroughOrder, equalConstraint);
            equalConstraint = Is.EqualTo("N-352");
            Assert.That(model.ThroughNode, equalConstraint);
            equalConstraint = Is.EqualTo("");
            Assert.That(model.ThroughRoute, equalConstraint);
            equalConstraint = Is.EqualTo(true);
            Assert.That(model.IsThroughFlag, equalConstraint);
        }

        [Test]
        public void TestGetHarnessMidWireComponents()
        {
            Assert.That(_Model.MidWireComponentList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.MidWireComponentList.Count, equalConstraint);
        }

        [Test]
        public void TestGetHarnessWireMulticoreMarkers()
        {
            Assert.That(_Model.WireMulticoreMarkerList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.WireMulticoreMarkerList.Count, equalConstraint);
        }

        [Test]
        public void TestGetHarnessPinMappings()
        {
            Assert.That(_Model.PinMappingList, Is.Not.Null);

            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(0);
            Assert.That(_Model.PinMappingList.Count, equalConstraint);
        }

        [Test]
        public void TestGetHarnessScope()
        {
            Assert.That(_Model.HarnessScopeList, Is.Not.Null);

            if (_Model.HarnessScopeList != null)
            {
                NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(1);
                Assert.That(_Model.HarnessScopeList.Count, equalConstraint);
                HarnessScopeDto model = _Model.HarnessScopeList.Last();
                equalConstraint = Is.EqualTo("T2L2-14A005-ZC");
                Assert.That(model.HarnessName1, equalConstraint);
                equalConstraint = Is.EqualTo("171");
                Assert.That(model.HarnessIssue1, equalConstraint);
                equalConstraint = Is.EqualTo("T2L2-14A005-ZC");
                Assert.That(model.HarnessName2, equalConstraint);
                equalConstraint = Is.EqualTo("171");
                Assert.That(model.HarnessIssue2, equalConstraint);
                equalConstraint = Is.EqualTo("LV Harness");
                Assert.That(model.ScopeCategory, equalConstraint);
                equalConstraint = Is.EqualTo("LV Harness");
                Assert.That(model.Scope, equalConstraint);
            }
        }
    }
}
