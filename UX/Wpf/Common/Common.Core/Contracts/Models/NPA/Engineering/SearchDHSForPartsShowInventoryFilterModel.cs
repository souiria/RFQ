using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
   public class SearchDHSForPartsShowInventoryFilterModel : BaseModel<Guid>
    {
        private string _sectionCode;
        [DataMember]
        public string SectionCode
        {
            get => _sectionCode;
            set => SetProperty(ref _sectionCode, value);
        }
        private string _sws_no;
        [DataMember]
        public string Sws_No
        {
            get => _sws_no;
            set => SetProperty(ref _sws_no, value);
        }
    }
}
