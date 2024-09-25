/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  TransportMethodMasterModel.cs
Function           :  Model for Transport Site Master Model
Created By         :  Nishu Kumari
Created on         :  10-Apr-2024
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    [DataContract, Serializable]
    public class TransportMethodMasterModel : BaseModel<Guid>
    {
        private string _transportMethod;
        /// <summary>
        /// Get or Set for {TransportMethod}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string TransportMethod
        {
            get => _transportMethod;
            set => SetProperty(ref _transportMethod, value);
        }
        private string _tMSTransport;
        /// <summary>
        /// Get or Set for {TMSTransport}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string TMSTransport
        {
            get => _tMSTransport;
            set => SetProperty(ref _tMSTransport, value);
        }
        private bool _isActive = true;
        /// <summary>
        /// Get or Set for {IsActive}.
        /// </summary>
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
