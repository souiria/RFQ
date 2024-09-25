/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   RFQEmailSettingsModel.cs
Function           :   Set default email details 
Created By         :   Param
Created on         :   12-Jun-2019
Revision History   :   [14-Jun-2019] : Pawan
                   :   [] : Added RFQ Status Guid to save different stages of email
                      
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of Supplier Email Settings
    /// </summary>
    [DataContract, Serializable]
    public class RFQEmailSettingsModel : BaseModel<Guid>
    {
        private Guid _rfqStatusGuid;
        /// <summary>
        /// Gets or sets GUID value for the RFQ Status.
        /// </summary>
        [DataMember]
        [Required]
        public Guid RFQStatusGuid
        {
            get => _rfqStatusGuid;
            set => SetProperty(ref _rfqStatusGuid, value);
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
    }

}