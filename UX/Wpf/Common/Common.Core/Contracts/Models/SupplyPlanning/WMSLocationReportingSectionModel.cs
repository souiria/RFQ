/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WMSArticleModel.cs
Function           :   Data Contract for WMSArticleModel
Created By         :   Shivam Dhingra
Created on         :   04-Jun-2020
Revision History   :   [03-July-2020] : Srashti Gupta
*                  :   Rename the properties & datasize                      
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for WMSLocationReportingSection
    /// </summary>
    [DataContract, Serializable]
    public  class WMSLocationReportingSectionModel : BaseModel<Guid>
    {
        private string _locationReportingSection;
        /// <summary>
        /// Get or Set for {LocationReportingSection}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string LocationReportingSection
        {
            get => _locationReportingSection;
            set => SetProperty(ref _locationReportingSection, value);
        }
    }
}
