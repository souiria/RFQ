using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [DataContract, Serializable]
    public class PartGroupConstModel : ExternalDataSourceModel<long>
    {
        private int _id;
        [DataMember, Key]
        public int ID {
            get => _id;
            set => SetProperty(ref _id, value); }
        [DataMember]
        private int _groupNo;
        public int GroupNo
        {
            get => _groupNo;
            set => SetProperty(ref _groupNo, value);
        }
        private int _groupPos;
        [DataMember]
        public int GroupPos
        {
            get => _groupPos;
            set => SetProperty(ref _groupPos, value);
        }
        private string _groupName;
        [DataMember]
        public string GroupName
        {
            get => _groupName;
            set => SetProperty(ref _groupName, value);
        }
        private string _code;
        [DataMember]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }
        private string _description;
        [DataMember]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        public string Display => Code + " : " + Description;
    }
}
