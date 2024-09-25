/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  DepartmentMasterModel.cs
Function           :  DepartmentMasterModel
Created By         :  Piyush Anand
Created on         :  05-Oct-2023
Revision History   : []
****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    [DataContract, Serializable]
    public class DepartmentMasterModel : BaseModel<Guid>
    {
        private string _departmentName;
        [DataMember]
        public string DepartmentName
        {
            get => _departmentName;
            set => _departmentName = value;
        }

        private bool _isActive= true ;
        [DataMember]
        public  bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value); 
        }
    }
}