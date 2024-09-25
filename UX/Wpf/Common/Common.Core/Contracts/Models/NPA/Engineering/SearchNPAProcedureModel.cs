using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
    public class SearchNPAProcedureModel : ExternalDataSourceModel<object>
    {
        private Int64 _id;
        [DataMember]
        public new Int64 Id
        {
            get => _id;
            set => _id = value;
        }

        private string _facility_nm;
        [DataMember]
        public string facility_nm   
        {
            get => _facility_nm;
            set => SetProperty(ref _facility_nm, value);
        }

        private string _ref_no;
        [DataMember]
        public string ref_no
        {
            get => _ref_no;
            set => SetProperty(ref _ref_no, value);
        }

        private string _type;
        [DataMember]
        public string type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private DateTime _raise_date;
        [DataMember]
        public DateTime raise_date
        {
            get => _raise_date;
            set => SetProperty(ref _raise_date, value);
        }
        private string _user_id;
        public string user_id
        {
            get => _user_id;
            set => SetProperty(ref _user_id, value);
        }

        private string _raisedbymail;
        [DataMember]
        public string raisedbymail
        {
            get => _raisedbymail;
            set => SetProperty(ref _raisedbymail, value);
        }

        private int _status;
        [DataMember]
        public int status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private string _sumitomo_no;
        [DataMember]
        public string sumitomo_no
        {
            get => _sumitomo_no;
            set => SetProperty(ref _sumitomo_no, value);
        }

        private string _project_id;
        [DataMember]
        public string project_id
        {
            get => _project_id;
            set => SetProperty(ref _project_id, value);
        }

        private string _actual_supplier_id;
        [DataMember]
        public string actual_supplier_id
        {
            get => _actual_supplier_id;
            set => SetProperty(ref _actual_supplier_id, value);
        }

        private string _actualsupplierbuyermail;
        [DataMember]
        public string actualsupplierbuyermail
        {
            get => _actualsupplierbuyermail;
            set => SetProperty(ref _actualsupplierbuyermail, value);
        }
        private string _actualsupplierbuyer;
        [DataMember]
        public string actualsupplierbuyer
        {
            get => _actualsupplierbuyer;
            set => SetProperty(ref _actualsupplierbuyer, value);
        }
        private string _suggested_supplier_id;
        [DataMember]
        public string suggested_supplier_id
        {
            get => _suggested_supplier_id;
            set => SetProperty(ref _suggested_supplier_id, value);
        }
        private string _suggestedsupplierbuyermail;
        [DataMember]
        public string suggestedsupplierbuyermail
        {
            get => _suggestedsupplierbuyermail;
            set => SetProperty(ref _suggestedsupplierbuyermail, value);
        }

        private string _suggestedsupplierbuyer;
        [DataMember]
        public string suggestedsupplierbuyer
        {
            get => _suggestedsupplierbuyer;
            set => SetProperty(ref _suggestedsupplierbuyer, value);
        }

        private string _replaced_part;
        [DataMember]
        public string replaced_part
        {
            get => _replaced_part;
            set => SetProperty(ref _replaced_part, value);
        }

        private string _customer_id;
        [DataMember]
        public string customer_id
        {
            get => _customer_id;
            set => SetProperty(ref _customer_id, value);
        }

        private string _supplier_no;
        [DataMember]
        public string supplier_no
        {
            get => _supplier_no;
            set => SetProperty(ref _supplier_no, value);
        }

        private string _assembly_no;
        [DataMember]
        public string assembly_no
        {
            get => _assembly_no;
            set => SetProperty(ref _assembly_no, value);
        }
        private string _customer_no;
        [DataMember]
        public string customer_no
        {
            get => _customer_no;
            set => SetProperty(ref _customer_no, value);
        }
        
             private string _deletestatus;
        [DataMember]
        public string deletestatus
        {
            get => _deletestatus;
            set => SetProperty(ref _deletestatus, value);
        }

    }
}
