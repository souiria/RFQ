namespace Emacs.Data.Model
{
    public class DbPARTMS : IAggregateRoot
    {
        public string? SumitomoNumber
        { get; set; }
        public string? SumitomoDescription
        { get; set; }
        public string? SumitomoDescriptionEnglish
        { get; set; }
        public string? C_P_RYAKU_KIGO
        { get; set; }
        public string? OldPartClass
        { get; set; }
        public string? OldMaterial
        { get; set; }
        public string? ClassDetailGroupCode
        { get; set; }
        public string? ClassDetailId
        { get; set; }
        public string? MaterialGroupId
        { get; set; }
        public string? MaterialTypeId
        { get; set; }
        public string? ColorCode
        { get; set; }
        public short? NumberOfCavity
        { get; set; }
        public decimal? InsideDiameter
        { get; set; }
        public decimal? WallThickness
        { get; set; }
        public decimal? Length
        { get; set; }
        public decimal? WidthOrOutsideDiameter
        { get; set; }
        public short? HoleDiameter
        { get; set; }
        public short? ShrinkRateLength
        { get; set; }
        public short? NumberOfTapingSpots
        { get; set; }
        public decimal? MassOrWeight
        { get; set; }
        public string? C_P_MEKKI_K
        { get; set; }
        public decimal? Quantity
        { get; set; }
        public string? UoM
        { get; set; }
        public string? Group1
        { get; set; }
        public string? Group2
        { get; set; }
        public string? Group3
        { get; set; }
        public string? Group4
        { get; set; }
        public string? CavityCount
        { get; set; }
        public string? Group6
        { get; set; }
        public string? Group7
        { get; set; }
        public string? Group8
        { get; set; }
        public short? C_P_TANSIK
        { get; set; }
        public short? C_P_SAISUNK_T
        { get; set; }
        public short? C_P_SAISUNK_N
        { get; set; }
        public short? C_P_SAISUNK_S
        { get; set; }
        public string? C_P_SAKITOSHI_K
        { get; set; }
        public string? C_P_ZUKEI_C
        { get; set; }
        public string? C_P_KAIHATU_C
        { get; set; }
        public string? CustomerId
        { get; set; }
        public string? C_P_T_BAN
        { get; set; }
        public string? C_P_TOROKU_YMD
        { get; set; }
        public string? C_P_KOSIN_YMD
        { get; set; }
        public decimal? MassOrWeight2
        { get; set; }
        public short? L1
        { get; set; }
        public short? L2
        { get; set; }
        public short? L3
        { get; set; }
        public decimal? PitchWidth
        { get; set; }
        public short? Tilt
        { get; set; }
        public int? Grease
        { get; set; }
        public int? C_P_GURISUT
        { get; set; }
        public short? C_P_TP_NOBIRITUH
        { get; set; }
        public short? C_P_BOUSUIGOM
        { get; set; }
        public short? C_P_TAPECHOU
        { get; set; }
        public int? C_P_BUHINCHOU
        { get; set; }
        public short? C_P_COTANASU
        { get; set; }
        public string? C_P_KZUKEI_HK
        { get; set; }
        public string? C_P_GMSENZA_K
        { get; set; }
        public string? C_P_OLD_BUHIN_C
        { get; set; }
        public string? C_P_PAIR_BUHIN_C
        { get; set; }
        public string? C_P_DAIHYO_BUHIN_C
        { get; set; }
        public string? CategoryCode
        { get; set; }
        public string? C_P_HANYO_SENYO_K
        { get; set; }
        public string? C_P_KANAGATA_YOHI_K
        { get; set; }
        public string? C_P_RYOSI_K
        { get; set; }
        public string? C_P_NIT_C
        { get; set; }
        public string? C_P_B_SERIES_C
        { get; set; }
        public string? C_P_S_BUI_C
        { get; set; }
        public string? C_P_BUHIN_RIYU
        { get; set; }
        public string? C_P_KNA_SEI_K
        { get; set; }
        public string? C_P_KNA_K
        { get; set; }
        public string? C_P_GT_BUHIN_C
        { get; set; }
        public string? C_P_T_BUHIN_C
        { get; set; }
        public string? C_P_ASSY_K
        { get; set; }
        public string? C_P_SEIKARI_K
        { get; set; }
        public string? C_P_ZUMEN_SIZE
        { get; set; }
        public string? C_P_H_TATI_ZIKI
        { get; set; }
        public string? C_P_U_TATI_ZIKI
        { get; set; }
        public decimal? C_P_SWS_SU
        { get; set; }
        public decimal? C_P_HA_T_SU
        { get; set; }
        public decimal? C_P_HO_T_SU
        { get; set; }
        public decimal? C_P_KOGEISU
        { get; set; }
        public decimal? C_P_MAX_SU
        { get; set; }
        public decimal? C_P_SK_TORISU
        { get; set; }
        public string? C_P_S_S_NOKI
        { get; set; }
        public string? C_P_H_S_NOKI
        { get; set; }
        public string? C_P_K_KONYU_C
        { get; set; }
        public decimal? C_P_MOKU_GK
        { get; set; }
        public decimal? C_P_K_KANAHI
        { get; set; }
        public string? C_P_HAN_K
        { get; set; }
        public string? C_P_K_NAIGAI_HN
        { get; set; }
        public string? C_P_KK_GYOSYA_C
        { get; set; }
        public string? C_P_KK_NOKI
        { get; set; }
        public int? C_P_KK_TORISU
        { get; set; }
        public short? C_P_KK_MENSU
        { get; set; }
        public string? C_P_HAKKO_NO
        { get; set; }
        public string? C_P_HAKKO_YMD
        { get; set; }
        public string? C_P_H_BUSYO_C
        { get; set; }
        public string? C_P_MSG1
        { get; set; }
        public string? C_P_MSG2
        { get; set; }
        public string? C_P_SG_TAN_YMD
        { get; set; }
        public string? C_P_SG_TAN_KAI_C
        { get; set; }
        public string? C_P_SG_TAN_C
        { get; set; }
        public string? C_P_SG_KT_YMD
        { get; set; }
        public string? C_P_SG_KT_KAI_C
        { get; set; }
        public string? C_P_SG_KT_TAN_C
        { get; set; }
        public string? C_P_KB_TAN_YMD
        { get; set; }
        public string? C_P_KB_TAN_KAI_C
        { get; set; }
        public string? C_P_KB_TAN_C
        { get; set; }
        public string? C_P_GM_TAN_YMD
        { get; set; }
        public string? C_P_GM_TAN_KAI_C
        { get; set; }
        public string? C_P_GM_ATN_C
        { get; set; }
        public short? C_P_KOSINSU
        { get; set; }
        public string? C_P_BUHIN_C_AT_K1
        { get; set; }
        public decimal? C_P_COVER_SIZE
        { get; set; }
        public short? C_P_FUKUSU_KASYO
        { get; set; }
    }
}
