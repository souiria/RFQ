/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SiteSequenceTypeModel.cs
Function           :   Manages data for Generation of Sequence Number 
Created By         :   Dharmendra 
Created on         :   18-Mar-2022
Revision History   :   [] : 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    [DataContract, Serializable]
    public class SiteSequenceTypeModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference of {_siteGuid} property
        /// </summary>
        private Guid _siteGuid;

        /// <summary>
        /// Gets or Sets the value of {SiteGuid}
        /// </summary>
        [DataMember]
        [Required]
        public Guid SiteGuid
        {
            get => _siteGuid;
            set => SetProperty(ref _siteGuid, value);
        }

        /// <summary>
        /// Local Reference of {_yearEndAutoReset} property
        /// </summary>
        private bool _yearEndAutoReset;

        /// <summary>
        /// Gets or Sets the value of {YearEndAutoReset}
        /// </summary>
        [DataMember]
        [Required]
        public bool YearEndAutoReset
        {
            get => _yearEndAutoReset;
            set => SetProperty(ref _yearEndAutoReset, value);
        }
        /// <summary>
        /// Local Reference of {_seriesSiteSpecific} property
        /// </summary>
        private bool _seriesSiteSpecific;

        /// <summary>
        /// Gets or Sets the value of {SeriesSiteSpecific}
        /// </summary>
        [DataMember]
        [Required]
        public bool SeriesSiteSpecific
        {
            get => _seriesSiteSpecific;
            set => SetProperty(ref _seriesSiteSpecific, value);
        }
        /// <summary>
        /// Local Reference of {_standardSequencePattern} property
        /// </summary>
        private bool _standardSequencePattern;

        /// <summary>
        /// Gets or Sets the value of {StandardSequencePattern}
        /// </summary>
        [DataMember]
        [Required]
        public bool StandardSequencePattern
        {
            get => _standardSequencePattern;
            set => SetProperty(ref _standardSequencePattern, value);
        }

        /// <summary>
        /// Local Reference of {_prefix} property
        /// </summary>
        private bool _prefix;

        /// <summary>
        /// Gets or Sets the value of {Prefix}
        /// </summary>
        [DataMember]
        [Required]
        public bool Prefix
        {
            get => _prefix;
            set => SetProperty(ref _prefix, value);
        }

        private string _sequenceNumber;

        /// <summary>
        /// Gets or Sets the value of {SequenceNumber}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(4)]
        public string SequenceNumber
        {
            get => _sequenceNumber;
            set => SetProperty(ref _sequenceNumber, value);
        }


        /// <summary>
        /// Local Reference of {_prefixPosition} property
        /// </summary>
        private Int16 _prefixPosition;

        /// <summary>
        /// Gets or Sets the value of {PrefixPosition}
        /// </summary>
        [DataMember]
        [Required]

        public Int16 PrefixPosition
        {
            get => _prefixPosition;
            set => SetProperty(ref _prefixPosition, value);
        }

        /// <summary>
        /// Local Reference of {_prefixLength} property
        /// </summary>
        private Int16 _prefixLength;

        /// <summary>
        /// Gets or Sets the value of {PrefixPrefix}
        /// </summary>
        [DataMember]
        [Required]

        public Int16 PrefixLength
        {
            get => _prefixLength;
            set => SetProperty(ref _prefixLength, value);
        }

        /// <summary>
        /// Local Reference of {LastSequenceNumber} property
        /// </summary>
        private string _lastSequenceNumber;

        /// <summary>
        /// Gets or Sets the value of {LastSequenceNumber}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(20)]
        public string LastSequenceNumber
        {
            get => _lastSequenceNumber;
            set => SetProperty(ref _lastSequenceNumber, value);
        }

    }
}
