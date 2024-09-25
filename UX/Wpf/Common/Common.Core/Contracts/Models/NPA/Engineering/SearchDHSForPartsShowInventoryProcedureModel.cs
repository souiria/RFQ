using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
   public class SearchDHSForPartsShowInventoryProcedureModel : BaseModel<Guid>
    {
        private string _material_nm;
        [DataMember]
        public string material_nm
        {
            get => _material_nm;
            set => SetProperty(ref _material_nm, value);
        }
        private string _bom_unit;
        [DataMember]
        public string bom_unit
        {
            get => _bom_unit;
            set => SetProperty(ref _bom_unit, value);
        }
        private int _sum_invt_qty;
        [DataMember]
        public int sum_invt_qty
        {
            get => _sum_invt_qty;
            set => SetProperty(ref _sum_invt_qty, value);
        }
        private int? _sum_recv_qty=0 ;
        [DataMember]
        public int? sum_recv_qty
        {
            get => _sum_recv_qty;
            set => SetProperty(ref _sum_recv_qty, value);
        }
        private int _sum_wip_qty;
        [DataMember]
        public int sum_wip_qty
        {
            get => _sum_wip_qty;
            set => SetProperty(ref _sum_wip_qty, value);
        }
        private int? _sum_po_qty=0;
        [DataMember]
        public int? sum_po_qty
        {
            get => _sum_po_qty;
            set => SetProperty(ref _sum_po_qty, value);
        }
        private string _section_c;
        [DataMember]
        public string section_c
        {
            get => _section_c;
            set => SetProperty(ref _section_c, value);
        }

    }
}
