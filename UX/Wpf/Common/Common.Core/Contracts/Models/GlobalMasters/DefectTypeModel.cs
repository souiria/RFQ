using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class DefectTypeModel : BaseModel<Guid>
    {
       
        private string _defectTypeCode;
        [DataMember]
        [Required]
        [StringLength(40)]
        public string DefectTypeCode
        {
            get => _defectTypeCode;
            set => SetProperty(ref _defectTypeCode, value);
        }

        private string _defectTypeDescription = null;
        [DataMember]
        [StringLength(50)]
        public string DefectTypeDescription
        {
            get => _defectTypeDescription;
            set => SetProperty(ref _defectTypeDescription, value);
        }
        private List<string> _imagesPath = null;
        [DataMember]
        [StringLength(500)]
        public List<string> ImagesPathList
        {
            get => _imagesPath;
            set => SetProperty(ref _imagesPath, value);
        }
    }
}
