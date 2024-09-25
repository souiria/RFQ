/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DRPGenerationBySupplyChainMatrixModel.cs
Function           :   DRP Generation By Supply Chain Matrix
Created By         :   Shivam Dhingra
Created on         :   03-Dec-2020
Revision History   :   [07-Dec-2020] : Shivam Dhingra
                   :   Modified model as per DB table 
                   :   [09-Dec-2020] : Shivam Dhingra
                   :   Modified Column name as per table name
                   :   [09-Dec-2020] : Shivam Dhingra
                   :   Added new model DRPCalculationStageOneProcedureParameterModel
                   :   [11-Dec-2020] : Shivam Dhingra
                   :   Added new fields OrderIssuedToPPS and OrderIssuedToWMS
                   :   [16-Dec-2020] : Shivam Dhingra
                   :   [] : Added new field WarehouseGuid 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// Data Contract for DRPGenerationBySupplyChainMatrixModel
    /// </summary>
    [DataContract,Serializable]
    public class DRPGenerationBySupplyChainMatrixModel : BaseModel<Guid>
    {
        private Guid _customerDemandCalculationGuid;
        /// <summary>
        /// Get or Set for {CustomerDemandCalculationGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerDemandCalculationGuid
        {
            get => _customerDemandCalculationGuid;
            set => SetProperty(ref _customerDemandCalculationGuid, value);
        }

        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private DateTime _demandDate;
        /// <summary>
        /// Get or Set for {DemandDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime DemandDate
        {
            get => _demandDate;
            set => SetProperty(ref _demandDate, value);
        }

        private string _workOrderNumber;
        /// <summary>
        /// Get or Set for {WorkOrderNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(18)]
        public string WorkOrderNumber
        {
            get => _workOrderNumber;
            set => SetProperty(ref _workOrderNumber, value);
        }

        private DateTime _issueDate;
        /// <summary>
        /// Get or Set for {IssueDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime IssueDate
        {
            get => _issueDate;
            set => SetProperty(ref _issueDate, value);
        }

        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }

        private string _wMSSite;
        /// <summary>
        /// Get or Set for {WMSSite}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string WMSSite
        {
            get => _wMSSite;
            set => SetProperty(ref _wMSSite, value);
        }

        private DateTime? _dcArrivalDate;
        /// <summary>
        /// Get or Set for {DCArrivalDate}.
        /// </summary>
        [DataMember]
        public DateTime? DCArrivalDate
        {
            get => _dcArrivalDate;
            set => SetProperty(ref _dcArrivalDate, value);
        }

        private DateTime? _shipmentToDCDate;
        /// <summary>
        /// Get or Set for {ShipmentToDCDate}.
        /// </summary>
        [DataMember]
        public DateTime? ShipmentToDCDate
        {
            get => _shipmentToDCDate;
            set => SetProperty(ref _shipmentToDCDate, value);
        }

        private DateTime? _assemblyFinishDate;
        /// <summary>
        /// Get or Set for {AssemblyFinishDate}.
        /// </summary>
        [DataMember]
        public DateTime? AssemblyFinishDate
        {
            get => _assemblyFinishDate;
            set => SetProperty(ref _assemblyFinishDate, value);
        }

        private DateTime? _cuttingFinishDate;
        /// <summary>
        /// Get or Set for {CuttingFinishDate}.
        /// </summary>
        [DataMember]
        public DateTime? CuttingFinishDate
        {
            get => _cuttingFinishDate;
            set => SetProperty(ref _cuttingFinishDate, value);
        }

        private DateTime? _orderLeadTime;
        /// <summary>
        /// Get or Set for {OrderLeadTime}.
        /// </summary>
        [DataMember]
        public DateTime? OrderLeadTime
        {
            get => _orderLeadTime;
            set => SetProperty(ref _orderLeadTime, value);
        }

        private DateTime? _demandDate6;
        /// <summary>
        /// Get or Set for {DemandDate6}.
        /// </summary>
        [DataMember]
        public DateTime? DemandDate6
        {
            get => _demandDate6;
            set => SetProperty(ref _demandDate6, value);
        }

        private DateTime? _demandDate7;
        /// <summary>
        /// Get or Set for {DemandDate7}.
        /// </summary>
        [DataMember]
        public DateTime? DemandDate7
        {
            get => _demandDate7;
            set => SetProperty(ref _demandDate7, value);
        }

        private DateTime? _demandDate8;
        /// <summary>
        /// Get or Set for {DemandDate8}.
        /// </summary>
        [DataMember]
        public DateTime? DemandDate8
        {
            get => _demandDate8;
            set => SetProperty(ref _demandDate8, value);
        }

        private DateTime? _demandDate9;
        /// <summary>
        /// Get or Set for {DemandDate9}.
        /// </summary>
        [DataMember]
        public DateTime? DemandDate9
        {
            get => _demandDate9;
            set => SetProperty(ref _demandDate9, value);
        }

        private DateTime? _demandDate10;
        /// <summary>
        /// Get or Set for {DemandDate10}.
        /// </summary>
        [DataMember]
        public DateTime? DemandDate10
        {
            get => _demandDate10;
            set => SetProperty(ref _demandDate10, value);
        }

        private string _demandType;
        /// <summary>
        /// Get or Set for {DemandType}.
        /// </summary>
        [DataMember]
        [StringLength(40)]
        public string DemandType
        {
            get => _demandType;
            set => SetProperty(ref _demandType, value);
        }

        private string _ppsCustomerCode;
        /// <summary>
        /// Get or Set for {PPSCustomerCode}.
        /// </summary>
        [DataMember]
        [StringLength(10)]
        public string PPSCustomerCode
        {
            get => _ppsCustomerCode;
            set => SetProperty(ref _ppsCustomerCode, value);
        }

        private string _wmsCustomerCode;
        /// <summary>
        /// Get or Set for {WMSCustomerCode}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WMSCustomerCode
        {
            get => _wmsCustomerCode;
            set => SetProperty(ref _wmsCustomerCode, value);
        }

        private string _billToSite;
        /// <summary>
        /// Get or Set for {BillToSite}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string BillToSite
        {
            get => _billToSite;
            set => SetProperty(ref _billToSite, value);
        }

        private string _shipToSite;
        /// <summary>
        /// Get or Set for {ShipToSite}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string ShipToSite
        {
            get => _shipToSite;
            set => SetProperty(ref _shipToSite, value);
        }

        private DateTime? _orderDate;
        /// <summary>
        /// Get or Set for {OrderDate}.
        /// </summary>
        [DataMember]
        public DateTime? OrderDate
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value);
        }

        private DateTime? _wmsDueDate;
        /// <summary>
        /// Get or Set for {WMSDueDate}.
        /// </summary>
        [DataMember]
        public DateTime? WMSDueDate
        {
            get => _wmsDueDate;
            set => SetProperty(ref _wmsDueDate, value);
        }

        private string _orderIndicator;
        /// <summary>
        /// Get or Set for {OrderIndicator}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string OrderIndicator
        {
            get => _orderIndicator;
            set => SetProperty(ref _orderIndicator, value);
        }

        private string _orderType;
        /// <summary>
        /// Get or Set for {OrderType}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string OrderType
        {
            get => _orderType;
            set => SetProperty(ref _orderType, value);
        }

        private bool? _orderIssuedToWMS;
        /// <summary>
        /// Get or Set for {OrderIssuedToWMS}.
        /// </summary>
        [DataMember]
        public bool? OrderIssuedToWMS
        {
            get => _orderIssuedToWMS;
            set => SetProperty(ref _orderIssuedToWMS, value);
        }

        private bool? _orderIssuedToPPS;
        /// <summary>
        /// Get or Set for {OrderIssuedToPPS}.
        /// </summary>
        [DataMember]
        public bool? OrderIssuedToPPS
        {
            get => _orderIssuedToPPS;
            set => SetProperty(ref _orderIssuedToPPS, value);
        }


        private Guid? _warehouseGuid;
        /// <summary>
        /// Get or Set for {WarehouseGuid}.
        /// </summary>
        [DataMember]
        public Guid? WarehouseGuid
        {
            get => _warehouseGuid;
            set => SetProperty(ref _warehouseGuid, value);
        }

    }

    /// <summary>
    /// Data Contract for DRPGenerationBySupplyChainMatrixParameters
    /// </summary>
    [DataContract,Serializable]
    public class DRPGenerationBySupplyChainMatrixParamModel
    {
        /// <summary>
        /// Get or set for CustomerNameGuid
        /// </summary>
        [DataMember]
        public Guid CustomerNameGuid { get; set; } = Guid.Empty;

        /// <summary>
        /// Get or set for CustomerNameGuid
        /// </summary>
        [DataMember]
        public Guid WarehouseGuid { get; set; } = Guid.Empty;


        /// <summary>
        /// Get or set for ManufacturingSite
        /// </summary>
        [DataMember]
        public string ManufacturingSite { get; set; } = string.Empty;

    }

    /// <summary>
    /// Data Contract for DRPCalculationStageOneProcedureParameterModel
    /// </summary>
    [DataContract, Serializable]
    public class DRPCalculationStageOneProcedureParameterModel
    {

        /// <summary>
        /// Get or set for CustomerCode
        /// </summary>
        [DataMember]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Get or set for CustomerNameGuid
        /// </summary>
        [DataMember]
        public Guid UserGuid { get; set; }

        /// <summary>
        /// Get or set for CustomerNameGuid
        /// </summary>
        [DataMember]
        public Guid WarehouseGuid { get; set; }


        /// <summary>
        /// Get or set for ManufacturingSiteCode
        /// </summary>
        [DataMember]
        public string ManufacturingSiteCode { get; set; }

    }



}
