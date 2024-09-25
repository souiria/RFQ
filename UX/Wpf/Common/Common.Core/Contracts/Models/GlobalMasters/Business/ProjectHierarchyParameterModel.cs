/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name           :   ProjectHierarchyParameterModel.cs
Function            :   
Created By          :   Vishwadeep Singh : HD:00375862 
Created on          :   [23-Feb-2023]
Revision History    :

****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMasters.Business
{
    [DataContract]
    public class ProjectHierarchyParameterModel
    {
        [DataMember]
        public List<PlatformHierarchyModel> ListPlatformHierarchy { get; set; }
        [DataMember]
        public List<ProgramHierarchyModel> ListProgramHierarchy { get; set; }
        [DataMember]
        public List<ProjectHierarchyModel> ListProjectHierarchy { get; set; }
        [DataMember]
        public List<MilestoneHierarchyModel> ListMilestoneHierarchy { get; set; }
    }
}
