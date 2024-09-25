/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerHierarchyModel.cs
Function           :   Customer Hierarchy
Created By         :   Dharmendra 
Created on         :   29-Nov-2019
Revision History   :   [30-Nov-2019] : Pawan
                   :   [] : Added validation for each property  
                   :   [02-Dec-2019] : Pawan
                   :   [] : Added interface for IValidatable   
                   :   [03-Dec-2019] : Pawan
                   :   [] : Changed List to Observable Collection             
                   :   [29-Jan-2020] : Srashti
                   :   [] : Change the StringLength to 50 of {CustomerName}.           
                   :   [10-Jun-2020] : Pawan
                   :   [] : Added field for Customer Business Quality Manager
                   :   [15-Jun-2020] : Srashti
                   :   [] : Added field for Customer Business Quality Manager Name
                   :   [18-Jun-2020] : Shivam Dhingra
                   :   [] : Changed length from 10 to 18 for CustomerCode and commented the validation for the same
                   :   [05-May-2022] : Shivam Kalia
                   :   [] : Added CustomerCountryGuid field in CustomerSalesEntityHierarchyModel
                   :   [31-May-2022] : Anmol jain
                   :   [] : Added string length in diffrent fields according to database Tables
                   :   [15-Feb-2023] : Ranjay
                   :   [] : [HD Call Number - 00370357] Added new class CustomerHierarchyDropDownModel
*                  :   [27-Feb-2023] : Ranjay
*                  :   [HD-00375862] : Added new field CustomerBusinessHierarchyGuid
*                  :   [31-March-2023] : Virendra
*                  :   [] : Added new Model CustomerHierarchyStateLessModel
****************************************************************************************************/
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using Common.SF.Contracts.Interfaces.GlobalMasters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class CustomerHierarchyModel : BaseModel<Guid>, ICustomerHierarchy, IValidatable
    {
        private string _customerCode;
        /// <summary>
        /// CustomerCode
        /// </summary>
        /// <example>
        /// HTR, HUM, Renault_Fr, Renault_Tr, PSA_POISSY, PSA_MADRID, TMMR, TMMT
        /// </example>
        [DataMember]
        [StringLength(18)]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }

        private string _customerName;
        /// <summary>
        /// CustomerName
        /// </summary>
        /// <example>
        /// Honda Turkey, Honda UK, Renault France, Renault Turkey, PSA Poissy, PSA Madrid, Toyota Russia
        /// </example>
        [DataMember]
        [StringLength(50)]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        private string _streetNumber;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string StreetNumber
        {
            get => _streetNumber;
            set => SetProperty(ref _streetNumber, value);
        }

        private string _streetName;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string StreetName
        {
            get => _streetName;
            set => SetProperty(ref _streetName, value);
        }

        private string _city;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private string _region;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        private string _zipCode;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string ZipCode
        {
            get => _zipCode;
            set => SetProperty(ref _zipCode, value);
        }

        private string _country;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private Guid _customerCountryGuid;
        /// <summary>
        /// Country Guid
        /// </summary>
        [DataMember]
        public Guid CustomerCountryGuid
        {
            get => _customerCountryGuid;
            set => SetProperty(ref _customerCountryGuid, value);
        }

        private string _customerBusinessType;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(25)]
        public string CustomerBusinessType
        {
            get => _customerBusinessType;
            set => SetProperty(ref _customerBusinessType, value);
        }

        private string _indexedMaterial;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string IndexedMaterial
        {
            get => _indexedMaterial;
            set => SetProperty(ref _indexedMaterial, value);
        }

        private Guid _customerBusinessQualityManagerGuid;
        /// <summary>
        /// Quality Manager Guid
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessQualityManagerGuid
        {
            get => _customerBusinessQualityManagerGuid;
            set => SetProperty(ref _customerBusinessQualityManagerGuid, value);
        }

        private string _customerBusinessQualityManagerName;
        /// <summary>
        /// Quality Manager Name
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerBusinessQualityManagerName
        {
            get => _customerBusinessQualityManagerName;
            set => SetProperty(ref _customerBusinessQualityManagerName, value);
        }

        private ObservableCollection<CustomerSalesEntityHierarchyModel> _customerSalesEntityHierarchy;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public ObservableCollection<CustomerSalesEntityHierarchyModel> CustomerSalesEntityHierarchy
        {
            get => _customerSalesEntityHierarchy;
            set => SetProperty(ref _customerSalesEntityHierarchy, value);
        }

        private ObservableCollection<PlatformHierarchyModel> _platformHierarchyModel;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public ObservableCollection<PlatformHierarchyModel> PlatformHierarchy
        {
            get => _platformHierarchyModel;
            set => SetProperty(ref _platformHierarchyModel, value);
        }

        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// CustomerBusinessHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => SetProperty(ref _customerBusinessHierarchyGuid, value);
        }

        #region  -- Validation --
        /// <summary>
        /// Property to validate 
        /// </summary>
        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(CustomerCode),
            nameof(StreetNumber),
            nameof(StreetName),
            nameof(City),
            nameof(Region),
            nameof(ZipCode),
            nameof(Country),
            nameof(CustomerBusinessType),
            nameof(IndexedMaterial)
        };
        /// <summary>
        /// Method to validate properties
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public override string this[string propertyName]
        {
            get
            {
                Error = string.Empty;
                try
                {
                    switch (propertyName)
                    {
                        case nameof(CustomerName) when string.IsNullOrWhiteSpace(CustomerName):
                            Error = "Customer Name must not be empty."; break;

                        case nameof(CustomerCode) when string.IsNullOrWhiteSpace(_customerCode):
                            Error = "Customer Code must not be empty."; break;

                        //case nameof(StreetNumber) when string.IsNullOrWhiteSpace(_streetNumber):
                        //    return "Street number must not be empty.";

                        case nameof(StreetNumber) when _streetNumber != null && !_streetNumber.All(char.IsNumber):
                            Error = "Street number must only contain numbers."; break;

                        case nameof(StreetName) when string.IsNullOrWhiteSpace(_streetName):
                            Error = "Street name must not be empty."; break;

                        case nameof(City) when string.IsNullOrWhiteSpace(_city):
                            Error = "City name must not be empty."; break;

                        case nameof(Region) when string.IsNullOrWhiteSpace(_region):
                            Error = "Region must not be empty."; break;

                        case nameof(ZipCode) when string.IsNullOrWhiteSpace(_zipCode):
                            Error = "Zip Code must not be empty."; break;

                        case nameof(Country) when string.IsNullOrWhiteSpace(_country):
                            Error = "Country must not be empty."; break;

                        case nameof(CustomerBusinessType) when string.IsNullOrWhiteSpace(_customerBusinessType):
                            Error = "Type must not be empty."; break;

                        case nameof(IndexedMaterial) when string.IsNullOrWhiteSpace(_indexedMaterial):
                            Error = "Indexed Material must not be empty."; break;

                        default:
                            Error = null; break;
                    }
                    UpdateErrors(propertyName, Error);
                }
                catch (Exception) { }
                return Error;
            }
        }

        #endregion
    }

    [DataContract, Serializable]
    public class CustomerHierarchyDropDownModel
    {
        private Guid _id;
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private string _customerCode;
        /// <summary>
        /// CustomerCode
        /// </summary>
        /// <example>
        /// HTR, HUM, Renault_Fr, Renault_Tr, PSA_POISSY, PSA_MADRID, TMMR, TMMT
        /// </example>
        [DataMember]
        public string CustomerCode
        {
            get => _customerCode;
            set => _customerCode = value;
        }

        private string _customerName;
        /// <summary>
        /// CustomerName
        /// </summary>
        /// <example>
        /// Honda Turkey, Honda UK, Renault France, Renault Turkey, PSA Poissy, PSA Madrid, Toyota Russia
        /// </example>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }
    }

    [DataContract, Serializable]
    public class CustomerHierarchyDropDownFilterModel
    {
        private Guid _CustomerBusinessHierarchyGuid;
        /// <summary>
        /// CustomerBusinessHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _CustomerBusinessHierarchyGuid;
            set => _CustomerBusinessHierarchyGuid = value;
        }
    }
    [DataContract, Serializable]
    public class CustomerHierarchyStateLessModel
    {
        private Guid _id;
        /// <summary>
        /// _id
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private string _customerCode;
        /// <summary>
        /// CustomerName
        /// </summary>
        [DataMember]
        public string CustomerCode
        {
            get => _customerCode;
            set => _customerCode = value;
        }
        private string _customerName;
        /// <summary>
        /// CustomerName
        /// </summary>
        /// <example>
        /// Honda Turkey, Honda UK, Renault France, Renault Turkey, PSA Poissy, PSA Madrid, Toyota Russia
        /// </example>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName= value;
        }
        private Guid _CustomerBusinessHierarchyGuid;
        /// <summary>
        /// CustomerBusinessHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _CustomerBusinessHierarchyGuid;
            set => _CustomerBusinessHierarchyGuid = value;
        }
    }

}
