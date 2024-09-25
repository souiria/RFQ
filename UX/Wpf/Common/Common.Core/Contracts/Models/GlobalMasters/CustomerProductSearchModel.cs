/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ConsolidatedCustomerProductModel.cs
Function           :   Data contract for ConsolidatedCustomerProductModel
Created By         :   Amit
Created on         :   23-May-2020
Revision History   :   [] : 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class CustomerProductSearchModel
    {
        [DataMember]
        public string CustomerProductFrom { get; set; } = string.Empty;

        [DataMember]
        public string CustomerProductTo { get; set; } = string.Empty;
    }
}
