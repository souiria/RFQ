using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    ///  Represents a row of TariffCodeCountryAssociation data.
    /// </summary>
    [DataContract, Serializable]
   public class TariffCodeCountryAssociationModel: BaseModel<Guid>
    {
        /// <summary>
        /// Gets or sets a Guid value for the TariffCodeGuid column.
        /// </summary>
        private Guid _tariffCodeGuid;
        [DataMember]
        [Required]
        public Guid TariffCodeGuid
        {
            get => _tariffCodeGuid;
            set => SetProperty(ref _tariffCodeGuid, value);
        }
        /// <summary>
        ///  /// Gets or sets a Guid value for the CountryGuid column.
        /// </summary>
        private Guid _countryGuid;
        [DataMember]
        [Required]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }
    }
}
