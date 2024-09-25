using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
    public class NPAProjectDetailsModel : BaseModel<Guid>
    {
        private string _projectCode;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        private string _projectName;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }

        private Guid _subsidiaryGuid;
        [DataMember]
        [Required]
        public Guid SubsidiaryGuid
        {
            get => _subsidiaryGuid;
            set => SetProperty(ref _subsidiaryGuid, value);
        }

        private Guid _purchasingCustomerGuid;
        [DataMember]
        [Required]
        public Guid PurchasingCustomerGuid
        {
            get => _purchasingCustomerGuid;
            set => SetProperty(ref _purchasingCustomerGuid, value);
        }

        private Guid _purchasingVehicleGuid;
        [DataMember]
        [Required]
        public Guid PurchasingVehicleGuid
        {
            get => _purchasingVehicleGuid;
            set => SetProperty(ref _purchasingVehicleGuid, value);
        }

        private Guid _projectManagerGuid;
        [DataMember]
        [Required]
        public Guid ProjectManagerGuid      //It will be filled from H1 User List and user Ad Guid will be saved
        {
            get => _projectManagerGuid;
            set => SetProperty(ref _projectManagerGuid, value);
        }

        private int _vehicleVolume;
        [DataMember]
        [Required]
        public int VehicleVolume
        {
            get => _vehicleVolume;
            set => SetProperty(ref _vehicleVolume, value);
        }

        private DateTime _projectStartDate;
        [DataMember]
        public DateTime ProjectStartDate
        {
            get => _projectStartDate;
            set => SetProperty(ref _projectStartDate, value);
        }

        private DateTime _projectBuildDate1;
        [DataMember]
        public DateTime ProjectBuildDate1
        {
            get => _projectBuildDate1;
            set => SetProperty(ref _projectBuildDate1, value);
        }

        private DateTime _projectBuildDate2;
        [DataMember]
        public DateTime ProjectBuildDate2
        {
            get => _projectBuildDate2;
            set => SetProperty(ref _projectBuildDate2, value);
        }

        private DateTime _projectBuildDate3;
        [DataMember]
        public DateTime ProjectBuildDate3
        {
            get => _projectBuildDate3;
            set => SetProperty(ref _projectBuildDate3, value);
        }

        private DateTime _projectBuildDate4;
        [DataMember]
        public DateTime ProjectBuildDate4
        {
            get => _projectBuildDate4;
            set => SetProperty(ref _projectBuildDate4, value);
        }

        private DateTime _projectBuildDate5;
        [DataMember]
        public DateTime ProjectBuildDate5
        {
            get => _projectBuildDate5;
            set => SetProperty(ref _projectBuildDate5, value);
        }
    }
}
