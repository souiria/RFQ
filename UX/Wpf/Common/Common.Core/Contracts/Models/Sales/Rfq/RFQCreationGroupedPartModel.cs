/**************************************************************************************************
(C) 2019 SEWS-E Ltd., All rights reserved
File Name          :   RFQCreationGroupedPartModel.cs
Function           :   Maintain Details for RFQCreationGroupedPartModel
Created By         :   Yati Mathur
Created on         :   18-Nov-2019
Revision History   :   
****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, NotMapped, Serializable]
    public class RFQCreationGroupedPartModel
    {
        [DataMember, NotMapped]
        public Guid Id { get; set; }
        [DataMember, NotMapped]
        public string PartNumber1 { get; set; }
        [DataMember, NotMapped]
        public string PartNumber2 { get; set; }
        [DataMember, NotMapped]
        public string PartNumber3 { get; set; }
        [DataMember, NotMapped]
        public List<AssociatedDerivativeInfoModel> AssociatedDerivativeCollection { get; set; }
        [DataMember, NotMapped]
        public bool IsLoaded { get; set; }
        [DataMember, NotMapped]
        public string MaterialType { get; set; }
        [DataMember, NotMapped]
        public string PartNumberType { get; set; }
        [DataMember, NotMapped]
        public bool IsPartNumberSelected { get; set; }


    }
}
