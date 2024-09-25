using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    /// <summary>
    /// Represents a row of SourceApplication data.
    /// </summary>
    [DataContract, Serializable]
    public class SourceApplicationModel : BaseModel<Guid>
    {
        /// <summary>
        /// Gets or sets a string value for the Global SourceApplicationName column.
        /// </summary>
        private string _sourceApplicationName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SourceApplicationName
        {
            get => _sourceApplicationName;
            set => SetProperty(ref _sourceApplicationName, value);
        }

        /// <summary>
        /// Gets or sets a string value for the Global SourceSystemDescription column.
        /// </summary>
        private string _sourceApplicationDescription;
        [DataMember]
        [StringLength(100)]
        public string SourceApplicationDescription
        {
            get => _sourceApplicationDescription;
            set => SetProperty(ref _sourceApplicationDescription, value);
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