/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WMSLocationMappingModel.cs
Function           :   Data Contract for WMSLocationMapping
Created By         :   Shivam Dhingra
Created on         :   04-Jun-2020
Revision History   :   [03-July-2020] : Srashti Gupta
*                  :   Rename the properties & datasize  
*                  :   [30-Sep-2020] : Shivam Dhingra
*                  :   Added new column WHCODE
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for WMSLocationMappingModel
    /// </summary>
    [DataContract, Serializable]
    public class WMSLocationMappingModel : BaseModel<Guid>
    {
        private string _wmsSourceType;
        /// <summary>
        /// Get or Set for {WMSSourceType}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WMSSourceType
        {
            get => _wmsSourceType;
            set => SetProperty(ref _wmsSourceType, value);
        }

        private string _wmsSourceLocation;
        /// <summary>
        /// Get or Set for {WMSSourceLocation}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WMSSourceLocation
        {
            get => _wmsSourceLocation;
            set => SetProperty(ref _wmsSourceLocation, value);
        }

        private string _wmsStockLocationId;
        /// <summary>
        /// Get or Set for {WMSStockLocationId}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string WMSStockLocationId
        {
            get => _wmsStockLocationId;
            set => SetProperty(ref _wmsStockLocationId, value);
        }

        private List<Guid> _wmsLocationReportingSectionGuid;
        /// <summary>
        /// Get or Set for {WMSLocationReportingSectionGuid}.
        /// </summary>
        [DataMember]
        public List<Guid> WMSLocationReportingSectionGuid
        {
            get => _wmsLocationReportingSectionGuid;
            set => SetProperty(ref _wmsLocationReportingSectionGuid, value);
        }

        private string _whCODE;
        /// <summary>
        /// Get or Set for {WHCODE}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string WHCODE
        {
            get => _whCODE;
            set => SetProperty(ref _whCODE, value);
        }
    }
}

 
