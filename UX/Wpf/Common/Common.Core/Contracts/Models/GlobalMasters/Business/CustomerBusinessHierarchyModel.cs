/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   BusinessHierarchyModel.cs
Function           :   Business Hierarchy
Created By         :   Dharmendra 
Created on         :   29-Nov-2019
Revision History   :   [30-Nov-2019] : Pawan
                   :   [] : Added validation for each property
                   :   [02-Dec-2019] : Pawan
                   :   [] : Added interface for IValidatable  
                   :   [03-Dec-2019] : Pawan
                   :   [] : Changed List to Observable Collection
                   :   [18-Jun-2020] : Shivam Dhingra
                   :   [] : Changed length from 10 to 18 for CustomerBusinessGroupCode and commented the validation for the same
                   :   [14-Sep-2022] : Ashish Dutta
                   :   [] : Added new column in customer business group(SEWSEBusinessTeam)
                   :   [15-Feb-2023] : Ranjay
                   :   [] : [HD Call Number - 00370357] Added new class CustomerBusinessHierarchyDropDownModel
*                  :   [27-Feb-2023] : Ranjay
*                  :   [HD-00375862] : Added new class CustomerBusinessHierarchyProcessModel
*                  :   [21-Apr-2023] : Prakhar
*                  :   [HD-00375862] : Added new class H1CustomerBusinessHierarchy
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
    /// <summary>
    /// Represents a customer business unit within the system.
    /// </summary>
    [DataContract, Serializable]
    public class CustomerBusinessHierarchyModel : BaseModel<Guid>, ICustomerBusinessHierarchy, IValidatable
    {
        private string _customerBusinessGroupCode;
        /// <summary>
        /// CustomerBusinessGroupCode
        /// </summary>
        ///<example>
        /// Honda, Nissan, Toyota, Renault, PSA
        ///</example>
        [DataMember]
        [StringLength(10)]
        public string CustomerBusinessGroupCode
        {
            get => _customerBusinessGroupCode;
            set => SetProperty(ref _customerBusinessGroupCode, value);
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
        private string _sewsebusinessteam;
        /// <summary>
        /// SEWEBusinessTeam
        /// </summary>
        ///<example>
        /// Honda Industries, Renault Plc., PSA Ltd.
        ///</example>
        [DataMember]
        [StringLength(50)]
        public string SEWSEBusinessTeam
        {
            get => _sewsebusinessteam;
            set => SetProperty(ref _sewsebusinessteam, value);
        }


        private ObservableCollection<CustomerHierarchyModel> _customerHierarchy;
        /// <summary>
        /// Hierarchy of Purchasing Supplier Material
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public ObservableCollection<CustomerHierarchyModel> CustomerHierarchy
        {
            get => _customerHierarchy;
            set => SetProperty(ref _customerHierarchy, value);
        }
        #region  -- Validation --
        /// <summary>
        /// Property to validate 
        /// </summary>
        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(CustomerBusinessGroupCode),
            nameof(CustomerBusinessGroupName)

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
                        case nameof(CustomerBusinessGroupName) when string.IsNullOrWhiteSpace(CustomerBusinessGroupName):
                            Error = "Customer Business Group Name must not be empty.";break;

                        case nameof(CustomerBusinessGroupCode) when string.IsNullOrWhiteSpace(_customerBusinessGroupCode):
                            Error = "Customer Business Group Code must not be empty."; break;

                        default:
                            Error= null;break;
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
    public class CustomerBusinessHierarchyDropDownModel
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

        private string _customerBusinessGroupCode;
        /// <summary>
        /// CustomerBusinessGroupCode
        /// </summary>
        ///<example>
        /// Honda, Nissan, Toyota, Renault, PSA
        ///</example>
        [DataMember]
        public string CustomerBusinessGroupCode
        {
            get => _customerBusinessGroupCode;
            set => _customerBusinessGroupCode = value;
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// CustomerBusinessGroupName
        /// </summary>
        ///<example>
        /// Honda Industries, Renault Plc., PSA Ltd.
        ///</example>
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => _customerBusinessGroupName = value;
        }
    }

    [DataContract, Serializable]
    public class CustomerBusinessHierarchyProcessModel
    {
        private List<CustomerBusinessHierarchyModel> _customerBusinessHierarchyModel;
        /// <summary>
        /// CustomerBusinessHierarchyModel
        /// </summary>
        [DataMember]
        public List<CustomerBusinessHierarchyModel> CustomerBusinessHierarchyModel
        {
            get => _customerBusinessHierarchyModel;
            set => _customerBusinessHierarchyModel = value;
        }

        private List<CustomerHierarchyModel> _customerHierarchy;
        /// <summary>
        /// CustomerHierarchyModel
        /// </summary>
        [DataMember]
        public List<CustomerHierarchyModel> CustomerHierarchy
        {
            get => _customerHierarchy;
            set => _customerHierarchy = value;
        }

        private List<CustomerSalesEntityHierarchyModel> _customerSalesEntityHierarchyModel;
        /// <summary>
        /// CustomerSalesEntityHierarchyModel
        /// </summary>
        [DataMember]
        public List<CustomerSalesEntityHierarchyModel> CustomerSalesEntityHierarchyModel
        {
            get => _customerSalesEntityHierarchyModel;
            set => _customerSalesEntityHierarchyModel = value;
        }
    }

    [DataContract, Serializable]
    public class H1CustomerBusinessHierarchy
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



        private string _customerBusinessGroupCode;
        /// <summary>
        /// CustomerBusinessGroupCode
        /// </summary>
        ///<example>
        /// Honda, Nissan, Toyota, Renault, PSA
        ///</example>
        [DataMember]
        public string CustomerBusinessGroupCode
        {
            get => _customerBusinessGroupCode;
            set => _customerBusinessGroupCode = value;
        }




    }

 
}
