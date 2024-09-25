/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FileUploadFilterModel.cs
Function           :   Data contract for File Upload Filtered Data
Created By         :   Shivam Dhingra
Created on         :   23-Feb-2021
Revision History   :
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data Contract for FileUploadFilterModel
    /// </summary>
    [DataContract, Serializable]
    public class FileUploadFilterModel
    {
        private Guid _reportSectionGuid;
        /// <summary>
        /// This field will set _reportSectionGuid
        /// </summary>
        [DataMember]
        public Guid ReportSectionGuid
        {
            get => _reportSectionGuid;
            set => _reportSectionGuid = value;
        }

        private string _filePath;
        /// <summary>
        /// This field will set FilePath
        /// </summary>
        [DataMember]
        public string FilePath
        {
            get => _filePath;
            set => _filePath = value;
        }

    }
}
