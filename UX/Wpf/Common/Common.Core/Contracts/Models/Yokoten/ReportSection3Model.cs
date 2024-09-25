/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ReportSection2Model.cs
Function           :   Data contract for Report Section3
Created By         :   Srashti Gupta
Created on         :   19-March-2020
Revision History   :   [19-May-2020] : Pawan
                   :   [] : Changed file upload model
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class ReportSection3Model : BaseModel<Guid>
    {
        private string _submittedBy;
        /// <summary>
        /// This field will set SubmittedBy
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string SubmittedBy
        {
            get => _submittedBy;
            set => SetProperty(ref _submittedBy, value);
        }

        private string _department;
        /// <summary>
        /// This field will set Department
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string Department
        {
            get => _department;
            set => SetProperty(ref _department, value);
        }

        private DateTime? _dateSubmitted;
        /// <summary>
        /// This field will set DateSubmitted
        /// </summary>
        [DataMember]
        public DateTime? DateSubmitted
        {
            get => _dateSubmitted;
            set => SetProperty(ref _dateSubmitted, value);
        }

        private string _raisedBy;
        /// <summary>
        /// This field will set RaisedBy
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string RaisedBy
        {
            get => _raisedBy;
            set => SetProperty(ref _raisedBy, value);
        }

        private List<FileUploadModel> _documentList;
        /// <summary>
        /// This field will set DocumentList
        /// </summary>
        [DataMember]
        public List<FileUploadModel> DocumentList
        {
            get => _documentList;
            set => SetProperty(ref _documentList, value);
        }
    }

    /// <summary>
    /// List for FileUpload Model
    /// </summary>
    public class FileUploadModel
    {
        private Guid _fileUploadId = Guid.NewGuid();
        /// <summary>
        /// This will assign Guid to each files
        /// </summary>
        [DataMember]
        public Guid FileUploadId { get => _fileUploadId; set => _fileUploadId = value; }

        private string _fileName;
        /// <summary>
        /// This field will set FileName
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _filePath;
        /// <summary>
        /// This field will set FilePath
        /// </summary>
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        private byte[] _fileContent;
        /// <summary>
        /// This field will set FileContent
        /// </summary>
        [NotMapped, DataMember]
        public byte[] FileContent
        {
            get { return _fileContent; }
            set { _fileContent = value; }
        }
    }
}
