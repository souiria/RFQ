/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerBusinessHierarchyFlattenDataModel.cs
Function           :   Customer Business Hierarchy Flattening Data
Created By         :   Amit 
Created on         :   29-Nov-2019
Revision History   :   [] :
****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// <summary>
    /// Flatten Data for Customer Business Hierarchy
    /// </summary>
    [DataContract, Serializable]
    public class CustomerBusinessHierarchyFlattenDataModel
    {
        /// <summary>
        /// CustomerBusinessHierarchyItem
        /// </summary>
        [DataMember]
        public CustomerBusinessHierarchyModel CustomerBusinessHierarchyItem { get; set; }
        /// <summary>
        /// CustomerHierarchyItem
        /// </summary>
        [DataMember]
        public CustomerHierarchyModel CustomerHierarchyItem { get; set; }
        /// <summary>
        /// CustomerSalesEntityHierarchyItems
        /// </summary>
        [DataMember]
        public ObservableCollection<CustomerSalesEntityHierarchyModel> CustomerSalesEntityHierarchyItems { get; set; }
        /// <summary>
        /// PlatformHierarchyItem
        /// </summary>
        [DataMember]
        public PlatformHierarchyModel PlatformHierarchyItem { get; set; }
        /// <summary>
        /// ProgramHierarchyItem
        /// </summary>
        [DataMember]
        public ProgramHierarchyModel ProgramHierarchyItem { get; set; }
        /// <summary>
        /// ProjectHierarchyItem
        /// </summary>
        [DataMember]
        public ProjectHierarchyModel ProjectHierarchyItem { get; set; }
        /// <summary>
        /// MilestoneHierarchyItem
        /// </summary>
        [DataMember]
        public MilestoneHierarchyModel MilestoneHierarchyItem { get; set; }

    }
}
