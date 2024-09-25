/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  DRPOrderCancelationModel.cs
Function           :   
Created By         :  Ranjay
Created on         :  01-Nov-2022
Revision History   :   
*                  :   [04-Nov-2022] : Vishwadeep Singh
*                  :   [] Added new class DRPOrderSuggestedToCancelUpdateModel
*                  :   [25-May-2023] : Ranjay
                   :   [HD-00334393] : Added a new field CancelledQty
                   :   [23-August-2023] : Sachin
                   :   [] : Added a new field Remarks
                   :   [30-Jan-2024] : Sachin 
                   :   [HD-00394058] : Lock During DRP run(Added ViewName Property).
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// This class is used to have information about to DRP Order Cancelation.
    /// </summary>
    [DataContract, Serializable]
    public class DRPOrderCancelationModel : BaseModel<Guid>
    {
        private Guid _customerguid;
        /// <summary>
        /// Get or Set for {CustomerGuid}
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerguid;
            set => SetProperty(ref _customerguid, value);
        }

        private string _originator;
        /// <summary>
        /// Get or Set for {Originator}
        /// </summary>
        [DataMember]
        public string Originator
        {
            get => _originator;
            set => SetProperty(ref _originator, value);
        }

        private string _partnumber;
        /// <summary>
        /// Get or Set for {PartNumber}
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partnumber;
            set => SetProperty(ref _partnumber, value);
        }

        private string _ordernumber;
        /// <summary>
        /// Get or Set for {OrderNumber}
        /// </summary>
        [DataMember]
        public string OrderNumber
        {
            get => _ordernumber;
            set => SetProperty(ref _ordernumber, value);
        }

        private DateTime? _drpshipdate;
        /// <summary>
        /// Get or Set for {DRPShipDate}
        /// </summary>
        [DataMember]
        public DateTime? DRPShipDate
        {
            get => _drpshipdate;
            set => SetProperty(ref _drpshipdate, value);
        }

        private DateTime? _orderissuedate;
        /// <summary>
        /// Get or Set for {OrderIssueDate}
        /// </summary>
        [DataMember]
        public DateTime? OrderIssueDate
        {
            get => _orderissuedate;
            set => SetProperty(ref _orderissuedate, value);
        }

        private string _supplychain;
        /// <summary>
        /// Get or Set for {SupplyChain}
        /// </summary>
        [DataMember]
        public string SupplyChain
        {
            get => _supplychain;
            set => SetProperty(ref _supplychain, value);
        }

        private int _orderqty;
        /// <summary>
        /// Get or Set for {OrderQty}
        /// </summary>
        [DataMember]
        public int OrderQty
        {
            get => _orderqty;
            set => SetProperty(ref _orderqty, value);
        }

        private int _cancelledQty;
        /// <summary>
        /// Get or Set for {CancelledQty}
        /// </summary>
        [DataMember]
        public int CancelledQty
        {
            get => _cancelledQty;
            set => SetProperty(ref _cancelledQty, value);
        }

        private int _pendingqty;
        /// <summary>
        /// Get or Set for {PendingQty}
        /// </summary>
        [DataMember]
        public int PendingQty
        {
            get => _pendingqty;
            set => SetProperty(ref _pendingqty, value);
        }

        private int _indeliveryqty;
        /// <summary>
        /// Get or Set for {InDeliveryQty}
        /// </summary>
        [DataMember]
        public int InDeliveryQty
        {
            get => _indeliveryqty;
            set => SetProperty(ref _indeliveryqty, value);
        }
        
        private int _receivedqty;
        /// <summary>
        /// Get or Set for {ReceivedQty}
        /// </summary>
        [DataMember]
        public int ReceivedQty
        {
            get => _receivedqty;
            set => SetProperty(ref _receivedqty, value);
        }

        private int _notshippedqty;
        /// <summary>
        /// Get or Set for {NotShippedQty}
        /// </summary>
        [DataMember]
        public int NotShippedQty
        {
            get => _notshippedqty;
            set => SetProperty(ref _notshippedqty, value);
        }

        private int _suggestedtocancelqty;
        /// <summary>
        /// Get or Set for {SuggestedToCancelQty}
        /// </summary>
        [DataMember]
        public int SuggestedToCancelQty
        {
            get => _suggestedtocancelqty;
            set => SetProperty(ref _suggestedtocancelqty, value);
        }

        private int _acceptedToCancelQty;
        /// <summary>
        /// Get or Set for {AcceptedToCancelQty}
        /// </summary>
        [DataMember]
        public int AcceptedToCancelQty
        {
            get => _acceptedToCancelQty;
            set => SetProperty(ref _acceptedToCancelQty, value);
        }

        private int _orderbatchqty;
        /// <summary>
        /// Get or Set for {OrderBatchQty}
        /// </summary>
        [DataMember]
        public int OrderBatchQty
        {
            get => _orderbatchqty;
            set => SetProperty(ref _orderbatchqty, value);
        }

        private string _project;
        /// <summary>
        /// Get or Set for {Project}
        /// </summary>
        [DataMember]
        public string Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }
        
        private string _dclocation;
        /// <summary>
        /// Get or Set for {DCLocation}
        /// </summary>
        [DataMember]
        public string DCLocation
        {
            get => _dclocation;
            set => SetProperty(ref _dclocation, value);
        }

        private string _customerdeliverypoint;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPoint}
        /// </summary>
        [DataMember]
        public string CustomerDeliveryPoint
        {
            get => _customerdeliverypoint;
            set => SetProperty(ref _customerdeliverypoint, value);
        }

        private int _remainingAfterCancel;
        /// <summary>
        /// Get or Set for {RemainingAfterCancel}
        /// </summary>
        [DataMember]
        public int RemainingAfterCancel
        {
            get => _remainingAfterCancel;
            set => SetProperty(ref _remainingAfterCancel, value);
        }

        private int _conflictBatchQty;
        /// <summary>
        /// Get or Set for {ConflictBatchQty}
        /// </summary>
        [DataMember]
        public int ConflictBatchQty
        {
            get => _conflictBatchQty;
            set => SetProperty(ref _conflictBatchQty, value);
        }
        private string _remarks;
        /// <summary>
        /// Get or Set for {Originator}
        /// </summary>
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }
    }

    /// <summary>
    /// Class for filter data
    /// </summary>
    public class FilterDRPOrderCancelationModel
    {

        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }

        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

    }

    /// <summary>
    /// This class is used to update OrderSuggestedToCancel details
    /// </summary>
    [DataContract, Serializable]
    public class DRPOrderSuggestedToCancelUpdateModel : BaseModel<Guid>
    {
        private string _originator;
        /// <summary>
        /// Get or Set for {Originator}
        /// </summary>
        [DataMember]
        public string Originator
        {
            get => _originator;
            set => SetProperty(ref _originator, value);
        }

        private int _acceptedQty;
        /// <summary>
        /// Get or Set for {AcceptedQty}
        /// </summary>
        [DataMember]
        public int AcceptedQty
        {
            get => _acceptedQty;
            set => SetProperty(ref _acceptedQty, value);
        }

        private Guid _userId;
        /// <summary>
        /// Get or Set for {UserId}
        /// </summary>
        [DataMember]
        public Guid UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _orderNumber;
        /// <summary>
        /// Get or Set for {OrderNumber}
        /// </summary>
        [DataMember]
        public string OrderNumber
        {
            get => _orderNumber;
            set => SetProperty(ref _orderNumber, value);
        }
        private string _partNumber;
        /// <summary>
        /// Get or Set for {Originator}
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private string _remarks;
        /// <summary>
        /// Get or Set for {Originator}
        /// </summary>
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        /// <summary>
        /// Local variable _viewName     
        /// </summary>
        private string _viewName;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
    }
}
