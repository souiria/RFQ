/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProductFamilyCustomerAssociationModel.cs
Function           :   Product Family Customer Association
Created By         :   Shivam Dhingra
Created on         :   04-Jun-2021
Revision History   :   [04-Jun-2021] : Shivam Dhingra
                   :   [] Added model to fetch ProductNumber data only
                   :   [05-Jul-2021] : Shivam Dhingra
                   :   [] Added new fields VehicleNumber and EffectiveDate
                   :   [05-Jul-2021] : Shivam Dhingra
				   :	[] : changed list<BusinessUnitGuid> to BusinessUnitGuid
                   :   [08-Jul-2021] : Shivam Dhingra
				   :	[] : Added model for UploadData
                   :   [30-Jul-2021] : Shivam Kalia
                   :   [] Added new field ProjectGuid and removed VehicleName in ProductFamilyCustomerAssociationModel
:                  :   [02-Aug-2021] : Shivam Kalia
                   :   [] Replaced VehicleName with ProjectName in ProductFamilyCustomerAssociationUploadModel
                   :   [13-Aug-2021] : Shivam Dhingra
                   :   [] Added new filters and new fields as per table structure
                   :   [07-Oct-2022] : Prakhar
                   :   [] Added new fields CustomerGuid
                   :   [21-Sept-2023] : Virendra
                   :   [00391154] Added new fields 'P_UserGuid' in the Model 'CustomerGuid ProductFamilyCustomerAssociationFilterModel '
                   :   [03-Apr-2024] : Prakhar
                   :   [HD-00410021] Added new fields Vehicle in the Model ProductFamilyCustomerAssociationUploadModel and added new model ProductFamilyVehicle'
                   :   [12-Apr-2024] : Prakhar
                   :   [HD-00410021] Added new model ProductFamilyproductNoAndVehicle' and removed ProductFamilyVehicle.

****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// Class File for ProductFamilyCustomerAssociationModel
    /// </summary>
    [DataContract, Serializable]
    public class ProductFamilyCustomerAssociationModel : BaseModel<Guid>
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

        private string _customerDesign1;
        /// <summary>
        /// CustomerDesign1
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(4)]
        public string CustomerDesign1
        {
            get => _customerDesign1;
            set => SetProperty(ref _customerDesign1, value);
        }


        private string _customerDesign2;
        /// <summary>
        /// CustomerDesign2
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(2)]
        public string CustomerDesign2
        {
            get => _customerDesign2;
            set => SetProperty(ref _customerDesign2, value);
        }


        private string _internalDesign;
        /// <summary>
        /// InternalDesign
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(2)]
        public string InternalDesign
        {
            get => _internalDesign;
            set => SetProperty(ref _internalDesign, value);
        }

        private Guid? _harnessFamilyGuid;
        /// <summary>
        /// HarnessFamilyGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? HarnessFamilyGuid
        {
            get => _harnessFamilyGuid;
            set => SetProperty(ref _harnessFamilyGuid, value);
        }

        private Guid? _customerBusinessGuid;
        /// <summary>
        /// CustomerBusinessGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? CustomerBusinessGuid
        {
            get => _customerBusinessGuid;
            set => SetProperty(ref _customerBusinessGuid, value);
        }



        private string _customerProductNumber;
        /// <summary>
        /// CustomerProductNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(26)]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set => SetProperty(ref _customerProductNumber, value);
        }

        private Guid _businessUnitGuid;
        /// <summary>
        /// BusinessUnitGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private DateTime? _effectiveDate;
        /// <summary>
        /// VehicleName
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? EffectiveDate
        {
            get => _effectiveDate;
            set => SetProperty(ref _effectiveDate, value);
        }

        private Guid _projectGuid;
        /// <summary>
        /// ProjectGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

    }

    /// <summary>
    /// Class File for ProductFamilyCustomerAssociationFilterModel
    /// </summary>
    [DataContract, Serializable]
    public class ProductFamilyCustomerAssociationFilterModel
    {
        private string _productNumberFrom;
        /// <summary>
        /// Get or Set for {ProductNumberFrom}.
        /// </summary>
        [DataMember]
        public string ProductNumberFrom
        {
            get => _productNumberFrom;
            set => _productNumberFrom = value;
        }

        private string _productNumberTo;
        /// <summary>
        /// Get or Set for {ProductNumberTo}.
        /// </summary>
        [DataMember]
        public string ProductNumberTo
        {
            get => _productNumberTo;
            set => _productNumberTo = value;
        }

        private string _p_option;
        /// <summary>
        /// Get or Set for {P_option}.
        /// </summary>
        [DataMember]
        [StringLength(1)]
        public string P_option
        {
            get => _p_option;
            set => _p_option = value;
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

        private Guid? _p_projectGuid;
        /// <summary>
        /// Get or Set for {P_projectGuid}.
        /// </summary>
        [DataMember]
        public Guid? P_ProjectGuid
        {
            get => _p_projectGuid;
            set => _p_projectGuid = value;
        }

        private Guid? _p_harnessFamilyGuid;
        /// <summary>
        /// Get or Set for {P_harnessFamilyGuid}.
        /// </summary>
        [DataMember]
        public Guid? P_harnessFamilyGuid
        {
            get => _p_harnessFamilyGuid;
            set => _p_harnessFamilyGuid = value;
        }

        private bool? _p_bomIsActive;
        /// <summary>
        /// Get or Set for {_p_bomIsActive}.
        /// </summary>
        [DataMember]
        public bool? P_BOMIsActive
        {
            get => _p_bomIsActive;
            set => _p_bomIsActive = value;
        }

        private bool? _p_businessUnitIsActive;
        /// <summary>
        /// Get or Set for {P_businessUnitIsActive}.
        /// </summary>
        [DataMember]
        public bool? P_businessUnitIsActive
        {
            get => _p_businessUnitIsActive;
            set => _p_businessUnitIsActive = value;
        }
        private Guid? p_UserGuid;
        /// <summary>
        /// Get or Set for {P_UserGuid}.
        /// </summary>
        [DataMember]
        public Guid? P_UserGuid
        {
            get => p_UserGuid;
            set => p_UserGuid = value;
        }
    }

    /// <summary>
    /// Class File for ProductFamilyCustomerAssociationModel
    /// </summary>
    [DataContract, Serializable]
    public class ProductFamilyCustomerComboModel
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
            set => _productNumber = value;
        }
    }

    /// <summary>
    /// Class File for ProductFamilyCustomerAssociationUploadModel
    /// </summary>
    [DataContract, Serializable]
    public class ProductFamilyCustomerAssociationUploadModel : BaseModel<Guid>
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

        private string _customerDesign1;
        /// <summary>
        /// CustomerDesign1
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(4)]
        public string CustomerDesign1
        {
            get => _customerDesign1;
            set => SetProperty(ref _customerDesign1, value);
        }


        private string _customerDesign2;
        /// <summary>
        /// CustomerDesign2
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(2)]
        public string CustomerDesign2
        {
            get => _customerDesign2;
            set => SetProperty(ref _customerDesign2, value);
        }


        private string _internalDesign;
        /// <summary>
        /// InternalDesign
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(2)]
        public string InternalDesign
        {
            get => _internalDesign;
            set => SetProperty(ref _internalDesign, value);
        }

        private string _harnessFamilyGroupName;
        /// <summary>
        /// HarnessFamilyGroupName
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(4)]
        public string HarnessFamilyGroupName
        {
            get => _harnessFamilyGroupName;
            set => SetProperty(ref _harnessFamilyGroupName, value);
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// CustomerBusinessGroupCode
        /// </summary>
        ///<example>
        /// Honda Industries, Renault Plc., PSA Ltd.
        ///</example>
        [DataMember]
        [StringLength(100)]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => SetProperty(ref _customerBusinessGroupName, value);
        }



        private string _customerProductNumber;
        /// <summary>
        /// CustomerProductNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(26)]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set => SetProperty(ref _customerProductNumber, value);
        }

        private string _businessUnitCode;
        /// <summary>
        /// BusinessUnitCode
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(4)]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }

        private string _projectName;
        /// <summary>
        /// ProjectName
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(50)]
        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }

        private DateTime? _effectiveDate;
        /// <summary>
        /// VehicleName
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? EffectiveDate
        {
            get => _effectiveDate;
            set => SetProperty(ref _effectiveDate, value);
        }
        private bool _bomIsActive;
        /// <summary>
        /// BOMIsActive
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public bool BOMIsActive
        {
            get => _bomIsActive;
            set => SetProperty(ref _bomIsActive, value);
        }
        private bool _productEffectivityIsActive;
        /// <summary>
        /// ProductEffectivityIsActive
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public bool ProductEffectivityIsActive
        {
            get => _productEffectivityIsActive;
            set => SetProperty(ref _productEffectivityIsActive, value);
        }
        private Guid? _p_customerGuid;
        /// <summary>
        /// Get or Set for {_p_customerGuid}.
        /// </summary>
        [DataMember]
        public Guid? CustomerGuid
        {
            get => _p_customerGuid;
            set => _p_customerGuid = value;
        }

        private string _vehicle;
        /// <summary>
        /// ProjectName
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(50)]
        public string Vehicle
        {
            get => _vehicle;
            set => SetProperty(ref _vehicle, value);
        }


    }

    [DataContract, Serializable]
    public class ProductFamilyproductNoAndVehicle
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
            set =>  _productNumber = value;
        }

        private Guid? p_vehicleGuid;
        /// <summary>
        /// Get or Set for {p_vehicleGuid}.
        /// </summary>
        [DataMember]
        public Guid? VehicleGuid
        {
            get => p_vehicleGuid;
            set => p_vehicleGuid = value;
        }

        private string _VehicleDisplay;
        /// <summary>
        /// VehicleDisplay
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(203)]
        public string VehicleDisplay
        {
            get => _VehicleDisplay;
            set => _VehicleDisplay = value;
        }

        private Guid? _p_projectGuid;
        /// <summary>
        /// Get or Set for {P_projectGuid}.
        /// </summary>
        [DataMember]
        public Guid? P_ProjectGuid
        {
            get => _p_projectGuid;
            set => _p_projectGuid = value;
        }

        private string _customerProductNumber;
        /// <summary>
        /// CustomerProductNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(26)]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set =>  _customerProductNumber = value;
        }
    }

}
