/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WMSArticleModel.cs
Function           :   Data Contract for WMSArticleModel
Created By         :   Srashti Gupta
Created on         :   06-July-2020
Revision History   :   Obsolete Model                    
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for WMSArticleModel
    /// </summary>
    [DataContract, Serializable]
    public  class WMSArticleModel : BaseModel<Guid>
    {
        private string _wmsArticleName;
        /// <summary>
        /// Get or Set for {LocationReportingSection}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WMSArticleName
        {
            get => _wmsArticleName;
            set => SetProperty(ref _wmsArticleName, value);
        }
    }
}
