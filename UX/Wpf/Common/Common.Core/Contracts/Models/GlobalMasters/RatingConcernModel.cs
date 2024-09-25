using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class RatingConcernModel : BaseModel<Guid>
    {
        private string _ratingConcernCode;
        [DataMember]
        [Required]
        [StringLength(1)]
        public string RatingConcernCode
        {
            get => _ratingConcernCode;
            set => SetProperty(ref _ratingConcernCode, value);
        }

        private string _ratingConcernDesc;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string RatingConcernDesc
        {
            get => _ratingConcernDesc;
            set => SetProperty(ref _ratingConcernDesc, value);
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
