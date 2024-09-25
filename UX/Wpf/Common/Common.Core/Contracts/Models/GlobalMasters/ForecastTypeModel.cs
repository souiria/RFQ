using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class ForecastTypeModel : BaseModel<Guid>
    {
        private bool? _isRowChecked=false;
        [NotMapped, DataMember]
        public bool? IsRowChecked
        {
            get => _isRowChecked;
            set => SetProperty(ref _isRowChecked, value);
        }

        private string _forecastType;
        [DataMember]
        [StringLength(1)]
        public string ForecastType
        {
            get => _forecastType;
            set => SetProperty(ref _forecastType, value);
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
