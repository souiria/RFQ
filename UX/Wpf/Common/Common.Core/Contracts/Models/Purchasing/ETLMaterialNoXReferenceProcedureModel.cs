using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLMaterialNoXReferenceProcedureModel: ExternalDataSourceModel<object>
    {
        private string _supplierCode;
        [DataMember]
        public string SUPPLIER_C
        {
            get { return _supplierCode; }
            set {  _supplierCode= value; }
        }
        private string _materialNumber;
        [DataMember]
        public string MATERIAL_NO
        {
            get { return _materialNumber; }
            set {_materialNumber= value; }
        }
        private string _supplierMaterialNumber;
        [DataMember]

        public string SUPP_MAT_NO
        {
            get => _supplierMaterialNumber;
            set => _supplierMaterialNumber=value;
        }

        private string _materialName;
        [DataMember]

        public string MATERIAL_NM
        {
            get => _materialName;
            set => _materialName= value;
        }

        private decimal _poPrice;
        [DataMember]

        public decimal PO_PRICE
        {
            get => _poPrice;
            set => _poPrice=value;
        }
        private int _minimumOrderQuantity;
        [DataMember]
        public int PO_MINORD_QTY
        {
            get => _minimumOrderQuantity;
            set => _minimumOrderQuantity=value;
        }

        private string _poUnit;
        [DataMember]
        public string PO_UNIT
        {
            get => _poUnit;
            set => _poUnit=value;
        }
        private string _bomUnit;
        [DataMember]
        public string BOM_UNIT
        {
            get => _bomUnit;
            set => _bomUnit= value;
        }

        private int _conversionFactor;
        [DataMember]

        public int UNIT_CONFAC_PO
        {
            get => _conversionFactor;
            set =>_conversionFactor=value;
        }
        private string _currencyCode;
        [DataMember]
        public string CURR_C
        {
            get => _currencyCode;
            set => _currencyCode= value;
        }

        private decimal _exchangeRate;
        [DataMember]
        public decimal EXCH_RATE
        {
            get => _exchangeRate;
            set => _exchangeRate= value;
        }
        private byte _rowmode = 0;
        [DataMember]
        public byte ROWMODE
        {
            get => _rowmode;
            set => _rowmode= value;
        }
        private byte _po_Ratio = 0;
        [DataMember]
        public byte PO_RATIO
        {
            get => _po_Ratio;
            set => _po_Ratio = value;
        }
    }


}
