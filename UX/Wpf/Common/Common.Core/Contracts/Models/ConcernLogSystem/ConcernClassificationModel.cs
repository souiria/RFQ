/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  ConcernClassification.cs
Function           :  Concern Classification Model
Created By         :  Prakhar
Created on         :  06-Oct-2023
Revision History   :  []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    public class ConcernClassificationModel : BaseModel<Guid>
    {

        private string _concernType;
        /// <summary>
        /// Get or Set for {ConcernType}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]

        public string ConcernType
        {
            get => _concernType;
            set => SetProperty(ref _concernType, value);
        }

        private string _rating;
        /// <summary>
        /// Get or Set for {Rating}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]

        public string Rating
        {
            get => _rating;
            set => SetProperty(ref _rating, value);
        }

        private int _deadline;
        /// <summary>
        /// Get or Set for {Deadline}.
        /// </summary>
        [DataMember]
        [Required]
        
        public int Deadline
        {
            get => _deadline;
            set => SetProperty(ref _deadline, value);
        }

        private int _deadline2;
        /// <summary>
        /// Get or Set for {Deadline}.
        /// </summary>
        [DataMember]
        [Required]

        public int Deadline2
        {
            get => _deadline2;
            set => SetProperty(ref _deadline2, value);
        }

        private int _deadline3;
        /// <summary>
        /// Get or Set for {Deadline}.
        /// </summary>
        [DataMember]
        [Required]

        public int Deadline3
        {
            get => _deadline3;
            set => SetProperty(ref _deadline3, value);
        }

        private String _reminder;
        /// <summary>
        /// Get or Set for {Reminder}.
        /// </summary>
        [DataMember]
        [Required]

        public String Reminder
        {
            get => _reminder;
            set => SetProperty(ref _reminder, value);
        }

        private bool _isActive = true;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
