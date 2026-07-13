using DSI;

namespace RfqModule.Extentions
{
    public static class HarnessExtensions
    {
        public static DSIHarnessGrpc? ToDSIHarness(this HarnessGrpc harnessGrpc)
        {
            if (harnessGrpc == null)
            {
                return null;
            }

            DSIHarnessGrpc dsiHarnessGrpc = new DSIHarnessGrpc();

            // field 1
            dsiHarnessGrpc.Id = harnessGrpc.Id;

            // fields 2–6: Harness 1 group
            dsiHarnessGrpc.HarnessName1 = harnessGrpc.HarnessName1;
            dsiHarnessGrpc.SimilarHarnessName1 = harnessGrpc.SimilarHarnessName1;
            dsiHarnessGrpc.HarnessIssue1 = harnessGrpc.HarnessIssue1;
            dsiHarnessGrpc.SimilarHarnessIssue1 = harnessGrpc.SimilarHarnessIssue1;
            if (harnessGrpc.HarnessDate1 != null)
            {
                dsiHarnessGrpc.HarnessDate1 = harnessGrpc.HarnessDate1;
            }

            // fields 7–11: Harness 2 group
            dsiHarnessGrpc.HarnessName2 = harnessGrpc.HarnessName2;
            dsiHarnessGrpc.SimilarHarnessName2 = harnessGrpc.SimilarHarnessName2;
            dsiHarnessGrpc.HarnessIssue2 = harnessGrpc.HarnessIssue2;
            dsiHarnessGrpc.SimilarHarnessIssue2 = harnessGrpc.SimilarHarnessIssue2;
            if (harnessGrpc.HarnessDate2 != null)
            {
                dsiHarnessGrpc.HarnessDate2 = harnessGrpc.HarnessDate2;
            }

            // field 12: FileVersion
            dsiHarnessGrpc.FileVersion = harnessGrpc.FileVersion;

            // fields 13–15: Customer / Site / Range
            dsiHarnessGrpc.Customer = harnessGrpc.Customer;
            dsiHarnessGrpc.Site = harnessGrpc.Site;
            dsiHarnessGrpc.Range = harnessGrpc.Range;

            // fields 16–17: Board dimensions
            dsiHarnessGrpc.BoardLength = harnessGrpc.BoardLength;
            dsiHarnessGrpc.BoardWidth = harnessGrpc.BoardWidth;

            // field 18: Datum
            dsiHarnessGrpc.Datum = harnessGrpc.Datum;

            // fields 19–23: User fields
            dsiHarnessGrpc.UserField1 = harnessGrpc.UserField1;
            dsiHarnessGrpc.UserField2 = harnessGrpc.UserField2;
            dsiHarnessGrpc.UserField3 = harnessGrpc.UserField3;
            dsiHarnessGrpc.UserField4 = harnessGrpc.UserField4;
            dsiHarnessGrpc.UserField5 = harnessGrpc.UserField5;

            // fields 24–27: People
            dsiHarnessGrpc.Checker = harnessGrpc.Checker;
            dsiHarnessGrpc.Inputter = harnessGrpc.Inputter;
            dsiHarnessGrpc.DraftedBy = harnessGrpc.DraftedBy;
            dsiHarnessGrpc.PreparedBy = harnessGrpc.PreparedBy;

            // fields 28–33: Harness characteristics
            dsiHarnessGrpc.Type = harnessGrpc.Type;
            dsiHarnessGrpc.Title = harnessGrpc.Title;
            dsiHarnessGrpc.EngineSize = harnessGrpc.EngineSize;
            dsiHarnessGrpc.ManufacturingCell = harnessGrpc.ManufacturingCell;
            dsiHarnessGrpc.Trim = harnessGrpc.Trim;
            dsiHarnessGrpc.HandDrive = harnessGrpc.HandDrive;

            // fields 34–35: Tube add-on
            dsiHarnessGrpc.TubeAddOnType = harnessGrpc.TubeAddOnType;
            dsiHarnessGrpc.TubeAddOnFactor = harnessGrpc.TubeAddOnFactor;

            // fields 36–39: Boolean flags
            dsiHarnessGrpc.IsManualTerminal = harnessGrpc.IsManualTerminal;
            dsiHarnessGrpc.IsAllConnectorsSealed = harnessGrpc.IsAllConnectorsSealed;
            dsiHarnessGrpc.IsModule = harnessGrpc.IsModule;
            dsiHarnessGrpc.IsPitchTableUsed = harnessGrpc.IsPitchTableUsed;

            // fields 40–41: Comments
            dsiHarnessGrpc.AlphaCode = harnessGrpc.AlphaCode;
            dsiHarnessGrpc.AdditionalComments = harnessGrpc.AdditionalComments;

            // fields 42–43: Timestamps
            if (harnessGrpc.CreatedDate != null)
            {
                dsiHarnessGrpc.CreatedDate = harnessGrpc.CreatedDate;
            }

            if (harnessGrpc.ModifiedDate != null)
            {
                dsiHarnessGrpc.ModifiedDate = harnessGrpc.ModifiedDate;
            }

            // fields 44–45: Audit
            dsiHarnessGrpc.CreatedBy = harnessGrpc.CreatedBy;
            dsiHarnessGrpc.ModifiedBy = harnessGrpc.ModifiedBy;

            return dsiHarnessGrpc;
        }

        public static HarnessGrpc? ToHarness(this DSIHarnessGrpc dsiHarnessGrpc)
        {
            if (dsiHarnessGrpc == null)
            {
                return null;
            }

            HarnessGrpc harnessGrpc = new HarnessGrpc();
            // field 1
            harnessGrpc.Id = dsiHarnessGrpc.Id;
            // fields 2–6: Harness 1 group
            harnessGrpc.HarnessName1 = dsiHarnessGrpc.HarnessName1;
            harnessGrpc.SimilarHarnessName1 = dsiHarnessGrpc.SimilarHarnessName1;
            harnessGrpc.HarnessIssue1 = dsiHarnessGrpc.HarnessIssue1;
            harnessGrpc.SimilarHarnessIssue1 = dsiHarnessGrpc.SimilarHarnessIssue1;
            if (dsiHarnessGrpc.HarnessDate1 != null)
            {
                harnessGrpc.HarnessDate1 = dsiHarnessGrpc.HarnessDate1;
            }
            // fields 7–11: Harness 2 group
            harnessGrpc.HarnessName2 = dsiHarnessGrpc.HarnessName2;
            harnessGrpc.SimilarHarnessName2 = dsiHarnessGrpc.SimilarHarnessName2;
            harnessGrpc.HarnessIssue2 = dsiHarnessGrpc.HarnessIssue2;
            harnessGrpc.SimilarHarnessIssue2 = dsiHarnessGrpc.SimilarHarnessIssue2;
            if (dsiHarnessGrpc.HarnessDate2 != null)
            {
                harnessGrpc.HarnessDate2 = dsiHarnessGrpc.HarnessDate2;
            }
            // field 12: FileVersion
            harnessGrpc.FileVersion = dsiHarnessGrpc.FileVersion;
            // fields 13–15: Customer / Site / Range
            harnessGrpc.Customer = dsiHarnessGrpc.Customer;
            harnessGrpc.Site = dsiHarnessGrpc.Site;
            harnessGrpc.Range = dsiHarnessGrpc.Range;
            // fields 16–17: Board dimensions
            harnessGrpc.BoardLength = dsiHarnessGrpc.BoardLength;
            harnessGrpc.BoardWidth = dsiHarnessGrpc.BoardWidth;

            // field 18: Datum
            harnessGrpc.Datum = dsiHarnessGrpc.Datum;

            // fields 19–23: User fields
            harnessGrpc.UserField1 = dsiHarnessGrpc.UserField1;
            harnessGrpc.UserField2 = dsiHarnessGrpc.UserField2;
            harnessGrpc.UserField3 = dsiHarnessGrpc.UserField3;
            harnessGrpc.UserField4 = dsiHarnessGrpc.UserField4;
            harnessGrpc.UserField5 = dsiHarnessGrpc.UserField5;

            // fields 24–27: People
            harnessGrpc.Checker = dsiHarnessGrpc.Checker;
            harnessGrpc.Inputter = dsiHarnessGrpc.Inputter;
            harnessGrpc.DraftedBy = dsiHarnessGrpc.DraftedBy;
            harnessGrpc.PreparedBy = dsiHarnessGrpc.PreparedBy;

            // fields 28–33: Harness characteristics
            harnessGrpc.Type = dsiHarnessGrpc.Type;
            harnessGrpc.Title = dsiHarnessGrpc.Title;
            harnessGrpc.EngineSize = dsiHarnessGrpc.EngineSize;
            harnessGrpc.ManufacturingCell = dsiHarnessGrpc.ManufacturingCell;
            harnessGrpc.Trim = dsiHarnessGrpc.Trim;
            harnessGrpc.HandDrive = dsiHarnessGrpc.HandDrive;

            // fields 34–35: Tube add-on
            harnessGrpc.TubeAddOnType = dsiHarnessGrpc.TubeAddOnType;
            harnessGrpc.TubeAddOnFactor = dsiHarnessGrpc.TubeAddOnFactor;

            // fields 36–39: Boolean flags
            harnessGrpc.IsManualTerminal = dsiHarnessGrpc.IsManualTerminal;
            harnessGrpc.IsAllConnectorsSealed = dsiHarnessGrpc.IsAllConnectorsSealed;
            harnessGrpc.IsModule = dsiHarnessGrpc.IsModule;
            harnessGrpc.IsPitchTableUsed = dsiHarnessGrpc.IsPitchTableUsed;

            // fields 40–41: Comments
            harnessGrpc.AlphaCode = dsiHarnessGrpc.AlphaCode;
            harnessGrpc.AdditionalComments = dsiHarnessGrpc.AdditionalComments;
            // fields 42–43: Timestamps
            if (dsiHarnessGrpc.CreatedDate != null)
            {
                harnessGrpc.CreatedDate = dsiHarnessGrpc.CreatedDate;
            }

            if (dsiHarnessGrpc.ModifiedDate != null)
            {
                harnessGrpc.ModifiedDate = dsiHarnessGrpc.ModifiedDate;
            }

            // fields 44–45: Audit
            harnessGrpc.CreatedBy = dsiHarnessGrpc.CreatedBy;
            harnessGrpc.ModifiedBy = dsiHarnessGrpc.ModifiedBy;

            return harnessGrpc;
        }

        public static DSICompositeDetailGrpc? ToDSICompositeDetail(this CompositeDetailGrpc compositeDetailGrpc)
        {
            if (compositeDetailGrpc == null)
            {
                return null;
            }

            DSICompositeDetailGrpc dsiCompositeDetailGrpc = new DSICompositeDetailGrpc();

            dsiCompositeDetailGrpc.Id = compositeDetailGrpc.Id;
            dsiCompositeDetailGrpc.HarnessName1 = compositeDetailGrpc.HarnessName1;
            dsiCompositeDetailGrpc.SimilarHarnessName1 = compositeDetailGrpc.SimilarHarnessName1;
            dsiCompositeDetailGrpc.HarnessIssue1 = compositeDetailGrpc.HarnessIssue1;
            dsiCompositeDetailGrpc.SimilarHarnessIssue1 = compositeDetailGrpc.SimilarHarnessIssue1;
            dsiCompositeDetailGrpc.HarnessDate1 = compositeDetailGrpc.HarnessDate1;
            dsiCompositeDetailGrpc.HarnessName2 = compositeDetailGrpc.HarnessName2;
            dsiCompositeDetailGrpc.SimilarHarnessName2 = compositeDetailGrpc.SimilarHarnessName2;
            dsiCompositeDetailGrpc.HarnessIssue2 = compositeDetailGrpc.HarnessIssue2;
            dsiCompositeDetailGrpc.SimilarHarnessIssue2 = compositeDetailGrpc.SimilarHarnessIssue2;
            dsiCompositeDetailGrpc.HarnessDate2 = compositeDetailGrpc.HarnessDate2;
            dsiCompositeDetailGrpc.Customer = compositeDetailGrpc.Customer;
            dsiCompositeDetailGrpc.Site = compositeDetailGrpc.Site;
            dsiCompositeDetailGrpc.Range = compositeDetailGrpc.Range;
            dsiCompositeDetailGrpc.BoardLength = compositeDetailGrpc.BoardLength;
            dsiCompositeDetailGrpc.BoardWidth = compositeDetailGrpc.BoardWidth;
            dsiCompositeDetailGrpc.Datum = compositeDetailGrpc.Datum;
            dsiCompositeDetailGrpc.UserField1 = compositeDetailGrpc.UserField1;
            dsiCompositeDetailGrpc.UserField2 = compositeDetailGrpc.UserField2;
            dsiCompositeDetailGrpc.UserField3 = compositeDetailGrpc.UserField3;
            dsiCompositeDetailGrpc.UserField4 = compositeDetailGrpc.UserField4;
            dsiCompositeDetailGrpc.UserField5 = compositeDetailGrpc.UserField5;
            dsiCompositeDetailGrpc.Checker = compositeDetailGrpc.Checker;
            dsiCompositeDetailGrpc.Inputter = compositeDetailGrpc.Inputter;
            dsiCompositeDetailGrpc.DraftedBy = compositeDetailGrpc.DraftedBy;
            dsiCompositeDetailGrpc.PreparedBy = compositeDetailGrpc.PreparedBy;
            dsiCompositeDetailGrpc.Type = compositeDetailGrpc.Type;
            dsiCompositeDetailGrpc.Title = compositeDetailGrpc.Title;
            dsiCompositeDetailGrpc.EngineSize = compositeDetailGrpc.EngineSize;
            dsiCompositeDetailGrpc.ManufacturingCell = compositeDetailGrpc.ManufacturingCell;
            dsiCompositeDetailGrpc.Trim = compositeDetailGrpc.Trim;
            dsiCompositeDetailGrpc.HandDrive = compositeDetailGrpc.HandDrive;
            dsiCompositeDetailGrpc.TubeAddOnType = compositeDetailGrpc.TubeAddOnType;
            dsiCompositeDetailGrpc.TubeAddOnFactor = compositeDetailGrpc.TubeAddOnFactor;
            dsiCompositeDetailGrpc.IsManualTerminal = compositeDetailGrpc.IsManualTerminal;
            dsiCompositeDetailGrpc.IsAllConnectorsSealed = compositeDetailGrpc.IsAllConnectorsSealed;
            dsiCompositeDetailGrpc.AlphaCode = compositeDetailGrpc.AlphaCode;
            dsiCompositeDetailGrpc.HarnessID = compositeDetailGrpc.HarnessID;
            dsiCompositeDetailGrpc.CircuitOption = compositeDetailGrpc.CircuitOption;
            dsiCompositeDetailGrpc.CreatedDate = compositeDetailGrpc.CreatedDate;
            dsiCompositeDetailGrpc.ModifiedDate = compositeDetailGrpc.ModifiedDate;
            dsiCompositeDetailGrpc.CreatedBy = compositeDetailGrpc.CreatedBy;
            dsiCompositeDetailGrpc.ModifiedBy = compositeDetailGrpc.ModifiedBy;

            return dsiCompositeDetailGrpc;
        }

        public static DSIWireSpecificationGrpc? ToDSIWireSpecification(this WireSpecificationGrpc wireSpecificationGrpc)
        {
            if (wireSpecificationGrpc == null)
            {
                return null;
            }

            DSIWireSpecificationGrpc dsiWireSpecificationGrpc = new DSIWireSpecificationGrpc();

            dsiWireSpecificationGrpc.Id = wireSpecificationGrpc.Id;

            dsiWireSpecificationGrpc.WireName = wireSpecificationGrpc.WireName;
            dsiWireSpecificationGrpc.WireType = wireSpecificationGrpc.WireType;
            dsiWireSpecificationGrpc.Colour = wireSpecificationGrpc.Colour;
            
            dsiWireSpecificationGrpc.CrossSectionalArea = wireSpecificationGrpc.CrossSectionalArea;
            
            dsiWireSpecificationGrpc.Material = wireSpecificationGrpc.Material;
            
            dsiWireSpecificationGrpc.IsIncludedOnBom = wireSpecificationGrpc.IsIncludedOnBom;
            dsiWireSpecificationGrpc.IsIncludedOnChart = wireSpecificationGrpc.IsIncludedOnChart;

            dsiWireSpecificationGrpc.WireTag = wireSpecificationGrpc.WireTag;
            dsiWireSpecificationGrpc.WireNote = wireSpecificationGrpc.WireNote;

            dsiWireSpecificationGrpc.UnmodifiedWireLength = wireSpecificationGrpc.UnmodifiedWireLength;
            dsiWireSpecificationGrpc.ModifiedWireLength = wireSpecificationGrpc.ModifiedWireLength;

            dsiWireSpecificationGrpc.PartNumber1 = wireSpecificationGrpc.PartNumber1;
            dsiWireSpecificationGrpc.PartNumber2 = wireSpecificationGrpc.PartNumber2;
            dsiWireSpecificationGrpc.PartNumber3 = wireSpecificationGrpc.PartNumber3;

            dsiWireSpecificationGrpc.HarnessID = wireSpecificationGrpc.HarnessID;
            dsiWireSpecificationGrpc.CreatedDate = wireSpecificationGrpc.CreatedDate;
            dsiWireSpecificationGrpc.ModifiedDate = wireSpecificationGrpc.ModifiedDate;
            dsiWireSpecificationGrpc.Compositeoptionstring = wireSpecificationGrpc.Compositeoptionstring;

            dsiWireSpecificationGrpc.End1NodeName = wireSpecificationGrpc.End1NodeName;
            dsiWireSpecificationGrpc.End2NodeName = wireSpecificationGrpc.End2NodeName;

            //dsiWireSpecificationGrpc.UserModule = wireSpecificationGrpc.UserModule;
            //dsiWireSpecificationGrpc.MulticoreName = wireSpecificationGrpc.MulticoreName;
            //dsiWireSpecificationGrpc.End1Route = wireSpecificationGrpc.End1Route;
            //dsiWireSpecificationGrpc.End1Cavity = wireSpecificationGrpc.End1Cavity;
            //dsiWireSpecificationGrpc.End1MaterialCode = wireSpecificationGrpc.End1MaterialCode;
            //dsiWireSpecificationGrpc.End2Route = wireSpecificationGrpc.End2Route;
            //dsiWireSpecificationGrpc.End2Cavity = wireSpecificationGrpc.End2Cavity;
            //dsiWireSpecificationGrpc.End2MaterialCode = wireSpecificationGrpc.End2MaterialCode;
            //dsiWireSpecificationGrpc.WireLengthChangeType = wireSpecificationGrpc.WireLengthChangeType;
            //dsiWireSpecificationGrpc.WireLengthChangeValue = wireSpecificationGrpc.WireLengthChangeValue;
            //dsiWireSpecificationGrpc.AssemblyItemNumber = wireSpecificationGrpc.AssemblyItemNumber;
            //dsiWireSpecificationGrpc.MulticoreOption = wireSpecificationGrpc.MulticoreOption;
            //dsiWireSpecificationGrpc.CutbackAtEnd1 = wireSpecificationGrpc.CutbackAtEnd1;
            //dsiWireSpecificationGrpc.CutbackAtEnd2 = wireSpecificationGrpc.CutbackAtEnd2;
            //dsiWireSpecificationGrpc.Signal = wireSpecificationGrpc.Signal;
            //dsiWireSpecificationGrpc.CreatedBy = wireSpecificationGrpc.CreatedBy;
            //dsiWireSpecificationGrpc.ModifiedBy = wireSpecificationGrpc.ModifiedBy;

            return dsiWireSpecificationGrpc;
        }
    }
}
