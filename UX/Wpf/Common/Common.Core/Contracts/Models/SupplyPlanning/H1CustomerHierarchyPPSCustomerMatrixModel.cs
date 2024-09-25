/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   H1CustomerHierarchyPPSCustomerMatrixModel.cs
Function           :   H1 Customer Hierarchy PPS Customer Matrix Model 
Created By         :   Dharmendra Kumar
Created on         :   21-Apr-2020
Revision History   :   [] 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    ///  Class file for H1CustomerHierarchyPPSCustomerMatrixModel
    /// </summary>
    [DataContract, Serializable]
    public class H1CustomerHierarchyPPSCustomerMatrixModel : BaseModel<Guid>
    {

        private H1CustomerMappingModel _h1CustomerMappingModel;
        /// <summary>
        /// Get or Set for H1CustomerMappingModel
        /// </summary>
        [DataMember]
        public H1CustomerMappingModel H1CustomerMappingModel
        {
            get => _h1CustomerMappingModel;
            set => SetProperty(ref _h1CustomerMappingModel, value);
        }

        private List<PPSCustomerMappingModel> _ppsCustomerMappingModel;
        /// <summary>
        /// Get or Set value for PPSCustomerMappingModel
        /// </summary>
        [DataMember]
        public List<PPSCustomerMappingModel> PPSCustomerMappingModel
        {
            get => _ppsCustomerMappingModel;
            set => SetProperty(ref _ppsCustomerMappingModel, value);
        }


    }
}