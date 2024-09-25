/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   GetCustomerHierarchyModel.cs
Function           :   CustomerHierarchy
Created By         :   Prakhar Singh  
Created on         :   [14-Jul-2022]
Revision History   :   []
                   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// Represents a DropDownCustomerHierarchyData 
    [DataContract, Serializable]
    public class DropDownCustomerHierarchyModel
    {

        private Guid _id;

        /// get or set for id
        [DataMember]       
        [StringLength(20)]
        public Guid ID
        {
            get => _id;
            set => _id=value;
        }
      
        private string _customerName;

        /// get or set for customername
        [DataMember]
        [StringLength(100)]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName= value;
        }

        private string _customerCode;

        /// get or set for customercode
        [DataMember]
        [StringLength(20)]
        public string CustomerCode
        {
            get => _customerCode;
            set => _customerCode= value;
        }


    }
}
