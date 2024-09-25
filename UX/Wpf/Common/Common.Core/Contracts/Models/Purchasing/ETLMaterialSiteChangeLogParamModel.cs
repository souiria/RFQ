/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ETLMaterialSiteChangeLogParamModel.cs
Function           :   Material Site Change Log 
Created By         :   Shivam Dhingra
Created on         :   13-Jul-2020
Revision History   :   
                   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLMaterialSiteChangeLogParamModel : BaseModel<Guid>
    {

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

        private string _businessUnit;
        [DataMember]
        public string BusinessUnit
        {
            get => _businessUnit;
            set => _businessUnit = value;
        }

        private string _sortBy;
        [DataMember]
        public string SortBy
        {
            get => _sortBy;
            set => _sortBy = value;
        }
    }
}
