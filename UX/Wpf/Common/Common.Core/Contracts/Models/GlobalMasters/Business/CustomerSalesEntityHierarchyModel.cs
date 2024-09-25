/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerSalesEntityHierarchyModel.cs
Function           :   Customer Sales Entity Hierarchy
Created By         :   Amit Agarwal 
Created on         :   29-Nov-2019
Revision History   :   [30-Nov-2019] : Pawan
                   :   [] : Added validation for each property  
                   :   [02-Dec-2019] : Nitin
                   :   [] : Added field length validation
                   :   [02-Dec-2019] : Pawan
                   :   [] : Added interface for IValidatable 
                   :   [29-Jan-2020] : Yati
                   :   [] : Added Code to remove validation on Customer Sales Entity  
                   :   [29-Jan-2020] : Yati
                   :   [] : Added Code to remove validation on Zip Code for Customer Sales Entity    
                   :   [05-May-2022] : Shivam Kalia
                   :   [] : Added CustomerSalesCountryGuid field in CustomerSalesEntityHierarchyModel
                   :   [31-May-2022] : Anmol jain
                   :   [] : Added string length in diffrent fields according to database Tables
*                  :   [27-Feb-2023] : Ranjay
*                  :   [HD-00375862] : Added new field CustomerHierarchyGuid
****************************************************************************************************/
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract]
    public class CustomerSalesEntityHierarchyModel : BaseModel<Guid>, IValidatable
    {
        private string _customerSalesEntityCode;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(10)]
        public string CustomerSalesEntityCode
        {
            get => _customerSalesEntityCode;
            set => SetProperty(ref _customerSalesEntityCode, value);
        }

        private string _customerSalesEntityName;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string CustomerSalesEntityName
        {
            get => _customerSalesEntityName;
            set => SetProperty(ref _customerSalesEntityName, value);
        }

        private string _financeCode;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(10)]
        public string FinanceCode
        {
            get => _financeCode;
            set => SetProperty(ref _financeCode, value);
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

        private Guid _customerSalesCountryGuid;
        /// <summary>
        /// Country Guid
        /// </summary>
        [DataMember]
        public Guid CustomerSalesCountryGuid
        {
            get => _customerSalesCountryGuid;
            set => SetProperty(ref _customerSalesCountryGuid, value);
        }

        private Guid _customerHierarchyGuid;
        /// <summary>
        /// CustomerHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid CustomerHierarchyGuid
        {
            get => _customerHierarchyGuid;
            set => SetProperty(ref _customerHierarchyGuid, value);
        }
        #region  -- Validation --
        /// <summary>
        /// Property to validate 
        /// </summary>
        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(CustomerSalesEntityName),
            nameof(CustomerSalesEntityCode),
            nameof(FinanceCode),
            nameof(StreetNumber),
            nameof(StreetName),
            nameof(City),
            nameof(Region),
            nameof(ZipCode),
            nameof(Country)
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
                        case nameof(CustomerSalesEntityName) when string.IsNullOrWhiteSpace(_customerSalesEntityName):
                            Error = "Customer Sales Entity Name must not be empty."; break;

                        case nameof(CustomerSalesEntityCode) when string.IsNullOrWhiteSpace(_customerSalesEntityCode):
                            Error = "Customer Sales Entity Code must not be empty"; break;

                        case nameof(FinanceCode) when string.IsNullOrWhiteSpace(_financeCode):
                            Error = "Finance code must not be empty."; break;

                        case nameof(StreetNumber) when _streetNumber != null && !_streetNumber.All(char.IsNumber):
                            Error = "Street number must only contain numbers."; break;

                        case nameof(StreetName) when string.IsNullOrWhiteSpace(_streetName):
                            Error = "Street name must not be empty."; break;

                        //case nameof(StreetName) when !_streetName.All(char.IsLetter):
                        //	Error = "Street name cannot contain any special characters."; break;

                        case nameof(City) when string.IsNullOrWhiteSpace(_city):
                            Error = "City must not be empty."; break;

                        //case nameof(City) when !_city.All(char.IsLetter):
                        //	Error = "City cannot contain any special characters."; break;

                        case nameof(Region) when string.IsNullOrWhiteSpace(_region):
                            Error = "Region must not be empty."; break;

                        //case nameof(Region) when !_region.All(char.IsLetter):
                        //	Error = "Region cannot contain any special characters."; break;

                        case nameof(ZipCode) when string.IsNullOrWhiteSpace(_zipCode):
                            Error = "Zip code must not be empty."; break;

                        //case nameof(ZipCode) when !_zipCode.All(char.IsLetterOrDigit):
                        //	Error = "Zip code cannot contain any special characters."; break;

                        case nameof(Country) when string.IsNullOrWhiteSpace(_country):
                            Error = "Country must not be empty."; break;

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
}
