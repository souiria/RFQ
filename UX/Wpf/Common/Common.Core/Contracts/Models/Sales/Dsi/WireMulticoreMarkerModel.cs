using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("WireMulticoreMarker")]
    public class WireMulticoreMarkerModel : BaseModel<Guid>
    {
        private string _itemType;
        [DataMember]
        public string ItemType
        {
            get => _itemType;
            set => SetProperty(ref _itemType, value);
        }

        private string _itemName;
        [DataMember]
        public string ItemName
        {
            get => _itemName;
            set => SetProperty(ref _itemName, value);
        }

        private string _option;
        [DataMember]
        public string Option
        {
            get => _option;
            set => SetProperty(ref _option, value);
        }

        private string _location;
        [DataMember]
        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        private string _text;
        [DataMember]
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _colourCode;
        [DataMember]
        public string ColourCode
        {
            get => _colourCode;
            set => SetProperty(ref _colourCode, value);
        }

        private double _spacing;
        [DataMember]
        public double Spacing
        {
            get => _spacing;
            set => SetProperty(ref _spacing, value);
        }

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }
    }
}
