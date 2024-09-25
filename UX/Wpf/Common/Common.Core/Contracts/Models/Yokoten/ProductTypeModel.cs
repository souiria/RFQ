/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProductTypeModel.cs
Function           :   Data contract for ProductType
Created By         :   Shivam Dhingra
Created on         :   07-Feb-2020
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class ProductTypeModel : BaseModel<Guid>
    {
        private string _productName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ProductName
        {
            get => _productName;
            set => SetProperty(ref _productName, value);
        }
    }
}
