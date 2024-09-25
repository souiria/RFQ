/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NPRStageChangeLogModel.cs
Function           :   NPR Stage Change Log
Created By         :   Amit
Created on         :   11-Sep-2019
Revision History   :   [] : Nitin Sagar     
                   :   [18-09-2019]: New Fields Added w.r.t track changes in NPR stage  
                   :   [28-Nov-2019] : Pawan     
                   :   []: Removed Required fields attribute from Stage Description
                   :   [16-Jan-2020] : Amit
                   :   [] : Changed length of ManufacturerGroup to 50 character
                   :   [11-May-2020] : Pawan
                   :   [] : Added field for NPRId
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Logging
{
    /// <summary>
    /// NPR Stages need to log on storage
    /// </summary>
    [DataContract, Serializable]
    public class NPRStageChangeLogModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference of RequestID
        /// </summary>
        private string _requestID;
        /// <summary>
        /// Get or Sets the value of indicating {RequestID} of NPR, exp: NPR0000001 for New Part Request, PUR0000001 for Price Update Request
        /// </summary>
        [DataMember]
        [StringLength(18)]
        [Required]
        public string RequestID
        {
            get => _requestID;
            set => SetProperty(ref _requestID, value);
        }
        /// <summary>
        /// Local reference of OriginatorName
        /// </summary>
        private string _originatorName;
        /// <summary>
        /// Gets of Sets the value of indicating {Originator} of NPR
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string OriginatorName
        {
            get => _originatorName;
            set => SetProperty(ref _originatorName, value);
        }

        /// <summary>
        /// Old NPR Stage before change
        /// </summary>
        private string _oldNPRStage;
        /// <summary>
        /// Gets or sets a string value for the Old NPR Stage.
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string OldNPRStage
        {
            get => _oldNPRStage;
            set => SetProperty(ref _oldNPRStage, value);
        }

        /// <summary>
        /// New NPR Stage after change
        /// </summary>
        private string _newNPRStage;
        /// <summary>
        /// Gets or sets a string value for the New NPR.
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string NewNPRStage
        {
            get => _newNPRStage;
            set => SetProperty(ref _newNPRStage, value);
        }

        /// <summary>
        /// Local Reference of Remarks
        /// </summary>
        private string _remarks;
        /// <summary>
        /// Gets or sets a string value for the Remarks.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }
        /// <summary>
        /// Local reference of OldNPRStageDescription
        /// </summary>
        private string _oldNPRStageDescription;
        /// <summary>
        /// Gets of Sets the value of OldNPRStageDescription
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string OldNPRStageDescription
        {
            get => _oldNPRStageDescription;
            set => SetProperty(ref _oldNPRStageDescription, value);
        }
        /// <summary>
        /// Local reference of NewNPRStageDescription
        /// </summary>
        private string _newNPRStageDescription;
        /// <summary>
        /// Gets of Sets the value of NewNPRStageDescription 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string NewNPRStageDescription
        {
            get => _newNPRStageDescription;
            set => SetProperty(ref _newNPRStageDescription, value);
        }
        /// <summary>
        /// Local reference of ManufacturerGroup property
        /// </summary>
        private string _manufacturerGroup;
        /// <summary>
        /// Gets of Sets the value of indicating {ManufacturerGroup} supplier group of NPR , ex : ACAPLAST , SEI
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string ManufacturerGroup
        {
            get => _manufacturerGroup;
            set => SetProperty(ref _manufacturerGroup, value);
        }

        /// <summary>
        /// Local reference of NPRId property
        /// </summary>
        private Guid _nprId;
        /// <summary>
        /// Gets of Sets the value of indicating {NPRId} 
        /// </summary>
        [DataMember]
        public Guid NPRId
        {
            get => _nprId;
            set => SetProperty(ref _nprId, value);
        }
    }
}