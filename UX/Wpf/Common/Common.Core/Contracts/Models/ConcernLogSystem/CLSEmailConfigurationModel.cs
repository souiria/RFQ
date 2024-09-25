/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CLSEmailConfigurationModel.cs
Function           :   Set default email details 
Created By         :   Piyush Anand
Created on         :   05-Jan-2024
Revision History   :  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of CLS Email Configuration
    /// </summary>
    [DataContract, Serializable]
    public class CLSEmailConfigurationModel : BaseModel<Guid>
    {
        private Guid _cLSStatusGuid;
        /// <summary>
        /// Gets or sets GUID value for the CLS Status.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CLSStatusGuid
        {
            get => _cLSStatusGuid;
            set => SetProperty(ref _cLSStatusGuid, value);
        }

        private string _emailSubject;
        /// <summary>
        /// Gets or sets a string value for the Email Subject.
        /// </summary>
        [DataMember]
        [StringLength(150)]
        [Required]
        public string EmailSubject
        {
            get => _emailSubject;
            set => SetProperty(ref _emailSubject, value);
        }


        private string _emailBodyDetails;
        /// <summary>
        /// Gets or sets a string value for the Reason Description column.
        /// </summary>
        [DataMember]
        [StringLength(8000)]
        [Required]
        public string EmailBodyDetails
        {
            get => _emailBodyDetails;
            set => SetProperty(ref _emailBodyDetails, value);
        }


        private string _emailFooter;
        /// <summary>
        /// Gets or sets a string value for the Email Footer column.
        /// </summary>
        [DataMember]
        [StringLength(3000)]
        [Required]
        public string EmailFooter
        {
            get => _emailFooter;
            set => SetProperty(ref _emailFooter, value);
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }

}