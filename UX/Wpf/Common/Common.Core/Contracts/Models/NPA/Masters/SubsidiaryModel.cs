using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Masters
{
    [DataContract,Serializable]
    public class SubsidiaryModel: BaseModel<Guid>
    {
        private Guid _purchasingOrganisationGuid;
        [DataMember]
        [Required]
        public Guid PurchasingOrganisationGuid
        {
            get { return _purchasingOrganisationGuid; }
            set { _purchasingOrganisationGuid = value; }
        }

        private string _subsidiaryName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SubsidiaryName
        {
            get { return _subsidiaryName; }
            set { _subsidiaryName = value; }
        }

        private string _subsidiaryDescription;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SubsidiaryDescription
        {
            get { return _subsidiaryDescription; }
            set { _subsidiaryDescription = value; }
        }

        private string _npaPrefix;
        [DataMember]
        [Required]
        [StringLength(10)]
        public string NPAPrefix
        {
            get { return _npaPrefix; }
            set { _npaPrefix = value; }
        }

        private Guid _h1ConfigurationSettingGuid;
        [DataMember]
        [Required]
        public Guid H1ConfigurationSettingGuid
        {
            get { return _h1ConfigurationSettingGuid; }
            set { _h1ConfigurationSettingGuid = value; }
        }

        private bool _uploadData;
        [DataMember]
        public bool UploadData
        {
            get { return _uploadData; }
            set { _uploadData = value; }
        }
    
    }
}
