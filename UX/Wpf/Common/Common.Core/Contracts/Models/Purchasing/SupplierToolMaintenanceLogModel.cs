/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierToolMaintenanceLogModel.cs
Function           :   Audit Trail Model
Created By         :   Virendra
Created on         :   07-Nov-2022
Revision History   :   [09-Dec-2022]:Virendra  
                   :   Added some more fileds in this model same as suppliertoolmaintenancemodel
                   :   [13-Dec-2022]:Virendra  
                   :   Added new model AuditIDModel
                   :   [15-Dec-2022]:Virendra  
                   :   Added new field(SupplierGroupGuid and SupplierGuid) in AuditIDModel model
                   :   [29-Nov-2023]: Piyush Anand
				   :   [HD-00396309] : Remove Property AvailablePartsRemainingLessScrap and PartsProducedIncludingScrap
****************************************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    
    [DataContract, Serializable]
    public class SupplierToolMaintenanceLogModel : BaseModel<Guid>
    {

        private string _supplierGroupName;
        [DataMember]
        public string SupplierGroupName
        {
            get { return _supplierGroupName; }
            set { _supplierGroupName = value; }
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
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { _materialNumber = value; }
        }
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
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

        private string _doMultipleToolsExist ;
        /// <summary>
        /// Get or Set for {DoMultipleToolsExist}.
        /// </summary>
        [DataMember]
        public string DoMultipleToolsExist
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
        private string _thirdPartyUsage ;
        /// <summary>
        /// Get or Set for {ThirdPartyUsage}.
        /// </summary>
        [DataMember]
        public string ThirdPartyUsage
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



        private string _fieldName;
        [DataMember]
        public string FieldName { get => _fieldName; set => _fieldName = value; }

        private string _newValue;
        [DataMember]
        public string NewValue { get => _newValue; set => _newValue = value; }

        private string _oldValue;
        [DataMember]       
        public string OldValue { get => _oldValue; set => _oldValue = value; }

        private string _action;
        [DataMember]
        public string Action { get => _action; set => _action = value; }

        private Guid _itemGuid;
        [DataMember]
        public Guid ItemGuid
        {
            get => _itemGuid; set => _itemGuid = value;
        }
        private Guid _batchGuid;
        [DataMember]
        public Guid BatchGuid
        {
            get => _batchGuid; set => _batchGuid = value;
        }

        private string _modifiedByUserName;
        [DataMember]
        public string ModifiedByUserName
        {
            get => _modifiedByUserName; set => _modifiedByUserName = value;
        }

        private DateTime _modifiedDate;
        [DataMember]
        public DateTime ModifiedDate
        {
            get => _modifiedDate; set => _modifiedDate = value;
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

    }
    [DataContract, Serializable]
    public class AuditTrailSearchModelForSupplierToolMaintenance
    {
        //TODO: Convert these to auto properties.
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id; set => _id = value;
        }
        private Guid _supplierGroupGuid;
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid; set => _supplierGroupGuid = value;
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid; set => _supplierGuid = value;
        }
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid; set => _materialGuid = value;
        }

        private DateTime? _fromDate;

        [DataMember, DataType(DataType.DateTime)]
        public DateTime? FromDate
        {
            get => _fromDate;
            set => _fromDate = value;
        }
        private DateTime? _toDate;

        [DataMember, DataType(DataType.DateTime)]
        public DateTime? ToDate
        {
            get => _toDate;
            set => _toDate = value;
        }
        private string _auditID;
        [DataMember]
        public string AuditID
        {
            get { return _auditID; }
            set { _auditID = value; }
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { _materialNumber = value; }
        }
    }
    [DataContract, Serializable]
    public class AuditIDModel
    {
        private string _auditID;
        [DataMember]
        public string AuditID
        {
            get { return _auditID; }
            set { _auditID = value; }
        }
        private Guid _supplierGroupGuid;
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid; set => _supplierGroupGuid = value;
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid; set => _supplierGuid = value;
        }
    }
}
