/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WireColourModel.cs
Function           :   Wire Colour Model
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
    /// Represents a row of Wire Colour data.
    /// </summary>
    [DataContract, Serializable]
    public class WireColourModel : BaseModel<Guid>
    {
        private string _wireColourCode;
        /// <summary>
        /// Gets or sets a string value for the Global Wire Colour Code column.
        /// </summary>
        [DataMember]
        [StringLength(5)]
        [Required]
        public string WireColourCode
        {
            get => _wireColourCode;
            set => SetProperty(ref _wireColourCode, value);
        }

        
        private string _wireColourDescription;
        /// <summary>
        ///  Gets or sets a string value for the Global Wire Colour Description column.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WireColourDescription
        {
            get => _wireColourDescription;
            set => SetProperty(ref _wireColourDescription, value);
        }
    }
}