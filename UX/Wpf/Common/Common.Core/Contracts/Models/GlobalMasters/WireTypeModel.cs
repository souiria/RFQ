/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WireTypeModel.cs
Function           :   Wire Type Model
Created By         :   Pawan
Created on         :   27-Nov-2019
Revision History   :   [] Nitin
                   :   [] Renamed Cable to Wire  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of Wire Type data.
    /// </summary>
    [DataContract, Serializable]
    public class WireTypeModel : BaseModel<Guid>
    {
        private string _wireTypeCode;
        /// <summary>
        /// Gets or sets a string value for the Global Wire Type column.
        /// </summary>
        [DataMember]
        [StringLength(5)]
        [Required]
        public string WireTypeCode
        {
            get => _wireTypeCode;
            set => SetProperty(ref _wireTypeCode, value);
        }

        
        private string _wireTypeDescription;
        /// <summary>
        ///  Gets or sets a string value for the Global Wire Type Description column.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WireTypeDescription
        {
            get => _wireTypeDescription;
            set => SetProperty(ref _wireTypeDescription, value);
        }
    }
}