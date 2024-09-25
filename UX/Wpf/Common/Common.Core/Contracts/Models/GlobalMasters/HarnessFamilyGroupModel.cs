using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class HarnessFamilyGroupModel : BaseModel<Guid>
    {
        private string _harnessFamilyGroupCode;
        [DataMember]
        [Required]
        [StringLength(40)]
        public string HarnessFamilyGroupCode
        {
            get => _harnessFamilyGroupCode;
            set => SetProperty(ref _harnessFamilyGroupCode, value);
        }
        private string _harnessFamilyGroupName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string HarnessFamilyGroupName
        {
            get => _harnessFamilyGroupName;
            set => SetProperty(ref _harnessFamilyGroupName, value);
        }
        private ObservableCollection<HarnessFamilyModel> _HarnessFamilyList = null;
        [DataMember]
        public ObservableCollection<HarnessFamilyModel> HarnessFamilyList
        {
            get => _HarnessFamilyList;
            set => SetProperty(ref _HarnessFamilyList, value);
        }
    }
}
