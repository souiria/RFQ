/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DRPPreCheckReportModel.cs
Function           :   DRP Pre Check Report
Created By         :  Virendra
Created on         :   08-Aug-2022
Revision History   :   
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
    public class DRPPreCheckReportModel
    {
        private int _sNo;
        /// <summary>
        /// SNo
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int SNo
        {
            get => _sNo;
            set => _sNo = value;
        }
        private string _customerName;
        /// <summary>
        /// CustomerName
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }
        private string _partNumber;
        /// <summary>
        /// PartNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }
        private string _mFG_Site;
        /// <summary>
        /// MFG_Site
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string MFG_Site
        {
            get => _mFG_Site;
            set => _mFG_Site = value;
        }

        private string _dCLocation;
        /// <summary>
        /// DCLocation
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string DCLocation
        {
            get => _dCLocation;
            set => _dCLocation = value;
        }
        private string _unbSenderId;
        /// <summary>
        /// UnbSenderId
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string UnbSenderId
        {
            get => _unbSenderId;
            set => _unbSenderId = value;
        }

        private string _remarks;
        /// <summary>
        /// Remarks
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => _remarks = value;
        }
    }
    /// <summary>
    /// Class File for DRPGenerationIssueOrderParameterModel
    /// </summary>
    [DataContract, Serializable]
    public class DRPPreCheckReportParameterModel
    {
        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessHierarchyGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => _customerBusinessHierarchyGuid = value;
        }
    }
}
