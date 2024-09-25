using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
   public class SearchDHSForPartsFilterModel: BaseModel<Guid>
    {
        private string _searchPartno;
        [DataMember]
        public string SearchPartno
        {
            get => _searchPartno;
            set => SetProperty(ref _searchPartno, value);
        }
        private string _flag;
        [DataMember]
        public string Flag
        {
            get => _flag;
            set => SetProperty(ref _flag, value);
        }

        private long _subsidiary_id;
        [DataMember]
        public long Subsidiary_id
        {
            get => _subsidiary_id;
            set => SetProperty(ref _subsidiary_id, value);
        }
    }
    public class SearchDHSForPartsProcedureModel : BaseModel<Guid>
    {
        private string _supplier_c;
        [DataMember]
        public string Supplier_c
        {
            get => _supplier_c;
            set => SetProperty(ref _supplier_c, value);
        }

        private int _po_ratio;
        [DataMember]
        public int Po_ratio
        {
            get => _po_ratio;
            set => SetProperty(ref _po_ratio, value);
        }

        private string _material_no;
        [DataMember]
        public string Material_no
        {
            get => _material_no;
            set => SetProperty(ref _material_no, value);
        }

        private string _supp_mat_no;
        [DataMember]
        public string Supp_mat_no
        {
            get => _supp_mat_no;
            set => SetProperty(ref _supp_mat_no, value);
        }
        private int _po_minord_qty;
        [DataMember]
        public int Po_minord_qty
        {
            get => _po_minord_qty;
            set => SetProperty(ref _po_minord_qty, value);
        }
        private string _po_unit;
        [DataMember]
        public string Po_unit
        {
            get => _po_unit;
            set => SetProperty(ref _po_unit, value);
        }
        private decimal _po_price;
        [DataMember]
        public decimal Po_price
        {
            get => _po_price;
            set => SetProperty(ref _po_price, value);
        }
        private string _curr_c;
        [DataMember]
        public string Curr_c
        {
            get => _curr_c;
            set => SetProperty(ref _curr_c, value);
        }
        private decimal _copper_wt;
        [DataMember]
        public decimal Copper_wt
        {
            get => _copper_wt;
            set => SetProperty(ref _copper_wt, value);
        }
    }
    public class SearchDHSForPartsSectionCodeProcedureModel : BaseModel<Guid>
    {
        private string _section_c;
        [DataMember]
        public string Section_c
        {
            get => _section_c;
            set => SetProperty(ref _section_c, value);
        }
        private string _section_material_id;
        [DataMember]
        public string SectionMaterial_Id
        {
            get => _section_material_id;
            set => SetProperty(ref _section_material_id, value);
        }
    }
}
