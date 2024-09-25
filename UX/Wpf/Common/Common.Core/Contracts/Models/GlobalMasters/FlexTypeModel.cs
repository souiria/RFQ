/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FlexTypeModel.cs
Function           :   Flex Type Model
Created By         :   Pawan
Created on         :   27-Nov-2019
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of Flex Type data.
    /// </summary>
    [DataContract, Serializable]
    public class FlexTypeModel : BaseModel<Guid>
    {
        private string _flexTypeCode;
        /// <summary>
        /// Gets or sets a string value for the Global Flex Type column.
        /// </summary>
        [DataMember]
        [StringLength(1)]
        [Required]
        public string FlexTypeCode
        {
            get => _flexTypeCode;
            set => SetProperty(ref _flexTypeCode, value);
        }

        
        private string _flexTypeDescription;
        /// <summary>
        ///  Gets or sets a string value for the Global Flex Type Description column.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string FlexTypeDescription
        {
            get => _flexTypeDescription;
            set => SetProperty(ref _flexTypeDescription, value);
        }
    }
}