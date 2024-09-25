/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerIdentificationSettingsModel.cs
Function           :   Data Contract for CustomerIdentificationSettings
Created By         :   Shivam Dhingra
Created on         :   21-May-2020
Revision History   :   [28-Sep-2020] : Dharmendra
                   :   Added new field CustomerHierarchyGuid  
                   :   [07-Jun-2021] : Shivam Kalia
                   :   Changed the data length from 12 characters to 35 characters for UNBSenderId
                   :   [11-oct-2021] : Shivam Dhingra
                   :   Added new field CustomerDeliveryPointGuid
                   :   [01-Dec-2022] : Ranjay
                   :   Added new class CustomerIdentificationSettingsFilterModel  
                   :   [03-Feb-2023] : Prakhar
                   :   [HD Call No-00369212]Added new class CustomerIdentificationSettingsGetDataFilterModel and added other properties in CustomerIdentificationSettingsModel.
                   :   [06-Oct-2023] : Virendra
                   :   []Added new property UserGuid in the class CustomerIdentificationSettingsGetDataFilterModel 
                   :   [30-Jan-2024] : Sachin 
                   :   [HD-00394058] : Lock During DRP run(Added ViewName Property).
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data contract for CustomerIdentificationSettings
    /// </summary>
    [DataContract, Serializable]
    public class CustomerIdentificationSettingsModel: BaseModel<Guid>
    {

        private string _unbSenderId;
        /// <summary>
        /// Get or Set for {UNBSenderId}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        [Required]
        public string UNBSenderId
        {
            get => _unbSenderId;
            set => SetProperty(ref _unbSenderId, value);
        }

        private string _accountNumber;
        /// <summary>
        /// Get or Set for {AccountNumber}.
        /// </summary>
        [DataMember]
        [StringLength(70)]
        public string AccountNumber
        {
            get => _accountNumber;
            set => SetProperty(ref _accountNumber, value);
        }

        private string _buyerCode;
        /// <summary>
        /// Get or Set for {BuyerCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string BuyerCode
        {
            get => _buyerCode;
            set => SetProperty(ref _buyerCode, value);
        }

        private string _consigneeCode;
        /// <summary>
        /// Get or Set for {ConsigneeCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string ConsigneeCode
        {
            get => _consigneeCode;
            set => SetProperty(ref _consigneeCode, value);
        }

        private string _consignorCode;
        /// <summary>
        /// Get or Set for {ConsignorCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string ConsignorCode
        {
            get => _consignorCode;
            set => SetProperty(ref _consignorCode, value);
        }


        private string _unloadingPointCode;
        /// <summary>
        /// Get or Set for {UnloadingPointCode}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string UnloadingPointCode
        {
            get => _unloadingPointCode;
            set => SetProperty(ref _unloadingPointCode, value);
        }


        /*Commented by Ranjay 01/Dec/2022 -- This field is not in use. */
        /*
        private string _ediMessageCustomerBusinessGroup;
        /// <summary>
        /// Get or Set for {EDIMessageCustomerBusinessGroup}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string EDIMessageCustomerBusinessGroup
        {
            get => _ediMessageCustomerBusinessGroup;
            set => SetProperty(ref _ediMessageCustomerBusinessGroup, value);
        }
        */

        private Guid _customerHierarchyBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerHierarchyBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerHierarchyBusinessGroupGuid
        {
            get => _customerHierarchyBusinessGroupGuid;
            set => SetProperty(ref _customerHierarchyBusinessGroupGuid, value);
        }
        private Guid _customerHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerHierarchyGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerHierarchyGuid
        {
            get => _customerHierarchyGuid;
            set => SetProperty(ref _customerHierarchyGuid, value);
        }

        private Guid _customerDeliveryPointAssociationGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointAssociationGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointAssociationGuid
        {
            get => _customerDeliveryPointAssociationGuid;
            set => SetProperty(ref _customerDeliveryPointAssociationGuid, value);
        }

        private string _unloadingPointDescription;
        /// <summary>
        /// Get or Set for {UnloadingPointCode}.
        /// </summary>
        [DataMember]
        public string UnloadingPointDescription
        {
            get => _unloadingPointDescription;
            set => SetProperty(ref _unloadingPointDescription, value);
        }


        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        private string _customerDeliveryPoint;
        /// <summary>
        /// Get or Set for {_customerDeliveryPointAssociation}.
        /// </summary>
        [DataMember]
        public string CustomerDeliveryPoint
        {
            get => _customerDeliveryPoint;
            set => SetProperty(ref _customerDeliveryPoint, value);
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {CustomerHierarchyBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => SetProperty(ref _customerBusinessGroupName, value);
        }

        /// <summary>
        /// Local variable _viewName     
        /// </summary>
        private string _viewName;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [NotMapped,DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }

    }

    /// <summary>
    /// Data contract for CustomerIdentificationSettings
    /// </summary>
    [DataContract, Serializable]
    public class CustomerIdentificationSettingsFilterModel 
    {
        private Guid _customerHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerHierarchyGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerHierarchyGuid
        {
            get => _customerHierarchyGuid;
            set => _customerHierarchyGuid = value;
        }

        private Guid _customerDeliveryPointAssociationGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointAssociationGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointAssociationGuid
        {
            get => _customerDeliveryPointAssociationGuid;
            set => _customerDeliveryPointAssociationGuid= value;
        }
    }

    public class CustomerIdentificationSettingsGetDataFilterModel
    {
      

        private Guid _customerHierarchyBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointAssociationGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerHierarchyBusinessGroupGuid
        {
            get => _customerHierarchyBusinessGroupGuid;
            set => _customerHierarchyBusinessGroupGuid = value;
        }
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {UserGuid}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }
    }

}
