using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    public class RFQPartSearchProcedureModel : ExternalDataSourceModel<Guid>
    {
        public RFQPartSearchProcedureModel()
        {
            Id = Guid.NewGuid();
        }

        private bool _isSelected;
        [DataMember, NotMapped]
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
        [DataMember, Column(TypeName = "varchar")]
        public string MatchedPart { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string SumitomoNumber { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string Customer { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string CustomerNumber { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string Supplier { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string SupplierNumber { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string Currency { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string Price { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string UnitOfMeasure { get; set; }
        [DataMember, Column(TypeName = "varchar")]
        public string NPAReferenceNumber { get; set; }
        [DataMember, Column(TypeName = "datetime")]
        public DateTime? NPARaisedDate { get; set; }
        [DataMember, Column(TypeName = "bit")]
        public bool IsCPDPrice { get; set; }
    }
}
