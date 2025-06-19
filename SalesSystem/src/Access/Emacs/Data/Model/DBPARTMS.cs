namespace Emacs.Data.Model
{
    public class DbPARTMS : IAggregateRoot
    {
        [Column("C_P_BUHIN_C")]
        public string? SumitomoNumber
        { get; set; }
        [Column("C_P_BUHIN_NM")]
        public string? SumitomoDescription
        { get; set; }
        [Column("C_P_BUHIN_ENM")]
        public string? SumitomoDescriptionEnglish
        { get; set; }
        [Column("C_P_RYAKU_KIGO")]
        public string? C_P_RYAKU_KIGO
        { get; set; }
        [Column("C_P_OLD_SYUBETU")]
        public string? OldPartClass
        { get; set; }
        [Column("C_P_OLD_ZAISITU")]
        public string? OldMaterial
        { get; set; }
        [Column("C_P_SYUBETU1")]
        public string? ClassDetailGroupCode
        { get; set; }
        [Column("C_P_SYUBETU2")]
        public string? ClassDetailId
        { get; set; }
        [Column("C_P_ZAISITU1")]
        public string? MaterialGroupId
        { get; set; }
        [Column("C_P_ZAISITU2")]
        public string? MaterialTypeId
        { get; set; }
        [Column("C_P_IRO")]
        public string? ColorCode
        { get; set; }
        [Column("C_P_KYOKUSU")]
        public short? NumberOfCavity
        { get; set; }
        [Column("C_P_SIZE1")]
        public decimal? InsideDiameter
        { get; set; }
        [Column("C_P_SIZE2")]
        public decimal? WallThickness
        { get; set; }
        [Column("C_P_SIZE3")]
        public decimal? Length
        { get; set; }
        [Column("C_P_SIZE4")]
        public decimal? WidthOrOutsideDiameter
        { get; set; }
        [Column("C_P_LA_ANAKEI")]
        public short? HoleDiameter
        { get; set; }
        [Column("C_P_TP_NOBIRITU")]
        public short? ShrinkRateLength
        { get; set; }
        [Column("C_P_TP_DOMESU")]
        public short? NumberOfTapingSpots
        { get; set; }
        [Column("C_P_ZYURYO")]
        public decimal? MassOrWeight
        { get; set; }
        [Column("C_P_MEKKI_K")]
        public string? C_P_MEKKI_K
        { get; set; }
        [Column("C_P_SURYO")]
        public decimal? Quantity
        { get; set; }
        [Column("C_P_TANI")]
        public string? UoM
        { get; set; }
        [Column("C_P_SOBETU_K1")]
        public string? Group1
        { get; set; }
        [Column("C_P_SOBETU_K2")]
        public string? Group2
        { get; set; }
        [Column("C_P_SOBETU_K3")]
        public string? Group3
        { get; set; }
        [Column("C_P_SOBETU_K4")]
        public string? Group4
        { get; set; }
        [Column("C_P_SOBETU_K5")]
        public string? CavityCount
        { get; set; }
        [Column("C_P_SOBETU_K6")]
        public string? Group6
        { get; set; }
        [Column("C_P_SOBETU_K7")]
        public string? Group7
        { get; set; }
        [Column("C_P_SOBETU_K8")]
        public string? Group8
        { get; set; }
        [Column("C_P_TANSIK")]
        public short? C_P_TANSIK
        { get; set; }
        [Column("C_P_SAISUNK_T")]
        public short? C_P_SAISUNK_T
        { get; set; }
        [Column("C_P_SAISUNK_N")]
        public short? C_P_SAISUNK_N
        { get; set; }
        [Column("C_P_SAISUNK_S")]
        public short? C_P_SAISUNK_S
        { get; set; }
        [Column("C_P_SAKITOSHI_K")]
        public string? C_P_SAKITOSHI_K
        { get; set; }
        [Column("C_P_ZUKEI_C")]
        public string? C_P_ZUKEI_C
        { get; set; }
        [Column("C_P_KAIHATU_C")]
        public string? C_P_KAIHATU_C
        { get; set; }
        [Column("C_P_SINKI_MAKER")]
        public string? CustomerId
        { get; set; }
        [Column("C_P_T_BAN")]
        public string? C_P_T_BAN
        { get; set; }
        [Column("C_P_TOROKU_YMD")]
        public string? C_P_TOROKU_YMD
        { get; set; }
        [Column("C_P_KOSIN_YMD")]
        public string? C_P_KOSIN_YMD
        { get; set; }
        [Column("C_P_SEKKEI_ZYURYO")]
        public decimal? MassOrWeight2
        { get; set; }
        [Column("C_P_L1")]
        public short? L1
        { get; set; }
        [Column("C_P_L2")]
        public short? L2
        { get; set; }
        [Column("C_P_L3")]
        public short? L3
        { get; set; }
        [Column("C_P_PITCH_HABA")]
        public decimal? PitchWidth
        { get; set; }
        [Column("C_P_KATAMUKI")]
        public short? Tilt
        { get; set; }
        [Column("C_P_GURISUA")]
        public int? Grease
        { get; set; }
        [Column("C_P_GURISUT")]
        public int? C_P_GURISUT
        { get; set; }
        [Column("C_P_TP_NOBIRITUH")]
        public short? C_P_TP_NOBIRITUH
        { get; set; }
        [Column("C_P_BOUSUIGOM")]
        public short? C_P_BOUSUIGOM
        { get; set; }
        [Column("C_P_TAPECHOU")]
        public short? C_P_TAPECHOU
        { get; set; }
        [Column("C_P_BUHINCHOU")]
        public int? C_P_BUHINCHOU
        { get; set; }
        [Column("C_P_COTANASU")]
        public short? C_P_COTANASU
        { get; set; }
        [Column("C_P_KZUKEI_HK")]
        public string? C_P_KZUKEI_HK
        { get; set; }
        [Column("C_P_GMSENZA_K")]
        public string? C_P_GMSENZA_K
        { get; set; }
        [Column("C_P_OLD_BUHIN_C")]
        public string? C_P_OLD_BUHIN_C
        { get; set; }
        [Column("C_P_PAIR_BUHIN_C")]
        public string? C_P_PAIR_BUHIN_C
        { get; set; }
        [Column("C_P_DAIHYO_BUHIN_C")]
        public string? C_P_DAIHYO_BUHIN_C
        { get; set; }
        [Column("C_P_HINMOKU_C")]
        public string? CategoryCode
        { get; set; }
        [Column("C_P_HANYO_SENYO_K")]
        public string? C_P_HANYO_SENYO_K
        { get; set; }
        [Column("C_P_KANAGATA_YOHI_K")]
        public string? C_P_KANAGATA_YOHI_K
        { get; set; }
        [Column("C_P_RYOSI_K")]
        public string? C_P_RYOSI_K
        { get; set; }
        [Column("C_P_NIT_C")]
        public string? C_P_NIT_C
        { get; set; }
        [Column("C_P_B_SERIES_C")]
        public string? C_P_B_SERIES_C
        { get; set; }
        [Column("C_P_S_BUI_C")]
        public string? C_P_S_BUI_C
        { get; set; }
        [Column("C_P_BUHIN_RIYU")]
        public string? C_P_BUHIN_RIYU
        { get; set; }
        [Column("C_P_KNA_SEI_K")]
        public string? C_P_KNA_SEI_K
        { get; set; }
        [Column("C_P_KNA_K")]
        public string? C_P_KNA_K
        { get; set; }
        [Column("C_P_GT_BUHIN_C")]
        public string? C_P_GT_BUHIN_C
        { get; set; }
        [Column("C_P_T_BUHIN_C")]
        public string? C_P_T_BUHIN_C
        { get; set; }
        [Column("C_P_ASSY_K")]
        public string? C_P_ASSY_K
        { get; set; }
        [Column("C_P_SEIKARI_K")]
        public string? C_P_SEIKARI_K
        { get; set; }
        [Column("C_P_ZUMEN_SIZE")]
        public string? C_P_ZUMEN_SIZE
        { get; set; }
        [Column("C_P_H_TATI_ZIKI")]
        public string? C_P_H_TATI_ZIKI
        { get; set; }
        [Column("C_P_U_TATI_ZIKI")]
        public string? C_P_U_TATI_ZIKI
        { get; set; }
        [Column("C_P_SWS_SU")]
        public decimal? C_P_SWS_SU
        { get; set; }
        [Column("C_P_HA_T_SU")]
        public decimal? C_P_HA_T_SU
        { get; set; }
        [Column("C_P_HO_T_SU")]
        public decimal? C_P_HO_T_SU
        { get; set; }
        [Column("C_P_KOGEISU")]
        public decimal? C_P_KOGEISU
        { get; set; }
        [Column("C_P_MAX_SU")]
        public decimal? C_P_MAX_SU
        { get; set; }
        [Column("C_P_SK_TORISU")]
        public decimal? C_P_SK_TORISU
        { get; set; }
        [Column("C_P_S_S_NOKI")]
        public string? C_P_S_S_NOKI
        { get; set; }
        [Column("C_P_H_S_NOKI")]
        public string? C_P_H_S_NOKI
        { get; set; }
        [Column("C_P_K_KONYU_C")]
        public string? C_P_K_KONYU_C
        { get; set; }
        [Column("C_P_MOKU_GK")]
        public decimal? C_P_MOKU_GK
        { get; set; }
        [Column("C_P_K_KANAHI")]
        public decimal? C_P_K_KANAHI
        { get; set; }
        [Column("C_P_HAN_K")]
        public string? C_P_HAN_K
        { get; set; }
        [Column("C_P_K_NAIGAI_HN")]
        public string? C_P_K_NAIGAI_HN
        { get; set; }
        [Column("C_P_KK_GYOSYA_C")]
        public string? C_P_KK_GYOSYA_C
        { get; set; }
        [Column("C_P_KK_NOKI")]
        public string? C_P_KK_NOKI
        { get; set; }
        [Column("C_P_KK_TORISU")]
        public int? C_P_KK_TORISU
        { get; set; }
        [Column("C_P_KK_MENSU")]
        public short? C_P_KK_MENSU
        { get; set; }
        [Column("C_P_HAKKO_NO")]
        public string? C_P_HAKKO_NO
        { get; set; }
        [Column("C_P_HAKKO_YMD")]
        public string? C_P_HAKKO_YMD
        { get; set; }
        [Column("C_P_H_BUSYO_C")]
        public string? C_P_H_BUSYO_C
        { get; set; }
        [Column("C_P_MSG1")]
        public string? C_P_MSG1
        { get; set; }
        [Column("C_P_MSG2")]
        public string? C_P_MSG2
        { get; set; }
        [Column("C_P_SG_TAN_YMD")]
        public string? C_P_SG_TAN_YMD
        { get; set; }
        [Column("C_P_SG_TAN_KAI_C")]
        public string? C_P_SG_TAN_KAI_C
        { get; set; }
        [Column("C_P_SG_TAN_C")]
        public string? C_P_SG_TAN_C
        { get; set; }
        [Column("C_P_SG_KT_YMD")]
        public string? C_P_SG_KT_YMD
        { get; set; }
        [Column("C_P_SG_KT_KAI_C")]
        public string? C_P_SG_KT_KAI_C
        { get; set; }
        [Column("C_P_SG_KT_TAN_C")]
        public string? C_P_SG_KT_TAN_C
        { get; set; }
        [Column("C_P_KB_TAN_YMD")]
        public string? C_P_KB_TAN_YMD
        { get; set; }
        [Column("C_P_KB_TAN_KAI_C")]
        public string? C_P_KB_TAN_KAI_C
        { get; set; }
        [Column("C_P_KB_TAN_C")]
        public string? C_P_KB_TAN_C
        { get; set; }
        [Column("C_P_GM_TAN_YMD")]
        public string? C_P_GM_TAN_YMD
        { get; set; }
        [Column("C_P_GM_TAN_KAI_C")]
        public string? C_P_GM_TAN_KAI_C
        { get; set; }
        [Column("C_P_GM_ATN_C")]
        public string? C_P_GM_ATN_C
        { get; set; }
        [Column("C_P_KOSINSU")]
        public short? C_P_KOSINSU
        { get; set; }
        [Column("C_P_BUHIN_C_AT_K1")]
        public string? C_P_BUHIN_C_AT_K1
        { get; set; }
        [Column("C_P_COVER_SIZE")]
        public decimal? C_P_COVER_SIZE
        { get; set; }
        [Column("C_P_FUKUSU_KASYO")]
        public short? C_P_FUKUSU_KASYO
        { get; set; }
    }
}
