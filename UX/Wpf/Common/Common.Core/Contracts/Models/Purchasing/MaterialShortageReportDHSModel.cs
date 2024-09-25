/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   MaterialShortageReportDHSModel.cs
Function           :   MaterialShortageReportDHS Data
Created By         :   Shivam Kalia
Created on         :   06-Sept-2021
Revision History   :   [09-Sep-2021]: Shivam Kalia
*                  :   Changed BusinessUnitGuid to BusinessUnitCode in MaterialShortageReportDHSProcedureParameterModel                  
*                  :   [10-Sep-2021]: Shivam Kalia
*                  :   Removed @P_DateFormat field from MaterialShortageReportDHSProcedureParameterModel and added Column224 in MaterialShortageReportDHSModel     
*                  :   [15-Sep-2021]: Shivam Kalia
*                  :   Added ColumnRemarks in MaterialShortageReportDHSModel
*                  :   [28-Sep-2021]: Shivam Dhingra
*                  :   Added new columns
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Class File for MaterialShortageReportDHSModel
    /// </summary>
    /// 
    [DataContract, Serializable]
    public class MaterialShortageReportDHSModel : BaseModel<Guid>
    {
        private string _column1;
        /// <summary>
        /// Get or Set for {Column1}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column1
        {
            get => _column1;
            set => _column1 = value;
        }
        private string _column2;
        /// <summary>
        /// Get or Set for {Column2}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column2
        {
            get => _column2;
            set => _column2 = value;
        }
        private string _column3;
        /// <summary>
        /// Get or Set for {Column3}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column3
        {
            get => _column3;
            set => _column3 = value;
        }

        private string _column4;
        /// <summary>
        /// Get or Set for {Column4}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column4
        {
            get => _column4;
            set => _column4 = value;
        }

        private string _column5;
        /// <summary>
        /// Get or Set for {Column5}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column5
        {
            get => _column5;
            set => _column5 = value;
        }

        private string _column6;
        /// <summary>
        /// Get or Set for {Column6}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column6
        {
            get => _column6;
            set => _column6 = value;
        }

        private string _column7;
        /// <summary>
        /// Get or Set for {Column7}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column7
        {
            get => _column7;
            set => _column7 = value;
        }

        private string _column8;
        /// <summary>
        /// Get or Set for {Column8}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column8
        {
            get => _column8;
            set => _column8 = value;
        }

        private string _column9;
        /// <summary>
        /// Get or Set for {Column9}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column9
        {
            get => _column9;
            set => _column9 = value;
        }

        private string _column10;
        /// <summary>
        /// Get or Set for {Column10}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column10
        {
            get => _column10;
            set => _column10 = value;
        }

        private string _column11;
        /// <summary>
        /// Get or Set for {Column11}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column11
        {
            get => _column11;
            set => _column11 = value;
        }

        private string _column12;
        /// <summary>
        /// Get or Set for {Column12}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column12
        {
            get => _column12;
            set => _column12 = value;
        }

        private string _column13;
        /// <summary>
        /// Get or Set for {Column13}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column13
        {
            get => _column13;
            set => _column13 = value;
        }

        private string _column14;
        /// <summary>
        /// Get or Set for {Column14}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column14
        {
            get => _column14;
            set => _column14 = value;
        }

        private string _column15;
        /// <summary>
        /// Get or Set for {Column15}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column15
        {
            get => _column15;
            set => _column15 = value;
        }

        private string _column16;
        /// <summary>
        /// Get or Set for {Column16}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column16
        {
            get => _column16;
            set => _column16 = value;
        }

        private string _column17;
        /// <summary>
        /// Get or Set for {Column17}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column17
        {
            get => _column17;
            set => _column17 = value;
        }

        private string _column18;
        /// <summary>
        /// Get or Set for {Column18}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column18
        {
            get => _column18;
            set => _column18 = value;
        }

        private string _column19;
        /// <summary>
        /// Get or Set for {Column19}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column19
        {
            get => _column19;
            set => _column19 = value;
        }

        private string _column20;
        /// <summary>
        /// Get or Set for {Column20}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column20
        {
            get => _column20;
            set => _column20 = value;
        }

        private string _column21;
        /// <summary>
        /// Get or Set for {Column21}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column21
        {
            get => _column21;
            set => _column21 = value;
        }

        private string _column22;
        /// <summary>
        /// Get or Set for {Column22}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column22
        {
            get => _column22;
            set => _column22 = value;
        }

        private string _column23;
        /// <summary>
        /// Get or Set for {Column23}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column23
        {
            get => _column23;
            set => _column23 = value;
        }

        private string _column24;
        /// <summary>
        /// Get or Set for {Column24}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column24
        {
            get => _column24;
            set => _column24 = value;
        }

        private string _column25;
        /// <summary>
        /// Get or Set for {Column25}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column25
        {
            get => _column25;
            set => _column25 = value;
        }

        private string _column26;
        /// <summary>
        /// Get or Set for {Column26}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column26
        {
            get => _column26;
            set => _column26 = value;
        }

        private string _column27;
        /// <summary>
        /// Get or Set for {Column27}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column27
        {
            get => _column27;
            set => _column27 = value;
        }

        private string _column28;
        /// <summary>
        /// Get or Set for {Column28}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column28
        {
            get => _column28;
            set => _column28 = value;
        }

        private string _column29;
        /// <summary>
        /// Get or Set for {Column2}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column29
        {
            get => _column29;
            set => _column29 = value;
        }

        private string _column30;
        /// <summary>
        /// Get or Set for {Column30}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column30
        {
            get => _column30;
            set => _column30 = value;
        }

        private string _column31;
        /// <summary>
        /// Get or Set for {Column31}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column31
        {
            get => _column31;
            set => _column31 = value;
        }

        private string _column32;
        /// <summary>
        /// Get or Set for {Column32}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column32
        {
            get => _column32;
            set => _column32 = value;
        }

        private string _column33;
        /// <summary>
        /// Get or Set for {Column33}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column33
        {
            get => _column33;
            set => _column33 = value;
        }

        private string _column34;
        /// <summary>
        /// Get or Set for {Column34}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column34
        {
            get => _column34;
            set => _column34 = value;
        }

        private string _column35;
        /// <summary>
        /// Get or Set for {Column35}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column35
        {
            get => _column35;
            set => _column35 = value;
        }

        private string _column36;
        /// <summary>
        /// Get or Set for {Column36}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column36
        {
            get => _column36;
            set => _column36 = value;
        }

        private string _column37;
        /// <summary>
        /// Get or Set for {Column37}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column37
        {
            get => _column37;
            set => _column37 = value;
        }

        private string _column38;
        /// <summary>
        /// Get or Set for {Column38}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column38
        {
            get => _column38;
            set => _column38 = value;
        }

        private string _column39;
        /// <summary>
        /// Get or Set for {Column39}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column39
        {
            get => _column39;
            set => _column39 = value;
        }

        private string _column40;
        /// <summary>
        /// Get or Set for {Column40}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column40
        {
            get => _column40;
            set => _column40 = value;
        }

        private string _column41;
        /// <summary>
        /// Get or Set for {Column41}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column41
        {
            get => _column41;
            set => _column41 = value;
        }

        private string _column42;
        /// <summary>
        /// Get or Set for {Column42}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column42
        {
            get => _column42;
            set => _column42 = value;
        }

        private string _column43;
        /// <summary>
        /// Get or Set for {Column43}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column43
        {
            get => _column43;
            set => _column43 = value;
        }

        private string _column44;
        /// <summary>
        /// Get or Set for {Column44}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column44
        {
            get => _column44;
            set => _column44 = value;
        }

        private string _column45;
        /// <summary>
        /// Get or Set for {Column45}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column45
        {
            get => _column45;
            set => _column45 = value;
        }

        private string _column46;
        /// <summary>
        /// Get or Set for {Column46}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column46
        {
            get => _column46;
            set => _column46 = value;
        }

        private string _column47;
        /// <summary>
        /// Get or Set for {Column47}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column47
        {
            get => _column47;
            set => _column47 = value;
        }

        private string _column48;
        /// <summary>
        /// Get or Set for {Column48}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column48
        {
            get => _column48;
            set => _column48 = value;
        }

        private string _column49;
        /// <summary>
        /// Get or Set for {Column49}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column49
        {
            get => _column49;
            set => _column49 = value;
        }

        private string _column50;
        /// <summary>
        /// Get or Set for {Column50}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column50
        {
            get => _column50;
            set => _column50 = value;
        }

        private string _column51;
        /// <summary>
        /// Get or Set for {Column51}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column51
        {
            get => _column51;
            set => _column51 = value;
        }

        private string _column52;
        /// <summary>
        /// Get or Set for {Column52}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column52
        {
            get => _column52;
            set => _column52 = value;
        }

        private string _column53;
        /// <summary>
        /// Get or Set for {Column53}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column53
        {
            get => _column53;
            set => _column53 = value;
        }

        private string _column54;
        /// <summary>
        /// Get or Set for {Column54}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column54
        {
            get => _column54;
            set => _column54 = value;
        }

        private string _column55;
        /// <summary>
        /// Get or Set for {Column55}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column55
        {
            get => _column55;
            set => _column55 = value;
        }

        private string _column56;
        /// <summary>
        /// Get or Set for {Column56}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column56
        {
            get => _column56;
            set => _column56 = value;
        }

        private string _column57;
        /// <summary>
        /// Get or Set for {Column57}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column57
        {
            get => _column57;
            set => _column57 = value;
        }

        private string _column58;
        /// <summary>
        /// Get or Set for {Column58}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column58
        {
            get => _column58;
            set => _column58 = value;
        }

        private string _column59;
        /// <summary>
        /// Get or Set for {Column59}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column59
        {
            get => _column59;
            set => _column59 = value;
        }

        private string _column60;
        /// <summary>
        /// Get or Set for {Column60}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column60
        {
            get => _column60;
            set => _column60 = value;
        }

        private string _column61;
        /// <summary>
        /// Get or Set for {Column61}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column61
        {
            get => _column61;
            set => _column61 = value;
        }

        private string _column62;
        /// <summary>
        /// Get or Set for {Column62}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column62
        {
            get => _column62;
            set => _column62 = value;
        }

        private string _column63;
        /// <summary>
        /// Get or Set for {Column63}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column63
        {
            get => _column63;
            set => _column63 = value;
        }

        private string _column64;
        /// <summary>
        /// Get or Set for {Column64}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column64
        {
            get => _column64;
            set => _column64 = value;
        }

        private string _column65;
        /// <summary>
        /// Get or Set for {Column65}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column65
        {
            get => _column65;
            set => _column65 = value;
        }

        private string _column66;
        /// <summary>
        /// Get or Set for {Column66}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column66
        {
            get => _column66;
            set => _column66 = value;
        }

        private string _column67;
        /// <summary>
        /// Get or Set for {Column67}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column67
        {
            get => _column67;
            set => _column67 = value;
        }

        private string _column68;
        /// <summary>
        /// Get or Set for {Column68}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column68
        {
            get => _column68;
            set => _column68 = value;
        }

        private string _column69;
        /// <summary>
        /// Get or Set for {Column69}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column69
        {
            get => _column69;
            set => _column69 = value;
        }

        private string _column70;
        /// <summary>
        /// Get or Set for {Column70}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column70
        {
            get => _column70;
            set => _column70 = value;
        }

        private string _column71;
        /// <summary>
        /// Get or Set for {Column71}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column71
        {
            get => _column71;
            set => _column71 = value;
        }

        private string _column72;
        /// <summary>
        /// Get or Set for {Column72}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column72
        {
            get => _column72;
            set => _column72 = value;
        }

        private string _column73;
        /// <summary>
        /// Get or Set for {Column73}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column73
        {
            get => _column73;
            set => _column73 = value;
        }

        private string _column74;
        /// <summary>
        /// Get or Set for {Column74}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column74
        {
            get => _column74;
            set => _column74 = value;
        }

        private string _column75;
        /// <summary>
        /// Get or Set for {Column75}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column75
        {
            get => _column75;
            set => _column75 = value;
        }

        private string _column76;
        /// <summary>
        /// Get or Set for {Column76}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column76
        {
            get => _column76;
            set => _column76 = value;
        }

        private string _column77;
        /// <summary>
        /// Get or Set for {Column77}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column77
        {
            get => _column77;
            set => _column77 = value;
        }

        private string _column78;
        /// <summary>
        /// Get or Set for {Column78}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column78
        {
            get => _column78;
            set => _column78 = value;
        }

        private string _column79;
        /// <summary>
        /// Get or Set for {Column79}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column79
        {
            get => _column79;
            set => _column79 = value;
        }

        private string _column80;
        /// <summary>
        /// Get or Set for {Column80}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column80
        {
            get => _column80;
            set => _column80 = value;
        }

        private string _column81;
        /// <summary>
        /// Get or Set for {Column81}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column81
        {
            get => _column81;
            set => _column81 = value;
        }

        private string _column82;
        /// <summary>
        /// Get or Set for {Column82}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column82
        {
            get => _column82;
            set => _column82 = value;
        }

        private string _column83;
        /// <summary>
        /// Get or Set for {Column83}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column83
        {
            get => _column83;
            set => _column83 = value;
        }

        private string _column84;
        /// <summary>
        /// Get or Set for {Column84}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column84
        {
            get => _column84;
            set => _column84 = value;
        }

        private string _column85;
        /// <summary>
        /// Get or Set for {Column85}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column85
        {
            get => _column85;
            set => _column85 = value;
        }

        private string _column86;
        /// <summary>
        /// Get or Set for {Column86}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column86
        {
            get => _column86;
            set => _column86 = value;
        }

        private string _column87;
        /// <summary>
        /// Get or Set for {Column87}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column87
        {
            get => _column87;
            set => _column87 = value;
        }

        private string _column88;
        /// <summary>
        /// Get or Set for {Column88}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column88
        {
            get => _column88;
            set => _column88 = value;
        }

        private string _column89;
        /// <summary>
        /// Get or Set for {Column89}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column89
        {
            get => _column89;
            set => _column89 = value;
        }

        private string _column90;
        /// <summary>
        /// Get or Set for {Column90}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column90
        {
            get => _column90;
            set => _column90 = value;
        }

        private string _column91;
        /// <summary>
        /// Get or Set for {Column91}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column91
        {
            get => _column91;
            set => _column91 = value;
        }

        private string _column92;
        /// <summary>
        /// Get or Set for {Column92}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column92
        {
            get => _column92;
            set => _column92 = value;
        }

        private string _column93;
        /// <summary>
        /// Get or Set for {Column93}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column93
        {
            get => _column93;
            set => _column93 = value;
        }

        private string _column94;
        /// <summary>
        /// Get or Set for {Column94}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column94
        {
            get => _column94;
            set => _column94 = value;
        }

        private string _column95;
        /// <summary>
        /// Get or Set for {Column95}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column95
        {
            get => _column95;
            set => _column95 = value;
        }

        private string _column96;
        /// <summary>
        /// Get or Set for {Column96}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column96
        {
            get => _column96;
            set => _column96 = value;
        }

        private string _column97;
        /// <summary>
        /// Get or Set for {Column97}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column97
        {
            get => _column97;
            set => _column97 = value;
        }

        private string _column98;
        /// <summary>
        /// Get or Set for {Column98}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column98
        {
            get => _column98;
            set => _column98 = value;
        }

        private string _column99;
        /// <summary>
        /// Get or Set for {Column99}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column99
        {
            get => _column99;
            set => _column99 = value;
        }

        private string _column100;
        /// <summary>
        /// Get or Set for {Column100}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column100
        {
            get => _column100;
            set => _column100 = value;
        }

        private string _column101;
        /// <summary>
        /// Get or Set for {Column101}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column101
        {
            get => _column101;
            set => _column101 = value;
        }

        private string _column102;
        /// <summary>
        /// Get or Set for {Column102}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column102
        {
            get => _column102;
            set => _column102 = value;
        }

        private string _column103;
        /// <summary>
        /// Get or Set for {Column103}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column103
        {
            get => _column103;
            set => _column103 = value;
        }

        private string _column104;
        /// <summary>
        /// Get or Set for {Column104}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column104
        {
            get => _column104;
            set => _column104 = value;
        }

        private string _column105;
        /// <summary>
        /// Get or Set for {Column105}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column105
        {
            get => _column105;
            set => _column105 = value;
        }

        private string _column106;
        /// <summary>
        /// Get or Set for {Column106}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column106
        {
            get => _column106;
            set => _column106 = value;
        }

        private string _column107;
        /// <summary>
        /// Get or Set for {Column107}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column107
        {
            get => _column107;
            set => _column107 = value;
        }

        private string _column108;
        /// <summary>
        /// Get or Set for {Column108}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column108
        {
            get => _column108;
            set => _column108 = value;
        }

        private string _column109;
        /// <summary>
        /// Get or Set for {Column109}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column109
        {
            get => _column109;
            set => _column109 = value;
        }

        private string _column110;
        /// <summary>
        /// Get or Set for {Column110}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column110
        {
            get => _column110;
            set => _column110 = value;
        }

        private string _column111;
        /// <summary>
        /// Get or Set for {Column111}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column111
        {
            get => _column111;
            set => _column111 = value;
        }

        private string _column112;
        /// <summary>
        /// Get or Set for {Column112}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column112
        {
            get => _column112;
            set => _column112 = value;
        }

        private string _column113;
        /// <summary>
        /// Get or Set for {Column113}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column113
        {
            get => _column113;
            set => _column113 = value;
        }

        private string _column114;
        /// <summary>
        /// Get or Set for {Column114}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column114
        {
            get => _column114;
            set => _column114 = value;
        }

        private string _column115;
        /// <summary>
        /// Get or Set for {Column115}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column115
        {
            get => _column115;
            set => _column115 = value;
        }

        private string _column116;
        /// <summary>
        /// Get or Set for {Column116}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column116
        {
            get => _column116;
            set => _column116 = value;
        }

        private string _column117;
        /// <summary>
        /// Get or Set for {Column117}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column117
        {
            get => _column117;
            set => _column117 = value;
        }

        private string _column118;
        /// <summary>
        /// Get or Set for {Column118}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column118
        {
            get => _column118;
            set => _column118 = value;
        }

        private string _column119;
        /// <summary>
        /// Get or Set for {Column119}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column119
        {
            get => _column119;
            set => _column119 = value;
        }

        private string _column120;
        /// <summary>
        /// Get or Set for {Column120}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column120
        {
            get => _column120;
            set => _column120 = value;
        }

        private string _column121;
        /// <summary>
        /// Get or Set for {Column121}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column121
        {
            get => _column121;
            set => _column121 = value;
        }

        private string _column122;
        /// <summary>
        /// Get or Set for {Column122}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column122
        {
            get => _column122;
            set => _column122 = value;
        }

        private string _column123;
        /// <summary>
        /// Get or Set for {Column123}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column123
        {
            get => _column123;
            set => _column123 = value;
        }

        private string _column124;
        /// <summary>
        /// Get or Set for {Column124}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column124
        {
            get => _column124;
            set => _column124 = value;
        }

        private string _column125;
        /// <summary>
        /// Get or Set for {Column125}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column125
        {
            get => _column125;
            set => _column125 = value;
        }

        private string _column126;
        /// <summary>
        /// Get or Set for {Column126}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column126
        {
            get => _column126;
            set => _column126 = value;
        }

        private string _column127;
        /// <summary>
        /// Get or Set for {Column127}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column127
        {
            get => _column127;
            set => _column127 = value;
        }

        private string _column128;
        /// <summary>
        /// Get or Set for {Column128}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column128
        {
            get => _column128;
            set => _column128 = value;
        }

        private string _column129;
        /// <summary>
        /// Get or Set for {Column129}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column129
        {
            get => _column129;
            set => _column129 = value;
        }

        private string _column130;
        /// <summary>
        /// Get or Set for {Column130}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column130
        {
            get => _column130;
            set => _column130 = value;
        }

        private string _column131;
        /// <summary>
        /// Get or Set for {Column131}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column131
        {
            get => _column131;
            set => _column131 = value;
        }

        private string _column132;
        /// <summary>
        /// Get or Set for {Column132}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column132
        {
            get => _column132;
            set => _column132 = value;
        }

        private string _column133;
        /// <summary>
        /// Get or Set for {Column133}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column133
        {
            get => _column133;
            set => _column133 = value;
        }

        private string _column134;
        /// <summary>
        /// Get or Set for {Column134}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column134
        {
            get => _column134;
            set => _column134 = value;
        }

        private string _column135;
        /// <summary>
        /// Get or Set for {Column135}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column135
        {
            get => _column135;
            set => _column135 = value;
        }

        private string _column136;
        /// <summary>
        /// Get or Set for {Column136}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column136
        {
            get => _column136;
            set => _column136 = value;
        }

        private string _column137;
        /// <summary>
        /// Get or Set for {Column137}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column137
        {
            get => _column137;
            set => _column137 = value;
        }

        private string _column138;
        /// <summary>
        /// Get or Set for {Column138}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column138
        {
            get => _column138;
            set => _column138 = value;
        }

        private string _column139;
        /// <summary>
        /// Get or Set for {Column139}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column139
        {
            get => _column139;
            set => _column139 = value;
        }

        private string _column140;
        /// <summary>
        /// Get or Set for {Column140}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column140
        {
            get => _column140;
            set => _column140 = value;
        }

        private string _column141;
        /// <summary>
        /// Get or Set for {Column141}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column141
        {
            get => _column141;
            set => _column141 = value;
        }

        private string _column142;
        /// <summary>
        /// Get or Set for {Column142}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column142
        {
            get => _column142;
            set => _column142 = value;
        }

        private string _column143;
        /// <summary>
        /// Get or Set for {Column143}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column143
        {
            get => _column143;
            set => _column143 = value;
        }

        private string _column144;
        /// <summary>
        /// Get or Set for {Column144}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column144
        {
            get => _column144;
            set => _column144 = value;
        }

        private string _column145;
        /// <summary>
        /// Get or Set for {Column145}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column145
        {
            get => _column145;
            set => _column145 = value;
        }

        private string _column146;
        /// <summary>
        /// Get or Set for {Column146}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column146
        {
            get => _column146;
            set => _column146 = value;
        }

        private string _column147;
        /// <summary>
        /// Get or Set for {Column147}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column147
        {
            get => _column147;
            set => _column147 = value;
        }

        private string _column148;
        /// <summary>
        /// Get or Set for {Column148}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column148
        {
            get => _column148;
            set => _column148 = value;
        }

        private string _column149;
        /// <summary>
        /// Get or Set for {Column149}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column149
        {
            get => _column149;
            set => _column149 = value;
        }

        private string _column150;
        /// <summary>
        /// Get or Set for {Column150}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column150
        {
            get => _column150;
            set => _column150 = value;
        }

        private string _column151;
        /// <summary>
        /// Get or Set for {Column151}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column151
        {
            get => _column151;
            set => _column151 = value;
        }

        private string _column152;
        /// <summary>
        /// Get or Set for {Column152}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column152
        {
            get => _column152;
            set => _column152 = value;
        }

        private string _column153;
        /// <summary>
        /// Get or Set for {Column153}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column153
        {
            get => _column153;
            set => _column153 = value;
        }

        private string _column154;
        /// <summary>
        /// Get or Set for {Column154}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column154
        {
            get => _column154;
            set => _column154 = value;
        }

        private string _column155;
        /// <summary>
        /// Get or Set for {Column155}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column155
        {
            get => _column155;
            set => _column155 = value;
        }

        private string _column156;
        /// <summary>
        /// Get or Set for {Column156}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column156
        {
            get => _column156;
            set => _column156 = value;
        }

        private string _column157;
        /// <summary>
        /// Get or Set for {Column157}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column157
        {
            get => _column157;
            set => _column157 = value;
        }

        private string _column158;
        /// <summary>
        /// Get or Set for {Column158}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column158
        {
            get => _column158;
            set => _column158 = value;
        }

        private string _column159;
        /// <summary>
        /// Get or Set for {Column159}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column159
        {
            get => _column159;
            set => _column159 = value;
        }

        private string _column160;
        /// <summary>
        /// Get or Set for {Column160}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column160
        {
            get => _column160;
            set => _column160 = value;
        }

        private string _column161;
        /// <summary>
        /// Get or Set for {Column161}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column161
        {
            get => _column161;
            set => _column161 = value;
        }

        private string _column162;
        /// <summary>
        /// Get or Set for {Column162}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column162
        {
            get => _column162;
            set => _column162 = value;
        }

        private string _column163;
        /// <summary>
        /// Get or Set for {Column163}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column163
        {
            get => _column163;
            set => _column163 = value;
        }

        private string _column164;
        /// <summary>
        /// Get or Set for {Column164}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column164
        {
            get => _column164;
            set => _column164 = value;
        }

        private string _column165;
        /// <summary>
        /// Get or Set for {Column165}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column165
        {
            get => _column165;
            set => _column165 = value;
        }

        private string _column166;
        /// <summary>
        /// Get or Set for {Column166}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column166
        {
            get => _column166;
            set => _column166 = value;
        }

        private string _column167;
        /// <summary>
        /// Get or Set for {Column167}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column167
        {
            get => _column167;
            set => _column167 = value;
        }

        private string _column168;
        /// <summary>
        /// Get or Set for {Column168}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column168
        {
            get => _column168;
            set => _column168 = value;
        }

        private string _column169;
        /// <summary>
        /// Get or Set for {Column169}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column169
        {
            get => _column169;
            set => _column169 = value;
        }

        private string _column170;
        /// <summary>
        /// Get or Set for {Column170}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column170
        {
            get => _column170;
            set => _column170 = value;
        }

        private string _column171;
        /// <summary>
        /// Get or Set for {Column171}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column171
        {
            get => _column171;
            set => _column171 = value;
        }

        private string _column172;
        /// <summary>
        /// Get or Set for {Column172}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column172
        {
            get => _column172;
            set => _column172 = value;
        }

        private string _column173;
        /// <summary>
        /// Get or Set for {Column173}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column173
        {
            get => _column173;
            set => _column173 = value;
        }

        private string _column174;
        /// <summary>
        /// Get or Set for {Column174}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column174
        {
            get => _column174;
            set => _column174 = value;
        }

        private string _column175;
        /// <summary>
        /// Get or Set for {Column175}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column175
        {
            get => _column175;
            set => _column175 = value;
        }

        private string _column176;
        /// <summary>
        /// Get or Set for {Column176}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column176
        {
            get => _column176;
            set => _column176 = value;
        }

        private string _column177;
        /// <summary>
        /// Get or Set for {Column177}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column177
        {
            get => _column177;
            set => _column177 = value;
        }

        private string _column178;
        /// <summary>
        /// Get or Set for {Column178}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column178
        {
            get => _column178;
            set => _column178 = value;
        }

        private string _column179;
        /// <summary>
        /// Get or Set for {Column179}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column179
        {
            get => _column179;
            set => _column179 = value;
        }

        private string _column180;
        /// <summary>
        /// Get or Set for {Column180}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column180
        {
            get => _column180;
            set => _column180 = value;
        }

        private string _column181;
        /// <summary>
        /// Get or Set for {Column181}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column181
        {
            get => _column181;
            set => _column181 = value;
        }

        private string _column182;
        /// <summary>
        /// Get or Set for {Column182}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column182
        {
            get => _column182;
            set => _column182 = value;
        }

        private string _column183;
        /// <summary>
        /// Get or Set for {Column183}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column183
        {
            get => _column183;
            set => _column183 = value;
        }

        private string _column184;
        /// <summary>
        /// Get or Set for {Column184}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column184
        {
            get => _column184;
            set => _column184 = value;
        }

        private string _column185;
        /// <summary>
        /// Get or Set for {Column185}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column185
        {
            get => _column185;
            set => _column185 = value;
        }

        private string _column186;
        /// <summary>
        /// Get or Set for {Column186}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column186
        {
            get => _column186;
            set => _column186 = value;
        }

        private string _column187;
        /// <summary>
        /// Get or Set for {Column187}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column187
        {
            get => _column187;
            set => _column187 = value;
        }

        private string _column188;
        /// <summary>
        /// Get or Set for {Column188}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column188
        {
            get => _column188;
            set => _column188 = value;
        }

        private string _column189;
        /// <summary>
        /// Get or Set for {Column189}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column189
        {
            get => _column189;
            set => _column189 = value;
        }

        private string _column190;
        /// <summary>
        /// Get or Set for {Column190}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column190
        {
            get => _column190;
            set => _column190 = value;
        }

        private string _column191;
        /// <summary>
        /// Get or Set for {Column191}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column191
        {
            get => _column191;
            set => _column191 = value;
        }

        private string _column192;
        /// <summary>
        /// Get or Set for {Column192}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column192
        {
            get => _column192;
            set => _column192 = value;
        }

        private string _column193;
        /// <summary>
        /// Get or Set for {Column193}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column193
        {
            get => _column193;
            set => _column193 = value;
        }

        private string _column194;
        /// <summary>
        /// Get or Set for {Column194}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column194
        {
            get => _column194;
            set => _column194 = value;
        }

        private string _column195;
        /// <summary>
        /// Get or Set for {Column195}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column195
        {
            get => _column195;
            set => _column195 = value;
        }

        private string _column196;
        /// <summary>
        /// Get or Set for {Column196}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column196
        {
            get => _column196;
            set => _column196 = value;
        }

        private string _column197;
        /// <summary>
        /// Get or Set for {Column197}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column197
        {
            get => _column197;
            set => _column197 = value;
        }

        private string _column198;
        /// <summary>
        /// Get or Set for {Column198}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column198
        {
            get => _column198;
            set => _column198 = value;
        }

        private string _column199;
        /// <summary>
        /// Get or Set for {Column199}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column199
        {
            get => _column199;
            set => _column199 = value;
        }

        private string _column200;
        /// <summary>
        /// Get or Set for {Column200}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column200
        {
            get => _column200;
            set => _column200 = value;
        }

        private string _column201;
        /// <summary>
        /// Get or Set for {Column201}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column201
        {
            get => _column201;
            set => _column201 = value;
        }

        private string _column202;
        /// <summary>
        /// Get or Set for {Column202}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column202
        {
            get => _column202;
            set => _column202 = value;
        }

        private string _column203;
        /// <summary>
        /// Get or Set for {Column203}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column203
        {
            get => _column203;
            set => _column203 = value;
        }

        private string _column204;
        /// <summary>
        /// Get or Set for {Column204}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column204
        {
            get => _column204;
            set => _column204 = value;
        }

        private string _column205;
        /// <summary>
        /// Get or Set for {Column205}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column205
        {
            get => _column205;
            set => _column205 = value;
        }

        private string _column206;
        /// <summary>
        /// Get or Set for {Column206}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column206
        {
            get => _column206;
            set => _column206 = value;
        }

        private string _column207;
        /// <summary>
        /// Get or Set for {Column207}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column207
        {
            get => _column207;
            set => _column207 = value;
        }

        private string _column208;
        /// <summary>
        /// Get or Set for {Column208}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column208
        {
            get => _column208;
            set => _column208 = value;
        }

        private string _column209;
        /// <summary>
        /// Get or Set for {Column209}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column209
        {
            get => _column209;
            set => _column209 = value;
        }

        private string _column210;
        /// <summary>
        /// Get or Set for {Column210}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column210
        {
            get => _column210;
            set => _column210 = value;
        }

        private string _column211;
        /// <summary>
        /// Get or Set for {Column211}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column211
        {
            get => _column211;
            set => _column211 = value;
        }

        private string _column212;
        /// <summary>
        /// Get or Set for {Column212}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column212
        {
            get => _column212;
            set => _column212 = value;
        }

        private string _column213;
        /// <summary>
        /// Get or Set for {Column213}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column213
        {
            get => _column213;
            set => _column213 = value;
        }

        private string _column214;
        /// <summary>
        /// Get or Set for {Column214}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column214
        {
            get => _column214;
            set => _column214 = value;
        }

        private string _column215;
        /// <summary>
        /// Get or Set for {Column215}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column215
        {
            get => _column215;
            set => _column215 = value;
        }

        private string _column216;
        /// <summary>
        /// Get or Set for {Column216}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column216
        {
            get => _column216;
            set => _column216 = value;
        }

        private string _column217;
        /// <summary>
        /// Get or Set for {Column217}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column217
        {
            get => _column217;
            set => _column217 = value;
        }

        private string _column218;
        /// <summary>
        /// Get or Set for {Column218}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column218
        {
            get => _column218;
            set => _column218 = value;
        }

        private string _column219;
        /// <summary>
        /// Get or Set for {Column219}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column219
        {
            get => _column219;
            set => _column219 = value;
        }

        private string _column220;
        /// <summary>
        /// Get or Set for {Column220}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column220
        {
            get => _column220;
            set => _column220 = value;
        }

        private string _column221;
        /// <summary>
        /// Get or Set for {Column221}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column221
        {
            get => _column221;
            set => _column221 = value;
        }

        private string _column222;
        /// <summary>
        /// Get or Set for {Column222}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column222
        {
            get => _column222;
            set => _column222 = value;
        }

        private string _column223;
        /// <summary>
        /// Get or Set for {Column223}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column223
        {
            get => _column223;
            set => _column223 = value;
        }

        private string _column224;
        /// <summary>
        /// Get or Set for {Column224}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column224
        {
            get => _column224;
            set => _column224 = value;
        }

        private string _columnFields;
        /// <summary>
        /// Get or Set for {ColumnFields}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ColumnFields
        {
            get => _columnFields;
            set => _columnFields = value;
        }

        private string _columnRemarks;
        /// <summary>
        /// Get or Set for {ColumnRemarks}.
        /// </summary>
        [DataMember]
        [StringLength(int.MaxValue)]
        public string ColumnRemarks
        {
            get => _columnRemarks;
            set => _columnRemarks = value;
        }

        private string _column225;
        /// <summary>
        /// Get or Set for {Column225}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column225
        {
            get => _column225;
            set => _column225 = value;
        }

        private string _column226;
        /// <summary>
        /// Get or Set for {Column226}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column226
        {
            get => _column226;
            set => _column226 = value;
        }

        private string _column227;
        /// <summary>
        /// Get or Set for {Column227}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Column227
        {
            get => _column227;
            set => _column227 = value;
        }
    }

    /// <summary>
    /// Data Contract use for PurchasingReport Service in DaysOfDemandSettings endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class MaterialShortageReportDHSProcedureParameterModel
    {
        /// <summary>
        /// Local variable _businessUnitCode     
        /// </summary>
        private string _businessUnitCode;
        /// <summary>
        /// Get or Set for {BusinessUnitCode}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }

        /// <summary>
        /// Local variable _supplierCode     
        /// </summary>
        private string _supplierCode;
        /// <summary>
        /// Get or Set for {SupplierCode}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        /// Local variable _fromDate     
        /// </summary>
        private DateTime _fromDate;
        /// <summary>
        /// Get or Set for {FromDate}.
        /// </summary>
        [DataMember]
        public DateTime FromDate
        {
            get => _fromDate;
            set => _fromDate = value;
        }

        /// Local variable _toDate     
        /// </summary>
        private DateTime _toDate;
        /// <summary>
        /// Get or Set for {ToDate}.
        /// </summary>
        [DataMember]
        public DateTime ToDate
        {
            get => _toDate;
            set => _toDate = value;
        }

        /// <summary>
        /// Local variable _sortOrder     
        /// </summary>
        private string _sortOrder;
        /// <summary>
        /// Get or Set for {SortOrder}.
        /// </summary>
        [DataMember]
        [StringLength(1)]
        public string SortOrder
        {
            get => _sortOrder;
            set => _sortOrder = value;
        }
    }
}
