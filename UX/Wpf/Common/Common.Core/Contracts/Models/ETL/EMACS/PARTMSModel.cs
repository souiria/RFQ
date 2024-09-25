using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;


namespace Common.Core.Contracts.Models.ETL.EMACS
{
    [DataContract, Serializable]
    public class PARTMSModel : ExternalDataSourceModel<long>
    {
        private string _c_p_buhin_c;
        [DataMember, Key]
        public string C_P_BUHIN_C
        {
            get => _c_p_buhin_c;
            set => SetProperty(ref _c_p_buhin_c, value);
        }

        private string _c_p_buhin_nm;
        [DataMember]
        public string C_P_BUHIN_NM
        {
            get => _c_p_buhin_nm;
            set => SetProperty(ref _c_p_buhin_nm, value);
        }

        private string _c_p_buhin_enm;
        [DataMember]
        public string C_P_BUHIN_ENM
        {
            get => _c_p_buhin_enm;
            set => SetProperty(ref _c_p_buhin_enm, value);
        }

        private string _c_p_ryaku_kigo;
        [DataMember]
        public string C_P_RYAKU_KIGO
        {
            get => _c_p_ryaku_kigo;
            set => SetProperty(ref _c_p_ryaku_kigo, value);
        }

        private string _c_p_old_syubetu;
        [DataMember]
        public string C_P_OLD_SYUBETU
        {
            get => _c_p_old_syubetu;
            set => SetProperty(ref _c_p_old_syubetu, value);
        }

        private string _c_p_old_zaisitu;
        [DataMember]
        public string C_P_OLD_ZAISITU
        {
            get => _c_p_old_zaisitu;
            set => SetProperty(ref _c_p_old_zaisitu, value);
        }

        private string _c_p_syubetu1;
        [DataMember]
        public string C_P_SYUBETU1
        {
            get => _c_p_syubetu1;
            set => SetProperty(ref _c_p_syubetu1, value);
        }

        private string _c_p_syubetu2;
        [DataMember]
        public string C_P_SYUBETU2
        {
            get => _c_p_syubetu2;
            set => SetProperty(ref _c_p_syubetu2, value);
        }

        private string _c_p_zaisitu1;
        [DataMember]
        public string C_P_ZAISITU1
        {
            get => _c_p_zaisitu1;
            set => SetProperty(ref _c_p_zaisitu1, value);
        }

        private string _c_p_zaisitu2;
        [DataMember]
        public string C_P_ZAISITU2
        {
            get => _c_p_zaisitu2;
            set => SetProperty(ref _c_p_zaisitu2, value);
        }

        private string _c_p_iro;
        [DataMember]
        public string C_P_IRO
        {
            get => _c_p_iro;
            set => SetProperty(ref _c_p_iro, value);
        }

        private short? _c_p_kyokusu;
        [DataMember]
        public short? C_P_KYOKUSU
        {
            get => _c_p_kyokusu;
            set => SetProperty(ref _c_p_kyokusu, value);
        }

        private decimal? _c_p_size1;
        [DataMember]
        public decimal? C_P_SIZE1
        {
            get => _c_p_size1;
            set => SetProperty(ref _c_p_size1, value);
        }

        private decimal? _c_p_size2;
        [DataMember]
        public decimal? C_P_SIZE2
        {
            get => _c_p_size2;
            set => SetProperty(ref _c_p_size2, value);
        }

        private decimal? _c_p_size3;
        [DataMember]
        public decimal? C_P_SIZE3
        {
            get => _c_p_size3;
            set => SetProperty(ref _c_p_size3, value);
        }

        private decimal? _c_p_size4;
        [DataMember]
        public decimal? C_P_SIZE4
        {
            get => _c_p_size4;
            set => SetProperty(ref _c_p_size4, value);
        }

        private short? _c_p_la_anakei;
        [DataMember]
        public short? C_P_LA_ANAKEI
        {
            get => _c_p_la_anakei;
            set => SetProperty(ref _c_p_la_anakei, value);
        }

        private short? _c_p_tp_nobiritu;
        [DataMember]
        public short? C_P_TP_NOBIRITU
        {
            get => _c_p_tp_nobiritu;
            set => SetProperty(ref _c_p_tp_nobiritu, value);
        }

        private short? _c_p_tp_domesu;
        [DataMember]
        public short? C_P_TP_DOMESU
        {
            get => _c_p_tp_domesu;
            set => SetProperty(ref _c_p_tp_domesu, value);
        }

        private decimal? _c_p_zyuryo;
        [DataMember]
        public decimal? C_P_ZYURYO
        {
            get => _c_p_zyuryo;
            set => SetProperty(ref _c_p_zyuryo, value);
        }

        private string _c_p_mekki_k;
        [DataMember]
        public string C_P_MEKKI_K
        {
            get => _c_p_mekki_k;
            set => SetProperty(ref _c_p_mekki_k, value);
        }

        private decimal? _c_p_suryo;
        [DataMember]
        public decimal? C_P_SURYO
        {
            get => _c_p_suryo;
            set => SetProperty(ref _c_p_suryo, value);
        }

        private string _c_p_tani;
        [DataMember]
        public string C_P_TANI
        {
            get => _c_p_tani;
            set => SetProperty(ref _c_p_tani, value);
        }

        private string _c_p_sobetu_k1;
        [DataMember]
        public string C_P_SOBETU_K1
        {
            get => _c_p_sobetu_k1;
            set => SetProperty(ref _c_p_sobetu_k1, value);
        }

        private string _c_p_sobetu_k2;
        [DataMember]
        public string C_P_SOBETU_K2
        {
            get => _c_p_sobetu_k2;
            set => SetProperty(ref _c_p_sobetu_k2, value);
        }

        private string _c_p_sobetu_k3;
        [DataMember]
        public string C_P_SOBETU_K3
        {
            get => _c_p_sobetu_k3;
            set => SetProperty(ref _c_p_sobetu_k3, value);
        }

        private string _c_p_sobetu_k4;
        [DataMember]
        public string C_P_SOBETU_K4
        {
            get => _c_p_sobetu_k4;
            set => SetProperty(ref _c_p_sobetu_k4, value);
        }

        private string _c_p_sobetu_k5;
        [DataMember]
        public string C_P_SOBETU_K5
        {
            get => _c_p_sobetu_k5;
            set => SetProperty(ref _c_p_sobetu_k5, value);
        }

        private string _c_p_sobetu_k6;
        [DataMember]
        public string C_P_SOBETU_K6
        {
            get => _c_p_sobetu_k6;
            set => SetProperty(ref _c_p_sobetu_k6, value);
        }

        private string _c_p_sobetu_k7;
        [DataMember]
        public string C_P_SOBETU_K7
        {
            get => _c_p_sobetu_k7;
            set => SetProperty(ref _c_p_sobetu_k7, value);
        }

        private string _c_p_sobetu_k8;
        [DataMember]
        public string C_P_SOBETU_K8
        {
            get => _c_p_sobetu_k8;
            set => SetProperty(ref _c_p_sobetu_k8, value);
        }

        private short? _c_p_tansik;
        [DataMember]
        public short? C_P_TANSIK
        {
            get => _c_p_tansik;
            set => SetProperty(ref _c_p_tansik, value);
        }

        private short? _c_p_saisunk_t;
        [DataMember]
        public short? C_P_SAISUNK_T
        {
            get => _c_p_saisunk_t;
            set => SetProperty(ref _c_p_saisunk_t, value);
        }

        private short? _c_p_saisunk_n;
        [DataMember]
        public short? C_P_SAISUNK_N
        {
            get => _c_p_saisunk_n;
            set => SetProperty(ref _c_p_saisunk_n, value);
        }

        private short? _c_p_saisunk_s;
        [DataMember]
        public short? C_P_SAISUNK_S
        {
            get => _c_p_saisunk_s;
            set => SetProperty(ref _c_p_saisunk_s, value);
        }

        private string _c_p_sakitoshi_k;
        [DataMember]
        public string C_P_SAKITOSHI_K
        {
            get => _c_p_sakitoshi_k;
            set => SetProperty(ref _c_p_sakitoshi_k, value);
        }

        private string _c_p_zukei_c;
        [DataMember]
        public string C_P_ZUKEI_C
        {
            get => _c_p_zukei_c;
            set => SetProperty(ref _c_p_zukei_c, value);
        }

        private string _c_p_kaihatu_c;
        [DataMember]
        public string C_P_KAIHATU_C
        {
            get => _c_p_kaihatu_c;
            set => SetProperty(ref _c_p_kaihatu_c, value);
        }

        private string _c_p_sinki_maker;
        [DataMember]
        public string C_P_SINKI_MAKER
        {
            get => _c_p_sinki_maker;
            set => SetProperty(ref _c_p_sinki_maker, value);
        }

        private string _c_p_t_ban;
        [DataMember]
        public string C_P_T_BAN
        {
            get => _c_p_t_ban;
            set => SetProperty(ref _c_p_t_ban, value);
        }

        private string _c_p_toroku_ymd;
        [DataMember]
        public string C_P_TOROKU_YMD
        {
            get => _c_p_toroku_ymd;
            set => SetProperty(ref _c_p_toroku_ymd, value);
        }

        private string _c_p_kosin_ymd;
        [DataMember]
        public string C_P_KOSIN_YMD
        {
            get => _c_p_kosin_ymd;
            set => SetProperty(ref _c_p_kosin_ymd, value);
        }

        private decimal? _c_p_sekkei_zyuryo;
        [DataMember]
        public decimal? C_P_SEKKEI_ZYURYO
        {
            get => _c_p_sekkei_zyuryo;
            set => SetProperty(ref _c_p_sekkei_zyuryo, value);
        }

        private short? _c_p_l1;
        [DataMember]
        public short? C_P_L1
        {
            get => _c_p_l1;
            set => SetProperty(ref _c_p_l1, value);
        }

        private short? _c_p_l2;
        [DataMember]
        public short? C_P_L2
        {
            get => _c_p_l2;
            set => SetProperty(ref _c_p_l2, value);
        }

        private short? _c_p_l3;
        [DataMember]
        public short? C_P_L3
        {
            get => _c_p_l3;
            set => SetProperty(ref _c_p_l3, value);
        }

        private decimal? _c_p_pitch_haba;
        [DataMember]
        public decimal? C_P_PITCH_HABA
        {
            get => _c_p_pitch_haba;
            set => SetProperty(ref _c_p_pitch_haba, value);
        }

        private short? _c_p_katamuki;
        [DataMember]
        public short? C_P_KATAMUKI
        {
            get => _c_p_katamuki;
            set => SetProperty(ref _c_p_katamuki, value);
        }

        private int? _c_p_gurisua;
        [DataMember]
        public int? C_P_GURISUA
        {
            get => _c_p_gurisua;
            set => SetProperty(ref _c_p_gurisua, value);
        }

        private int? _c_p_gurisut;
        [DataMember]
        public int? C_P_GURISUT
        {
            get => _c_p_gurisut;
            set => SetProperty(ref _c_p_gurisut, value);
        }

        private short? _c_p_tp_nobirituh;
        [DataMember]
        public short? C_P_TP_NOBIRITUH
        {
            get => _c_p_tp_nobirituh;
            set => SetProperty(ref _c_p_tp_nobirituh, value);
        }

        private short? _c_p_bousuigom;
        [DataMember]
        public short? C_P_BOUSUIGOM
        {
            get => _c_p_bousuigom;
            set => SetProperty(ref _c_p_bousuigom, value);
        }

        private short? _c_p_tapechou;
        [DataMember]
        public short? C_P_TAPECHOU
        {
            get => _c_p_tapechou;
            set => SetProperty(ref _c_p_tapechou, value);
        }

        private int? _c_p_buhinchou;
        [DataMember]
        public int? C_P_BUHINCHOU
        {
            get => _c_p_buhinchou;
            set => SetProperty(ref _c_p_buhinchou, value);
        }

        private short? _c_p_cotanasu;
        [DataMember]
        public short? C_P_COTANASU
        {
            get => _c_p_cotanasu;
            set => SetProperty(ref _c_p_cotanasu, value);
        }

        private string _c_p_kzukei_hk;
        [DataMember]
        public string C_P_KZUKEI_HK
        {
            get => _c_p_kzukei_hk;
            set => SetProperty(ref _c_p_kzukei_hk, value);
        }

        private string _c_p_gmsenza_k;
        [DataMember]
        public string C_P_GMSENZA_K
        {
            get => _c_p_gmsenza_k;
            set => SetProperty(ref _c_p_gmsenza_k, value);
        }

        private string _c_p_old_buhin_c;
        [DataMember]
        public string C_P_OLD_BUHIN_C
        {
            get => _c_p_old_buhin_c;
            set => SetProperty(ref _c_p_old_buhin_c, value);
        }

        private string _c_p_pair_buhin_c;
        [DataMember]
        public string C_P_PAIR_BUHIN_C
        {
            get => _c_p_pair_buhin_c;
            set => SetProperty(ref _c_p_pair_buhin_c, value);
        }

        private string _c_p_daihyo_buhin_c;
        [DataMember]
        public string C_P_DAIHYO_BUHIN_C
        {
            get => _c_p_daihyo_buhin_c;
            set => SetProperty(ref _c_p_daihyo_buhin_c, value);
        }

        private string _c_p_hinmoku_c;
        [DataMember]
        public string C_P_HINMOKU_C
        {
            get => _c_p_hinmoku_c;
            set => SetProperty(ref _c_p_hinmoku_c, value);
        }

        private string _c_p_hanyo_senyo_k;
        [DataMember]
        public string C_P_HANYO_SENYO_K
        {
            get => _c_p_hanyo_senyo_k;
            set => SetProperty(ref _c_p_hanyo_senyo_k, value);
        }

        private string _c_p_naigaisei_k;
        [DataMember]
        public string C_P_NAIGAISEI_K
        {
            get => _c_p_naigaisei_k;
            set => SetProperty(ref _c_p_naigaisei_k, value);
        }

        private string _c_p_kanagata_yohi_k;
        [DataMember]
        public string C_P_KANAGATA_YOHI_K
        {
            get => _c_p_kanagata_yohi_k;
            set => SetProperty(ref _c_p_kanagata_yohi_k, value);
        }

        private string _c_p_gokan_k;
        [DataMember]
        public string C_P_GOKAN_K
        {
            get => _c_p_gokan_k;
            set => SetProperty(ref _c_p_gokan_k, value);
        }

        private string _c_p_ryosi_k;
        [DataMember]
        public string C_P_RYOSI_K
        {
            get => _c_p_ryosi_k;
            set => SetProperty(ref _c_p_ryosi_k, value);
        }

        private string _c_p_nit_c;
        [DataMember]
        public string C_P_NIT_C
        {
            get => _c_p_nit_c;
            set => SetProperty(ref _c_p_nit_c, value);
        }

        private string _c_p_b_series_c;
        [DataMember]
        public string C_P_B_SERIES_C
        {
            get => _c_p_b_series_c;
            set => SetProperty(ref _c_p_b_series_c, value);
        }

        private string _c_p_s_bui_c;
        [DataMember]
        public string C_P_S_BUI_C
        {
            get => _c_p_s_bui_c;
            set => SetProperty(ref _c_p_s_bui_c, value);
        }

        private string _c_p_buhin_riyu;
        [DataMember]
        public string C_P_BUHIN_RIYU
        {
            get => _c_p_buhin_riyu;
            set => SetProperty(ref _c_p_buhin_riyu, value);
        }

        private string _c_p_kna_sei_k;
        [DataMember]
        public string C_P_KNA_SEI_K
        {
            get => _c_p_kna_sei_k;
            set => SetProperty(ref _c_p_kna_sei_k, value);
        }

        private string _c_p_kna_k;
        [DataMember]
        public string C_P_KNA_K
        {
            get => _c_p_kna_k;
            set => SetProperty(ref _c_p_kna_k, value);
        }

        private string _c_p_gt_buhin_c;
        [DataMember]
        public string C_P_GT_BUHIN_C
        {
            get => _c_p_gt_buhin_c;
            set => SetProperty(ref _c_p_gt_buhin_c, value);
        }

        private string _c_p_t_buhin_c;
        [DataMember]
        public string C_P_T_BUHIN_C
        {
            get => _c_p_t_buhin_c;
            set => SetProperty(ref _c_p_t_buhin_c, value);
        }

        private string _c_p_assy_k;
        [DataMember]
        public string C_P_ASSY_K
        {
            get => _c_p_assy_k;
            set => SetProperty(ref _c_p_assy_k, value);
        }

        private string _c_p_seikari_k;
        [DataMember]
        public string C_P_SEIKARI_K
        {
            get => _c_p_seikari_k;
            set => SetProperty(ref _c_p_seikari_k, value);
        }

        private string _c_p_zumen_size;
        [DataMember]
        public string C_P_ZUMEN_SIZE
        {
            get => _c_p_zumen_size;
            set => SetProperty(ref _c_p_zumen_size, value);
        }

        private string _c_p_h_tati_ziki;
        [DataMember]
        public string C_P_H_TATI_ZIKI
        {
            get => _c_p_h_tati_ziki;
            set => SetProperty(ref _c_p_h_tati_ziki, value);
        }

        private string _c_p_u_tati_ziki;
        [DataMember]
        public string C_P_U_TATI_ZIKI
        {
            get => _c_p_u_tati_ziki;
            set => SetProperty(ref _c_p_u_tati_ziki, value);
        }

        private decimal? _c_p_sws_su;
        [DataMember]
        public decimal? C_P_SWS_SU
        {
            get => _c_p_sws_su;
            set => SetProperty(ref _c_p_sws_su, value);
        }

        private decimal? _c_p_ha_t_su;
        [DataMember]
        public decimal? C_P_HA_T_SU
        {
            get => _c_p_ha_t_su;
            set => SetProperty(ref _c_p_ha_t_su, value);
        }

        private decimal? _c_p_ho_t_su;
        [DataMember]
        public decimal? C_P_HO_T_SU
        {
            get => _c_p_ho_t_su;
            set => SetProperty(ref _c_p_ho_t_su, value);
        }

        private decimal? _c_p_kogeisu;
        [DataMember]
        public decimal? C_P_KOGEISU
        {
            get => _c_p_kogeisu;
            set => SetProperty(ref _c_p_kogeisu, value);
        }

        private decimal? _c_p_max_su;
        [DataMember]
        public decimal? C_P_MAX_SU
        {
            get => _c_p_max_su;
            set => SetProperty(ref _c_p_max_su, value);
        }

        private decimal? _c_p_sk_torisu;
        [DataMember]
        public decimal? C_P_SK_TORISU
        {
            get => _c_p_sk_torisu;
            set => SetProperty(ref _c_p_sk_torisu, value);
        }

        private string _c_p_s_s_noki;
        [DataMember]
        public string C_P_S_S_NOKI
        {
            get => _c_p_s_s_noki;
            set => SetProperty(ref _c_p_s_s_noki, value);
        }

        private string _c_p_h_s_noki;
        [DataMember]
        public string C_P_H_S_NOKI
        {
            get => _c_p_h_s_noki;
            set => SetProperty(ref _c_p_h_s_noki, value);
        }

        private string _c_p_k_konyu_c;
        [DataMember]
        public string C_P_K_KONYU_C
        {
            get => _c_p_k_konyu_c;
            set => SetProperty(ref _c_p_k_konyu_c, value);
        }

        private decimal? _c_p_moku_gk;
        [DataMember]
        public decimal? C_P_MOKU_GK
        {
            get => _c_p_moku_gk;
            set => SetProperty(ref _c_p_moku_gk, value);
        }

        private decimal? _c_p_k_kanahi;
        [DataMember]
        public decimal? C_P_K_KANAHI
        {
            get => _c_p_k_kanahi;
            set => SetProperty(ref _c_p_k_kanahi, value);
        }

        private string _c_p_han_k;
        [DataMember]
        public string C_P_HAN_K
        {
            get => _c_p_han_k;
            set => SetProperty(ref _c_p_han_k, value);
        }

        private string _c_p_k_naigai_hn;
        [DataMember]
        public string C_P_K_NAIGAI_HN
        {
            get => _c_p_k_naigai_hn;
            set => SetProperty(ref _c_p_k_naigai_hn, value);
        }

        private string _c_p_kk_gyosya_c;
        [DataMember]
        public string C_P_KK_GYOSYA_C
        {
            get => _c_p_kk_gyosya_c;
            set => SetProperty(ref _c_p_kk_gyosya_c, value);
        }

        private string _c_p_kk_noki;
        [DataMember]
        public string C_P_KK_NOKI
        {
            get => _c_p_kk_noki;
            set => SetProperty(ref _c_p_kk_noki, value);
        }

        private int? _c_p_kk_torisu;
        [DataMember]
        public int? C_P_KK_TORISU
        {
            get => _c_p_kk_torisu;
            set => SetProperty(ref _c_p_kk_torisu, value);
        }

        private short? _c_p_kk_mensu;
        [DataMember]
        public short? C_P_KK_MENSU
        {
            get => _c_p_kk_mensu;
            set => SetProperty(ref _c_p_kk_mensu, value);
        }

        private string _c_p_hakko_no;
        [DataMember]
        public string C_P_HAKKO_NO
        {
            get => _c_p_hakko_no;
            set => SetProperty(ref _c_p_hakko_no, value);
        }

        private string _c_p_hakko_ymd;
        [DataMember]
        public string C_P_HAKKO_YMD
        {
            get => _c_p_hakko_ymd;
            set => SetProperty(ref _c_p_hakko_ymd, value);
        }

        private string _c_p_h_busyo_c;
        [DataMember]
        public string C_P_H_BUSYO_C
        {
            get => _c_p_h_busyo_c;
            set => SetProperty(ref _c_p_h_busyo_c, value);
        }

        private string _c_p_msg1;
        [DataMember]
        public string C_P_MSG1
        {
            get => _c_p_msg1;
            set => SetProperty(ref _c_p_msg1, value);
        }

        private string _c_p_msg2;
        [DataMember]
        public string C_P_MSG2
        {
            get => _c_p_msg2;
            set => SetProperty(ref _c_p_msg2, value);
        }

        private string _c_p_sg_tan_ymd;
        [DataMember]
        public string C_P_SG_TAN_YMD
        {
            get => _c_p_sg_tan_ymd;
            set => SetProperty(ref _c_p_sg_tan_ymd, value);
        }

        private string _c_p_sg_tan_kai_c;
        [DataMember]
        public string C_P_SG_TAN_KAI_C
        {
            get => _c_p_sg_tan_kai_c;
            set => SetProperty(ref _c_p_sg_tan_kai_c, value);
        }

        private string _c_p_sg_tan_c;
        [DataMember]
        public string C_P_SG_TAN_C
        {
            get => _c_p_sg_tan_c;
            set => SetProperty(ref _c_p_sg_tan_c, value);
        }

        private string _c_p_sg_kt_ymd;
        [DataMember]
        public string C_P_SG_KT_YMD
        {
            get => _c_p_sg_kt_ymd;
            set => SetProperty(ref _c_p_sg_kt_ymd, value);
        }

        private string _c_p_sg_kt_kai_c;
        [DataMember]
        public string C_P_SG_KT_KAI_C
        {
            get => _c_p_sg_kt_kai_c;
            set => SetProperty(ref _c_p_sg_kt_kai_c, value);
        }

        private string _c_p_sg_kt_tan_c;
        [DataMember]
        public string C_P_SG_KT_TAN_C
        {
            get => _c_p_sg_kt_tan_c;
            set => SetProperty(ref _c_p_sg_kt_tan_c, value);
        }

        private string _c_p_kb_tan_ymd;
        [DataMember]
        public string C_P_KB_TAN_YMD
        {
            get => _c_p_kb_tan_ymd;
            set => SetProperty(ref _c_p_kb_tan_ymd, value);
        }

        private string _c_p_kb_tan_kai_c;
        [DataMember]
        public string C_P_KB_TAN_KAI_C
        {
            get => _c_p_kb_tan_kai_c;
            set => SetProperty(ref _c_p_kb_tan_kai_c, value);
        }

        private string _c_p_kb_tan_c;
        [DataMember]
        public string C_P_KB_TAN_C
        {
            get => _c_p_kb_tan_c;
            set => SetProperty(ref _c_p_kb_tan_c, value);
        }

        private string _c_p_gm_tan_ymd;
        [DataMember]
        public string C_P_GM_TAN_YMD
        {
            get => _c_p_gm_tan_ymd;
            set => SetProperty(ref _c_p_gm_tan_ymd, value);
        }

        private string _c_p_gm_tan_kai_c;
        [DataMember]
        public string C_P_GM_TAN_KAI_C
        {
            get => _c_p_gm_tan_kai_c;
            set => SetProperty(ref _c_p_gm_tan_kai_c, value);
        }

        private string _c_p_gm_atn_c;
        [DataMember]
        public string C_P_GM_ATN_C
        {
            get => _c_p_gm_atn_c;
            set => SetProperty(ref _c_p_gm_atn_c, value);
        }

        private short? _c_p_kosinsu;
        [DataMember]
        public short? C_P_KOSINSU
        {
            get => _c_p_kosinsu;
            set => SetProperty(ref _c_p_kosinsu, value);
        }

        private string _c_p_buhin_c_at_k1;
        [DataMember]
        public string C_P_BUHIN_C_AT_K1
        {
            get => _c_p_buhin_c_at_k1;
            set => SetProperty(ref _c_p_buhin_c_at_k1, value);
        }

        private decimal? _c_p_cover_size;
        [DataMember]
        public decimal? C_P_COVER_SIZE
        {
            get => _c_p_cover_size;
            set => SetProperty(ref _c_p_cover_size, value);
        }

        private short? _c_p_fukusu_kasyo;
        [DataMember]
        public short? C_P_FUKUSU_KASYO
        {
            get => _c_p_fukusu_kasyo;
            set => SetProperty(ref _c_p_fukusu_kasyo, value);
        }
        [NotMapped]
        public Uri  Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
        private Uri _image;
    }
}
