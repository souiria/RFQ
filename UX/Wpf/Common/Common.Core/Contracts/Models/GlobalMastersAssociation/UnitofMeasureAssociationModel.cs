using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of UnitOfMeasureAssociation data.
    /// </summary>
    [DataContract, Serializable]
    public class UnitOfMeasureAssociationModel : BaseModel<Guid>
    {
        /// <summary>
        /// Gets or sets a Guid value for the SourceSystemGuid column.
        /// </summary>
        private Guid _sourceApplicationGuid;
        [DataMember]
        [Required]
        public Guid SourceApplicationGuid
        {
            get => _sourceApplicationGuid;
            set => SetProperty(ref _sourceApplicationGuid, value);
        }

        /// <summary>
        /// Gets or sets a Guid value for the ISOUnitOfMeasureGuid column.
        /// </summary>
        private Guid _iSOUnitOfMeasureGuid;
        [DataMember]
        [Required]
        public Guid ISOUnitOfMeasureGuid
        {
            get => _iSOUnitOfMeasureGuid;
            set => SetProperty(ref _iSOUnitOfMeasureGuid, value);
        }
        /// <summary>
        /// Gets or sets a value for the SourceUnitOfMeasureCode column.
        /// </summary>
        private string _sourceUnitOfMeasureCode;
        [DataMember]
        [Required][StringLength(20)]
        public string SourceUnitOfMeasureCode
        {
            get => _sourceUnitOfMeasureCode;
            set => SetProperty(ref _sourceUnitOfMeasureCode, value);
        }
    }
}