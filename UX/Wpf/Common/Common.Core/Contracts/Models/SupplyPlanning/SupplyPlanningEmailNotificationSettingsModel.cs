/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyPlanningEmailNotificationSettingsModel.cs
Function           :   Set default email details 
Created By         :   Shivam Dhingra
Created on         :   26-Feb-2020
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
    /// <summary>
    /// Represents a row of Supply Planning Email Settings
    /// </summary>
    [DataContract, Serializable]
    public class SupplyPlanningEmailNotificationSettingsModel : BaseModel<Guid>
    {


        private string _emailType;
        /// <summary>
        /// Gets or sets a string value for the Email Type.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string EmailType
        {
            get => _emailType;
            set => SetProperty(ref _emailType, value);
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
