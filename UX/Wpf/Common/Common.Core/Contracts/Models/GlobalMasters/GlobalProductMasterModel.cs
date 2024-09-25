/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   GlobalProductMasterModel.cs
Function           :   Data contract for GlobalProductMasterModel
Created By         :   Prakhar Singh
Created on         :   14-Jun-2022
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
    public class GlobalProductMasterModel
    {
        private string _customerBusinessGroupName;
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => _customerBusinessGroupName = value;
        }


        private string _h1_Vehicle;
        [DataMember]
        public string h1_Vehicle
        {
            get => _h1_Vehicle;
            set => _h1_Vehicle = value;
        }


        private string _product_number;
        [DataMember]
        [StringLength(26)]
        public string product_number
        {
            get => _product_number;
            set => _product_number = value;
        }


    }
}

