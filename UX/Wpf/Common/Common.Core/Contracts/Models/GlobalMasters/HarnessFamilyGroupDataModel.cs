/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   HarnessFamilyGroupDataModel.cs
Function           :  Get Harness Family Group
Created By         :   Dharmendra 
Created on         :   06-Dec-2022
Revision History   :  
****************************************************************************************************/
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    public class HarnessFamilyGroupDataModel
    {
        private string _harnessFamilyGroupName;
        [DataMember]
        public string HarnessFamilyGroupName
        {
            get => _harnessFamilyGroupName;
            set => _harnessFamilyGroupName= value;
        }
    }
}
