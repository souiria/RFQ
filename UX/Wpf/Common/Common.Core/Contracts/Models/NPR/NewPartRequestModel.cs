/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NewPartRequestModel.cs
Function           :   New Part Request 
Created By         :   Dharmendra Kumar
Created on         :   31-May-2019
Revision History   :   [] : Amit Agarwal
                   :   [07-Jul-2019]: Data contract fields changed as per discussion
                   :   []  : Dharmendra Kumar
                   :   [09-Aug-2019] : Data contract fields added NPR Type as per discussion
                   :   [24-Aug-2019]  : Pawan Kumar
                   :   [] : Added two new fields , Supplier Detail Comments and Remarks , ManufacturingSite
                   :   [] : Added fields for BusinessUnitCode , Supplier Code and PriceTypeCode  
                   :   [05-Sep-2019]  : Pawan Kumar
                   :   [] : Added new field for NPR Return Remarks
                   :   [09-Sep-2019] : Pawan
                   :   [] : Added field for IsCustomerNominatedSupplier , IsCustomerNominatedMaterial
                   :   [04-Oct-2019] : Yati
                   :   [] : Added field for CustomerCode
                   :   [04-Dec-2019] : Pawan
                   :   [] : Added field for Platform , Program
                   :   [17-Dec-2019] : Dharmendra
                   :   [] : Modified field Project code data length
                   :   [31-Dec-2019] : Aditya Rastogi
                   :   [] : Added field for CancellationComments
                   :   [03-Jan-2020] : Pawan
                   :   [] : Renamed Cancellation Comments to NPR Cancellation Comments
                   :   [09-Jan-2020] : Pawan
                   :   [] : Changed length of material name to 15 character
                   :   [16-Jan-2020] : Amit
                   :   [] : Changed length of ManufacturerGroup to 50 character
                   :   [07-Feb-2020] : Srashti
                   :   [] : Changed datatype of QtyPerVehicle to decimal.
                   :   [11-May-2020] : Pawan
                   :   [] : Added field for IsAdhoc
                   :   [26-June-2020] : Srashti Gupta
                   :   [] : Added field for CustomerGuid & ProjectGuid
                   :   [28-Jan-2022] : Shivam Dhingra
                   :   [] : Added field for CustomerHiearchyGuid
                   :   [04-May-2022] : Ranjay
                   :   [] : Added field for CommodityGuid
                   :   [06-May-2022] : Anmol jain
                   :   [] : Added field for BomUnitOfMeasureGuid
                   :   [04-May-2022] : Ranjay
                   :   [] : Added field for SupplierGroupGuid   
                   :   [29-Apr-2022] : Shivam Dhingra
                   :   [] : Added field BusinessUnitGuid
                   :   [10-May-2022] : Anmol jain
                   :   [] : Added field for ProjectHirarchyGuid,ProgramHirarchyGuid,PlateformHirarchyGuid 
*                  :   [30-Jan-2023] : Ashish Dutta
*                  :   [] : Changes for NPR Screen Performance
*                  :   [23-Faeb-2023] : Vishwadeep Singh
*                  :   [] HD:00375862 : Added property ProjectHierarchyGuid in FilterNewPartRequestModelData model.
*                  :   [29-May-2023] : Ashish Dutta
*                  :   [] HD:00367270,00379375 : Added property Associated Parts,Suggested Manufcturing Group.      
                   :   [30-May-2023] Vishwadeep Singh
*                  :   [HD-00367270,HD-00379375] : Added Model FilterAssociatedPartsModel 
                   :   [16-June-2023] Ranjay
*                  :   [] : Added New Model  MultiCheckManufacturingSiteModel
                   :   [21-June-2023] Virendra
*                  :   [] : Added New Field 'ActualManufacturingSite' in the Model UXDisplayCreateUpdateNPRModel 
                   :   [22-June-2023] Virendra
*                  :   [] : Added New Field 'BusinessUnitGuid' in the Model UXDisplayCreateUpdateNPRModel 
*                  :   [06-Jul-2023] : Ranjay 
                   :   [] : Added new class SupplierGroupGuidModel
*                  :   [11-July-2023] Prakhar
*                  :   [HD-00385117] Added New Model CheckNprByRequestIdAndSupplierModel 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.GlobalMasters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPR
{
    ///// <summary>
    ///// This public enumerated defines the Request Type steps
    ///// </summary>
    //public enum NPRStatusType
    //{
    //    /// <summary>
    //    /// New Request
    //    /// </summary>
    //    NewRequest,
    //    /// <summary>
    //    /// NPR is submitted to NPR Log
    //    /// </summary>
    //    NPRSubmittedToNPRBacklog,
    //    /// <summary>
    //    /// Supplier Group in Quarantine
    //    /// </summary>
    //    SupplierQuarantine,
    //    /// <summary>
    //    /// Email Notification Send
    //    /// </summary>
    //    EmailNotificationSend
    //}
    ///// <summary>
    ///// this will use for NPRType
    ///// </summary>
    //public enum NPRType
    //{
    //    /// <summary>
    //    /// New Part
    //    /// </summary>
    //    NewPartRequest,
    //    /// <summary>
    //    /// Price Update
    //    /// </summary>
    //    PriceUpdateRequest,
    //}

    /// <summary>
    /// This class is used to have information about new part request or price update from Enginnering system.
    /// </summary>
    [DataContract, Serializable]
    public class NewPartRequestModel : BaseModel<Guid>
    {

        /// <summary>
        /// Local Reference of CustomerCode
        /// </summary>
        private string _customerCode;
        /// <summary>
        /// Get or Sets the value of {CustomerCode} of NPR, exp: DENSO , NISSAN
        /// </summary>
        [DataMember]
        [StringLength(100)]
        [Required]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }
        /// <summary>
        /// Local Reference of RequestID
        /// </summary>
        private string _requestID;
        /// <summary>
        /// Get or Sets the value of indicating {RequestID} of NPR, exp: NPR0000001 for New Part Request, PUR0000001 for Price Update Request
        /// </summary>
        [DataMember]
        [StringLength(18)]
        [Required]
        public string RequestID
        {
            get => _requestID;
            set => SetProperty(ref _requestID, value);
        }

        /// <summary>
        /// Local reference of when NPR is created.
        /// </summary>
        private DateTime _creationDate;
        /// <summary>
        /// Gets of Sets the value of indicating {CreationDate} of NPR
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime CreationDate
        {
            get => _creationDate;
            set => SetProperty(ref _creationDate, value.Date);
        }

        /// <summary>
        /// Local reference of OriginatorName
        /// </summary>
        private string _originatorName;
        /// <summary>
        /// Gets of Sets the value of indicating {Originator} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string OriginatorName
        {
            get => _originatorName;
            set => SetProperty(ref _originatorName, value);
        }

        /// <summary>
        /// Local reference of DeadlineDate
        /// </summary>
        private DateTime _deadlineDate;
        /// <summary>
        /// Gets of Sets the value of indicating {DeadlineDate} of NPR
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime DeadlineDate
        {
            get => _deadlineDate;
            set => SetProperty(ref _deadlineDate, value.Date);
        }

        /// <summary>
        /// Local reference of ReasonDescription
        /// </summary>
        private string _reasonDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {ReasonDescription} of NPR , exp : New Business from OEM/Product Distribution/Supplier Tender
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ReasonDescription
        {
            get => _reasonDescription;
            set => SetProperty(ref _reasonDescription, value);
        }

        /// <summary>
        /// Local reference of MaterialNumber
        /// </summary>
        private string _materialNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialNumber} of NPR , also known as Sumitomo Part Number , can be left blank.
        /// </summary>
        [DataMember]
        [StringLength(26)]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }

        /// <summary>
        /// Local reference of MaterialDescription
        /// </summary>
        private string _materialDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialDescription} of NPR
        /// </summary>
        [DataMember]
        [StringLength(15)]
        public string MaterialDescription
        {
            get => _materialDescription;
            set => SetProperty(ref _materialDescription, value);
        }

        /// <summary>
        /// Local reference of MaterialTypeCode
        /// </summary>
        private string _materialTypeCode;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialTypeCode} of NPR, exp: 1 - Component/2 - Cut Tube/3 - Wire
        /// </summary>
        [DataMember]
        [StringLength(1)]
        [Required]
        public string MaterialTypeCode
        {
            get => _materialTypeCode;
            set => SetProperty(ref _materialTypeCode, value);
        }

        /// <summary>
        /// Local reference of MaterialTypeDescription property
        /// </summary>
        private string _materialTypeDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialTypeDescription} of NPR, exp: Component/CutTubes/Wire
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string MaterialTypeDescription
        {
            get => _materialTypeDescription;
            set => SetProperty(ref _materialTypeDescription, value);
        }

        /// <summary>
        /// Local reference of CommodityDescription
        /// </summary>
        private string _commodityDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {CommodityDescription} of NPR , exp : BATTERY CABLE , Clamp
        /// </summary>
        [DataMember]
        [StringLength(30)]
        [Required]
        public string CommodityDescription
        {
            get => _commodityDescription;
            set => SetProperty(ref _commodityDescription, value);
        }

        /// <summary>
        /// Local reference of CustomerPartNumber
        /// </summary>
        private string _customerPartNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {CustomerPartNumber} of NPR
        /// </summary>
        [DataMember]
        [StringLength(26)]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => SetProperty(ref _customerPartNumber, value);
        }

        /// <summary>
        /// Local reference of SupplierPartNumber
        /// </summary>
        private string _supplierPartNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {SupplierPartNumber} of NPR
        /// </summary>
        [DataMember]
        [StringLength(26)]
        [Required]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => SetProperty(ref _supplierPartNumber, value);
        }

        /// <summary>
        /// Local reference of BOMUnitOfMeasurement
        /// </summary>
        private string _bomUnitofMeasurement;
        /// <summary>
        /// Gets of Sets the value of indicating {BOMUnitOfMeasurement} of NPR
        /// </summary>
        [DataMember]
        [StringLength(10)]
        [Required]
        public string BOMUnitOfMeasurement
        {
            get => _bomUnitofMeasurement;
            set => SetProperty(ref _bomUnitofMeasurement, value);
        }

        /// <summary>
        /// Local Reference of _bomUnitofMeasurementGuid
        /// </summary>
        private Guid _bomUnitofMeasurementGuid;
        /// <summary>
        /// get or set for BomUnitofMeasurementGuid
        /// </summary>
        [DataMember]
        public Guid BomUnitofMeasurementGuid
        {
            get => _bomUnitofMeasurementGuid;
            set => SetProperty(ref _bomUnitofMeasurementGuid, value);
        }

        /// <summary>
        /// Local reference of SEWSEUnitOfMeasurement
        /// </summary>
        private string _sewseUnitofMeasurement;
        /// <summary>
        /// Gets of Sets the value of indicating {SEWSEUnitOfMeasurement} of NPR
        /// </summary>
        [DataMember]
        [StringLength(10)]
        [Required]
        public string SEWSEUnitOfMeasurement
        {
            get => _sewseUnitofMeasurement;
            set => SetProperty(ref _sewseUnitofMeasurement, value);
        }

        /// <summary>
        /// Local reference of ManufacturerGroup property
        /// </summary>
        private string _manufacturerGroup;
        /// <summary>
        /// Gets of Sets the value of indicating {ManufacturerGroup} supplier group of NPR , exp : ACAPLAST , SEI
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string ManufacturerGroup
        {
            get => _manufacturerGroup;
            set => SetProperty(ref _manufacturerGroup, value);
        }

        /// <summary>
        /// Local reference of ProjectCode property
        /// </summary>
        private string _projectCode;
        /// <summary>
        /// Gets of Sets the value of indicating {ProjectCode}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        /// <summary>
        /// Local Reference of _projectHierarchyGuid
        /// </summary>
        private Guid _projectHierarchyGuid;
        /// <summary>
        /// get or set for ProjectHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid ProjectHierarchyGuid
        {
            get => _projectHierarchyGuid;
            set => SetProperty(ref _projectHierarchyGuid, value);
        }
        /// <summary>
        /// Local reference of QtyPerVehicle property
        /// </summary>
        private decimal _qtyPerVehicle;
        /// <summary>
        /// Gets of Sets the value of indicating {QtyPerVehicle}
        /// </summary>
        [DataMember]
        [Required]
        public decimal QtyPerVehicle
        {
            get => _qtyPerVehicle;
            set => SetProperty(ref _qtyPerVehicle, value);
        }

        /// <summary>
        /// Local reference of AnnualVolume property
        /// </summary>
        private Int64 _vehicleAnnualVolume;
        /// <summary>
        /// Gets of Sets the value of indicating {AnnualVolume}
        /// </summary>
        [DataMember]
        [Required]
        public Int64 VehicleAnnualVolume
        {
            get => _vehicleAnnualVolume;
            set => SetProperty(ref _vehicleAnnualVolume, value);
        }

        /// <summary>
        /// Local reference of TotalQuantity property
        /// </summary>
        private Int64 _vehicleTotalQuantity;
        /// <summary>
        /// Gets of Sets the value of indicating {VehicleTotalQuantity} , autocalculated as QtyPerVehicle * VehicleAnnualVolume
        /// </summary>
        [DataMember]
        [Required]
        public Int64 VehicleTotalQuantity
        {
            get => _vehicleTotalQuantity;
            set => SetProperty(ref _vehicleTotalQuantity, value);
        }
        ///// <summary>
        ///// Local reference of ProjectDetails
        ///// </summary>
        //private NPRProjectDetailsModel _projectDetails;
        ///// <summary>
        ///// Gets of Sets the value of indicating {ProjectDetails} a key value pair of Project details
        ///// </summary>
        //[DataMember]
        //public NPRProjectDetailsModel ProjectDetails
        //{
        //    get => _projectDetails;
        //    set => SetProperty(ref _projectDetails, value);
        //}
        ///// <summary>
        ///// Local reference of NPRProjectBuildDetails property
        ///// </summary>
        //private NPRProjectBuildDetailsModel _nprProjectBuildDetails;
        ///// <summary>
        ///// Gets of Sets the value of indicating {NPRProjectBuildDetails} for NPR
        ///// </summary>
        //[DataMember]
        //public NPRProjectBuildDetailsModel NPRProjectBuildDetails
        //{
        //    get => _nprProjectBuildDetails;
        //    set => SetProperty(ref _nprProjectBuildDetails, value);
        //}
        /// <summary>
        /// Local reference of SampleSiteDetails property
        /// </summary>
        private List<NPRSampleSiteModel> _sampleSiteDetails;
        /// <summary>
        /// Gets of Sets the value of indicating {SampleSiteDetails} a key value pair of Project details
        /// </summary>
        [DataMember]
        public List<NPRSampleSiteModel> SampleSiteDetails
        {
            get => _sampleSiteDetails;
            set => SetProperty(ref _sampleSiteDetails, value);
        }

        private string _nprStage;
        /// <summary>
        /// Gets or sets a string value for the NPR Stages.
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string NPRStage
        {
            get => _nprStage;
            set => SetProperty(ref _nprStage, value);
        }
        /// <summary>
        /// Local Reference of NPRStatus
        /// </summary>
        private string _nprType;
        /// <summary>
        /// Get or Sets the value of indicating {NPRStatus} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(20)]
        public string NPRType
        {
            get => _nprType;
            set => SetProperty(ref _nprType, value);
        }
        /// <summary>
        /// Local Reference of SupplierDetailComments
        /// </summary>
        private string _supplierDetailComments;
        /// <summary>
        /// Get or Sets the value of indicating {SupplierDetailsComments} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string SupplierDetailComments
        {
            get => _supplierDetailComments;
            set => SetProperty(ref _supplierDetailComments, value);
        }

        /// <summary>
        /// Local Reference of NPRCancellationComments
        /// </summary>
        private string _nprCancellationComments;
        /// <summary>
        /// Get or Sets the value of indicating {NPRCancellationComments} , it can only be cancelled by Engineering or Purchasing
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string NPRCancellationComments
        {
            get => _nprCancellationComments;
            set => SetProperty(ref _nprCancellationComments, value);
        }

        /// <summary>
        /// Local Reference of NPRRaisedRemarks
        /// </summary>
        private string _nprRaisedRemarks;
        /// <summary>
        /// Get or Sets the value of indicating {NPRRaisedRemarks} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string NPRRaisedRemarks
        {
            get => _nprRaisedRemarks;
            set => SetProperty(ref _nprRaisedRemarks, value);
        }

        /// <summary>
        /// Local reference of ManufacturingSite
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Gets of Sets the value of indicating {ManufacturingSite} of NPR
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }

        /// <summary>
        /// Local Reference of NPRReturnedRemarks
        /// </summary>
        private string _nprReturnedRemarks;
        /// <summary>
        /// NPR Returned Remarks
        /// </summary>
        [DataMember]
        public string NPRReturnedRemarks
        {
            get => _nprReturnedRemarks;
            set => SetProperty(ref _nprReturnedRemarks, value);
        }

        /// <summary>
        /// Local Reference of IsCustomerNominatedSupplier
        /// </summary>
        private bool _isCustomerNominatedSupplier;
        /// <summary>
        /// Is Customer Nominated Supplier
        /// </summary>
        [DataMember]
        public bool IsCustomerNominatedSupplier
        {
            get => _isCustomerNominatedSupplier;
            set => SetProperty(ref _isCustomerNominatedSupplier, value);
        }

        /// <summary>
        /// Local Reference of IsCustomerNominatedMaterial
        /// </summary>
        private bool _isCustomerNominatedMaterial;
        /// <summary>
        /// Is Customer Nominated Material
        /// </summary>
        [DataMember]
        public bool IsCustomerNominatedMaterial
        {
            get => _isCustomerNominatedMaterial;
            set => SetProperty(ref _isCustomerNominatedMaterial, value);
        }

        /// <summary>
        /// Local reference of PlatformName property
        /// </summary>
        private string _platformName;
        /// <summary>
        /// Gets of Sets the value of indicating {PlatformName}
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string PlatformName
        {
            get => _platformName;
            set => SetProperty(ref _platformName, value);
        }


        /// <summary>
        /// Local Reference of _platformHierarchyGuid
        /// </summary>
        private Guid _platformHierarchyGuid;
        /// <summary>
        /// get or set for PlatformHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid PlatformHierarchyGuid
        {
            get => _platformHierarchyGuid;
            set => SetProperty(ref _platformHierarchyGuid, value);
        }


        /// <summary>
        /// Local reference of ProgramName property
        /// </summary>
        private string _programName;
        /// <summary>
        /// Gets of Sets the value of indicating {ProgramName}
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ProgramName
        {
            get => _programName;
            set => SetProperty(ref _programName, value);
        }

        /// <summary>
        /// Local Reference of _programHierarchyGuid
        /// </summary>
        private Guid _programHierarchyGuid;
        /// <summary>
        /// get or set for ProgramHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid ProgramHierarchyGuid
        {
            get => _programHierarchyGuid;
            set => SetProperty(ref _programHierarchyGuid, value);
        }

        /// <summary>
        /// Local Reference of IsAdhoc
        /// </summary>
        private bool _isAdhoc = false;
        /// <summary>
        /// Is Adhoc NPR
        /// </summary>
        [DataMember]
        public bool IsAdhoc
        {
            get => _isAdhoc;
            set => SetProperty(ref _isAdhoc, value);
        }

        /// <summary>
        /// Local Reference of CustomerHierarchyGuid
        /// </summary>
        private Guid _customerHierarchyGuid;
        /// <summary>
        /// get or set for CustomerHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid CustomerHierarchyGuid
        {
            get => _customerHierarchyGuid;
            set => SetProperty(ref _customerHierarchyGuid, value);
        }

        /// <summary>
        /// Local Reference of _commodityGuid
        /// </summary>
        private Guid _commodityGuid;
        /// <summary>
        /// get or set for CommodityGuid
        /// </summary>
        [DataMember]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }

        /// <summary>
        /// Local Reference of _supplierGroupGuid
        /// </summary>
        private Guid _supplierGroupGuid;
        /// <summary>
        /// get or set for SupplierGroupGuid
        /// </summary>
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }
        private List<Guid> _manufacturingSiteGuid;
        /// <summary>
        /// ManufacturingSite Guid
        /// </summary>
        [DataMember]
        public List<Guid> ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => SetProperty(ref _manufacturingSiteGuid, value);
        }


        /// <summary>
        /// Local reference of SuggestedManufacturerGroup property
        /// </summary>
        private string _suggestedmanufacturerGroup;
        /// <summary>
        /// Gets of Sets the value of indicating {_suggestedManufacturerGroup} supplier group of NPR , exp : ACAPLAST , SEI
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string SuggestedManufacturerGroup
        {
            get => _suggestedmanufacturerGroup;
            set => SetProperty(ref _suggestedmanufacturerGroup, value);
        }

        /// <summary>
        /// Local reference of SuggestedManufacturerGroupGuid property
        /// </summary>
        private Guid _suggestedmanufacturerGroupGuid;
        /// <summary>
        /// Gets of Sets the value of indicating {SuggestedManufacturerGroupGuid} supplier group of NPR , exp : ACAPLAST , SEI
        /// </summary>
        [DataMember]

        public Guid SuggestedManufacturerGroupGuid
        {
            get => _suggestedmanufacturerGroupGuid;
            set => SetProperty(ref _suggestedmanufacturerGroupGuid, value);
        }

        /// <summary>
        /// Local reference of AssociatedParts property
        /// </summary>
        private string _associatedParts;
        /// <summary>
        /// Gets of Sets the value of indicating {AssociatedParts} 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string AssociatedParts
        {
            get => _associatedParts;
            set => SetProperty(ref _associatedParts, value);
        }
    }

    public class FilterNewPartRequestModelData
    {

        private string _nprType;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public string NprType
        {
            get => _nprType;
            set => _nprType = value;
        }

        private string _emailId;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public string EmailId
        {
            get => _emailId;
            set => _emailId = value;
        }


        private string _requestId;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public string RequestId
        {
            get => _requestId;
            set => _requestId = value;
        }


        private Guid _id;
        /// <summary>
        /// Get or Set for {MaterialGuid}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private string _nprStage;
        /// <summary>
        /// Get or Set for {SupplierGroupGuid}.
        /// </summary>
        [DataMember]
        public string NprStage
        {
            get => _nprStage;
            set => _nprStage = value;
        }

        private string _originatorName;
        /// <summary>
        /// Get or Set for {AuditStatus}.
        /// </summary>
        [DataMember]
        public string OriginatorName
        {
            get => _originatorName;
            set => _originatorName = value;
        }

        private string _viewName;
        /// <summary>
        /// Get or Set for {MaterialNumber}.
        /// </summary>
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
        private string _projectHierarchyGuid;
        /// <summary>
        /// Get or Set for {ProjectHierarchyGuid}.
        /// </summary>
        [DataMember]
        public string ProjectHierarchyGuid
        {
            get => _projectHierarchyGuid;
            set => _projectHierarchyGuid = value;
        }

    }
    [DataContract, Serializable]
    public class UXDisplayCreateUpdateNPRModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference of CustomerCode
        /// </summary>
        private string _customerCode;
        /// <summary>
        /// Get or Sets the value of {CustomerCode} of NPR, exp: DENSO , NISSAN
        /// </summary>
        [DataMember]
        [StringLength(100)]
        [Required]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }
        /// <summary>
        /// Local Reference of RequestID
        /// </summary>
        private string _requestID;
        /// <summary>
        /// Get or Sets the value of indicating {RequestID} of NPR, exp: NPR0000001 for New Part Request, PUR0000001 for Price Update Request
        /// </summary>
        [DataMember]
        [StringLength(18)]
        [Required]
        public string RequestID
        {
            get => _requestID;
            set => SetProperty(ref _requestID, value);
        }

        /// <summary>
        /// Local reference of when NPR is created.
        /// </summary>
        private DateTime _creationDate;
        /// <summary>
        /// Gets of Sets the value of indicating {CreationDate} of NPR
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime CreationDate
        {
            get => _creationDate;
            set => SetProperty(ref _creationDate, value.Date);
        }

        /// <summary>
        /// Local reference of OriginatorName
        /// </summary>
        private string _originatorName;
        /// <summary>
        /// Gets of Sets the value of indicating {Originator} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string OriginatorName
        {
            get => _originatorName;
            set => SetProperty(ref _originatorName, value);
        }

        /// <summary>
        /// Local reference of DeadlineDate
        /// </summary>
        private DateTime _deadlineDate;
        /// <summary>
        /// Gets of Sets the value of indicating {DeadlineDate} of NPR
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime DeadlineDate
        {
            get => _deadlineDate;
            set => SetProperty(ref _deadlineDate, value.Date);
        }

        /// <summary>
        /// Local reference of ReasonDescription
        /// </summary>
        private string _reasonDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {ReasonDescription} of NPR , exp : New Business from OEM/Product Distribution/Supplier Tender
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ReasonDescription
        {
            get => _reasonDescription;
            set => SetProperty(ref _reasonDescription, value);
        }

        /// <summary>
        /// Local reference of MaterialNumber
        /// </summary>
        private string _materialNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialNumber} of NPR , also known as Sumitomo Part Number , can be left blank.
        /// </summary>
        [DataMember]
        [StringLength(26)]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }

        /// <summary>
        /// Local reference of MaterialDescription
        /// </summary>
        private string _materialDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialDescription} of NPR
        /// </summary>
        [DataMember]
        [StringLength(15)]
        public string MaterialDescription
        {
            get => _materialDescription;
            set => SetProperty(ref _materialDescription, value);
        }

        /// <summary>
        /// Local reference of MaterialTypeCode
        /// </summary>
        private string _materialTypeCode;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialTypeCode} of NPR, exp: 1 - Component/2 - Cut Tube/3 - Wire
        /// </summary>
        [DataMember]
        [StringLength(1)]
        [Required]
        public string MaterialTypeCode
        {
            get => _materialTypeCode;
            set => SetProperty(ref _materialTypeCode, value);
        }

        /// <summary>
        /// Local reference of MaterialTypeDescription property
        /// </summary>
        private string _materialTypeDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {MaterialTypeDescription} of NPR, exp: Component/CutTubes/Wire
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string MaterialTypeDescription
        {
            get => _materialTypeDescription;
            set => SetProperty(ref _materialTypeDescription, value);
        }

        /// <summary>
        /// Local reference of CommodityDescription
        /// </summary>
        private string _commodityDescription;
        /// <summary>
        /// Gets of Sets the value of indicating {CommodityDescription} of NPR , exp : BATTERY CABLE , Clamp
        /// </summary>
        [DataMember]
        [StringLength(30)]
        [Required]
        public string CommodityDescription
        {
            get => _commodityDescription;
            set => SetProperty(ref _commodityDescription, value);
        }

        /// <summary>
        /// Local reference of CustomerPartNumber
        /// </summary>
        private string _customerPartNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {CustomerPartNumber} of NPR
        /// </summary>
        [DataMember]
        [StringLength(26)]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => SetProperty(ref _customerPartNumber, value);
        }

        /// <summary>
        /// Local reference of SupplierPartNumber
        /// </summary>
        private string _supplierPartNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {SupplierPartNumber} of NPR
        /// </summary>
        [DataMember]
        [StringLength(26)]
        [Required]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => SetProperty(ref _supplierPartNumber, value);
        }

        /// <summary>
        /// Local reference of BOMUnitOfMeasurement
        /// </summary>
        private string _bomUnitofMeasurement;
        /// <summary>
        /// Gets of Sets the value of indicating {BOMUnitOfMeasurement} of NPR
        /// </summary>
        [DataMember]
        [StringLength(10)]
        [Required]
        public string BOMUnitOfMeasurement
        {
            get => _bomUnitofMeasurement;
            set => SetProperty(ref _bomUnitofMeasurement, value);
        }

        /// <summary>
        /// Local Reference of _bomUnitofMeasurementGuid
        /// </summary>
        private Guid _bomUnitofMeasurementGuid;
        /// <summary>
        /// get or set for BomUnitofMeasurementGuid
        /// </summary>
        [DataMember]
        public Guid BomUnitofMeasurementGuid
        {
            get => _bomUnitofMeasurementGuid;
            set => SetProperty(ref _bomUnitofMeasurementGuid, value);
        }

        /// <summary>
        /// Local reference of SEWSEUnitOfMeasurement
        /// </summary>
        private string _sewseUnitofMeasurement;
        /// <summary>
        /// Gets of Sets the value of indicating {SEWSEUnitOfMeasurement} of NPR
        /// </summary>
        [DataMember]
        [StringLength(10)]
        [Required]
        public string SEWSEUnitOfMeasurement
        {
            get => _sewseUnitofMeasurement;
            set => SetProperty(ref _sewseUnitofMeasurement, value);
        }

        /// <summary>
        /// Local reference of ManufacturerGroup property
        /// </summary>
        private string _manufacturerGroup;
        /// <summary>
        /// Gets of Sets the value of indicating {ManufacturerGroup} supplier group of NPR , exp : ACAPLAST , SEI
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string ManufacturerGroup
        {
            get => _manufacturerGroup;
            set => SetProperty(ref _manufacturerGroup, value);
        }

        /// <summary>
        /// Local reference of ProjectCode property
        /// </summary>
        private string _projectCode;
        /// <summary>
        /// Gets of Sets the value of indicating {ProjectCode}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        /// <summary>
        /// Local Reference of _projectHierarchyGuid
        /// </summary>
        private Guid _projectHierarchyGuid;
        /// <summary>
        /// get or set for ProjectHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid ProjectHierarchyGuid
        {
            get => _projectHierarchyGuid;
            set => SetProperty(ref _projectHierarchyGuid, value);
        }
        /// <summary>
        /// Local reference of QtyPerVehicle property
        /// </summary>
        private decimal _qtyPerVehicle;
        /// <summary>
        /// Gets of Sets the value of indicating {QtyPerVehicle}
        /// </summary>
        [DataMember]
        [Required]
        public decimal QtyPerVehicle
        {
            get => _qtyPerVehicle;
            set => SetProperty(ref _qtyPerVehicle, value);
        }

        /// <summary>
        /// Local reference of AnnualVolume property
        /// </summary>
        private Int64 _vehicleAnnualVolume;
        /// <summary>
        /// Gets of Sets the value of indicating {AnnualVolume}
        /// </summary>
        [DataMember]
        [Required]
        public Int64 VehicleAnnualVolume
        {
            get => _vehicleAnnualVolume;
            set => SetProperty(ref _vehicleAnnualVolume, value);
        }

        /// <summary>
        /// Local reference of TotalQuantity property
        /// </summary>
        private Int64 _vehicleTotalQuantity;
        /// <summary>
        /// Gets of Sets the value of indicating {VehicleTotalQuantity} , autocalculated as QtyPerVehicle * VehicleAnnualVolume
        /// </summary>
        [DataMember]
        [Required]
        public Int64 VehicleTotalQuantity
        {
            get => _vehicleTotalQuantity;
            set => SetProperty(ref _vehicleTotalQuantity, value);
        }
        ///// <summary>
        ///// Local reference of ProjectDetails
        ///// </summary>
        //private NPRProjectDetailsModel _projectDetails;
        ///// <summary>
        ///// Gets of Sets the value of indicating {ProjectDetails} a key value pair of Project details
        ///// </summary>
        //[DataMember]
        //public NPRProjectDetailsModel ProjectDetails
        //{
        //    get => _projectDetails;
        //    set => SetProperty(ref _projectDetails, value);
        //}
        ///// <summary>
        ///// Local reference of NPRProjectBuildDetails property
        ///// </summary>
        //private NPRProjectBuildDetailsModel _nprProjectBuildDetails;
        ///// <summary>
        ///// Gets of Sets the value of indicating {NPRProjectBuildDetails} for NPR
        ///// </summary>
        //[DataMember]
        //public NPRProjectBuildDetailsModel NPRProjectBuildDetails
        //{
        //    get => _nprProjectBuildDetails;
        //    set => SetProperty(ref _nprProjectBuildDetails, value);
        //}
        /// <summary>
        /// Local reference of SampleSiteDetails property
        /// </summary>
        private List<NPRSampleSiteModel> _sampleSiteDetails;
        /// <summary>
        /// Gets of Sets the value of indicating {SampleSiteDetails} a key value pair of Project details
        /// </summary>
        [DataMember]

        public List<NPRSampleSiteModel> SampleSiteDetails
        {
            get => _sampleSiteDetails;
            set => SetProperty(ref _sampleSiteDetails, value);
        }

        private string _nprStage;
        /// <summary>
        /// Gets or sets a string value for the NPR Stages.
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string NPRStage
        {
            get => _nprStage;
            set => SetProperty(ref _nprStage, value);
        }
        /// <summary>
        /// Local Reference of NPRStatus
        /// </summary>
        private string _nprType;
        /// <summary>
        /// Get or Sets the value of indicating {NPRStatus} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(20)]
        public string NPRType
        {
            get => _nprType;
            set => SetProperty(ref _nprType, value);
        }
        /// <summary>
        /// Local Reference of SupplierDetailComments
        /// </summary>
        private string _supplierDetailComments;
        /// <summary>
        /// Get or Sets the value of indicating {SupplierDetailsComments} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string SupplierDetailComments
        {
            get => _supplierDetailComments;
            set => SetProperty(ref _supplierDetailComments, value);
        }

        /// <summary>
        /// Local Reference of NPRCancellationComments
        /// </summary>
        private string _nprCancellationComments;
        /// <summary>
        /// Get or Sets the value of indicating {NPRCancellationComments} , it can only be cancelled by Engineering or Purchasing
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string NPRCancellationComments
        {
            get => _nprCancellationComments;
            set => SetProperty(ref _nprCancellationComments, value);
        }

        /// <summary>
        /// Local Reference of NPRRaisedRemarks
        /// </summary>
        private string _nprRaisedRemarks;
        /// <summary>
        /// Get or Sets the value of indicating {NPRRaisedRemarks} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(500)]
        public string NPRRaisedRemarks
        {
            get => _nprRaisedRemarks;
            set => SetProperty(ref _nprRaisedRemarks, value);
        }

        /// <summary>
        /// Local reference of ManufacturingSite
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Gets of Sets the value of indicating {ManufacturingSite} of NPR
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }

        /// <summary>
        /// Local Reference of NPRReturnedRemarks
        /// </summary>
        private string _nprReturnedRemarks;
        /// <summary>
        /// NPR Returned Remarks
        /// </summary>
        [DataMember]
        public string NPRReturnedRemarks
        {
            get => _nprReturnedRemarks;
            set => SetProperty(ref _nprReturnedRemarks, value);
        }

        /// <summary>
        /// Local Reference of IsCustomerNominatedSupplier
        /// </summary>
        private bool _isCustomerNominatedSupplier;
        /// <summary>
        /// Is Customer Nominated Supplier
        /// </summary>
        [DataMember]
        public bool IsCustomerNominatedSupplier
        {
            get => _isCustomerNominatedSupplier;
            set => SetProperty(ref _isCustomerNominatedSupplier, value);
        }

        /// <summary>
        /// Local Reference of IsCustomerNominatedMaterial
        /// </summary>
        private bool _isCustomerNominatedMaterial;
        /// <summary>
        /// Is Customer Nominated Material
        /// </summary>
        [DataMember]
        public bool IsCustomerNominatedMaterial
        {
            get => _isCustomerNominatedMaterial;
            set => SetProperty(ref _isCustomerNominatedMaterial, value);
        }

        /// <summary>
        /// Local reference of PlatformName property
        /// </summary>
        private string _platformName;
        /// <summary>
        /// Gets of Sets the value of indicating {PlatformName}
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string PlatformName
        {
            get => _platformName;
            set => SetProperty(ref _platformName, value);
        }


        /// <summary>
        /// Local Reference of _platformHierarchyGuid
        /// </summary>
        private Guid _platformHierarchyGuid;
        /// <summary>
        /// get or set for PlatformHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid PlatformHierarchyGuid
        {
            get => _platformHierarchyGuid;
            set => SetProperty(ref _platformHierarchyGuid, value);
        }


        /// <summary>
        /// Local reference of ProgramName property
        /// </summary>
        private string _programName;
        /// <summary>
        /// Gets of Sets the value of indicating {ProgramName}
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ProgramName
        {
            get => _programName;
            set => SetProperty(ref _programName, value);
        }

        /// <summary>
        /// Local Reference of _programHierarchyGuid
        /// </summary>
        private Guid _programHierarchyGuid;
        /// <summary>
        /// get or set for ProgramHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid ProgramHierarchyGuid
        {
            get => _programHierarchyGuid;
            set => SetProperty(ref _programHierarchyGuid, value);
        }

        /// <summary>
        /// Local Reference of IsAdhoc
        /// </summary>
        private bool _isAdhoc = false;
        /// <summary>
        /// Is Adhoc NPR
        /// </summary>
        [DataMember]
        public bool IsAdhoc
        {
            get => _isAdhoc;
            set => SetProperty(ref _isAdhoc, value);
        }

        /// <summary>
        /// Local Reference of CustomerHierarchyGuid
        /// </summary>
        private Guid _customerHierarchyGuid;
        /// <summary>
        /// get or set for CustomerHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid CustomerHierarchyGuid
        {
            get => _customerHierarchyGuid;
            set => SetProperty(ref _customerHierarchyGuid, value);
        }

        /// <summary>
        /// Local Reference of _commodityGuid
        /// </summary>
        private Guid _commodityGuid;
        /// <summary>
        /// get or set for CommodityGuid
        /// </summary>
        [DataMember]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }

        /// <summary>
        /// Local Reference of _supplierGroupGuid
        /// </summary>
        private Guid _supplierGroupGuid;
        /// <summary>
        /// get or set for SupplierGroupGuid
        /// </summary>
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => SetProperty(ref _supplierGroupGuid, value);
        }
        private List<Guid> _manufacturingSiteGuid;
        /// <summary>
        /// ManufacturingSite Guid
        /// </summary>
        [DataMember]
        public List<Guid> ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => SetProperty(ref _manufacturingSiteGuid, value);
        }


        private string _startOfProduction;
        [DataMember]
        public string StartOfProduction
        {
            get { return _startOfProduction; }
            set { SetProperty(ref _startOfProduction, value); }
        }

        private string _reasonDescriptionHidden;
        [DataMember]
        public string ReasonDescriptionHidden
        {
            get { return _reasonDescriptionHidden; }
            set { SetProperty(ref _reasonDescriptionHidden, value); }
        }

        private bool _checkMaterialNumber;
        [DataMember]
        public bool CheckMaterialNumber
        {
            get { return _checkMaterialNumber; }
            set { SetProperty(ref _checkMaterialNumber, value); }
        }

        private bool _checkMaterialNumberLength;
        [DataMember]
        public bool CheckMaterialNumberLength
        {
            get { return _checkMaterialNumberLength; }
            set { SetProperty(ref _checkMaterialNumberLength, value); }
        }


        private string _projectCodePrevious;
        [DataMember]
        public string ProjectCodePrevious
        {
            get { return _projectCodePrevious; }
            set { SetProperty(ref _projectCodePrevious, value); }
        }

        private string _previousCommodityName;
        [DataMember]
        public string PreviousCommodityName
        {
            get { return _previousCommodityName; }
            set { SetProperty(ref _previousCommodityName, value); }
        }

        private string _previousManufacturerGroup;
        [DataMember]
        public string PreviousManufacturerGroup
        {
            get { return _previousManufacturerGroup; }
            set { SetProperty(ref _previousManufacturerGroup, value); }
        }



        private bool _verifyNPR;
        [DataMember]
        public bool VerifyNPR
        {
            get { return _verifyNPR; }
            set { SetProperty(ref _verifyNPR, value); }
        }

        private bool _cancelNPR;
        [DataMember]
        public bool CancelNPR
        {
            get { return _cancelNPR; }
            set { SetProperty(ref _cancelNPR, value); }
        }

        private bool _isErrorTrue;
        [DataMember]
        public bool IsErrorTrue
        {
            get { return _isErrorTrue; }
            set { SetProperty(ref _isErrorTrue, value); }
        }


        private bool _submittoBuyer;
        [DataMember]
        public bool SubmittoBuyer
        {
            get { return _submittoBuyer; }
            set { SetProperty(ref _submittoBuyer, value); }
        }


        private bool _isSWSPartNumberRequired;
        [DataMember]
        public bool IsSWSPartNumberRequired
        {
            get { return _isSWSPartNumberRequired; }
            set { SetProperty(ref _isSWSPartNumberRequired, value); }
        }

        private bool _isSampleRequired;
        [DataMember]
        public bool IsSampleRequired
        {
            get { return _isSampleRequired; }
            set { SetProperty(ref _isSampleRequired, value); }
        }

        private decimal _poPrice;
        [DataMember]
        public decimal POPrice
        {
            get { return _poPrice; }
            set { SetProperty(ref _poPrice, value); }
        }

        //private Guid _commodityGuid;
        //public Guid CommodityGuid
        //{
        //    get { return _commodityGuid; }
        //    set { SetProperty(ref _commodityGuid, value); }
        //}

        private string _NPRStageDescription;
        [DataMember]
        public string NPRStageDescription
        {
            get { return _NPRStageDescription; }
            set { SetProperty(ref _NPRStageDescription, value); }
        }

        private bool _isPastDeadlineDate;
        [DataMember]
        public bool IsPastDeadlineDate
        {
            get { return _isPastDeadlineDate; }
            set { SetProperty(ref _isPastDeadlineDate, value); }
        }



        private bool _samplesReceipt;
        [DataMember]
        public bool SamplesReceipt
        {
            get { return _samplesReceipt; }
            set { SetProperty(ref _samplesReceipt, value); }
        }

        private bool _isValidDeadlineDate;
        [DataMember]
        public bool IsValidDeadlineDate
        {
            get { return _isValidDeadlineDate; }
            set { SetProperty(ref _isValidDeadlineDate, value); }
        }

        private bool _approvedPrice;
        [DataMember]
        public bool ApprovedPrice
        {
            get { return _approvedPrice; }
            set { SetProperty(ref _approvedPrice, value); }
        }

        private string _currency;
        [DataMember]
        public string Currency
        {
            get { return _currency; }
            set { SetProperty(ref _currency, value); }
        }

        private string _poUOM;
        [DataMember]
        public string POUOM
        {
            get { return _poUOM; }
            set { SetProperty(ref _poUOM, value); }
        }

        private string _newNPRStage;
        [DataMember]
        public string NewNPRStage
        {
            get { return _newNPRStage; }
            set { SetProperty(ref _newNPRStage, value); }
        }
        private string _buyerName;
        [DataMember]
        public string BuyerName
        {
            get { return _buyerName; }
            set { SetProperty(ref _buyerName, value); }
        }
        private Guid _manufacturingGuid;
        [DataMember]
        public Guid ManufacturingGuid
        {
            get { return _manufacturingGuid; }
            set { SetProperty(ref _manufacturingGuid, value); }
        }

        private bool _requestReturn;
        [DataMember]
        public bool RequestReturn
        {
            get { return _requestReturn; }
            set { SetProperty(ref _requestReturn, value); }
        }


        /// <summary>
        /// Local reference of SuggestedManufacturerGroup property
        /// </summary>
        private string _suggestedmanufacturerGroup;
        /// <summary>
        /// Gets of Sets the value of indicating {_suggestedManufacturerGroup} supplier group of NPR , exp : ACAPLAST , SEI
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string SuggestedManufacturerGroup
        {
            get => _suggestedmanufacturerGroup;
            set => SetProperty(ref _suggestedmanufacturerGroup, value);
        }

        /// <summary>
        /// Local reference of SuggestedManufacturerGroupGuid property
        /// </summary>
        private Guid _suggestedmanufacturerGroupGuid;
        /// <summary>
        /// Gets of Sets the value of indicating {SuggestedManufacturerGroupGuid} supplier group of NPR , exp : ACAPLAST , SEI
        /// </summary>
        [DataMember]

        public Guid SuggestedManufacturerGroupGuid
        {
            get => _suggestedmanufacturerGroupGuid;
            set => SetProperty(ref _suggestedmanufacturerGroupGuid, value);
        }
        /// <summary>
        /// Local reference of AssociatedParts property
        /// </summary>
        private string _associatedParts;
        /// <summary>
        /// Gets of Sets the value of indicating {AssociatedParts} 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string AssociatedParts
        {
            get => _associatedParts;
            set => SetProperty(ref _associatedParts, value);
        }
        /// <summary>
        /// Local reference of ActualManufacturingSite
        /// </summary>
        private string _actualManufacturingSite;
        /// <summary>
        /// Gets of Sets the value of indicating {ActualManufacturingSite} of NPR
        /// </summary>
        [DataMember]
        public string ActualManufacturingSite
        {
            get => _actualManufacturingSite;
            set => SetProperty(ref _actualManufacturingSite, value);
        }
        private List<Guid> _businessUnitGuid;
        /// <summary>
        /// BusinessUnitGuid 
        /// </summary>
        [DataMember]
        public List<Guid> BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }
    }


    public class FilterAssociatedPartsModel
    {
        private string _associatedParts;
        /// <summary>
        /// Get or Set for {ProjectHierarchyGuid}.
        /// </summary>
        [DataMember]
        public string AssociatedParts
        {
            get => _associatedParts;
            set => _associatedParts = value;
        }

    }

    public class MultiCheckManufacturingSiteModel : BusinessUnitModel
    {
        #region properties
        /// <summary>
        /// Local variable _isSelected     
        /// </summary>
        private bool _isSelected = false;
        /// <summary>
        /// Get or Set for {IsSelected}.
        /// </summary>
        [DataMember]
        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }
        /// <summary>
        /// Local reference of ManufacturingSite
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Gets of Sets the value of indicating {ManufacturingSite} of NPR
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }
        #endregion
    }

    public class SupplierGroupGuidModel
    {
        /// <summary>
        /// Local Reference of _supplierGroupGuid
        /// </summary>
        private Guid _supplierGroupGuid;
        /// <summary>
        /// get or set for SupplierGroupGuid
        /// </summary>
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => _supplierGroupGuid =  value;
        }
    }

    //prakhar
    public class CheckNprByRequestIdAndSupplierModel
    {
        private string _requestID;
        /// <summary>
        /// Get or Sets the value of indicating {RequestID} 
        /// </summary>
        [DataMember]
        public string RequestID
        {
            get => _requestID;
            set => _requestID = value;
        }

        private Guid _supplierGroupGuid;
        /// <summary>
        /// get or set for supplierGroupGuid
        /// </summary>
        [DataMember]
        public Guid SupplierGroupGuid
        {
            get => _supplierGroupGuid;
            set => _supplierGroupGuid = value;
        }

        private string _supplierGroupName;
        /// <summary>
        /// Get or Set for {SupplierGroupName}.
        /// </summary>
        [DataMember]
        public string SupplierGroupName
        {
            get => _supplierGroupName;
            set => _supplierGroupName = value;
        }
    }

}
