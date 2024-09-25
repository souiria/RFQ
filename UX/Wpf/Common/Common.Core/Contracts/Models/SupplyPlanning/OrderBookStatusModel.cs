/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   OrderBookStatusModel.cs
Function           :   Order Book Status
Created By         :   Shivam Dhingra
Created on         :   01-Oct-2021
Revision History   :   [19-Oct-2021] : Shivam Dhingra
                   :   [] : Modified Product Range Filters
                   :   [27-Oct-2021] : Shivam Dhingra
                   :   Fix Performance issue
                   :   [08-Dec-2021] : Shivam Dhingra
                   :   Added new columns
                   :   [09-Dec-2021] : Shivam Dhingra
                   :   Renamed Parameters in orderBookstatus
                   :  [26-Apr-2022] : Ranjay
                   :   Added Class OrderBookStatusMissingTransferPriceModel
*                  :   [30-June-2022] : Sejal Srivastava
*                  :   [] : Added new columns TransferPrice and CurrencyCode
*                  :   [12-Sep-2022] : Ranjay
                   :   Added Class OrderBookStatusCustomerBusinessGroupFilterModel, HD Call No HD00354389
                   :   [08-Nov-2022] : Prakhar
*                  :   [] : Added new columns Cancelled quantity
*                  :   [04-May-2023] : Prakhar
*                  :   [] : Added new columns OriginalDRPShipDate
*                  :   [22-Apr-2024] : Prakhar
*                  :   [HD Call-00410526] : Added new columns OrderStatusPPS
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
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
    /// Data Contract for OrderBookStatus
    /// </summary>
    [DataContract, Serializable]
    public class OrderBookStatusModel : BaseModel<Guid>
    {
        private string _orderNumber;
        /// <summary>
        /// _orderNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(60)]
        public string OrderNumber
        {
            get => _orderNumber;
            set => SetProperty(ref _orderNumber, value);
        }

        private string _orderStatus;
        /// <summary>
        /// _orderStatus
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(20)]
        public string OrderStatus
        {
            get => _orderStatus;
            set => SetProperty(ref _orderStatus, value);
        }

        //private DateTime? _dueDate;
        ///// <summary>
        ///// _dueDate
        ///// </summary>
        /////<example>
        ///// 
        /////</example>
        //[DataMember]
        //public DateTime? DueDate
        //{
        //    get => _dueDate;
        //    set => SetProperty(ref _dueDate, value);
        //}

        private string _orderType;
        /// <summary>
        /// _orderType
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(20)]
        public string OrderType
        {
            get => _orderType;
            set => SetProperty(ref _orderType, value);
        }

        private DateTime? _orderIssueDate;
        /// <summary>
        /// _orderIssueDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? OrderIssueDate
        {
            get => _orderIssueDate;
            set => SetProperty(ref _orderIssueDate, value);
        }

        private Guid? _customerNameGuid;
        /// <summary>
        /// _customerNameGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? CustomerNameGuid
        {
            get => _customerNameGuid;
            set => SetProperty(ref _customerNameGuid, value);
        }

        private Guid? _projectGuid;
        /// <summary>
        /// _projectGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? ProjectGuid
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

        private Guid? _supplyChainGuid;
        /// <summary>
        /// _supplyChainGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? SupplyChainGuid
        {
            get => _supplyChainGuid;
            set => SetProperty(ref _supplyChainGuid, value);
        }

        private Guid? _customerDeliveryPlantGuid;
        /// <summary>
        /// _customerDeliveryPlantGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? CustomerDeliveryPlantGuid
        {
            get => _customerDeliveryPlantGuid;
            set => SetProperty(ref _customerDeliveryPlantGuid, value);
        }


        private Guid? _dcLocationGuid;
        /// <summary>
        /// _dcLocationGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? DCLocationGuid
        {
            get => _dcLocationGuid;
            set => SetProperty(ref _dcLocationGuid, value);
        }


        private Guid? _manufacturingSiteGuid;
        /// <summary>
        /// _manufacturingSiteGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => SetProperty(ref _manufacturingSiteGuid, value);
        }

        private DateTime? _drpShipDate;
        /// <summary>
        /// _drpShipDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? DRPShipDate
        {
            get => _drpShipDate;
            set => SetProperty(ref _drpShipDate, value);
        }

        private DateTime? _drpArrivalDate;
        /// <summary>
        /// _drpArrivalDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? DRPArrivalDate
        {
            get => _drpArrivalDate;
            set => SetProperty(ref _drpArrivalDate, value);
        }

        private DateTime? _drpReceivedDate;
        /// <summary>
        /// _drpReceivedDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? DRPReceivedDate
        {
            get => _drpReceivedDate;
            set => SetProperty(ref _drpReceivedDate, value);
        }



        private DateTime? _actualLatestShipDate;
        /// <summary>
        /// _ActualShipDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? ActualLatestShipDate
        {
            get => _actualLatestShipDate;
            set => SetProperty(ref _actualLatestShipDate, value);
        }

        private DateTime? _actualLatestReceivedDate;
        /// <summary>
        /// _actualReceivedDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? ActualLatestReceivedDate
        {
            get => _actualLatestReceivedDate;
            set => SetProperty(ref _actualLatestReceivedDate, value);
        }

        private List<OrderBookStatusProductModel> _orderBookStatusProduct;
        /// <summary>
        /// _orderBookStatusProduct
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public List<OrderBookStatusProductModel> OrderBookStatusProduct
        {
            get => _orderBookStatusProduct;
            set => SetProperty(ref _orderBookStatusProduct, value);
        }


        //table 2 columns

        //private Guid? _orderBookStatusGuid;
        ///// <summary>
        ///// _orderBookStatusGuid
        ///// </summary>
        /////<example>
        ///// 
        /////</example>
        //[DataMember]
        //public Guid? OrderBookStatusGuid
        //{
        //    get => _orderBookStatusGuid;
        //    set => SetProperty(ref _orderBookStatusGuid, value);
        //}



        //private Guid? _orderBookStatusProductId;
        ///// <summary>
        ///// OrderBookStatusProductId
        ///// </summary>
        /////<example>
        ///// 
        /////</example>
        //[DataMember]
        //public Guid? OrderBookStatusProductId
        //{
        //    get => _orderBookStatusProductId;
        //    set => SetProperty(ref _orderBookStatusProductId, value);
        //}


        //private DateTime? _orderBookStatusProductCreatedDate;
        ///// <summary>
        ///// OrderBookStatusProductCreatedDate
        ///// </summary>
        /////<example>
        ///// 
        /////</example>
        //[DataMember]
        //public DateTime? OrderBookStatusProductCreatedDate
        //{
        //    get => _orderBookStatusProductCreatedDate;
        //    set => SetProperty(ref _orderBookStatusProductCreatedDate, value);
        //}

        //private DateTime? _orderBookStatusProductModifiedDate;
        ///// <summary>
        ///// OrderBookStatusProductModifiedDate
        ///// </summary>
        /////<example>
        ///// 
        /////</example>
        //[DataMember]
        //public DateTime? OrderBookStatusProductModifiedDate
        //{
        //    get => _orderBookStatusProductModifiedDate;
        //    set => SetProperty(ref _orderBookStatusProductModifiedDate, value);
        //}


        //private Guid? _orderBookStatusProductCreatedBy;
        ///// <summary>
        ///// OrderBookStatusProductCreatedBy
        ///// </summary>
        /////<example>
        ///// 
        /////</example>
        //[DataMember]
        //public Guid? OrderBookStatusProductCreatedBy
        //{
        //    get => _orderBookStatusProductCreatedBy;
        //    set => SetProperty(ref _orderBookStatusProductCreatedBy, value);
        //}

        //private Guid? _orderBookStatusProductModifiedBy;
        ///// <summary>
        ///// OrderBookStatusProductModifiedBy
        ///// </summary>
        /////<example>
        ///// 
        /////</example>
        //[DataMember]
        //public Guid? OrderBookStatusProductModifiedBy
        //{
        //    get => _orderBookStatusProductModifiedBy;
        //    set => SetProperty(ref _orderBookStatusProductModifiedBy, value);
        //}

        //private bool _orderBookStatusProductIsActive;
        ///// <summary>
        ///// OrderBookStatusProductIsActive
        ///// </summary>
        /////<example>
        ///// 
        /////</example>
        //[DataMember]
        //public bool OrderBookStatusProductIsActive
        //{
        //    get => _orderBookStatusProductIsActive;
        //    set => SetProperty(ref _orderBookStatusProductIsActive, value);
        //}

        private DateTime? _originalDRPShipDate;
        /// <summary>
        /// _ActualShipDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? OriginalDRPShipDate
        {
            get => _originalDRPShipDate;
            set => SetProperty(ref _originalDRPShipDate, value);
        }

        private string _orderStatusPPS;
        /// <summary>
        /// _orderStatus
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(20)]
        public string OrderStatusPPS
        {
            get => _orderStatusPPS;
            set => SetProperty(ref _orderStatusPPS, value);
        }

    }

    /// <summary>
    /// OrderBookStatusProductModel
    /// </summary>
    [DataContract, Serializable]
    public class OrderBookStatusProductModel : BaseModel<Guid>
    {
        private string _productNumber;
        /// <summary>
        /// ProductNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(18)]
        public string ProductNumber
        {
            get => _productNumber;
            set => SetProperty(ref _productNumber, value);
        }

        private int? _orderQty;
        /// <summary>
        /// OrderQty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? OrderQty
        {
            get => _orderQty;
            set => SetProperty(ref _orderQty, value);
        }



        private int? _pendingQty;
        /// <summary>
        /// PendingQty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? PendingQty
        {
            get => _pendingQty;
            set => SetProperty(ref _pendingQty, value);
        }

        private int? _inDeliveryQtyQty;
        /// <summary>
        /// InDeliveryQty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? InDeliveryQty
        {
            get => _inDeliveryQtyQty;
            set => SetProperty(ref _inDeliveryQtyQty, value);
        }

        private int? _receivedQtyQty;
        /// <summary>
        /// ReceivedQty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? ReceivedQty
        {
            get => _receivedQtyQty;
            set => SetProperty(ref _receivedQtyQty, value);
        }

        private int? _cancelledQtyQty;
        /// <summary>
        /// ReceivedQty
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? CancelledQty
        {
            get => _cancelledQtyQty;
            set => SetProperty(ref _cancelledQtyQty, value);
        }

        private decimal _transferPrice;
        /// <summary>
        /// TransferPrice
        /// </summary>
        [DataMember]
        [DecimalPrecision(15, 6)]
        public decimal TransferPrice
        {
            get => _transferPrice;
            set => SetProperty(ref _transferPrice, value);
        }


        private string _currencyCode;
        /// <summary>
        /// CurrencyCode
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string CurrencyCode
        {
            get => _currencyCode;
            set => SetProperty(ref _currencyCode, value);
        }

    }


    /// <summary>
    /// Class File for OrderBookStatusFilterModel
    /// </summary>
    [DataContract, Serializable]
    public class OrderBookStatusFilterModel
    {
        private string _productNumbers;
        /// <summary>
        /// Get or Set for {ProductNumbers}.
        /// </summary>
        [DataMember]
        public string ProductNumbers
        {
            get => _productNumbers;
            set => _productNumbers = value;
        }

        private Guid? _p_customerGuid;
        /// <summary>
        /// Get or Set for {P_customerGuid}.
        /// </summary>
        [DataMember]
        public Guid? P_customerGuid
        {
            get => _p_customerGuid;
            set => _p_customerGuid = value;
        }

        private DateTime? _p_DRPReceivedDateFrom;
        /// <summary>
        /// Get or Set for {P_DRPReceivedDateFrom}.
        /// </summary>
        [DataMember]
        public DateTime? P_DRPReceivedDateFrom
        {
            get => _p_DRPReceivedDateFrom;
            set => _p_DRPReceivedDateFrom = value;
        }

        private DateTime? _p_DRPReceivedDateTo;
        /// <summary>
        /// Get or Set for {P_DRPReceivedDateTo}.
        /// </summary>
        [DataMember]
        public DateTime? P_DRPReceivedDateTo
        {
            get => _p_DRPReceivedDateTo;
            set => _p_DRPReceivedDateTo = value;
        }

        private string _p_orderStatus;
        /// <summary>
        /// Get or Set for {P_OrderStatus}.
        /// </summary>
        [DataMember]
        public string P_OrderStatus
        {
            get => _p_orderStatus;
            set => _p_orderStatus = value;
        }

        private Guid? _p_projectGuid;
        /// <summary>
        /// Get or Set for {P_projectGuid}.
        /// </summary>
        [DataMember]
        public Guid? P_projectGuid
        {
            get => _p_projectGuid;
            set => _p_projectGuid = value;
        }

    }


    /// <summary>
    /// Class File for OrderBookStatusTransferPriceFilterModel
    /// </summary>
    [DataContract,Serializable]
    public class OrderBookStatusMissingTransferPriceFilterModel
    {
        /// <summary>
        /// Get or Set for {userId}.
        /// </summary>
        [DataMember]
        private Guid userId { get; set; }
        /// <summary>
        /// Get or Set for {UserId}
        /// </summary>
        [DataMember]
        public Guid UserId
        {
            get => userId;
            set => userId = value;
        }

        /// <summary>
        /// Get or Set for {customerGuid}.
        /// </summary>
        private Guid customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => customerGuid;
            set => customerGuid = value;
        }
    }

    /// <summary>
    /// Data Contract for OrderBookStatusMissingTransferPriceModel
    /// </summary>
    [DataContract, Serializable]
    public class OrderBookStatusMissingTransferPriceModel
    {
        /// <summary>
        /// Get or Set for {supplyChainID}.
        /// </summary>
        private string supplyChainID;
        /// <summary>
        /// Get or Set for {SupplyChainID}.
        /// </summary>
        [DataMember]
        public string SupplyChainID
        {
            get => supplyChainID;
            set => supplyChainID = value;
        }

        /// <summary>
        /// Get or Set for {partNumber}.
        /// </summary>
        private string partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => partNumber;
            set => partNumber = value;
        }

        /// <summary>
        /// Get or Set for {customerName}.
        /// </summary>
        private string customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => customerName;
            set => customerName = value;
        }

        /// <summary>
        /// Get or Set for {_family}.
        /// </summary>
        private string family;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>
        [DataMember]
        public string Family
        {
            get => family;
            set => family = value;
        }

        /// <summary>
        /// Get or Set for {businessUnitCode}.
        /// </summary>
        private string businessUnitCode;
        /// <summary>
        /// Get or Set for {BusinessUnitCode}.
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get => businessUnitCode;
            set => businessUnitCode = value;
        }
    }

    /// <summary>
    /// Class File for OrderBookStatusCustomerBusinessGroupFilterModel
    /// </summary>
    [DataContract, Serializable]
    public class OrderBookStatusCustomerBusinessGroupFilterModel
    {
        /// <summary>
        /// Get or Set for {customerBusinessGroupGuid}.
        /// </summary>
        private Guid customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => customerBusinessGroupGuid;
            set => customerBusinessGroupGuid = value;
        }

        /// <summary>
        /// Get or Set for {_customerBusinessGroupName}.
        /// </summary>
        private string _customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupName}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => _customerBusinessGroupName = value;
        }

        /// <summary>
        /// Get or Set for {customerGuid}.
        /// </summary>
        private Guid customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => customerGuid;
            set => customerGuid = value;
        }
        /// <summary>
        /// Get or Set for {_customerName}.
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
    }

    }
