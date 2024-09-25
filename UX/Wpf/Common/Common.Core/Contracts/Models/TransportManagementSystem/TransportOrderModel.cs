/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   TransportOrderModel.cs
Function           :   Creating Trasport Order property for Transport Managment System.
Created By         :   Dharmendra
Created on         :   06-Mar-2024
Revision History   :
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    [DataContract, Serializable]
    public class TransportOrderModel : BaseModel<Guid>
    {

        private Guid _shipFromLocationGuid;
        /// <summary>
        /// Get or Set for {ShipFromLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid ShipFromLocationGuid
        {
            get => _shipFromLocationGuid;
            set => SetProperty(ref _shipFromLocationGuid, value);
        }
        private Guid _shipToLocationGuid;
        /// <summary>
        /// Get or Set for {ShipFromLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid ShipToLocationGuid
        {
            get => _shipToLocationGuid;
            set => SetProperty(ref _shipToLocationGuid, value);
        }

        private DateTime? _deliveryDate;
        /// <summary>
        /// Get or Set for {DeliveryDate}
        /// </summary>
        [DataMember]
        public DateTime? DeliveryDate
        {
            get => _deliveryDate;
            set => SetProperty(ref _deliveryDate, value);
        }
        private string _deliveryTimeStart;
        /// <summary>
        /// Get or Set for {DeliveryTimeStart}.
        /// </summary>
        [DataMember]

        public string DeliveryTimeStart
        {
            get => _deliveryTimeStart;
            set => SetProperty(ref _deliveryTimeStart, value);
        }

        private string _deliveryTimeEnd;
        /// <summary>
        /// Get or Set for {DeliveryTimeEnd}.
        /// </summary>
        [DataMember]

        public string DeliveryTimeEnd
        {
            get => _deliveryTimeEnd;
            set => SetProperty(ref _deliveryTimeEnd, value);
        }


        private DateTime? _pickUpDate;
        /// <summary>
        /// Get or Set for {PickUpDate}.
        /// </summary>
        [DataMember]
        public DateTime? PickUpDate
        {
            get => _pickUpDate;
            set => SetProperty(ref _pickUpDate, value);
        }
        private string _pickUpDateTimeStart;
        /// <summary>
        /// Get or Set for {PickUpTimeStart}.
        /// </summary>
        [DataMember]

        public string PickUpTimeStart
        {
            get => _pickUpDateTimeStart;
            set => SetProperty(ref _pickUpDateTimeStart, value);
        }

        private string _pickUpDateTimeEnd;
        /// <summary>
        /// Get or Set for {PickUpTimeEnd}.
        /// </summary>
        [DataMember]

        public string PickUpTimeEnd
        {
            get => _pickUpDateTimeEnd;
            set => SetProperty(ref _pickUpDateTimeEnd, value);
        }


        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => SetProperty(ref _customerBusinessHierarchyGuid, value);
        }

        private Guid _productCategoryGuid;
        /// <summary>
        /// Get or Set for {ProductCategoryGuid}.
        /// </summary>
        [DataMember]
        public Guid ProductCategoryGuid
        {
            get => _productCategoryGuid;
            set => SetProperty(ref _productCategoryGuid, value);
        }

        private string _direction;
        /// <summary>
        /// Get or Set for {Direction}.
        /// </summary>
        [DataMember]
        public string Direction
        {
            get => _direction;
            set => SetProperty(ref _direction, value);
        }
        private Guid _transportMethodGuid;
        /// <summary>
        /// Get or Set for {TransportMethodGuid}.
        /// </summary>
        [DataMember]
        public Guid TransportMethodGuid
        {
            get => _transportMethodGuid;
            set => SetProperty(ref _transportMethodGuid, value);
        }

        private string _deliveryCategory;
        /// <summary>
        /// Get or Set for {DeliveryCategory}.
        /// </summary>
        [DataMember]
        public string DeliveryCategory
        {
            get => _deliveryCategory;
            set => _deliveryCategory = value;
        }

        private string _spaceType;
        /// <summary>
        /// Get or Set for {SpaceType}.
        /// </summary>
        [DataMember]
        public string SpaceType
        {
            get => _spaceType;
            set => SetProperty(ref _spaceType, value);
        }

        private Guid _incotermGuid;
        /// <summary>
        /// Get or Set for {IncotermGuid}.
        /// </summary>
        [DataMember]
        public Guid IncotermGuid
        {
            get => _incotermGuid;
            set => SetProperty(ref _incotermGuid, value);
        }
        private bool _roundTrip = false;
        /// <summary>
        /// Get or Set for {RoundTrip}.
        /// </summary>
        [DataMember]
        public bool RoundTrip
        {
            get => _roundTrip;
            set => _roundTrip = value;
        }
        private Guid _packageTypeGuid;
        /// <summary>
        /// Get or Set for {PackageTypeGuid}.
        /// </summary>
        [DataMember]
        public Guid PackageTypeGuid
        {
            get => _packageTypeGuid;
            set => _packageTypeGuid = value;
        }
        private string _numberofPackages;
        /// <summary>
        /// Get or Set for {NumberofPackages}.
        /// </summary>
        [DataMember]

        public string NumberofPackages
        {
            get => _numberofPackages;
            set => SetProperty(ref _numberofPackages, value);
        }
        private string _numberofDrivers;
        /// <summary>
        /// Get or Set for {TMSOrderNo}.
        /// </summary>
        [DataMember]
        public string NumberofDrivers
        {
            get => _numberofDrivers;
            set => SetProperty(ref _numberofDrivers, value);
        }
        private string _tmsOrderNo = string.Empty;
        /// <summary>
        /// Get or Set for {TMSOrderNo}.
        /// </summary>
        [DataMember]
        public string TMSOrderNo
        {
            get => _tmsOrderNo;
            set => SetProperty(ref _tmsOrderNo, value);
        }
        private bool _isActive = true;
        /// <summary>
        /// Get or Set for {IsActive}
        /// </summary>
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
        private bool _alpegaSyncStatus = false;
        /// <summary>
        /// Get or Set for {AlpegaSyncStatus}
        /// </summary>
        [DataMember]
        public bool AlpegaSyncStatus
        {
            get => _alpegaSyncStatus;
            set => SetProperty(ref _alpegaSyncStatus, value);
        }
        private bool _wmsSyncStatus = false;
        /// <summary>
        ///  Get or Set for {WMSSyncStatus}
        /// </summary>
        [DataMember]
        public bool WMSSyncStatus
        {
            get => _wmsSyncStatus;
            set => SetProperty(ref _wmsSyncStatus, value);
        }
        private string _alpegaSyncRemark;
        /// <summary>
        /// Get or Set for {AlpegaSyncRemark}.
        /// </summary>
        [DataMember]
        public string AlpegaSyncRemark
        {
            get => _alpegaSyncRemark;
            set => SetProperty(ref _alpegaSyncRemark, value);
        }
        private string _wmsSyncRemark;
        /// <summary>
        /// Get or Set for {WMSSyncRemark}.
        /// </summary>
        [DataMember]
        public string WMSSyncRemark
        {
            get => _wmsSyncRemark;
            set => SetProperty(ref _wmsSyncRemark, value);
        }
    }
    public class ShipFromLocationComboModel : BindableBaseEntity
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _shipFromLocation;
        /// <summary>
        /// Get or Set for {ShipFromLocation}.
        /// </summary>
        [DataMember]
        public string ShipFromLocation
        {
            get => _shipFromLocation;
            set => SetProperty(ref _shipFromLocation, value);
        }
        private string _businessUnitName;
        /// <summary>
        /// Get or Set for {BusinessUnitName}.
        /// </summary>
        [DataMember]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }
    }
    public class ShipToLocationComboModel : BindableBaseEntity
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _shipToLocation;
        /// <summary>
        /// Get or Set for {ShipToLocation}.
        /// </summary>
        [DataMember]
        public string ShipToLocation
        {
            get => _shipToLocation;
            set => SetProperty(ref _shipToLocation, value);
        }
    }
    public class ShipingCustomerComboModel : BindableBaseEntity
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _customer;
        /// <summary>
        /// Get or Set for {Customer}.
        /// </summary>
        [DataMember]
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
    }
    public class ProductCategoryComboModel : BindableBaseEntity
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _productCategory;
        /// <summary>
        /// Get or Set for {ProductCategory}.
        /// </summary>
        [DataMember]
        public string ProductCategory
        {
            get => _productCategory;
            set => SetProperty(ref _productCategory, value);
        }

    }
    public class IncotermComboModel : BindableBaseEntity
    {

        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _incotermCode;
        /// <summary>
        /// Get or Set for {Incoterm}.
        /// </summary>
        [DataMember]
        public string Incoterm
        {
            get => _incotermCode;
            set => SetProperty(ref _incotermCode, value);
        }

    }
    public class TransportMethodComboModel : BindableBaseEntity
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _transportMethod;
        /// <summary>
        /// Get or Set for {TransportMethod}.
        /// </summary>
        [DataMember]
        public string TransportMethod
        {
            get => _transportMethod;
            set => SetProperty(ref _transportMethod, value);
        }

    }

    public class PackageTypeComboModel : BindableBaseEntity
    {
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _packageType;
        /// <summary>
        /// Get or Set for {PackageType}.
        /// </summary>
        [DataMember]
        public string PackageType
        {
            get => _packageType;
            set => SetProperty(ref _packageType, value);
        }
        private string _packageDescription;
        /// <summary>
        /// Get or Set for {PackageDescription}.
        /// </summary>
        [DataMember]
        public string PackageDescription
        {
            get => _packageDescription;
            set => SetProperty(ref _packageDescription, value);
        }

    }
    [DataContract, Serializable]
    public class TransportOrderFilterModel
    {

        private int _pcheck;
        /// <summary>
        /// Get or Set for {Pcheck}.
        /// </summary>
        [DataMember]
        public int Pcheck
        {
            get => _pcheck;
            set => _pcheck = value;
        }
        private string _tostatus;
        [DataMember]
        public string Tostatus
        {
            get => _tostatus;
            set => _tostatus = value;
        }
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }
        private Guid _shipFromLocationGuid;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid ShipFromLocationGuid
        {
            get => _shipFromLocationGuid;
            set => _shipFromLocationGuid = value;
        }
        private Guid _shipToLocationGuid;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid ShipToLocationGuid
        {
            get => _shipToLocationGuid;
            set => _shipToLocationGuid = value;
        }
        private string _tMSOrderNumber;
        /// <summary>
        /// Get or Set for {ShipFromLocation}.
        /// </summary>
        [DataMember]
        public string TMSOrderNumber
        {
            get => _tMSOrderNumber;
            set => _tMSOrderNumber = value;
        }
    }
    [DataContract, Serializable]
    public class SubmitTransportOrderToTMSandWMSModel
    {
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }
        private string _tmsOrderNumber;
        [DataMember]
        public string TMSOrderNumber
        {
            get => _tmsOrderNumber;
            set => _tmsOrderNumber = value;
        }

    }
    public class TransportOrderNumberComboModel : BindableBaseEntity
    {
        private string _tMSOrderNumber;
        /// <summary>
        /// Get or Set for {ShipFromLocation}.
        /// </summary>
        [DataMember]
        public string TMSOrderNumber
        {
            get => _tMSOrderNumber;
            set => SetProperty(ref _tMSOrderNumber, value);
        }
    }
}