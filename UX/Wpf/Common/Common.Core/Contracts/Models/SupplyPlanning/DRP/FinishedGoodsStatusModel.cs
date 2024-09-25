/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FinishedGoodsStatusModel.cs
Function           :  
Created By         :  Ranjay
Created on         :  23-Sep-2022
Revision History   :  [06-Oct-2022] : Sejal Srivastava
*                  :  [] : Added FinishedGoodsStatusReportModel, FinishedGoodsStatusFilteredDataModel, FinishedGoodsStatusChildFilteredDataModel, FinishedGoodsStatusChildModel
*                  :  [20-April-2023] : Virendra
                   :  HD Call NO:[00386762] : Added this 'CustomerName' field in the class FinishedGoodsStatusDeliveryPointModel 
                   :  [04-Aug-2023] : Prakhar
                   :  Added class FinishedGoodsStatusDeliveryPointFilterModel 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// Data Contract use for Finished Goods Status Model
    /// </summary>
    [DataContract, Serializable]
    public class FinishedGoodsStatusModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
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
        /// <summary>
        /// Local variable _customerGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _customerDeliveryPointGuid     
        /// </summary>
        private Guid _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => _customerDeliveryPointGuid = value;
        }

        /// <summary>
        /// Local variable _manufacturingSiteGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _projectGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _customerName     
        /// </summary>
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }

        /// <summary>
        /// Local variable _projectName     
        /// </summary>
        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}.
        /// </summary>
        [DataMember]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        /// <summary>
        /// Local variable _manufacturingSite     
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => _manufacturingSite = value;
        }

        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        /// <summary>
        /// Local variable _displayDate     
        /// </summary>
        private DateTime _displayDate;
        /// <summary>
        /// Get or Set for {_displayDate}.
        /// </summary>
        [DataMember]
        public DateTime DisplayDate
        {
            get => _displayDate;
            set => _displayDate = value;
        }

        /// <summary>
        /// Local variable _openingStock     
        /// </summary>
        private int _openingStock;
        /// <summary>
        /// Get or Set for {OpeningStock}.
        /// </summary>
        [DataMember]
        public int OpeningStock
        {
            get => _openingStock;
            set => _openingStock = value;
        }

        /// <summary>
        /// Local variable _reception     
        /// </summary>
        private int _reception;
        /// <summary>
        /// Get or Set for {Reception}.
        /// </summary>
        [DataMember]
        public int Reception
        {
            get => _reception;
            set => _reception = value;
        }

        /// <summary>
        /// Local variable _customerDemand     
        /// </summary>
        private int _customerDemand;
        /// <summary>
        /// Get or Set for {CustomerDemand}.
        /// </summary>
        [DataMember]
        public int CustomerDemand
        {
            get => _customerDemand;
            set => _customerDemand = value;
        }

        /// <summary>
        /// Local variable _weekNo     
        /// </summary>
        private int _weekNo;
        /// <summary>
        /// Get or Set for {WeekNo}.
        /// </summary>
        [DataMember]
        public int WeekNo
        {
            get => _weekNo;
            set => _weekNo = value;
        }

    }

    /// <summary>
    /// Data Contract use for Finished Goods Status Report Model
    /// </summary>
    public class FinishedGoodsStatusReportModel
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
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
        /// <summary>
        /// Local variable _customerGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _customerDeliveryPointGuid     
        /// </summary>
        private Guid _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => _customerDeliveryPointGuid = value;
        }

        /// <summary>
        /// Local variable _manufacturingSiteGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _projectGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _customerName     
        /// </summary>
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }

        /// <summary>
        /// Local variable _projectName     
        /// </summary>
        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}.
        /// </summary>
        [DataMember]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        /// <summary>
        /// Local variable _manufacturingSite     
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => _manufacturingSite = value;
        }

        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        /// <summary>
        /// Local variable _displayDate     
        /// </summary>
        private DateTime _displayDate;
        /// <summary>
        /// Get or Set for {_displayDate}.
        /// </summary>
        [DataMember]
        public DateTime DisplayDate
        {
            get => _displayDate;
            set => _displayDate = value;
        }

        /// <summary>
        /// Local variable _openingStock     
        /// </summary>
        private int _openingStock;
        /// <summary>
        /// Get or Set for {OpeningStock}.
        /// </summary>
        [DataMember]
        public int OpeningStock
        {
            get => _openingStock;
            set => _openingStock = value;
        }

        /// <summary>
        /// Local variable _reception     
        /// </summary>
        private int _reception;
        /// <summary>
        /// Get or Set for {Reception}.
        /// </summary>
        [DataMember]
        public int Reception
        {
            get => _reception;
            set => _reception = value;
        }

        /// <summary>
        /// Local variable _customerDemand     
        /// </summary>
        private int _customerDemand;
        /// <summary>
        /// Get or Set for {CustomerDemand}.
        /// </summary>
        [DataMember]
        public int CustomerDemand
        {
            get => _customerDemand;
            set => _customerDemand = value;
        }

        /// <summary>
        /// Local variable _weekNo     
        /// </summary>
        private int _weekNo;
        /// <summary>
        /// Get or Set for {WeekNo}.
        /// </summary>
        [DataMember]
        public int WeekNo
        {
            get => _weekNo;
            set => _weekNo = value;
        }

    }

    /// <summary>
    /// Data Contract use for Finished Goods Status Filtered Data Model
    /// </summary>
    public class FinishedGoodsStatusFilteredDataModel
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _customerDeliveryPointGuid     
        /// </summary>
        private Guid _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => _customerDeliveryPointGuid = value;
        }
    }

    /// <summary>
    /// Data Contract use for Finished Goods Status Child Filtered Data Model
    /// </summary>
    public class FinishedGoodsStatusChildFilteredDataModel
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
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
        /// <summary>
        /// Local variable _customerGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _customerDeliveryPointGuid     
        /// </summary>
        private Guid _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => _customerDeliveryPointGuid = value;
        }

        /// <summary>
        /// Local variable _manufacturingSiteGuid     
        /// </summary>
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

        /// <summary>
        /// Local variable _projectGuid     
        /// </summary>
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


        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }


        /// <summary>
        /// Local variable _mode     
        /// </summary>
        private bool _mode;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public bool Mode
        {
            get => _mode;
            set => _mode = value;
        }
    }

    /// <summary>
    /// Data Contract use for Finished Goods Status Child Model
    /// </summary>
    public class FinishedGoodsStatusChildModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerName     
        /// </summary>
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }

        /// <summary>
        /// Local variable _projectName     
        /// </summary>
        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}.
        /// </summary>
        [DataMember]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        /// <summary>
        /// Local variable _manufacturingSite     
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => _manufacturingSite = value;
        }

        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        /// <summary>
        /// Local variable _wMSOrderNumber     
        /// </summary>
        private string _wMSOrderNumber;
        /// <summary>
        /// Get or Set for {WMSOrderNumber}.
        /// </summary>
        [DataMember]
        public string WMSOrderNumber
        {
            get => _wMSOrderNumber;
            set => _wMSOrderNumber = value;
        }

        /// <summary>
        /// Local variable _dRPShipDate     
        /// </summary>
        private DateTime _dRPShipDate;
        /// <summary>
        /// Get or Set for {DRPShipDate}.
        /// </summary>
        [DataMember]
        public DateTime DRPShipDate
        {
            get => _dRPShipDate;
            set => _dRPShipDate = value;
        }
        /// <summary>
        /// Local variable _dRPArrivalDate     
        /// </summary>
        private DateTime _dRPArrivalDate;
        /// <summary>
        /// Get or Set for {DRPArrivalDate}.
        /// </summary>
        [DataMember]
        public DateTime DRPArrivalDate
        {
            get => _dRPArrivalDate;
            set => _dRPArrivalDate = value;
        }
        /// <summary>
        /// Local variable _displayDate     
        /// </summary>
        private DateTime _dRPReceivedDate;
        /// <summary>
        /// Get or Set for {DRPReceivedDate}.
        /// </summary>
        [DataMember]
        public DateTime DRPReceivedDate
        {
            get => _dRPReceivedDate;
            set => _dRPReceivedDate = value;
        }
        /// <summary>
        /// Local variable _notShippedQty     
        /// </summary>
        private int _notShippedQty;
        /// <summary>
        /// Get or Set for {NotShippedQty}.
        /// </summary>
        [DataMember]
        public int NotShippedQty
        {
            get => _notShippedQty;
            set => _notShippedQty = value;
        }

        /// <summary>
        /// Local variable _actualShipDate     
        /// </summary>
        private DateTime _actualShipDate;
        /// <summary>
        /// Get or Set for {ActualShipDate}.
        /// </summary>
        [DataMember]
        public DateTime ActualShipDate
        {
            get => _actualShipDate;
            set => _actualShipDate = value;
        }
        /// <summary>
        /// Local variable _actualReceiveDate     
        /// </summary>
        private DateTime _actualReceiveDate;
        /// <summary>
        /// Get or Set for {ActualReceiveDate}.
        /// </summary>
        [DataMember]
        public DateTime ActualReceiveDate
        {
            get => _actualReceiveDate;
            set => _actualReceiveDate = value;
        }
    }

    /// <summary>
    /// Data Contract use for FinishedGoodsStatusDeliveryPointModel
    /// </summary>
    [DataContract, Serializable]
    public class FinishedGoodsStatusDeliveryPointModel
    {
        /// <summary>
        /// Local variable CustomerBusinessGroupGuid     
        /// </summary>
        private Guid _id;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        /// <summary>
        /// Local variable CustomerDeliveryPoint     
        /// </summary>
        private string _CustomerDeliveryPoint;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPoint}.
        /// </summary>
        [DataMember]
        public string CustomerDeliveryPoint
        {
            get => _CustomerDeliveryPoint;
            set => _CustomerDeliveryPoint = value;
        }
        /// <summary>
        /// Local variable CustomerBusinessGroupGuid     
        /// </summary>
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
        private string _CustomerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _CustomerName;
            set => _CustomerName = value;
        }
    }

    //prakhar
    public class FinishedGoodsStatusDeliveryPointFilterModel
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
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
        /// <summary>
        /// Local variable _customerGuid     
        /// </summary>
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

    }
}

