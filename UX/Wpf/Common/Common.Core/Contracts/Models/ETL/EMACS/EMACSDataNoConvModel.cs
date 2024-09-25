using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.EMACS
{
    [DataContract, Serializable]
    public class EMACSDataNoConvModel : ExternalDataSourceModel<long>
    {
        private double? _partCode;
        [DataMember, Key, Column("Part Code")]
        public double? PartCode
        {
            get => _partCode;
            set => SetProperty(ref _partCode, value);
        }

        private string _projectCode;
        [DataMember, Column("Project Code")]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        private string _partsManagementCode;
        [DataMember, Column("Parts Management Code")]
        public string PartsManagementCode
        {
            get => _partsManagementCode;
            set => SetProperty(ref _partsManagementCode, value);
        }

        private double? _phase;
        [DataMember]
        public double? Phase
        {
            get => _phase;
            set => SetProperty(ref _phase, value);
        }

        private double? _f5;
        [DataMember]
        public double? F5
        {
            get => _f5;
            set => SetProperty(ref _f5, value);
        }

        private double? _phaseNumber;
        [DataMember, Column("Phase Number")]
        public double? PhaseNumber
        {
            get => _phaseNumber;
            set => SetProperty(ref _phaseNumber, value);
        }

        private double? _designChangeNumberOfIssues;
        [DataMember, Column("Design Change Number of Issues")]
        public double? DesignChangeNumberOfIssues
        {
            get => _designChangeNumberOfIssues;
            set => SetProperty(ref _designChangeNumberOfIssues, value);
        }

        private string _cadManagementCode;
        [DataMember, Column("CAD Management Code")]
        public string CADManagementCode
        {
            get => _cadManagementCode;
            set => SetProperty(ref _cadManagementCode, value);
        }

        private string _tNumber;
        [DataMember, Column("T Number")]
        public string TNumber
        {
            get => _tNumber;
            set => SetProperty(ref _tNumber, value);
        }

        private string _designChangeNotificationNumber;
        [DataMember, Column("Design Change Notification Number")]
        public string DesignChangeNotificationNumber
        {
            get => _designChangeNotificationNumber;
            set => SetProperty(ref _designChangeNotificationNumber, value);
        }

        private string _outputNameJP;
        [DataMember, Column("Output Name (JP)")]
        public string OutputNameJP
        {
            get => _outputNameJP;
            set => SetProperty(ref _outputNameJP, value);
        }

        private string _outputNameEN;
        [DataMember, Column("Output Name (EN)")]
        public string OutputNameEN
        {
            get => _outputNameEN;
            set => SetProperty(ref _outputNameEN, value);
        }

        private string _state;
        [DataMember]
        public string State
        {
            get => _state;
            set => SetProperty(ref _state, value);
        }

        private double? _assemblyConstructionDivision;
        [DataMember, Column("Assembly Construction Division")]
        public double? AssemblyConstructionDivision
        {
            get => _assemblyConstructionDivision;
            set => SetProperty(ref _assemblyConstructionDivision, value);
        }

        private double? _deleteFlag;
        [DataMember, Column("Delete Flag")]
        public double? DeleteFlag
        {
            get => _deleteFlag;
            set => SetProperty(ref _deleteFlag, value);
        }

        private DateTime? _dateOfIssue;
        [DataMember, Column("Date of Issue")]
        public DateTime? DateOfIssue
        {
            get => _dateOfIssue;
            set => SetProperty(ref _dateOfIssue, value);
        }

        private double? _issueNumber;
        [DataMember, Column("Issue Number")]
        public double? IssueNumber
        {
            get => _issueNumber;
            set => SetProperty(ref _issueNumber, value);
        }

        private double? _f18;
        [DataMember]
        public double? F18
        {
            get => _f18;
            set => SetProperty(ref _f18, value);
        }

        private string _supportToDistinguish;
        [DataMember, Column("Support to Distinguish")]
        public string SupportToDistinguish
        {
            get => _supportToDistinguish;
            set => SetProperty(ref _supportToDistinguish, value);
        }

        private double? _f20;
        [DataMember]
        public double? F20
        {
            get => _f20;
            set => SetProperty(ref _f20, value);
        }

        private string _classCode1;
        [DataMember, Column("Class Code 1")]
        public string ClassCode1
        {
            get => _classCode1;
            set => SetProperty(ref _classCode1, value);
        }

        private double? _classCode2;
        [DataMember, Column("Class Code 2")]
        public double? ClassCode2
        {
            get => _classCode2;
            set => SetProperty(ref _classCode2, value);
        }

        private string _recommendation;
        [DataMember]
        public string Recommendation
        {
            get => _recommendation;
            set => SetProperty(ref _recommendation, value);
        }

        private string _partSeriesCode;
        [DataMember, Column("Part Series Code")]
        public string PartSeriesCode
        {
            get => _partSeriesCode;
            set => SetProperty(ref _partSeriesCode, value);
        }

        private string _connectorClassification;
        [DataMember, Column("Connector Classification")]
        public string ConnectorClassification
        {
            get => _connectorClassification;
            set => SetProperty(ref _connectorClassification, value);
        }

        private double? _materialCode1;
        [DataMember, Column("Material Code 1")]
        public double? MaterialCode1
        {
            get => _materialCode1;
            set => SetProperty(ref _materialCode1, value);
        }

        private double? _materialCode2;
        [DataMember, Column("Material Code 2")]
        public double? MaterialCode2
        {
            get => _materialCode2;
            set => SetProperty(ref _materialCode2, value);
        }

        private string _colour;
        [DataMember]
        public string Colour
        {
            get => _colour;
            set => SetProperty(ref _colour, value);
        }

        private string _partItemCode;
        [DataMember, Column("Part Item Code")]
        public string PartItemCode
        {
            get => _partItemCode;
            set => SetProperty(ref _partItemCode, value);
        }

        private double? _userClassification;
        [DataMember, Column("User Classification")]
        public double? UserClassification
        {
            get => _userClassification;
            set => SetProperty(ref _userClassification, value);
        }

        private double? _userCode;
        [DataMember, Column("User Code")]
        public double? UserCode
        {
            get => _userCode;
            set => SetProperty(ref _userCode, value);
        }

        private string _userPartNumber;
        [DataMember, Column("User Part Number")]
        public string UserPartNumber
        {
            get => _userPartNumber;
            set => SetProperty(ref _userPartNumber, value);
        }

        private string _userColourSymbol;
        [DataMember, Column("User Colour Symbol")]
        public string UserColourSymbol
        {
            get => _userColourSymbol;
            set => SetProperty(ref _userColourSymbol, value);
        }

        private string _userPartsName;
        [DataMember, Column("User Parts Name")]
        public string UserPartsName
        {
            get => _userPartsName;
            set => SetProperty(ref _userPartsName, value);
        }

        private string _customerStandardColour;
        [DataMember, Column("Customer Standard Colour")]
        public string CustomerStandardColour
        {
            get => _customerStandardColour;
            set => SetProperty(ref _customerStandardColour, value);
        }

        private string _standardColour;
        [DataMember, Column("Standard Colour")]
        public string StandardColour
        {
            get => _standardColour;
            set => SetProperty(ref _standardColour, value);
        }

        private double? _f37;
        [DataMember]
        public double? F37
        {
            get => _f37;
            set => SetProperty(ref _f37, value);
        }

        private string _userRequestFormNumber;
        [DataMember, Column("Uer Request Form Number")]
        public string UserRequestFormNumber
        {
            get => _userRequestFormNumber;
            set => SetProperty(ref _userRequestFormNumber, value);
        }

        private string _connectorType1;
        [DataMember, Column("Connector Type 1")]
        public string ConnectorType1
        {
            get => _connectorType1;
            set => SetProperty(ref _connectorType1, value);
        }

        private double? _connectorNumberOfCavitiesType1;
        [DataMember, Column("Connector Number of Cavities Type 1")]
        public double? ConnectorNumberOfCavitiesType1
        {
            get => _connectorNumberOfCavitiesType1;
            set => SetProperty(ref _connectorNumberOfCavitiesType1, value);
        }

        private string _connectorType2;
        [DataMember, Column("Connector Type 2")]
        public string ConnectorType2
        {
            get => _connectorType2;
            set => SetProperty(ref _connectorType2, value);
        }

        private string _connectorNumberOfCavitiesType2;
        [DataMember, Column("Connector Number of Cavities Type 2")]
        public string ConnectorNumberOfCavitiesType2
        {
            get => _connectorNumberOfCavitiesType2;
            set => SetProperty(ref _connectorNumberOfCavitiesType2, value);
        }

        private string _connectorType3;
        [DataMember, Column("Connector Type 3")]
        public string ConnectorType3
        {
            get => _connectorType3;
            set => SetProperty(ref _connectorType3, value);
        }

        private string _connectorNumberOfCavitiesType3;
        [DataMember, Column("Connector Number of Cavities Type 3")]
        public string ConnectorNumberOfCavitiesType3
        {
            get => _connectorNumberOfCavitiesType3;
            set => SetProperty(ref _connectorNumberOfCavitiesType3, value);
        }

        private string _connectorType4;
        [DataMember, Column("Connector Type 4")]
        public string ConnectorType4
        {
            get => _connectorType4;
            set => SetProperty(ref _connectorType4, value);
        }

        private string _connectorNumberOfCavitiesType4;
        [DataMember, Column("Connector Number of Cavities Type 4")]
        public string ConnectorNumberOfCavitiesType4
        {
            get => _connectorNumberOfCavitiesType4;
            set => SetProperty(ref _connectorNumberOfCavitiesType4, value);
        }

        private string _connectorType5;
        [DataMember, Column("Connector Type 5")]
        public string ConnectorType5
        {
            get => _connectorType5;
            set => SetProperty(ref _connectorType5, value);
        }

        private string _connectorNumberOfCavitiesType5;
        [DataMember, Column("Connector Number of Cavities Type 5")]
        public string ConnectorNumberOfCavitiesType5
        {
            get => _connectorNumberOfCavitiesType5;
            set => SetProperty(ref _connectorNumberOfCavitiesType5, value);
        }

        private double? _connectorTotalNumberOfCavities;
        [DataMember, Column("Connector Total Number of Cavities")]
        public double? ConnectorTotalNumberOfCavities
        {
            get => _connectorTotalNumberOfCavities;
            set => SetProperty(ref _connectorTotalNumberOfCavities, value);
        }

        private double? _terminalTabWidth;
        [DataMember, Column("Terminal Tab Width")]
        public double? TerminalTabWidth
        {
            get => _terminalTabWidth;
            set => SetProperty(ref _terminalTabWidth, value);
        }

        private string _waterproofOrNonWaterproof;
        [DataMember, Column("Waterproof or Non-Waterproof")]
        public string WaterproofOrNonWaterproof
        {
            get => _waterproofOrNonWaterproof;
            set => SetProperty(ref _waterproofOrNonWaterproof, value);
        }

        private string _maleFemaleOtherClassification;
        [DataMember, Column("Male and Female (Other) Classification")]
        public string MaleFemaleOtherClassification
        {
            get => _maleFemaleOtherClassification;
            set => SetProperty(ref _maleFemaleOtherClassification, value);
        }

        private string _platingWithoutClassification;
        [DataMember, Column("Plating without Classification")]
        public string PlatingWithoutClassification
        {
            get => _platingWithoutClassification;
            set => SetProperty(ref _platingWithoutClassification, value);
        }

        private string _basePlatingType;
        [DataMember, Column("Base Plating Type")]
        public string BasePlatingType
        {
            get => _basePlatingType;
            set => SetProperty(ref _basePlatingType, value);
        }

        private string _platingMethod;
        [DataMember, Column("Plating Method")]
        public string PlatingMethod
        {
            get => _platingMethod;
            set => SetProperty(ref _platingMethod, value);
        }

        private string _surfacePlatingType1;
        [DataMember, Column("Surface Plating Tpe 1")]
        public string SurfacePlatingType1
        {
            get => _surfacePlatingType1;
            set => SetProperty(ref _surfacePlatingType1, value);
        }

        private string _platingMethod1;
        [DataMember, Column("Plating Method 1")]
        public string PlatingMethod1
        {
            get => _platingMethod1;
            set => SetProperty(ref _platingMethod1, value);
        }

        private string _surfacePlatingType2;
        [DataMember, Column("Surface Plating Tpe 2")]
        public string SurfacePlatingType2
        {
            get => _surfacePlatingType2;
            set => SetProperty(ref _surfacePlatingType2, value);
        }

        private string _platingMethod2;
        [DataMember, Column("Plating Method 2")]
        public string PlatingMethod2
        {
            get => _platingMethod2;
            set => SetProperty(ref _platingMethod2, value);
        }

        private string _surfacePlatingType3;
        [DataMember, Column("Surface Plating Tpe 3")]
        public string SurfacePlatingType3
        {
            get => _surfacePlatingType3;
            set => SetProperty(ref _surfacePlatingType3, value);
        }

        private string _platingMethod3;
        [DataMember, Column("Plating Method 3")]
        public string PlatingMethod3
        {
            get => _platingMethod3;
            set => SetProperty(ref _platingMethod3, value);
        }

        private double? _designQuality;
        [DataMember, Column("Design Quality")]
        public double? DesignQuality
        {
            get => _designQuality;
            set => SetProperty(ref _designQuality, value);
        }

        private double? _mass;
        [DataMember]
        public double? Mass
        {
            get => _mass;
            set => SetProperty(ref _mass, value);
        }

        private double? _id;
        [DataMember, Column("I/D")]
        public double? ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private double? _wallThickness;
        [DataMember, Column("Wall Thickness")]
        public double? WallThickness
        {
            get => _wallThickness;
            set => SetProperty(ref _wallThickness, value);
        }

        private double? _length;
        [DataMember]
        public double? Length
        {
            get => _length;
            set => SetProperty(ref _length, value);
        }

        private double? _widthAndOD;
        [DataMember, Column("Width and O/D")]
        public double? WidthAndOD
        {
            get => _widthAndOD;
            set => SetProperty(ref _widthAndOD, value);
        }

        private double? _tapeWindingPointNumber;
        [DataMember, Column("Tape Winding Point Number")]
        public double? TapeWindingPointNumber
        {
            get => _tapeWindingPointNumber;
            set => SetProperty(ref _tapeWindingPointNumber, value);
        }

        private double? _tapeStretchRatioLength;
        [DataMember, Column("Tape Stretch Ratio (Length)")]
        public double? TapeStretchRatioLength
        {
            get => _tapeStretchRatioLength;
            set => SetProperty(ref _tapeStretchRatioLength, value);
        }

        private double? _tapeStretchRatioWidth;
        [DataMember, Column("Tape Stretch Ratio (Width)")]
        public double? TapeStretchRatioWidth
        {
            get => _tapeStretchRatioWidth;
            set => SetProperty(ref _tapeStretchRatioWidth, value);
        }

        private double? _l1;
        [DataMember]
        public double? L1
        {
            get => _l1;
            set => SetProperty(ref _l1, value);
        }

        private double? _l2;
        [DataMember]
        public double? L2
        {
            get => _l2;
            set => SetProperty(ref _l2, value);
        }

        private double? _l3;
        [DataMember]
        public double? L3
        {
            get => _l3;
            set => SetProperty(ref _l3, value);
        }

        private string _rubberStopperMaterialClassification;
        [DataMember, Column("Rubber Stopper Material Classification")]
        public string RubberStopperMaterialClassification
        {
            get => _rubberStopperMaterialClassification;
            set => SetProperty(ref _rubberStopperMaterialClassification, value);
        }

        private double? _waterproofRubberPlugNumberOfHoles;
        [DataMember, Column("Waterproof Rubber plug Number of Holes")]
        public double? WaterproofRubberPlugNumberOfHoles
        {
            get => _waterproofRubberPlugNumberOfHoles;
            set => SetProperty(ref _waterproofRubberPlugNumberOfHoles, value);
        }

        private string _abbreviations;
        [DataMember]
        public string Abbreviations
        {
            get => _abbreviations;
            set => SetProperty(ref _abbreviations, value);
        }

        private string _f77;
        [DataMember]
        public string F77
        {
            get => _f77;
            set => SetProperty(ref _f77, value);
        }

        private double? _pitchWidth;
        [DataMember, Column("Pitch Width")]
        public double? PitchWidth
        {
            get => _pitchWidth;
            set => SetProperty(ref _pitchWidth, value);
        }

        private double? _laleTerminalHoleDiameter;
        [DataMember, Column("LA/LE Terminal Hole Diameter")]
        public double? LALETerminalHoleDiameter
        {
            get => _laleTerminalHoleDiameter;
            set => SetProperty(ref _laleTerminalHoleDiameter, value);
        }

        private double? _slope;
        [DataMember]
        public double? Slope
        {
            get => _slope;
            set => SetProperty(ref _slope, value);
        }

        private double? _tapeLength;
        [DataMember, Column("Tape Length")]
        public double? TapeLength
        {
            get => _tapeLength;
            set => SetProperty(ref _tapeLength, value);
        }

        private double? _greaseAmountEmptyHousing;
        [DataMember, Column("Grease Amount (Empty Housing)")]
        public double? GreaseAmountEmptyHousing
        {
            get => _greaseAmountEmptyHousing;
            set => SetProperty(ref _greaseAmountEmptyHousing, value);
        }

        private double? _greaseAmountTerminalInsertion;
        [DataMember, Column("Grease Amount (Terminal Insertion)")]
        public double? GreaseAmountTerminalInsertion
        {
            get => _greaseAmountTerminalInsertion;
            set => SetProperty(ref _greaseAmountTerminalInsertion, value);
        }

        private double? _partsLength;
        [DataMember, Column("Parts Length")]
        public double? PartsLength
        {
            get => _partsLength;
            set => SetProperty(ref _partsLength, value);
        }

        private double? _cotNumberOfHoles;
        [DataMember, Column("COT Number of Holes")]
        public double? COTNumberOfHoles
        {
            get => _cotNumberOfHoles;
            set => SetProperty(ref _cotNumberOfHoles, value);
        }

        private string _fixedGraphicTypeDeterminatioDivision;
        [DataMember, Column("Fixed Graphic Type Determination Division")]
        public string FixedGraphicTypeDeterminatioDivision
        {
            get => _fixedGraphicTypeDeterminatioDivision;
            set => SetProperty(ref _fixedGraphicTypeDeterminatioDivision, value);
        }

        private string _messageArticle1;
        [DataMember, Column("Message (Article) 1")]
        public string MessageArticle1
        {
            get => _messageArticle1;
            set => SetProperty(ref _messageArticle1, value);
        }

        private string _partsLayerByCategory1;
        [DataMember, Column("Parts Layer by Category 1")]
        public string PartsLayerByCategory1
        {
            get => _partsLayerByCategory1;
            set => SetProperty(ref _partsLayerByCategory1, value);
        }

        private string _partsLayerByCategory2;
        [DataMember, Column("Parts Layer by Category 2")]
        public string PartsLayerByCategory2
        {
            get => _partsLayerByCategory2;
            set => SetProperty(ref _partsLayerByCategory2, value);
        }

        private string _partsLayerByCategory3;
        [DataMember, Column("Parts Layer by Category 3")]
        public string PartsLayerByCategory3
        {
            get => _partsLayerByCategory3;
            set => SetProperty(ref _partsLayerByCategory3, value);
        }

        private string _partsLayerByCategory4;
        [DataMember, Column("Parts Layer by Category 4")]
        public string PartsLayerByCategory4
        {
            get => _partsLayerByCategory4;
            set => SetProperty(ref _partsLayerByCategory4, value);
        }

        private string _partsLayerByCategory5;
        [DataMember, Column("Parts Layer by Category 5")]
        public string PartsLayerByCategory5
        {
            get => _partsLayerByCategory5;
            set => SetProperty(ref _partsLayerByCategory5, value);
        }

        private string _partsLayerByCategory6;
        [DataMember, Column("Parts Layer by Category 6")]
        public string PartsLayerByCategory6
        {
            get => _partsLayerByCategory6;
            set => SetProperty(ref _partsLayerByCategory6, value);
        }

        private string _partsLayerByCategory7;
        [DataMember, Column("Parts Layer by Category 7")]
        public string PartsLayerByCategory7
        {
            get => _partsLayerByCategory7;
            set => SetProperty(ref _partsLayerByCategory7, value);
        }

        private string _partsLayerByCategory8;
        [DataMember, Column("Parts Layer by Category 8")]
        public string PartsLayerByCategory8
        {
            get => _partsLayerByCategory8;
            set => SetProperty(ref _partsLayerByCategory8, value);
        }

        private string _requestedProcedureNumber;
        [DataMember, Column("Requested Procedure No")]
        public string RequestedProcedureNumber
        {
            get => _requestedProcedureNumber;
            set => SetProperty(ref _requestedProcedureNumber, value);
        }

        private double? _targetPriceUserTarget;
        [DataMember, Column("Target Price (User Target)")]
        public double? TargetPriceUserTarget
        {
            get => _targetPriceUserTarget;
            set => SetProperty(ref _targetPriceUserTarget, value);
        }

        private double? _otherComaptMarketingApplications;
        [DataMember, Column("Other Comapt Marketing Applications")]
        public double? OtherComaptMarketingApplications
        {
            get => _otherComaptMarketingApplications;
            set => SetProperty(ref _otherComaptMarketingApplications, value);
        }

        private string _electronicComponentPackage;
        [DataMember, Column("Electronic Component Package")]
        public string ElectronicComponentPackage
        {
            get => _electronicComponentPackage;
            set => SetProperty(ref _electronicComponentPackage, value);
        }

        private string _compatibleWithTargetComponentCode;
        [DataMember, Column("Compatible with Target Component Code")]
        public string CompatibleWithTargetComponentCode
        {
            get => _compatibleWithTargetComponentCode;
            set => SetProperty(ref _compatibleWithTargetComponentCode, value);
        }

        private double? _goldTypeNecessity;
        [DataMember, Column("Gold Type Necessity")]
        public double? GoldTypeNecessity
        {
            get => _goldTypeNecessity;
            set => SetProperty(ref _goldTypeNecessity, value);
        }

        private string _toolingClassificationTrialAndQuantitySettingChange;
        [DataMember, Column("Tooling Classification (Trial and Quantity Setting Change)")]
        public string ToolingClassificationTrialAndQuantitySettingChange
        {
            get => _toolingClassificationTrialAndQuantitySettingChange;
            set => SetProperty(ref _toolingClassificationTrialAndQuantitySettingChange, value);
        }

        private string _toolingClassificationNewModifyExisting;
        [DataMember, Column("Tooling Classification (New/Modify/Existing)")]
        public string ToolingClassificationNewModifyExisting
        {
            get => _toolingClassificationNewModifyExisting;
            set => SetProperty(ref _toolingClassificationNewModifyExisting, value);
        }

        private double? _targetCostLessDepreciation;
        [DataMember, Column("Target Cost (Less Depreciation)")]
        public double? TargetCostLessDepreciation
        {
            get => _targetCostLessDepreciation;
            set => SetProperty(ref _targetCostLessDepreciation, value);
        }

        private double? _desiredFeeType;
        [DataMember, Column("Desired Fee Type")]
        public double? DesiredFeeType
        {
            get => _desiredFeeType;
            set => SetProperty(ref _desiredFeeType, value);
        }

        private string _desiredEquipmentCost;
        [DataMember, Column("Desired Equipment Cost")]
        public string DesiredEquipmentCost
        {
            get => _desiredEquipmentCost;
            set => SetProperty(ref _desiredEquipmentCost, value);
        }

        private double? _desiredAccessType;
        [DataMember, Column("Desired Access Type")]
        public double? DesiredAccessType
        {
            get => _desiredAccessType;
            set => SetProperty(ref _desiredAccessType, value);
        }

        private double? _desiredProfileNumber;
        [DataMember, Column("Desired Profile Number")]
        public double? DesiredProfileNumber
        {
            get => _desiredProfileNumber;
            set => SetProperty(ref _desiredProfileNumber, value);
        }

        private double? _internalAndExternalDecision;
        [DataMember, Column("Internal and External Decision")]
        public double? InternalAndExternalDecision
        {
            get => _internalAndExternalDecision;
            set => SetProperty(ref _internalAndExternalDecision, value);
        }

        private string _determinationReason;
        [DataMember, Column("Determination Reason")]
        public string DeterminationReason
        {
            get => _determinationReason;
            set => SetProperty(ref _determinationReason, value);
        }

        private string _judgementReason;
        [DataMember, Column("Judgement Reason")]
        public string JudgementReason
        {
            get => _judgementReason;
            set => SetProperty(ref _judgementReason, value);
        }

        private string _initialPurchase;
        [DataMember, Column("Initial Purchase")]
        public string InitialPurchase
        {
            get => _initialPurchase;
            set => SetProperty(ref _initialPurchase, value);
        }

        private DateTime? _massProductionLeadTimeHarness;
        [DataMember, Column("Mass Production Lead Time (Harness)")]
        public DateTime? MassProductionLeadTimeHarness
        {
            get => _massProductionLeadTimeHarness;
            set => SetProperty(ref _massProductionLeadTimeHarness, value);
        }

        private DateTime? _massProductionLeadTimeUsers;
        [DataMember, Column("Mass Production Lead Time (Users)")]
        public DateTime? MassProductionLeadTimeUsers
        {
            get => _massProductionLeadTimeUsers;
            set => SetProperty(ref _massProductionLeadTimeUsers, value);
        }

        private DateTime? _initialPaymentPeriodDesignReview;
        [DataMember, Column("Initial Payment Period (Design Review)")]
        public DateTime? InitialPaymentPeriodDesignReview
        {
            get => _initialPaymentPeriodDesignReview;
            set => SetProperty(ref _initialPaymentPeriodDesignReview, value);
        }

        private double? _initialOrderQuantity;
        [DataMember, Column("Initial Order Quantity")]
        public double? InitialOrderQuantity
        {
            get => _initialOrderQuantity;
            set => SetProperty(ref _initialOrderQuantity, value);
        }

        private double? _unit;
        [DataMember]
        public double? Unit
        {
            get => _unit;
            set => SetProperty(ref _unit, value);
        }

        private double? _harnessNumberOf;
        [DataMember, Column("Harness Number of")]
        public double? HarnessNumberOf
        {
            get => _harnessNumberOf;
            set => SetProperty(ref _harnessNumberOf, value);
        }

        private double? _harnessDirectSalesNumber;
        [DataMember, Column("Harness direct sales number")]
        public double? HarnessDirectSalesNumber
        {
            get => _harnessDirectSalesNumber;
            set => SetProperty(ref _harnessDirectSalesNumber, value);
        }

        private double? _sinceTheNecessaryNumberOfTraders;
        [DataMember, Column("Since the necessary number of traders")]
        public double? SinceTheNecessaryNumberOfTraders
        {
            get => _sinceTheNecessaryNumberOfTraders;
            set => SetProperty(ref _sinceTheNecessaryNumberOfTraders, value);
        }

        private double? _totalNumber;
        [DataMember, Column("Total number")]
        public double? TotalNumber
        {
            get => _totalNumber;
            set => SetProperty(ref _totalNumber, value);
        }

        private double? _theMaximumRequiredNumber;
        [DataMember, Column("The maximum required number")]
        public double? TheMaximumRequiredNumber
        {
            get => _theMaximumRequiredNumber;
            set => SetProperty(ref _theMaximumRequiredNumber, value);
        }

        private string _toInvestigateWhetherEnvironmentallyHazardousSubstances;
        [DataMember, Column("To investigate whether environmentally hazardous substances")]
        public string ToInvestigateWhetherEnvironmentallyHazardousSubstances
        {
            get => _toInvestigateWhetherEnvironmentallyHazardousSubstances;
            set => SetProperty(ref _toInvestigateWhetherEnvironmentallyHazardousSubstances, value);
        }

        private string _operatingZoneInformation;
        [DataMember, Column("Operating zone information")]
        public string OperatingZoneInformation
        {
            get => _operatingZoneInformation;
            set => SetProperty(ref _operatingZoneInformation, value);
        }

        private string _naisPartNumber;
        [DataMember, Column("NAIS Part Number")]
        public string NAISPartNumber
        {
            get => _naisPartNumber;
            set => SetProperty(ref _naisPartNumber, value);
        }

        private string _bpcsPartNumber;
        [DataMember, Column("BPCS Part Number")]
        public string BPCSPartNumber
        {
            get => _bpcsPartNumber;
            set => SetProperty(ref _bpcsPartNumber, value);
        }

        private string _csLocationCode;
        [DataMember, Column("CS Location Code")]
        public string CSLocationCode
        {
            get => _csLocationCode;
            set => SetProperty(ref _csLocationCode, value);
        }

        private string _csSiteCode;
        [DataMember, Column("CS Site Code")]
        public string CSSiteCode
        {
            get => _csSiteCode;
            set => SetProperty(ref _csSiteCode, value);
        }

        private string _csBreedCode;
        [DataMember, Column("CS Breed Code")]
        public string CSBreedCode
        {
            get => _csBreedCode;
            set => SetProperty(ref _csBreedCode, value);
        }

        private string _csRawMaterialInformation;
        [DataMember, Column("CS raw material information")]
        public string CSRawMaterialInformation
        {
            get => _csRawMaterialInformation;
            set => SetProperty(ref _csRawMaterialInformation, value);
        }

        private string _csConfigurationDivision;
        [DataMember, Column("CS configuration division")]
        public string CSConfigurationDivision
        {
            get => _csConfigurationDivision;
            set => SetProperty(ref _csConfigurationDivision, value);
        }

        private string _csManufacturingDistinction;
        [DataMember, Column("CS Manufacturing distinction")]
        public string CSManufacturingDistinction
        {
            get => _csManufacturingDistinction;
            set => SetProperty(ref _csManufacturingDistinction, value);
        }

        private string _supplierPartNumber;
        [DataMember, Column("Supplier Part Number")]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => SetProperty(ref _supplierPartNumber, value);
        }

        private string _partCodeAutomaticSettingCategory1;
        [DataMember, Column("Part code automatic setting Category 1")]
        public string PartCodeAutomaticSettingCategory1
        {
            get => _partCodeAutomaticSettingCategory1;
            set => SetProperty(ref _partCodeAutomaticSettingCategory1, value);
        }

        private string _partCodeAutomaticSettingCategory2;
        [DataMember, Column("Part code automatic setting Category 2")]
        public string PartCodeAutomaticSettingCategory2
        {
            get => _partCodeAutomaticSettingCategory2;
            set => SetProperty(ref _partCodeAutomaticSettingCategory2, value);
        }

        private double? _partCodeAutomaticSettingCategory3;
        [DataMember, Column("Part code automatic setting Category 3")]
        public double? PartCodeAutomaticSettingCategory3
        {
            get => _partCodeAutomaticSettingCategory3;
            set => SetProperty(ref _partCodeAutomaticSettingCategory3, value);
        }

        private double? _f137;
        [DataMember]
        public double? F137
        {
            get => _f137;
            set => SetProperty(ref _f137, value);
        }

        private double? _f138;
        [DataMember]
        public double? F138
        {
            get => _f138;
            set => SetProperty(ref _f138, value);
        }

        private string _motorSales;
        [DataMember, Column("Motor Sales")]
        public string MotorSales
        {
            get => _motorSales;
            set => SetProperty(ref _motorSales, value);
        }

        private string _storagePeriodSettingFlag;
        [DataMember, Column("Storage period setting flag")]
        public string StoragePeriodSettingFlag
        {
            get => _motorSales;
            set => SetProperty(ref _motorSales, value);
        }

        private double? _registrantID;
        [DataMember, Column("Registrant ID")]
        public double? RegistrantID
        {
            get => _registrantID;
            set => SetProperty(ref _registrantID, value);
        }

        private string _registrationNameJapanese;
        [DataMember, Column("Registration name (Japanese)")]
        public string RegistrationNameJapanese
        {
            get => _registrationNameJapanese;
            set => SetProperty(ref _registrationNameJapanese, value);
        }

        private string _registrationNameEnglish;
        [DataMember, Column("Registration name (English)")]
        public string RegistrationNameEnglish
        {
            get => _registrationNameEnglish;
            set => SetProperty(ref _registrationNameEnglish, value);
        }

        private double? _registrantDepartmentCode;
        [DataMember, Column("Registrant department code")]
        public double? RegistrantDepartmentCode
        {
            get => _registrantDepartmentCode;
            set => SetProperty(ref _registrantDepartmentCode, value);
        }

        private string _registrantDepartmentNameJapanese;
        [DataMember, Column("Registrant department name (Japanese)")]
        public string RegistrantDepartmentNameJapanese
        {
            get => _registrantDepartmentNameJapanese;
            set => SetProperty(ref _registrantDepartmentNameJapanese, value);
        }

        private string _registrantDepartmentNameEnglish;
        [DataMember, Column("Registrant department name (English)")]
        public string RegistrantDepartmentNameEnglish
        {
            get => _registrantDepartmentNameEnglish;
            set => SetProperty(ref _registrantDepartmentNameEnglish, value);
        }

        private DateTime? _registrationDate;
        [DataMember, Column("Registration date")]
        public DateTime? RegistrationDate
        {
            get => _registrationDate;
            set => SetProperty(ref _registrationDate, value);
        }

        private double? _updatesID;
        [DataMember, Column("Update's ID")]
        public double? UpdatesID
        {
            get => _updatesID;
            set => SetProperty(ref _updatesID, value);
        }

        private string _updatesNameJapanese;
        [DataMember, Column("Update's name (Japanese)")]
        public string UpdatesNameJapanese
        {
            get => _updatesNameJapanese;
            set => SetProperty(ref _updatesNameJapanese, value);
        }

        private string _updatesNameEnglish;
        [DataMember, Column("Update's name (English)")]
        public string UpdatesNameEnglish
        {
            get => _updatesNameEnglish;
            set => SetProperty(ref _updatesNameEnglish, value);
        }

        private double? _updatesDepartmentCode;
        [DataMember, Column("Update's department code")]
        public double? UpdatesDepartmentCode
        {
            get => _updatesDepartmentCode;
            set => SetProperty(ref _updatesDepartmentCode, value);
        }

        private string _updatedByDepartmentNameJapanese;
        [DataMember, Column("Updated by department name (Japanese)")]
        public string UpdatedByDepartmentNameJapanese
        {
            get => _updatedByDepartmentNameJapanese;
            set => SetProperty(ref _updatedByDepartmentNameJapanese, value);
        }

        private string _updatedByDepartmentNameEnglish;
        [DataMember, Column("Updated by department name (English)")]
        public string UpdatedByDepartmentNameEnglish
        {
            get => _updatedByDepartmentNameEnglish;
            set => SetProperty(ref _updatedByDepartmentNameEnglish, value);
        }

        private DateTime? _updatedDate;
        [DataMember, Column("Updated Date")]
        public DateTime? UpdatedDate
        {
            get => _updatedDate;
            set => SetProperty(ref _updatedDate, value);
        }

        private double? _swsPersonnelCode;
        [DataMember, Column("SWS personnel code")]
        public double? SWSPersonnelCode
        {
            get => _swsPersonnelCode;
            set => SetProperty(ref _swsPersonnelCode, value);
        }

        private string _swsContactNameJapanese;
        [DataMember, Column("SWS contact name (Japanese)")]
        public string SWSContactNameJapanese
        {
            get => _swsContactNameJapanese;
            set => SetProperty(ref _swsContactNameJapanese, value);
        }

        private string _swsContactNameEnglish;
        [DataMember, Column("SWS contact name (English)")]
        public string SWSContactNameEnglish
        {
            get => _swsContactNameEnglish;
            set => SetProperty(ref _swsContactNameEnglish, value);
        }

        private double? _swsDepartmentCode;
        [DataMember, Column("SWS department code")]
        public double? SWSDepartmentCode
        {
            get => _swsDepartmentCode;
            set => SetProperty(ref _swsDepartmentCode, value);
        }

        private string _swsDepartmentNameJapanese;
        [DataMember, Column("SWS department name (Japanese)")]
        public string SWSDepartmentNameJapanese
        {
            get => _swsDepartmentNameJapanese;
            set => SetProperty(ref _swsDepartmentNameJapanese, value);
        }

        private string _swsDepartmentNameEnglish;
        [DataMember, Column("SWS department name (English)")]
        public string SWSDepartmentNameEnglish
        {
            get => _swsDepartmentNameEnglish;
            set => SetProperty(ref _swsDepartmentNameEnglish, value);
        }

        private string _swsApproverCode;
        [DataMember, Column("SWS approver code")]
        public string SWSApproverCode
        {
            get => _swsApproverCode;
            set => SetProperty(ref _swsApproverCode, value);
        }

        private string _swsApproverNameJapanese;
        [DataMember, Column("SWS approver name (Japanese)")]
        public string SWSApproverNameJapanese
        {
            get => _swsApproverNameJapanese;
            set => SetProperty(ref _swsApproverNameJapanese, value);
        }

        private string _swsApproverNameEnglish;
        [DataMember, Column("SWS approver name (English)")]
        public string SWSApproverNameEnglish
        {
            get => _swsApproverNameEnglish;
            set => SetProperty(ref _swsApproverNameEnglish, value);
        }

        private string _swsApprovalDepartmentCode;
        [DataMember, Column("SWS approval department code")]
        public string SWSApprovalDepartmentCode
        {
            get => _swsApprovalDepartmentCode;
            set => SetProperty(ref _swsApprovalDepartmentCode, value);
        }

        private string _swsApprovalDepartmentNameJapanese;
        [DataMember, Column("SWS approval department name (Japanese)")]
        public string SWSApprovalDepartmentNameJapanese
        {
            get => _swsApprovalDepartmentNameJapanese;
            set => SetProperty(ref _swsApprovalDepartmentNameJapanese, value);
        }

        private string _swsApprovalDepartmentNameEnglish;
        [DataMember, Column("SWS approval department name (English)")]
        public string SWSApprovalDepartmentNameEnglish
        {
            get => _swsApprovalDepartmentNameEnglish;
            set => SetProperty(ref _swsApprovalDepartmentNameEnglish, value);
        }

        private string _issuePICCode;
        [DataMember, Column("Issue PIC code")]
        public string IssuePICCode
        {
            get => _issuePICCode;
            set => SetProperty(ref _issuePICCode, value);
        }

        private string _issuePICNameJapanese;
        [DataMember, Column("Issue PIC name (Japanese)")]
        public string IssuePICNameJapanese
        {
            get => _issuePICNameJapanese;
            set => SetProperty(ref _issuePICNameJapanese, value);
        }

        private string _issuePICNameEnglish;
        [DataMember, Column("Issue PIC name (English)")]
        public string IssuePICNameEnglish
        {
            get => _issuePICNameEnglish;
            set => SetProperty(ref _issuePICNameEnglish, value);
        }

        private string _issueDepartmentCode;
        [DataMember, Column("Issue Department Code")]
        public string IssueDepartmentCode
        {
            get => _issueDepartmentCode;
            set => SetProperty(ref _issueDepartmentCode, value);
        }

        private string _issueDepartmentNameJapanese;
        [DataMember, Column("Issue department name (Japanese)")]
        public string IssueDepartmentNameJapanese
        {
            get => _issueDepartmentNameJapanese;
            set => SetProperty(ref _issueDepartmentNameJapanese, value);
        }

        private string _issueDepartmentNameEnglish;
        [DataMember, Column("Issue department name (English)")]
        public string IssueDepartmentNameEnglish
        {
            get => _issueDepartmentNameEnglish;
            set => SetProperty(ref _issueDepartmentNameEnglish, value);
        }

        private string _approverCode;
        [DataMember, Column("Approver code")]
        public string ApproverCode
        {
            get => _approverCode;
            set => SetProperty(ref _approverCode, value);
        }

        private string _approverNameJapanese;
        [DataMember, Column("Approver name (Japanese)")]
        public string ApproverNameJapanese
        {
            get => _approverNameJapanese;
            set => SetProperty(ref _approverNameJapanese, value);
        }

        private string _approverNameEnglish;
        [DataMember, Column("Approver name (English)")]
        public string ApproverNameEnglish
        {
            get => _approverNameEnglish;
            set => SetProperty(ref _approverNameEnglish, value);
        }

        private string _approvalDepartmentCode;
        [DataMember, Column("Approval department code")]
        public string ApprovalDepartmentCode
        {
            get => _approvalDepartmentCode;
            set => SetProperty(ref _approvalDepartmentCode, value);
        }

        private string _approvalDepartmentNameJapanese;
        [DataMember, Column("Approval department name (Japanese)")]
        public string ApprovalDepartmentNameJapanese
        {
            get => _approvalDepartmentNameJapanese;
            set => SetProperty(ref _approvalDepartmentNameJapanese, value);
        }

        private string _approvalDepartmentNameEnglish;
        [DataMember, Column("Acknowledged the department name (English)")]
        public string ApprovalDepartmentNameEnglish
        {
            get => _approvalDepartmentNameEnglish;
            set => SetProperty(ref _approvalDepartmentNameEnglish, value);
        }

        private string _ihsUnit;
        [DataMember, Column("IHS Unit")]
        public string IHSUnit
        {
            get => _ihsUnit;
            set => SetProperty(ref _ihsUnit, value);
        }

        private string _prototypeAtTheTimeOrCurrentSituationTheTargetComponent;
        [DataMember, Column("Prototype at the time or current situation the target component")]
        public string PrototypeAtTheTimeOrCurrentSituationTheTargetComponent
        {
            get => _prototypeAtTheTimeOrCurrentSituationTheTargetComponent;
            set => SetProperty(ref _prototypeAtTheTimeOrCurrentSituationTheTargetComponent, value);
        }

        private string _partCodeConverted;
        [DataMember, Column("PartCodeConverted")]
        public string PartCodeConverted
        {
            get => _partCodeConverted;
            set => SetProperty(ref _partCodeConverted, value);
        }
    }
}
