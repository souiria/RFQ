using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("HarnessScope")]
    public class HarnessScopeModel : BaseModel<Guid>
    {
        private string _harnessName1;
        [DataMember]
        public string HarnessName1
        {
            get => _harnessName1;
            set => SetProperty(ref _harnessName1, value);
        }

        private string _harnessIssue1;
        [DataMember]
        public string HarnessIssue1
        {
            get => _harnessIssue1;
            set => SetProperty(ref _harnessIssue1, value);
        }

        private string _harnessName2;
        [DataMember]
        public string HarnessName2
        {
            get => _harnessName2;
            set => SetProperty(ref _harnessName2, value);
        }

        private string _harnessIssue2;
        [DataMember]
        public string HarnessIssue2
        {
            get => _harnessIssue2;
            set => SetProperty(ref _harnessIssue2, value);
        }

        private string _scopeCategory;
        [DataMember]
        public string ScopeCategory
        {
            get => _scopeCategory;
            set => SetProperty(ref _scopeCategory, value);
        }

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }

        private string _scope;
        [DataMember, NotMapped]
        public string Scope
        {
            get => _scope;
            set => SetProperty(ref _scope, value);
        }
    }
}
