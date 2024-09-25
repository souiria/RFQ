/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FunctionControlSequenceGeneratorModel.cs
Function           :   Generation of Sequence Number on the basis of function name
Created By         :   Nitin Sagar
Created on         :   26-Jun-2019
Revision History   :   [] : 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.NPR;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.RFQManagement
{
    [DataContract, Serializable]
    public class FunctionControlSequenceGeneratorModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference of {FunctionName} property
        /// </summary>
        private string _functionName;

        /// <summary>
        /// Gets or Sets the value of {FunctionName}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string FunctionName
        {
            get => _functionName;
            set => SetProperty(ref _functionName, value);
        }

        /// <summary>
        /// Local Reference of {FunctionCode} property
        /// </summary>
        private string _functionCode;

        /// <summary>
        /// Gets or Sets the value of {FunctionCode}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(2)]
        public string FunctionCode
        {
            get => _functionCode;
            set => SetProperty(ref _functionCode, value);
        }


        /// <summary>
        /// Local Reference of {Prefix} property
        /// </summary>
        private string _prefix;

        /// <summary>
        /// Gets or Sets the value of {Prefix}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(5)]
        public string Prefix
        {
            get => _prefix;
            set => SetProperty(ref _prefix, value);
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

        /// <summary>
        /// Local Reference of {SequenceNumber} property
        /// </summary>
        private string _sequenceNumber;

        /// <summary>
        /// Gets or Sets the value of {SequenceNumber}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(15)]
        public string SequenceNumber
        {
            get => _sequenceNumber;
            set => SetProperty(ref _sequenceNumber, value);
        }

        ///// <summary>
        ///// Local Reference of {FunctionControlSequence} property
        ///// </summary>
        //private string _functionControlSequence;

        ///// <summary>
        ///// Gets or Sets the value of {FunctionControlSequence}
        ///// </summary>
        //[DataMember]
        //[Required]
        //[StringLength(15)]
        //public string FunctionControlSequence
        //{
        //    get => _functionControlSequence;
        //    set => SetProperty(ref _functionControlSequence, value);
        //}
    }
}
