/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DRPManualOrderGenerationDataEntryModel.cs
Function           :   DRP Manual Order Generation Data Entry
Created By         :   Prakhar
Created on         :   18-Sep-2023
Revision History   :   [11-Dec-2023] : Prakhar
                   :   [] : Added model for SupplyChainIDCollection and modified model DRPManualOrderGenerationDataEntryDocumentIdModel
****************************************************************************************************/
using System;
using System.Collections.Generic;
using Common.Core.Contracts.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    [DataContract, Serializable]
    public class DRPManualOrderGenerationDataEntryModel : BaseModel<Guid>
    {
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private int _orderQuantity;
        /// <summary>
        /// Get or Set for {Orderquantity}.
        /// </summary>
        [DataMember]
        [Required]
       
        public int OrderQuantity
        {
            get => _orderQuantity;
            set => SetProperty(ref _orderQuantity, value);
        }

        private string _reasonForRequest;
        /// <summary>
        /// Get or Set for {ReasonForRequest}.
        /// </summary>
        [DataMember]
        [Required]

        public string ReasonForRequest
        {
            get => _reasonForRequest;
            set => SetProperty(ref _reasonForRequest, value);
        }

        private DateTime _receivedate;
        /// <summary>
        /// Get or Set for {Receivedate}.
        /// </summary>
        [DataMember]
        [Required]

        public DateTime Receivedate
        {
            get => _receivedate;
            set => SetProperty(ref _receivedate, value);
        }

        private string _documentStatus;
        /// <summary>
        /// Get or Set for {DocumentStatus}.
        /// </summary>
        [DataMember]
        [Required]

        public string DocumentStatus
        {
            get => _documentStatus;
            set => SetProperty(ref _documentStatus, value);
        }

        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        [Required]

        public string DocumentId
        {
            get => _documentId;
            set => SetProperty(ref _documentId, value);
        }      
    }

    //for Save

    public class DRPManualOrderGenerationDataEntrySaveModel : BaseModel<Guid>
    {
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]

        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private int _orderQuantity;
        /// <summary>
        /// Get or Set for {Orderquantity}.
        /// </summary>
        [DataMember]
        [Required]

        public int OrderQuantity
        {
            get => _orderQuantity;
            set => SetProperty(ref _orderQuantity, value);
        }

        private string _reasonForRequest;
        /// <summary>
        /// Get or Set for {ReasonForRequest}.
        /// </summary>
        [DataMember]
        [Required]

        public string ReasonForRequest
        {
            get => _reasonForRequest;
            set => SetProperty(ref _reasonForRequest, value);
        }

        private DateTime _receivedate;
        /// <summary>
        /// Get or Set for {Receivedate}.
        /// </summary>
        [DataMember]
        [Required]

        public DateTime Receivedate
        {
            get => _receivedate;
            set => SetProperty(ref _receivedate, value);
        }

        private string _documentStatus;
        /// <summary>
        /// Get or Set for {DocumentStatus}.
        /// </summary>
        [DataMember]
        [Required]

        public string DocumentStatus
        {
            get => _documentStatus;
            set => SetProperty(ref _documentStatus, value);
        }

        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        [Required]

        public string DocumentId
        {
            get => _documentId;
            set => SetProperty(ref _documentId, value);
        }

        //////

        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }

        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        private Guid _projectGuid;
        /// <summary>
        /// Get or Set for {ProjectGuid}.
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => _projectGuid = value;
        }

        private Guid _dCLocationGuid;
        /// <summary>
        /// Get or Set for {DCLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid DCLocationGuid
        {
            get => _dCLocationGuid;
            set => _dCLocationGuid = value;
        }

        private Guid _manufacturingSiteGuid;
        /// <summary>
        /// Get or Set for {ManufacturingSiteGuid}.
        /// </summary>
        [DataMember]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => _manufacturingSiteGuid = value;
        }

        private Guid _supplyChainGuid;
        /// <summary>
        /// Get or Set for {SupplyChainGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplyChainGuid
        {
            get => _supplyChainGuid;
            set => _supplyChainGuid = value;
        }

    }

    //Model Class for fetching DocumentId
    public class DRPManualOrderGenerationDataEntryDocumentIdModel 
    {
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }


        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        private string _dCLocation;
        /// <summary>
        /// Get or Set for {DCLocation}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string DCLocation
        {
            get => _dCLocation;
            set => _dCLocation = value;
        }

        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => _manufacturingSite = value;
        }

        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string DocumentId
        {
            get => _documentId;
            set => _documentId = value;
        }

        //private string _customerBusinessGroupName;
        ///// <summary>
        ///// Get or Set for {CustomerBusinessGroupName}.
        ///// </summary>
        //[DataMember]
        //[StringLength(100)]
        //public string CustomerBusinessGroupName
        //{
        //    get => _customerBusinessGroupName;
        //    set => _customerBusinessGroupName = value;
        //}

        private string _documentStatus;
        /// <summary>
        /// Get or Set for {DocumentStatus}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string DocumentStatus
        {
            get => _documentStatus;
            set => _documentStatus = value;
        }

        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }

        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        private Guid _projectGuid;
        /// <summary>
        /// Get or Set for {ProjectGuid}.
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => _projectGuid = value;
        }

        private Guid _dCLocationGuid;
        /// <summary>
        /// Get or Set for {DCLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid DCLocationGuid
        {
            get => _dCLocationGuid;
            set => _dCLocationGuid = value;
        }

        private Guid _manufacturingSiteGuid;
        /// <summary>
        /// Get or Set for {ManufacturingSiteGuid}.
        /// </summary>
        [DataMember]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => _manufacturingSiteGuid = value;
        }

        private string _supplyChainId;
        /// <summary>
        /// Get or Set for {SupplyChainId}.
        /// </summary>
        [DataMember]
        public string SupplyChainId
        {
            get => _supplyChainId;
            set => _supplyChainId = value;
        }

        private Guid _supplyChainGuid;
        /// <summary>
        /// Get or Set for {SupplyChainGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplyChainGuid
        {
            get => _supplyChainGuid;
            set => _supplyChainGuid = value;
        }

    }

    //Model Class for fetching PartNo
    public class DRPManualOrderGenerationDataEntryPartNoModel
    {
        private string _customerPartNumber;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => _customerPartNumber = value;
        }

    }

    //For Upload

    public class DRPManualOrderGenerationDataEntryUploadModel 
    {

        private List<DRPManualOrderGenerationUploadModel> _dRPManualOrderGenerationUpload;
        /// <summary>
        /// DRPManualOrderGenerationUploadModel
        /// </summary>
        [DataMember]
        public List<DRPManualOrderGenerationUploadModel> DRPManualOrderGenerationUpload
        {
            get => _dRPManualOrderGenerationUpload;
            set => _dRPManualOrderGenerationUpload = value;
        }


        private string _dataExistsCheck;
        /// <summary>
        /// Get or Set for {DataExistsCheck}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]

        public string DataExistsCheck
        {
            get => _dataExistsCheck;
            set =>  _dataExistsCheck = value;
        }
       
    }

    public class DRPManualOrderGenerationUploadModel:BaseModel<Guid>
    {

        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]

        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }
        private int _orderQuantity;
        ///// <summary>
        ///// Get or Set for {Orderquantity}.
        ///// </summary>
        [DataMember]
        [Required]

        public int OrderQuantity
        {
            get => _orderQuantity;
            set => SetProperty(ref _orderQuantity, value);
        }

        private string _reasonForRequest;
        ///// <summary>
        ///// Get or Set for {ReasonForRequest}.
        ///// </summary>
        [DataMember]
        [Required]

        public string ReasonForRequest
        {
            get => _reasonForRequest;
            set => SetProperty(ref _reasonForRequest, value);
        }

        private string _documentId;
        ///// <summary>
        ///// Get or Set for {DocumentId}.
        ///// </summary>
        [DataMember]
        [Required]

        public string DocumentId
        {
            get => _documentId;
            set => SetProperty(ref _documentId, value);
        }

        private DateTime _receivedate;
        ///// <summary>
        ///// Get or Set for {Receivedate}.
        ///// </summary>
        [DataMember]
        [Required]

        public DateTime Receivedate
        {
            get => _receivedate;
            set => SetProperty(ref _receivedate, value);
        }

        private Guid _customerBusinessGroupGuid;
        ///// <summary>
        ///// Get or Set for {CustomerBusinessGroupGuid}.
        ///// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }

        private Guid _customerGuid;
        ///// <summary>
        ///// Get or Set for {CustomerGuid}.
        ///// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        private Guid _projectGuid;
        ///// <summary>
        ///// Get or Set for {ProjectGuid}.
        ///// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => _projectGuid = value;
        }

        private Guid _dCLocationGuid;
        ///// <summary>
        ///// Get or Set for {DCLocationGuid}.
        ///// </summary>
        [DataMember]
        public Guid DCLocationGuid
        {
            get => _dCLocationGuid;
            set => _dCLocationGuid = value;
        }

        private Guid _manufacturingSiteGuid;
        ///// <summary>
        ///// Get or Set for {ManufacturingSiteGuid}.
        ///// </summary>
        [DataMember]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => _manufacturingSiteGuid = value;
        }

        private Guid _supplyChainGuid;
        ///// <summary>
        ///// Get or Set for {SupplyChainGuid}.
        ///// </summary>
        [DataMember]
        public Guid SupplyChainGuid
        {
            get => _supplyChainGuid;
            set => _supplyChainGuid = value;
        }

        private string _remarks;
        ///// <summary>
        ///// Get or Set for {Remarks}.
        ///// </summary>
        [DataMember]
        [Required]

        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        private bool _isError;
        ///// <summary>
        ///// Get or Set for {IsError}.
        ///// </summary>
        [DataMember]
        [Required]

        public bool IsError
        {
            get => _isError;
            set => SetProperty(ref _isError, value);
        }
    }


    //Model Class for fetching Default DocumentID on Button Click
    public class DRPManualOrderGenerationDefaultDocumentID
    {
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }


        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        private string _dCLocation;
        /// <summary>
        /// Get or Set for {DCLocation}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string DCLocation
        {
            get => _dCLocation;
            set => _dCLocation = value;
        }

        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => _manufacturingSite = value;
        }

        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string DocumentId
        {
            get => _documentId;
            set => _documentId = value;
        }

    }

    //Export Error Model
    public class DRPManualOrderGenerationDataEntryErrorModel
    {
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]

        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber=  value;
        }

        private int _orderQuantity;
        /// <summary>
        /// Get or Set for {Orderquantity}.
        /// </summary>
        [DataMember]
        [Required]

        public int OrderQuantity
        {
            get => _orderQuantity;
            set => _orderQuantity = value;
        }

        private string _reasonForRequest;
        /// <summary>
        /// Get or Set for {ReasonForRequest}.
        /// </summary>
        [DataMember]
        [Required]

        public string ReasonForRequest
        {
            get => _reasonForRequest;
            set => _reasonForRequest = value;
        }

        private DateTime? _receivedate;
        /// <summary>
        /// Get or Set for {Receivedate}.
        /// </summary>
        [DataMember]
        [Required]

        public DateTime? Receivedate
        {
            get => _receivedate;
            set => _receivedate =  value;
        }

        private string _documentId;
        /// <summary>
        /// Get or Set for {DocumentId}.
        /// </summary>
        [DataMember]
        [Required]

        public string DocumentId
        {
            get => _documentId;
            set => _documentId = value;
        }


        private string _error;
        /// <summary>
        /// Get or Set for {IsError}.
        /// </summary>
        [DataMember]
        [Required]

        public string Error
        {
            get => _error;
            set => _error = value;
        }
    }

    public class SupplyChainIDCollection
    {
        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}.
        /// </summary>
        [DataMember]
        [Required]
        

        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [Required]
        

        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupName}.
        /// </summary>
        [DataMember]
        [Required]
        

        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => _customerBusinessGroupName = value;
        }

        private string _dCLocation;
        /// <summary>
        /// Get or Set for {DCLocation}.
        /// </summary>
        [DataMember]
        [Required]
        

        public string DCLocation
        {
            get => _dCLocation;
            set => _dCLocation = value;
        }

        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        [Required]
        

        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => _manufacturingSite = value;
        }

        private Guid _supplyChainGuid;
        /// <summary>
        /// Get or Set for {SupplyChainGuid}.
        /// </summary>
        [DataMember]
        [Required]
        
        public Guid SupplyChainGuid
        {
            get => _supplyChainGuid;
            set => _supplyChainGuid = value;
        }

        private string _supplyChainId;
        /// <summary>
        /// Get or Set for {SupplyChainId}.
        /// </summary>
        [DataMember]
        [Required]
        
        public string SupplyChainId
        {
            get => _supplyChainId;
            set => _supplyChainId = value;
        }

        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        [Required]
        

        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }

        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        private Guid _projectGuid;
        /// <summary>
        /// Get or Set for {ProjectGuid}.
        /// </summary>
        [DataMember]
        [Required]
        

        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => _projectGuid = value;
        }

        private Guid _dCLocationGuid;
        /// <summary>
        /// Get or Set for {DCLocationGuid}.
        /// </summary>
        [DataMember]
        [Required]
        

        public Guid DCLocationGuid
        {
            get => _dCLocationGuid;
            set => _dCLocationGuid = value;
        }

        private Guid _manufacturingSiteGuid;
        /// <summary>
        /// Get or Set for {ManufacturingSiteGuid}.
        /// </summary>
        [DataMember]
        [Required]
        

        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => _manufacturingSiteGuid = value;
        }


    }
}
