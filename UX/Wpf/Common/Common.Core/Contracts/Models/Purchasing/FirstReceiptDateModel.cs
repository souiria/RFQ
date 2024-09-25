/*******************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FirstReceiptDateModel.cs
Function           :   FirstReceiptDateModel
Created By         :   
Created on         :   
Revision History   :   [08-May-2020] : Srashti Gupta
                   :   Added PurchasingSupplierMaterialHierarchyGuid & commented SupplierMaterialAssociationGuid property in FirstReceiptDateModel
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class FirstReceiptDateModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        //private Guid _supplierMaterialAssociationGuid;
        //[DataMember]
        //[Required]
        //public Guid SupplierMaterialAssociationGuid
        //{
        //    get => _supplierMaterialAssociationGuid;
        //    set => SetProperty(ref _supplierMaterialAssociationGuid, value);
        //}

        private string _poNumber;
        [DataMember]
        [StringLength(10)]
        public string PONumber
        {
            get => _poNumber;
            set => SetProperty(ref _poNumber, value);
        }

        private decimal _poPrice;
        [DataMember]
        [DecimalPrecision(13, 5)]
        public decimal POPrice
        {
            get => _poPrice;
            set => SetProperty(ref _poPrice, value);
        }

        private int _receivedQuantity;
        [DataMember]
        public int ReceivedQuantity
        {
            get => _receivedQuantity;
            set => SetProperty(ref _receivedQuantity, value);
        }

        private Guid _unitOfMeasureGuid;
        [DataMember]
        public Guid UnitOfMeasureGuid
        {
            get => _unitOfMeasureGuid;
            set => SetProperty(ref _unitOfMeasureGuid, value);
        }

        private DateTime _receiptDate;
        [DataMember]
        public DateTime ReceiptDate
        {
            get => _receiptDate;
            set => SetProperty(ref _receiptDate, value);
        }

        private string _transferFlag;
        [DataMember]
        [StringLength(1)]
        public string TransferFlag
        {
            get => _transferFlag;
            set => SetProperty(ref _transferFlag, value);
        }

        private Guid _purchasingSupplierMaterialHierarchyGuid;
        [DataMember]
        [Required]
        public Guid PurchasingSupplierMaterialHierarchyGuid
        {
            get => _purchasingSupplierMaterialHierarchyGuid;
            set => SetProperty(ref _purchasingSupplierMaterialHierarchyGuid, value);
        }
    }
    [DataContract, Serializable]
    public class CPDFirstReceiptModel : ExternalDataSourceModel<object>
    {

        private string _section_c;
        [DataMember]
        public string section_c
        {
            get => _section_c;
            set => SetProperty(ref _section_c, value);
        }
        private string _material_no;
        [DataMember]
        public string material_no
        {
            get => _material_no;
            set => SetProperty(ref _material_no, value);
        }
        private string _supp_mat_no;
        [DataMember]
        public string supp_mat_no
        {
            get => _supp_mat_no;
            set => SetProperty(ref _supp_mat_no, value);
        }

        private string _supplier_c;
        [DataMember]
        public string supplier_c
        {
            get => _supplier_c;
            set => SetProperty(ref _supplier_c, value);
        }

        private string _po_no;
        [DataMember]
        public string po_no
        {
            get => _po_no;
            set => SetProperty(ref _po_no, value);
        }
        private decimal _po_price;
        [DataMember]
        public decimal po_price
        {
            get => _po_price;
            set => SetProperty(ref _po_price, value);
        }
        private string _curr_c;
        [DataMember]
        public string curr_c
        {
            get => _curr_c;
            set => SetProperty(ref _curr_c, value);
        }
        private int _recv_qty;
        [DataMember]
        public int recv_qty
        {
            get => _recv_qty;
            set => SetProperty(ref _recv_qty, value);
        }

        private string _po_unit;
        [DataMember]
        public string po_unit
        {
            get => _po_unit;
            set => SetProperty(ref _po_unit, value);
        }

        private DateTime _recv_ent_dt;
        [DataMember]
        public DateTime recv_ent_dt
        {
            get => _recv_ent_dt;
            set => SetProperty(ref _recv_ent_dt, value);
        }

        private string _userid;
        [DataMember]
        public string userid
        {
            get => _userid;
            set => SetProperty(ref _userid, value);
        }
        private string _transfer_flg;
        [DataMember]
        public string transfer_flg
        {
            get => _transfer_flg;
            set => SetProperty(ref _transfer_flg, value);
        }
        private DateTime _ent_dt;
        [DataMember]
        public DateTime ent_dt
        {
            get => _ent_dt;
            set => SetProperty(ref _ent_dt, value);
        }
        //Add by Dharmendra Kumar on 05-Mar-2019
        private DateTime _upd_dt;
        [DataMember]
        public DateTime upd_dt
        {
            get => _upd_dt;
            set => SetProperty(ref _upd_dt, value);
        }
    }
}
