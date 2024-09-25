using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.EMACS
{
    [DataContract, Serializable]
    public class BUBANMModel : ExternalDataSourceModel<long>
    {
        private string _c_p_tmaker_c;
        [DataMember]
        public string C_P_TMAKER_C
        {
            get => _c_p_tmaker_c;
            set => SetProperty(ref _c_p_tmaker_c, value);
        }

        private string c_p_buban_no;
        [DataMember]
        public string C_P_BUBAN_NO
        {
            get => c_p_buban_no;
            set => SetProperty(ref c_p_buban_no, value);
        }

        private string c_p_buban_iro;
        [DataMember]
        public string C_P_BUBAN_IRO
        {
            get => c_p_buban_iro;
            set => SetProperty(ref c_p_buban_iro, value);
        }

        private string c_p_buban_spn;
        [DataMember]
        public string C_P_BUBAN_SPN
        {
            get => c_p_buban_spn;
            set => SetProperty(ref c_p_buban_spn, value);
        }

        private string c_p_buhin_c;
        [DataMember, Key]
        public string C_P_BUHIN_C
        {
            get => c_p_buhin_c;
            set => SetProperty(ref c_p_buhin_c, value);
        }

        private string c_p_buban_nm;
        [DataMember]
        public string C_P_BUBAN_NM
        {
            get => c_p_buban_nm;
            set => SetProperty(ref c_p_buban_nm, value);
        }

        private string c_p_kaisya_c;
        [DataMember]
        public string C_P_KAISYA_C
        {
            get => c_p_kaisya_c;
            set => SetProperty(ref c_p_kaisya_c, value);
        }

        private string c_p_tanto_c;
        [DataMember]
        public string C_P_TANTO_C
        {
            get => c_p_tanto_c;
            set => SetProperty(ref c_p_tanto_c, value);
        }

        private string c_p_toroku_ymd;
        [DataMember]
        public string C_P_TOROKU_YMD
        {
            get => c_p_toroku_ymd;
            set => SetProperty(ref c_p_toroku_ymd, value);
        }

        private string c_p_kosin_ymd;
        [DataMember]
        public string C_P_KOSIN_YMD
        {
            get => c_p_kosin_ymd;
            set => SetProperty(ref c_p_kosin_ymd, value);
        }

        private string c_p_tokuhyo_iro;
        [DataMember]
        public string C_P_TOKUHYO_IRO
        {
            get => c_p_tokuhyo_iro;
            set => SetProperty(ref c_p_tokuhyo_iro, value);
        }
    }
}
