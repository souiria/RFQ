/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProductFamilyCustomerBusinessEffectivityModel.cs
Function           :   Product Family Customer Business Effectivity
Created By         :   Shivam Dhingra
Created on         :   13-Aug-2021
Revision History   :   [13-Aug-2021] : Shivam Dhingra
                   :   [] : Corrected FieldName
                   :   [03-Apr-2024] :Prakhar
                   :   [HD-00410021] : Added property Vehicle and VehicleGuid
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
    /// Data Contract for ProductFamilyCustomerBusinessEffectivityModel
    /// </summary>
    [DataContract, Serializable]
    public class ProductFamilyCustomerBusinessEffectivityModel : BaseModel<Guid>
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

        private Guid? _customerGuid;
        /// <summary>
        /// CustomerGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid? CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
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

        private Guid _productBusinessUnitEffectivityId;
        /// <summary>
        /// ProductBusinessUnitEffectivityId
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid ProductBusinessUnitEffectivityId
        {
            get => _productBusinessUnitEffectivityId;
            set => SetProperty(ref _productBusinessUnitEffectivityId, value);
        }


        private DateTime? _productBusinessUnitEffectivityCreatedDate;
        /// <summary>
        /// ProductBusinessUnitEffectivityCreatedDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? ProductBusinessUnitEffectivityCreatedDate
        {
            get => _productBusinessUnitEffectivityCreatedDate;
            set => SetProperty(ref _productBusinessUnitEffectivityCreatedDate, value);
        }

        private DateTime? _productBusinessUnitEffectivityModifiedDate;
        /// <summary>
        /// ProductBusinessUnitEffectivityModifiedDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? ProductBusinessUnitEffectivityModifiedDate
        {
            get => _productBusinessUnitEffectivityModifiedDate;
            set => SetProperty(ref _productBusinessUnitEffectivityModifiedDate, value);
        }


        private Guid _productBusinessUnitEffectivityModifiedBy;
        /// <summary>
        /// ProductBusinessUnitEffectivityModifiedBy
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid ProductBusinessUnitEffectivityModifiedBy
        {
            get => _productBusinessUnitEffectivityModifiedBy;
            set => SetProperty(ref _productBusinessUnitEffectivityModifiedBy, value);
        }

        private Guid _productBusinessUnitEffectivityCreatedBy;
        /// <summary>
        /// ProductBusinessUnitEffectivityCreatedBy
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid ProductBusinessUnitEffectivityCreatedBy
        {
            get => _productBusinessUnitEffectivityCreatedBy;
            set => SetProperty(ref _productBusinessUnitEffectivityCreatedBy, value);
        }

        private bool _productBusinessUnitEffectivityIsActive;
        /// <summary>
        /// ProductBusinessUnitEffectivityIsActice
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public bool ProductBusinessUnitEffectivityIsActive
        {
            get => _productBusinessUnitEffectivityIsActive;
            set => SetProperty(ref _productBusinessUnitEffectivityIsActive, value);
        }
        private Guid _productFamilyCustomerGuid;
        [DataMember]

        public Guid ProductFamilyCustomerGuid
        {
            get => _productFamilyCustomerGuid;
            set => SetProperty(ref _productFamilyCustomerGuid, value);

        }
        private string _vehicle;
        /// <summary>
        /// CustomerGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string Vehicle
        {
            get => _vehicle;
            set => SetProperty(ref _vehicle, value);
        }

        private Guid _vehicleGuid;
        [DataMember]
        public Guid VehicleGuid
        {
            get { return _vehicleGuid; }
            //set { _CustomerGuid = value; }
            set => SetProperty(ref _vehicleGuid, value);
        }

    }
}
