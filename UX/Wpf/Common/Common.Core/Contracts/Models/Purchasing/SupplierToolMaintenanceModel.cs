/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierToolMaintenanceModel.cs
Function           :   Supplier Tool Maintenance
Created By         :   Dharmendra Kumar
Created on         :   12-Oct-2022
Revision History   : [16-Nov-2022]:Virendra
                   : Added Decimalprecision 10,0 in all decimal field
                   : [23-Nov-2022]: Virendra
                   : Added New property MaterialNumber in the class FilterDataSupplierToolMaintenance
                   : [29-Nov-2022]: Ranjay
                   : Added new field CustomerBusinessGroupGuid
                   : 22-Dec-2022]: Vishwadeep Singh
                   : Added new field SubmittedDate in DisplaySupplierToolMaintenanceModel
                   : [29-Nov-2023]: Piyush Anand
				   : [HD-00396309] : Remove Property AvailablePartsRemainingLessScrap and PartsProducedIncludingScrap
                   : [01-Dec-2023]: Prakhar
				   : [HD-00396309] : Added Property Requiring tool audit
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// This class is used to have information about  to Supplier Tool Maintenance  update from EOL system.
    /// </summary>
    [DataContract, Serializable]
    public class SupplierToolMaintenanceModel : BaseModel<Guid>
    {

        private Guid _supplierGroupGuid;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }

        private Guid _supplierGuid;
        /// <summary>
        /// Get or Set for {SupplierGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private string _toolDescription;
        /// <summary>
        /// Get or Set for {ToolDescription}.
        /// </summary>
        [DataMember]
        public string ToolDescription
        {
            get => _toolDescription;
            set => _toolDescription = value;
        }
        private Guid _materialGuid;
        /// <summary>
        /// Get or Set for {MaterialGuid}.
        /// </summary>
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }
        private string _supplierPartNumber;
        /// <summary>
        /// Get or Set for {SupplierPartNumber}.
        /// </summary>
        [DataMember]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => _supplierPartNumber = value;
        }
        private string _toolId;
        /// <summary>
        /// Get or Set for {ToolId}.
        /// </summary>
        [DataMember]
        public string ToolId
        {
            get => _toolId;
            set => _toolId = value;
        }
        private Guid _countryGuid;
        /// <summary>
        /// Get or Set for {CountryGuid}.
        /// </summary>
        [DataMember]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }

        private Guid _toolTypeGuid;
        /// <summary>
        /// Get or Set for {ToolTypeGuid}.
        /// </summary>
        [DataMember]
        public Guid ToolTypeGuid
        {
            get => _toolTypeGuid;
            set => SetProperty(ref _toolTypeGuid, value);
        }
        private Guid _toolOwnerGuid;
        /// <summary>
        /// Get or Set for {ToolOwnerGuid}.
        /// </summary>
        [DataMember]
        public Guid ToolOwnerGuid
        {
            get => _toolOwnerGuid;
            set => SetProperty(ref _toolOwnerGuid, value);
        }
        private string _oem;
        /// <summary>
        /// Get or Set for {OEM}.
        /// </summary>
        [DataMember]
        public string OEM
        {
            get => _oem;
            set => _oem = value;
        }
        private string _whpilot;
        /// <summary>
        /// Get or Set for {WHPilot}.
        /// </summary>
        [DataMember]
        public string WHPilot
        {
            get => _whpilot;
            set => _whpilot = value;
        }
        private decimal _cycleLifeAtSOP;
        /// <summary>
        /// Get or Set for {CycleLifeAtSOP}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal CycleLifeAtSOP
        {
            get => _cycleLifeAtSOP;
            set => SetProperty(ref _cycleLifeAtSOP, value);
        }
        private decimal _cavityScenario;
        /// <summary>
        /// Get or Set for {CavityScenario}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal CavityScenario
        {
            get => _cavityScenario;
            set => SetProperty(ref _cavityScenario, value);
        }
        private decimal _lifeSpanQtyParts;
        /// <summary>
        /// Get or Set for {LifeSpanQtyParts}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal LifeSpanQtyParts
        {
            get => _lifeSpanQtyParts;
            set => SetProperty(ref _lifeSpanQtyParts, value);
        }

        private bool _doMultipleToolsExist = false;
        /// <summary>
        /// Get or Set for {DoMultipleToolsExist}.
        /// </summary>
        [DataMember]
        public bool DoMultipleToolsExist
        {
            get => _doMultipleToolsExist;
            set => SetProperty(ref _doMultipleToolsExist, value);
        }
        private decimal _accumulatedCycleLife;
        /// <summary>
        /// Get or Set for {AccumulatedCycleLife}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal AccumulatedCycleLife
        {
            get => _accumulatedCycleLife;
            set => SetProperty(ref _accumulatedCycleLife, value);
        }
        private decimal _remainingCycleLife;
        /// <summary>
        /// Get or Set for {RemainingCycleLife}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal RemainingCycleLife
        {
            get => _remainingCycleLife;
            set => SetProperty(ref _remainingCycleLife, value);
        }
        //private decimal _partsProducedIncludingScrap;
        ///// <summary>
        ///// Get or Set for {PartsProducedIncludingScrap}.
        ///// </summary>
        //[DataMember]
        //[DecimalPrecision(10, 0)]
        //public decimal PartsProducedIncludingScrap
        //{
        //    get => _partsProducedIncludingScrap;
        //    set => SetProperty(ref _partsProducedIncludingScrap, value);
        //}
        //private decimal _availablePartsRemainingLessScrap;
        ///// <summary>
        ///// Get or Set for {AvailablePartsRemainingLessScrap}.
        ///// </summary>
        //[DataMember]
        //[DecimalPrecision(10, 0)]
        //public decimal AvailablePartsRemainingLessScrap
        //{
        //    get => _availablePartsRemainingLessScrap;
        //    set => SetProperty(ref _availablePartsRemainingLessScrap, value);
        //}                                                                     commented by [29-Nov-2023] : Piyush Anand               
        private bool _thirdPartyUsage = false;
        /// <summary>
        /// Get or Set for {ThirdPartyUsage}.
        /// </summary>
        [DataMember]
        public bool ThirdPartyUsage
        {
            get => _thirdPartyUsage;
            set => SetProperty(ref _thirdPartyUsage, value);
        }
        private Guid _toolConditionGuid;
        /// <summary>
        /// Get or Set for {ToolConditionGuid}.
        /// </summary>
        [DataMember]
        public Guid ToolConditionGuid
        {
            get => _toolConditionGuid;
            set => SetProperty(ref _toolConditionGuid, value);
        }
        private DateTime _auditDate;
        /// <summary>
        /// Get or Set for {AuditDate}.
        /// </summary>
        [DataMember]
        public DateTime AuditDate
        {
            get { return _auditDate; }
            set { _auditDate = value; }
        }
        private DateTime _forecastEOLDate;
        /// <summary>
        /// Get or Set for {ForecastEOLDate}.
        /// </summary>
        [DataMember]
        public DateTime ForecastEOLDate
        {
            get { return _forecastEOLDate; }
            set { _forecastEOLDate = value; }
        }
        /// <summary>
        /// Get or Set for {SupplierNotes}.
        /// </summary>
        private string _supplierNotes;
        [DataMember]
        public string SupplierNotes
        {
            get => _supplierNotes;
            set => _supplierNotes = value;
        }
        private string _auditID;
        /// <summary>
        /// Get or Set for {AuditID}.
        /// </summary>
        [DataMember]
        public string AuditID
        {
            get => _auditID;
            set => _auditID = value;
        }
        private short _auditStatus;
        /// <summary>
        /// Get or Set for {AuditStatus}.
        /// </summary>
        [DataMember]
        public short AuditStatus
        {
            get => _auditStatus;
            set => SetProperty(ref _auditStatus, value);
        }

    }

    /// <summary>
    /// This class is used to bind Supplier Tool Maintenance screen Grid.
    /// </summary>
    [DataContract, Serializable]
    public class DisplaySupplierToolMaintenanceModel: BaseModel<Guid>
    {
        private string _supplierGroupName;
        /// <summary>
        ///Get or Set for {SupplierGroupName}
        /// </summary>
        [DataMember]
        public string SupplierGroupName
        {
            get => _supplierGroupName;
            set => _supplierGroupName = value;
        }
        
        private Guid _supplierGroupGuid;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }
        private string _supplierCode = string.Empty;
        /// <summary>
        /// Get or Set for {SupplierCode}.
        /// </summary>
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }
        private Guid _supplierGuid;
        /// <summary>
        /// Get or Set for {SupplierGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private string _toolDescription;
        /// <summary>
        /// Get or Set for {ToolDescription}.
        /// </summary>
        [DataMember]
        public string ToolDescription
        {
            get => _toolDescription;
            set => _toolDescription = value;
        }
        private string _materialNumber = string.Empty;
        /// <summary>
        /// Get or Set for {MaterialNumber}.
        /// </summary>
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private Guid _materialGuid;
        /// <summary>
        /// Get or Set for {MaterialGuid}.
        /// </summary>
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }
        private string _supplierPartNumber;
        /// <summary>
        /// Get or Set for {SupplierPartNumber}.
        /// </summary>
        [DataMember]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => _supplierPartNumber = value;
        }
        private string _toolId;
        /// <summary>
        /// Get or Set for {ToolId}.
        /// </summary>
        [DataMember]
        public string ToolId
        {
            get => _toolId;
            set => _toolId = value;
        }
        private string _alpha2Code;
        /// <summary>
        /// Get or Set for {Alpha2Code}.
        /// </summary>
        [DataMember]
        public string Alpha2Code
        {
            get => _alpha2Code;
            set => _alpha2Code = value;
        }
        private Guid _countryGuid;
        /// <summary>
        /// Get or Set for {CountryGuid}.
        /// </summary>
        [DataMember]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }
        private string _toolType;
        /// <summary>
        /// Get or Set for {ToolType}.
        /// </summary>
        [DataMember]
        public string ToolType
        {
            get => _toolType;
            set => _toolType = value;
        }

        private Guid _toolTypeGuid;
        /// <summary>
        /// Get or Set for {ToolTypeGuid}.
        /// </summary>
        [DataMember]
        public Guid ToolTypeGuid
        {
            get => _toolTypeGuid;
            set => SetProperty(ref _toolTypeGuid, value);
        }
        private string _toolOwnerName;
        /// <summary>
        /// Get or Set for {ToolOwnerName}.
        /// </summary>
        [DataMember]
        public string ToolOwnerName
        {
            get => _toolOwnerName;
            set => SetProperty(ref _toolOwnerName, value);
        }
        private Guid _toolOwnerGuid;
        /// <summary>
        /// Get or Set for {ToolOwnerGuid}.
        /// </summary>
        [DataMember]
        public Guid ToolOwnerGuid
        {
            get => _toolOwnerGuid;
            set => SetProperty(ref _toolOwnerGuid, value);
        }
        private string _oem;
        /// <summary>
        /// Get or Set for {OEM}.
        /// </summary>
        [DataMember]
        public string OEM
        {
            get => _oem;
            set => _oem = value;
        }
        private string _whpilot;
        /// <summary>
        /// Get or Set for {WHPilot}.
        /// </summary>
        [DataMember]
        public string WHPilot
        {
            get => _whpilot;
            set => _whpilot = value;
        }
        private decimal _cycleLifeAtSOP;
        /// <summary>
        /// Get or Set for {CycleLifeAtSOP}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal CycleLifeAtSOP
        {
            get => _cycleLifeAtSOP;
            set => SetProperty(ref _cycleLifeAtSOP, value);
        }
        private decimal _cavityScenario;
        /// <summary>
        /// Get or Set for {CavityScenario}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal CavityScenario
        {
            get => _cavityScenario;
            set => SetProperty(ref _cavityScenario, value);
        }
        private decimal _lifeSpanQtyParts;
        /// <summary>
        /// Get or Set for {LifeSpanQtyParts}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal LifeSpanQtyParts
        {
            get => _lifeSpanQtyParts;
            set => SetProperty(ref _lifeSpanQtyParts, value);
        }

        private bool _doMultipleToolsExist = false;
        /// <summary>
        /// Get or Set for {DoMultipleToolsExist}.
        /// </summary>
        [DataMember]
        public bool DoMultipleToolsExist
        {
            get => _doMultipleToolsExist;
            set => SetProperty(ref _doMultipleToolsExist, value);
        }
        private decimal _accumulatedCycleLife;
        /// <summary>
        /// Get or Set for {AccumulatedCycleLife}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal AccumulatedCycleLife
        {
            get => _accumulatedCycleLife;
            set => SetProperty(ref _accumulatedCycleLife, value);
        }
        private decimal _remainingCycleLife;
        /// <summary>
        /// Get or Set for {RemainingCycleLife}.
        /// </summary>
        [DataMember]
        [DecimalPrecision(10, 0)]
        public decimal RemainingCycleLife
        {
            get => _remainingCycleLife;
            set => SetProperty(ref _remainingCycleLife, value);
        }
        //private decimal _partsProducedIncludingScrap;
        ///// <summary>
        ///// Get or Set for {PartsProducedIncludingScrap}.
        ///// </summary>
        //[DataMember]
        //[DecimalPrecision(10, 0)]
        //public decimal PartsProducedIncludingScrap
        //{
        //    get => _partsProducedIncludingScrap;
        //    set => SetProperty(ref _partsProducedIncludingScrap, value);
        //}
        //private decimal _availablePartsRemainingLessScrap;
        ///// <summary>
        ///// Get or Set for {AvailablePartsRemainingLessScrap}.
        ///// </summary>
        //[DataMember]
        //[DecimalPrecision(10, 0)]
        //public decimal AvailablePartsRemainingLessScrap
        //{
        //    get => _availablePartsRemainingLessScrap;
        //    set => SetProperty(ref _availablePartsRemainingLessScrap, value);
        //}                                                                     commented by [29-Nov-2023] : Piyush Anand
        private bool _thirdPartyUsage = false;
        /// <summary>
        /// Get or Set for {ThirdPartyUsage}.
        /// </summary>
        [DataMember]
        public bool ThirdPartyUsage
        {
            get => _thirdPartyUsage;
            set => SetProperty(ref _thirdPartyUsage, value);
        }
        private string _toolCondition;
        /// <summary>
        /// Get or Set for {ToolCondition}.
        /// </summary>
        [DataMember]
        public string ToolCondition
        {
            get => _toolCondition;
            set => _toolCondition = value;
        }

        private Guid _toolConditionGuid;
        /// <summary>
        /// Get or Set for {ToolConditionGuid}.
        /// </summary>
        [DataMember]
        public Guid ToolConditionGuid
        {
            get => _toolConditionGuid;
            set => SetProperty(ref _toolConditionGuid, value);
        }
        private DateTime? _auditDate;
        /// <summary>
        /// Get or Set for {AuditDate}.
        /// </summary>
        [DataMember]
        public DateTime? AuditDate
        {
            get { return _auditDate; }
            set { _auditDate = value; }
        }
        private DateTime? _forecastEOLDate;
        /// <summary>
        /// Get or Set for {ForecastEOLDate}.
        /// </summary>
        [DataMember]
        public DateTime? ForecastEOLDate
        {
            get { return _forecastEOLDate; }
            set { _forecastEOLDate = value; }
        }
        /// <summary>
        /// Get or Set for {SupplierNotes}.
        /// </summary>
        private string _supplierNotes;
        [DataMember]
        public string SupplierNotes
        {
            get => _supplierNotes;
            set => _supplierNotes = value;
        }
        private string _auditID;
        /// <summary>
        /// Get or Set for {AuditID}.
        /// </summary>
        [DataMember]
        public string AuditID
        {
            get => _auditID;
            set => _auditID = value;
        }
        private short _auditStatus;
        /// <summary>
        /// Get or Set for {AuditStatus}.
        /// </summary>
        [DataMember]
        public short AuditStatus
        {
            get => _auditStatus;
            set => SetProperty(ref _auditStatus, value);
        }

        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get { return _customerBusinessGroupGuid; }
            set { SetProperty(ref _customerBusinessGroupGuid, value); }
        }

        private DateTime? _submittedDate;
        /// <summary>
        /// Get or Set for {SubmittedDate}.
        /// </summary>
        [DataMember]
        public DateTime? SubmittedDate
        {
            get => _submittedDate;
            set => SetProperty(ref _submittedDate, value);
        }

        private bool _requiringToolAudit;
        [DataMember]
        public bool RequiringToolAudit
        {
            get => _requiringToolAudit;
            set => SetProperty(ref _requiringToolAudit, value);
        }
    }
    /// <summary>
    /// Class for bind Bind Mateiral Combo
    /// </summary>
    public class BindMaterialModelCombo
    {

        private string _materialNumber = string.Empty;
        /// <summary>
        /// Get or Set for {MaterialNumber}.
        /// </summary>
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private Guid _materialGuid;
        /// <summary>
        /// Get or Set for {MaterialGuid}.
        /// </summary>
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid =value;
        }
        private string _supplierPartNumber;
        /// <summary>
        /// Get or Set for {SupplierPartNumber}.
        /// </summary>
        [DataMember]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => _supplierPartNumber = value;
        }

    }
    /// <summary>
    /// Class for fetch filter data
    /// </summary>
    public class FilterDataSupplierToolMaintenance
    {

        private Guid _supplierGroupGuid;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => _supplierGroupGuid = value;
        }

        private Guid _supplierGuid;
        /// <summary>
        /// Get or Set for {SupplierGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set =>  _supplierGuid= value;
        }
        private Guid _materialGuid;
        /// <summary>
        /// Get or Set for {MaterialGuid}.
        /// </summary>
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }
        
       private Guid _supplierToolsMaintenanceGuid;
        /// <summary>
        /// Get or Set for {MaterialGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplierToolsMaintenanceGuid
        {
            get => _supplierToolsMaintenanceGuid;
            set => _supplierToolsMaintenanceGuid = value;
        }

        private string _auditStatus;
        /// <summary>
        /// Get or Set for {AuditStatus}.
        /// </summary>
        [DataMember]
        public string AuditStatus
        {
            get => _auditStatus;
            set => _auditStatus = value;
        }

        private string _materialNumber;
        /// <summary>
        /// Get or Set for {MaterialNumber}.
        /// </summary>
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

    }
}
