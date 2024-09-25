/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerDemandCalculationModel.cs
Function           :   Data Contract for CustomerDemandCalculation
Created By         :   Shivam Dhingra
Created on         :   06-Oct-2020
Revision History   :   [16-Dec-2020] : Shivam Dhingra
                   :   [] : Added new field WarehouseGuid  
                   :   [06-July-2022]:Anmol Jain
                   :   Added CustomerName and UnloadingPoint
                   :   [23-Jan-2023]: Prakhar
                   :   Added CustomerDemandDataModel
*                  :   [24-March-2023] : Virendra
*                  :   [] : Added new property UnloadingPointGuid in the class CustomerDemandCalculationProcedureParamModelForCustomerDemandData 
*                  :   [27-March-2023] : Virendra 
*                  :   [] : Added new property CustomerGuid,   pCustomerBusinessGroupGuid , pUnloadingPointGuid  and DemandAutoRun in the class CustomerDemandCalculationProcedureParamModel
*                  :   [03-April-2023] : Virendra 
*                  :   [] : Comment this 'EDIUploadDate' property in the class CustomerDemandDataModel 
*                  :   [04-April-2023] : Virendra 
*                  :   [] : Added this 'pCustomerBusinessGroupGuid' property in the class CustomerDemandCalculationProcedureParamModelForCustomerDemandData                  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for CustomerDemandCalculation
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandCalculationModel : BaseModel<Guid>
    {

        private Guid _customerNameGuid;
        /// <summary>
        /// Get or set for CustomerNameGuid
        /// </summary>
        [DataMember]
        public Guid CustomerNameGuid
        {
            get => _customerNameGuid;
            set => SetProperty(ref _customerNameGuid, value);
        }

        private string _partNumber;
        /// <summary>
        /// Get or set for PartNumber
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private DateTime _demandDate;
        /// <summary>
        /// Get or set for DemandDate
        /// </summary>
        [DataMember]
        public DateTime DemandDate
        {
            get => _demandDate;
            set => SetProperty(ref _demandDate, value);
        }

        private int _demandQuantity;
        /// <summary>
        /// Get or set for DemandQuantity
        /// </summary>
        [DataMember]
        public int DemandQuantity
        {
            get => _demandQuantity;
            set => SetProperty(ref _demandQuantity, value);
        }


        private string _eDIMessageFileName;
        /// <summary>
        /// Get or set for EDIMessageFileName
        /// </summary>
        [DataMember]
        [StringLength(150)]
        public string EDIMessageFileName
        {
            get => _eDIMessageFileName;
            set => SetProperty(ref _eDIMessageFileName, value);
        }

        private string _customerDeliveryPoint;
        /// <summary>
        /// Get or set for CustomerDeliveryPoint
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerDeliveryPoint
        {
            get => _customerDeliveryPoint;
            set => SetProperty(ref _customerDeliveryPoint, value);
        }

        private DateTime _eDIUploadDate;
        /// <summary>
        /// Get or set for EDIUploadDate
        /// </summary>
        [DataMember]
        public DateTime EDIUploadDate
        {
            get => _eDIUploadDate;
            set => SetProperty(ref _eDIUploadDate, value);
        }

        //private DateTime _batchStamp;
        ///// <summary>
        ///// Get or set for BatchStamp
        ///// </summary>
        //[DataMember]
        //public DateTime BatchStamp
        //{
        //    get => _batchStamp;
        //    set => SetProperty(ref _batchStamp, value);
        //}

        //private Guid _batchId;
        ///// <summary>
        ///// Get or set for BatchId
        ///// </summary>
        //[DataMember]
        //public Guid BatchId
        //{
        //    get => _batchId;
        //    set => SetProperty(ref _batchId, value);
        //}

        //private Guid? _warehouseGuid;
        ///// <summary>
        ///// Get or Set for {WarehouseGuid}.
        ///// </summary>
        //[DataMember]
        //public Guid? WarehouseGuid
        //{
        //    get => _warehouseGuid;
        //    set => SetProperty(ref _warehouseGuid, value);
        //}
        private string _remarks;
        /// <summary>
        /// Get or set for Remarks
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        private Guid? _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid? CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => SetProperty(ref _customerDeliveryPointGuid, value);
        }

        private string _customerName;
        /// <summary>
        /// Get or set for PartNumber
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        private string _unloadingPoint;
        /// <summary>
        /// Get or set for PartNumber
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => SetProperty(ref _unloadingPoint, value);
        }


    }

    public class CustomerDemandDataModel
    {

        private string _customerName;

        /// get or set for CustomerName

        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }

        private string _customerDeliveryPointName;

        /// get or set for CustomerDeliveryPointName

        [DataMember]
        public string CustomerDeliveryPointName
        {
            get => _customerDeliveryPointName;
            set => _customerDeliveryPointName = value;
        }

        private string _unloadingPoint;

        /// get or set for UnloadingPoint

        [DataMember]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => _unloadingPoint = value;
        }

        private string _partNumber;

        /// get or set for PartNumber

        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        private string _eDIMessageFileName;

        /// get or set for EDIMessageFileName

        [DataMember]
        public string EDIMessageFileName
        {
            get => _eDIMessageFileName;
            set => _eDIMessageFileName = value;
        }

        private int _demandQuantity;

        /// get or set for DemandQuantity

        [DataMember]
        public int DemandQuantity
        {
            get => _demandQuantity;
            set => _demandQuantity = value;
        }

        private DateTime _demandDate;

        /// get or set for DemandDate

        [DataMember]
        public DateTime DemandDate
        {
            get => _demandDate;
            set => _demandDate = value;
        }

        //private DateTime _eDIUploadDate;

        ///// get or set for EDIUploadDate

        //[DataMember]
        //public DateTime EDIUploadDate
        //{
        //    get => _eDIUploadDate;
        //    set => _eDIUploadDate = value;
        //}







    }

    /// <summary>
    /// Data Contract for CustomerDemandCalculationProcedureParameters
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandCalculationProcedureParamModel
    {

        private string _pcustomerNameGuid ;
        /// <summary>
        /// get or set for pCustomerCode
        /// </summary>
        [DataMember]
        public string pCustomerCode
        {
            get { return _pcustomerNameGuid; }
            set { _pcustomerNameGuid = value; }
        }

        private Guid _pUserGuid;
        /// <summary>
        /// get or set for pUserGuid
        /// </summary>
        [DataMember]
        public Guid pUserGuid
        {
            get { return _pUserGuid; }
            set { _pUserGuid = value; }
        }

        private Guid? _pcustomerDeliveryPointGuid;
        /// <summary>
        /// get or set for pCustomerDeliveryPointGuid
        /// </summary>
        [DataMember]
        public Guid? pCustomerDeliveryPointGuid
        {
            get { return _pcustomerDeliveryPointGuid; }
            set { _pcustomerDeliveryPointGuid = value; }
        }

        private string _pUnloadingPoint;
        /// <summary>
        /// get or set for pUserGuid
        /// </summary>
        [DataMember]
        public string pUnloadingPoint
        {
            get { return _pUnloadingPoint; }
            set { _pUnloadingPoint = value; }
        }

        private Guid _pCustomerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid pCustomerBusinessGroupGuid
        {
            get => _pCustomerBusinessGroupGuid;
            set => _pCustomerBusinessGroupGuid = value;
        }
        private Guid _pUnloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid pUnloadingPointGuid
        {
            get => _pUnloadingPointGuid;
            set => _pUnloadingPointGuid = value;
        }
        private Guid _pCustomerGuid;
        /// <summary>
        /// get or set for CustomerGuid
        /// </summary>
        [DataMember]
        public Guid CustomerGuid 
        {
            get { return _pCustomerGuid; }
            set { _pCustomerGuid = value; }
        }
        private bool _pDemandAutoRun;
        /// <summary>
        /// get or set for CustomerGuid
        /// </summary>
        [DataMember]
        public bool DemandAutoRun
        {
            get { return _pDemandAutoRun; }
            set { _pDemandAutoRun = value; }
        }
    }


    /// <summary>
    /// Data Contract for CustomerDemandCalculationProcedureParametersForCustomerDemandData
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandCalculationProcedureParamModelForCustomerDemandData
    {

        private Guid _pcustomerNameGuid;
        /// <summary>
        /// get or set for pCustomerNameGuid
        /// </summary>
        [DataMember]
        public Guid CustomerNameGuid
        {
            get { return _pcustomerNameGuid; }
            set { _pcustomerNameGuid = value; }
        }

        private Guid _pcustomerDeliveryPointGuid;
        /// <summary>
        /// get or set for pUserGuid
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get { return _pcustomerDeliveryPointGuid; }
            set { _pcustomerDeliveryPointGuid = value; }
        }


        private DateTime pdrpGenerationDate;
        /// <summary>
        /// get or set for pUserGuid
        /// </summary>
        [DataMember]
        public DateTime DrpGenerationDate
        {
            get { return pdrpGenerationDate; }
            set { pdrpGenerationDate = value; }
        }
        private Guid _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => _unloadingPointGuid = value;
        }
        private Guid _pCustomerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {pCustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid pCustomerBusinessGroupGuid
        {
            get => _pCustomerBusinessGroupGuid;
            set => _pCustomerBusinessGroupGuid = value;
        }
    }





    }
