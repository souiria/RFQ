using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    public class IndexedMaterialModel : BaseModel<Guid>
    {
        private string _indexedMaterialName;
        [DataMember]
        public string IndexedMaterialName
        {
            get => _indexedMaterialName;
            set => SetProperty(ref _indexedMaterialName, value);
        }

        private string _indexedMaterialElementName;
        [DataMember]
        public string IndexedMaterialElementName
        {
            get => _indexedMaterialElementName;
            set => SetProperty(ref _indexedMaterialElementName, value);
        }

        private decimal _defaultRate;
        [DataMember]
        public decimal DefaultRate
        {
            get => _defaultRate;
            set => SetProperty(ref _defaultRate, value);
        }
    }
}