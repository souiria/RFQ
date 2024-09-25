/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   GetProjectHierarchyModel.cs
Function           :   ProjectHierarchy
Created By         :   Prakhar Singh  
Created on         :   [14-Jul-2022]
Revision History   :   
                   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// Represents a DropDownProjectHierarchyData 
    [DataContract, Serializable]
   
    public class DropDownProjectHierarchyModel 
    {

        private Guid _id;

        /// get or set for id
        [DataMember]
        [StringLength(20)]
        public Guid ID
        {
            get => _id;
            set =>  _id= value;
        }

        private string _projectName;

        /// get or set for customername
        [DataMember]
        [StringLength(100)]
        public string ProjectName
        {
            get => _projectName;
            set => _projectName=value;
        }

       

    }
}

