/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ETLMaterialChangeLogpPramModel.cs
Function           :   Material Change Log Parameters
Created By         :   Shivam Dhingra
Created on         :   13-Jul-2020
Revision History   :   
                   :   
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract,Serializable]
   public class ETLMaterialChangeLogParamModel
    {

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
    }
}
