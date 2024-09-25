/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyChainDesignModel.cs
Function           :  
Created By         :   Sejal Srivastava
Created on         :   10-Aug-2021
Revision History   :  [16-Aug-2021]: Sejal Srivastava
                   :  [] : Added new data member Operation in SupplyChainDesignByProcedureParameterModel
                   :  [30-Sep-2021]: Shivam Kalia
                   :  [] : Added new data member CDAutoRun in SupplyChainDesignModel
                   :  [06-Oct-2021]: Shivam Kalia
                   :  [] : Added 3 new data member WMSCustomerCodeGuid,BillToSiteGuid and ShipToSiteGuid in SupplyChainDesignModel
                   :  [11-Oct-2021]: Shivam Kalia
                   :  [] : Added new data member CustomerDeliveryPointGuid in SupplyChainDesignModel and SupplyChainDesignByProcedureParameterModel
                   :  [19-Oct-2021] : Sejal Srivastava
                   :  [] : Modified to add new calendar days column for abc and inventory method
                   :  [25-Oct-2021] : Shivam Dhingra
                   :  [] : changed column names as per new table structure
*                  :  [08-Aug-2021] : Sejal Srivastava
*                  :  [] : Added 2 new class ABCAnalysisMethodModel and TargetInventoryMethodModel 
*                  :  [07-Oct-2022] : Virendra
*                  :  [] : Added one new field LocationTypeGuid
*                  :  [14-Oct-2022] : Prakhar
*                  :  [] : Modify LocationTypeGuid as List type.
* 				   :  [25-May-2023] : Vishwadeep Singh
* 				   :  [HD-00334393] : Added New Property OrderCancellation
* 				   :  [17-August-2023] : Sachin Pandey
* 				   :  [HD-00387943] : Added New Property UserGuid
* 				   :  [26-Aug-2023] : Piyush Anand
* 				   :  [] : Fixes Isactive Issues
* 				   :   [30-Jan-2024] : Sachin 
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
    /// Data Contract use for DaysOfDemandSettings Service
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainDesignModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _supplyChainId     
        /// </summary>
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
        /// Local variable _unloadingPoint     
        /// </summary>
        private List<Guid> _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        public List<Guid> UnloadingPoint
        {
            get => _unloadingPoint;
            set => _unloadingPoint = value;
        }

       
        /// <summary>
        /// Local variable _dCLocationGuid     
        /// </summary>
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
        /// Local variable _locationTypeGuid     
        /// </summary>
        private List<Guid> _locationTypeGuid;
        /// <summary>
        /// Get or Set for {LocationTypeGuid}.
        /// </summary>
        [DataMember]
        public List<Guid> LocationTypeGuid
        {
            get => _locationTypeGuid;
            set => _locationTypeGuid = value;
        }

        /// <summary>
        /// Local variable _aBCAnalysisMethod     
        /// </summary>
        private string _aBCAnalysisMethod;
        /// <summary>
        /// Get or Set for {ABCAnalysisMethod}.
        /// </summary>
        [DataMember]
        public string ABCAnalysisMethod
        {
            get => _aBCAnalysisMethod;
            set => _aBCAnalysisMethod = value;
        }

        /// <summary>
        /// Local variable _categoryAThreshold     
        /// </summary>
        private int _categoryAThreshold;
        /// <summary>
        /// Get or Set for {CategoryAThreshold}.
        /// </summary>
        [DataMember]
        public int CategoryAThreshold
        {
            get => _categoryAThreshold;
            set => _categoryAThreshold = value;
        }
        /// <summary>
        /// Local variable _categoryBThreshold     
        /// </summary>
        private int _categoryBThreshold;
        /// <summary>
        /// Get or Set for {CategoryBThreshold}.
        /// </summary>
        [DataMember]
        public int CategoryBThreshold
        {
            get => _categoryBThreshold;
            set => _categoryBThreshold = value;
        }
        /// <summary>
        /// Local variable _categoryCThreshold     
        /// </summary>
        private int _categoryCThreshold;
        /// <summary>
        /// Get or Set for {CategoryCThreshold}.
        /// </summary>
        [DataMember]
        public int CategoryCThreshold
        {
            get => _categoryCThreshold;
            set => _categoryCThreshold = value;
        }


        /// <summary>
        /// Local variable _aBCReviewPeriod     
        /// </summary>
        private int _aBCReviewPeriod;
        /// <summary>
        /// Get or Set for {ABCReviewPeriod}.
        /// </summary>
        [DataMember]
        public int ABCReviewPeriod
        {
            get => _aBCReviewPeriod;
            set => _aBCReviewPeriod = value;
        }
        /// <summary>
        /// Local variable _categoryATargets     
        /// </summary>
        private decimal _categoryATargets;
        /// <summary>
        /// Get or Set for {CategoryATargets}.
        /// </summary>
        [DataMember]
        public decimal CategoryATargets
        {
            get => _categoryATargets;
            set => _categoryATargets = value;
        }
        /// <summary>
        /// Local variable _categoryBTargets     
        /// </summary>
        private decimal _categoryBTargets;
        /// <summary>
        /// Get or Set for {CategoryBTargets}.
        /// </summary>
        [DataMember]
        public decimal CategoryBTargets
        {
            get => _categoryBTargets;
            set => _categoryBTargets = value;
        }
        /// <summary>
        /// Local variable _categoryCTargets     
        /// </summary>
        private decimal _categoryCTargets;
        /// <summary>
        /// Get or Set for {CategoryCTargets}.
        /// </summary>
        [DataMember]
        public decimal CategoryCTargets
        {
            get => _categoryCTargets;
            set => _categoryCTargets = value;
        }
        /// <summary>
        /// Local variable _targetInventoryMethod     
        /// </summary>
        private string _targetInventoryMethod;
        /// <summary>
        /// Get or Set for {TargetInventoryMethod}.
        /// </summary>
        [DataMember]
        public string TargetInventoryMethod
        {
            get => _targetInventoryMethod;
            set => _targetInventoryMethod = value;
        }
        /// <summary>
        /// Local variable _supplierEDIHorizon     
        /// </summary>
        private int _supplierEDIHorizon;
        /// <summary>
        /// Get or Set for {SupplierEDIHorizon}.
        /// </summary>
        [DataMember]
        public int SupplierEDIHorizon
        {
            get => _supplierEDIHorizon;
            set => _supplierEDIHorizon = value;
        }

        /// <summary>
        /// Local variable _operation     
        /// </summary>
        private string _operation;
        /// <summary>
        /// Get or Set for {Operation}.
        /// </summary>
        [DataMember]
        public string Operation
        {
            get => _operation;
            set => _operation = value;
        }

        /// <summary>
        /// Local variable _CDAutoRun
        /// </summary>
        private bool _CDAutoRun;
        /// <summary>
        /// Get or Set for {CDAutoRun}.
        /// </summary>
        [DataMember]
        public bool CDAutoRun
        {
            get => _CDAutoRun;
            set => _CDAutoRun = value;
        }

        /// <summary>
        /// Local variable _wMSCustomerCode     
        /// </summary>
        private string _wMSCustomerCode;
        /// <summary>
        /// Get or Set for {WMSCustomerCode}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string WMSCustomerCode
        {
            get => _wMSCustomerCode;
            set => _wMSCustomerCode = value;
        }

        /// <summary>
        /// Local variable _billToSite     
        /// </summary>
        private string _billToSite;
        /// <summary>
        /// Get or Set for {BillToSite}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string BillToSite
        {
            get => _billToSite;
            set => _billToSite = value;
        }

        /// <summary>
        /// Local variable _shipToSite     
        /// </summary>
        private string _shipToSite;
        /// <summary>
        /// Get or Set for {ShipToSite}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string ShipToSite
        {
            get => _shipToSite;
            set => _shipToSite = value;
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
        /// Local variable _ABCCalendarMethod   
        /// </summary>
        private string _ABCCalendarMethod;
        /// <summary>
        /// Get or Set for {ABCCalendarMethod}.
        /// </summary>
        [DataMember]
        public string ABCCalendarMethod
        {
            get => _ABCCalendarMethod;
            set => _ABCCalendarMethod = value;
        }


        /// <summary>
        /// Local variable _InventoryCalendarMethod  
        /// </summary>
        private string _InventoryCalendarMethod;
        /// <summary>
        /// Get or Set for {InventoryCalendarMethod}.
        /// </summary>
        [DataMember]
        public string InventoryCalendarMethod
        {
            get => _InventoryCalendarMethod;
            set => _InventoryCalendarMethod = value;
        }
        /// <summary>
        /// Local variable _orderCancellation  
        /// </summary>
        private bool _orderCancellation = true;
        /// <summary>
        /// Get or Set for {InventoryCalendarMethod}.
        /// </summary>
        [DataMember]
        public virtual bool OrderCancellation
        {
            get => _orderCancellation;
            set => SetProperty(ref _orderCancellation, value);
        }

        private bool _isActive = true;
        [DataMember]
      
        public  bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value); 
        }

        private string _viewName;
        [NotMapped,DataMember]
        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

       

        /// <summary>
        /// Local variable _viewName     
        /// </summary>

    }

    /// <summary>
    /// Data Contract use for WMSDataSynchronizationETL Service in SupplyChainDesign endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainDesignByProcedureParameterModel
    {
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
        /// Local variable _operation     
        /// </summary>
        private string _operation;
        /// <summary>
        /// Get or Set for {Operation}.
        /// </summary>
        [DataMember]
        public string Operation
        {
            get => _operation;
            set => _operation = value;
        }

        /// <summary>
        /// Local variable _userGuid
        /// </summary>
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

    /// <summary>
    /// Data Contract use for WMSDataSynchronizationETL Service in SupplyChainDesign to get data for ABC Analysis Method
    /// </summary>
    [DataContract, Serializable]
    public class ABCAnalysisMethodModel
    {
        /// <summary>
        /// Local variable _id
        /// </summary>
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

        /// <summary>
        /// Local variable _methodName     
        /// </summary>
        private string _methodName;
        /// <summary>
        /// Get or Set for {MethodName}.
        /// </summary>
        [DataMember]
        public string MethodName
        {
            get => _methodName;
            set => _methodName = value;
        }
    }

    /// <summary>
    /// Data Contract use for WMSDataSynchronizationETL Service in SupplyChainDesign to get data for Target Inventory Method
    /// </summary>
    [DataContract, Serializable]
    public class TargetInventoryMethodModel
    {
        /// <summary>
        /// Local variable _id
        /// </summary>
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

        /// <summary>
        /// Local variable _methodName     
        /// </summary>
        private string _methodName;
        /// <summary>
        /// Get or Set for {MethodName}.
        /// </summary>
        [DataMember]
        public string MethodName
        {
            get => _methodName;
            set => _methodName = value;
        } 
    }
}