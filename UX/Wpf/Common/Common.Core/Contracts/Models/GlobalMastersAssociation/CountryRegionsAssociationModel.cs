using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class CountryRegionsAssociationModel : BaseModel<Guid>
    {
        private Guid _countryGuid;
        [DataMember]
        [Required]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }

        private Guid _countryRegionsGuid;
        [DataMember]
        [Required]
        public Guid CountryRegionsGuid
        {
            get => _countryRegionsGuid;
            set => SetProperty(ref _countryRegionsGuid, value);
        }

        private Guid _originStatusGuid;
        [DataMember]
        [Required]
        public Guid OriginStatusGuid
        {
            get => _originStatusGuid;
            set => SetProperty(ref _originStatusGuid, value);
        }
    }
}
