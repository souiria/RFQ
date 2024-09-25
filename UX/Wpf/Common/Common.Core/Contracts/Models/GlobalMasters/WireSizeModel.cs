/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WireSizeModel.cs
Function           :   Wire Size Model
Created By         :   Pawan
Created on         :   27-Nov-2019
Revision History   :   [] Nitin   
                   :   [11-Dec-2019] Renamed Cable to Wire
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of Wire Size data.
    /// </summary>
    [DataContract, Serializable]
    public class WireSizeModel : BaseModel<Guid>
    {
        private string _wireSize;
        /// <summary>
        /// Gets or sets a string value for the Global Wire Size column.
        /// </summary>
        [DataMember]
        [StringLength(6)]
        [Required]
        public string WireSize
        {
            get => _wireSize;
            set => SetProperty(ref _wireSize, value);
        }

        
        private string _wireSizeDescription;
        /// <summary>
        ///  Gets or sets a string value for the Global Wire Size Description column.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WireSizeDescription
        {
            get => _wireSizeDescription;
            set => SetProperty(ref _wireSizeDescription, value);
        }
    }
}