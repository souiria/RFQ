using System;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Logging
{
    #region Classes
    public class SampleAuditModel
    {
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public Guid ModifiedBy { get; set; } = Guid.NewGuid();
        public Guid CreatedBy { get; set; } = Guid.NewGuid();
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public CrudOperationType CrudOperationType { get; set; } = CrudOperationType.Update;
    }
    public class NoModifiedDateSampleAuditModel
    {
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public Guid ModifiedBy { get; set; } = Guid.NewGuid();
        public Guid CreatedBy { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public CrudOperationType CrudOperationType { get; set; } = CrudOperationType.Update;
    }
    public class NoCreatedDateSampleAuditModel
    {
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public Guid ModifiedBy { get; set; } = Guid.NewGuid();
        public Guid CreatedBy { get; set; } = Guid.NewGuid();
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public CrudOperationType CrudOperationType { get; set; } = CrudOperationType.Update;
    }
    public class NoCreatedBySampleAuditModel
    {
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public Guid ModifiedBy { get; set; } = Guid.NewGuid();
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public CrudOperationType CrudOperationType { get; set; } = CrudOperationType.Update;
    }
    public class NoModifiedBySampleAuditModel
    {
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public Guid CreatedBy { get; set; } = Guid.NewGuid();
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public CrudOperationType CrudOperationType { get; set; } = CrudOperationType.Update;
    }
    public class NoCrudOperationTypeSampleAuditModel
    {
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public Guid ModifiedBy { get; set; } = Guid.NewGuid();
        public Guid CreatedBy { get; set; } = Guid.NewGuid();
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

    public class NoIdSampleAuditModel
    {
        [DataMember]
        public string Name { get; set; }
        public Guid ModifiedBy { get; set; } = Guid.NewGuid();
        public Guid CreatedBy { get; set; } = Guid.NewGuid();
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public CrudOperationType CrudOperationType { get; set; } = CrudOperationType.Update;
    }

    #endregion

    [TestClass]
    public class AuditLoggingModelTests
    {
        [TestMethod]
        public void GetIsAuditLoggingEnabled_ReturnsTrue()
        {
            //arrange
            var auditLoggingModel = new AuditLoggingModel();

            //act
            var result = auditLoggingModel.IsAuditLoggingEnabled;

            //assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SetIsAuditLoggingEnabled_IsSuccessful()
        {
            //arrange
            var auditLoggingModel = new AuditLoggingModel { IsAuditLoggingEnabled = null };

            //act
            var result = auditLoggingModel.IsAuditLoggingEnabled;

            //assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetAuditLoggingDBConnection_H1ConfigurationSettingGuid_ReturnsEmptyGuid()
        {
            //arrange
            var auditLoggingModel = new AuditLoggingModel();

            //act
            var result = auditLoggingModel.AuditLoggingDBConnection_H1ConfigurationSettingGuid;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetAuditLoggingDBConnection_H1ConfigurationSettingGuid_IsSuccessful()
        {
            //arrange
            var guid = Guid.NewGuid();
            var auditLoggingModel = new AuditLoggingModel { AuditLoggingDBConnection_H1ConfigurationSettingGuid = guid };

            //act
            var result = auditLoggingModel.AuditLoggingDBConnection_H1ConfigurationSettingGuid;

            //assert
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void GetItemDifferenceForAudit_IsSuccessful()
        {
            //arrange
            var auditLoggingModel = new AuditLoggingModel();
            var id = Guid.NewGuid();
            var beforeChanges = new SampleAuditModel { Id = id, Name = "SampleObject" };
            var afterChanges = new SampleAuditModel { Id = id, Name = "Sample" };

            //act
            var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, new string[] { });
            var nameAudit = result.First();

            //assert
            Assert.IsNotNull(nameAudit);
            Assert.AreEqual(id, nameAudit.ItemGuid);
            Assert.AreEqual("SampleObject", nameAudit.OldValue);
            Assert.AreEqual("Sample", nameAudit.NewValue);
        }

        [TestMethod]
        public void GetItemDifferenceForAudit_WhenCrudOperationTypeIsRead_DoNotAudit()
        {
            //arrange
            var auditLoggingModel = new AuditLoggingModel();
            var id = Guid.NewGuid();
            var beforeChanges = new SampleAuditModel { Id = id, Name = "SampleObject", CrudOperationType = CrudOperationType.Read };
            var afterChanges = new SampleAuditModel { Id = id, Name = "Sample", CrudOperationType = CrudOperationType.Read };

            //act
            var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, new string[] { });

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        //[TestMethod]
        //public void GetItemDifferenceForAudit_WhenIdPropertyDoesNotExist_DoNotAudit()
        //{
        //    //arrange
        //    var auditLoggingModel = new AuditLoggingModel();
        //    var beforeChanges = new NoIdSampleAuditModel { Name = "SampleObject" };
        //    var afterChanges = new NoIdSampleAuditModel { Name = "Sample" };

        //    //act
        //    var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, new string[] { });

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(0, result.Count);
        //}

        //[TestMethod]
        //public void GetItemDifferenceForAudit_WhenCrudOperationTypePropertyDoesNotExist_DoNotAudit()
        //{
        //    //arrange
        //    var auditLoggingModel = new AuditLoggingModel();
        //    var id = Guid.NewGuid();
        //    var beforeChanges = new NoCrudOperationTypeSampleAuditModel { Id = id, Name = "SampleObject" };
        //    var afterChanges = new NoCrudOperationTypeSampleAuditModel { Id = id, Name = "Sample" };

        //    //act
        //    var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, new string[] { });

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(0, result.Count);
        //}

        //[TestMethod]
        //public void GetItemDifferenceForAudit_WhenModifiedByPropertyDoesNotExist_DoNotAudit()
        //{
        //    //arrange
        //    var auditLoggingModel = new AuditLoggingModel();
        //    var id = Guid.NewGuid();
        //    var beforeChanges = new NoModifiedBySampleAuditModel { Id = id, Name = "SampleObject" };
        //    var afterChanges = new NoModifiedBySampleAuditModel { Id = id, Name = "Sample" };

        //    //act
        //    var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, new string[] { });

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(0, result.Count);
        //}

        //[TestMethod]
        //public void GetItemDifferenceForAudit_WhenCreatedByPropertyDoesNotExist_DoNotAudit()
        //{
        //    //arrange
        //    var auditLoggingModel = new AuditLoggingModel();
        //    var id = Guid.NewGuid();
        //    var beforeChanges = new NoCreatedBySampleAuditModel { Id = id, Name = "SampleObject" };
        //    var afterChanges = new NoCreatedBySampleAuditModel { Id = id, Name = "Sample" };

        //    //act
        //    var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, new string[] { });

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(0, result.Count);
        //}

        //[TestMethod]
        //public void GetItemDifferenceForAudit_WhenCreatedDatePropertyDoesNotExist_DoNotAudit()
        //{
        //    //arrange
        //    var auditLoggingModel = new AuditLoggingModel();
        //    var id = Guid.NewGuid();
        //    var beforeChanges = new NoCreatedDateSampleAuditModel { Id = id, Name = "SampleObject" };
        //    var afterChanges = new NoCreatedDateSampleAuditModel { Id = id, Name = "Sample" };

        //    //act
        //    var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, new string[] { });

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(0, result.Count);
        //}

        //[TestMethod]
        //public void GetItemDifferenceForAudit_WhenModifiedDatePropertyDoesNotExist_DoNotAudit()
        //{
        //    //arrange
        //    var auditLoggingModel = new AuditLoggingModel();
        //    var id = Guid.NewGuid();
        //    var beforeChanges = new NoModifiedDateSampleAuditModel { Id = id, Name = "SampleObject" };
        //    var afterChanges = new NoModifiedDateSampleAuditModel { Id = id, Name = "Sample" };

        //    //act
        //    var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, new string[] { });

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(0, result.Count);
        //}

        [TestMethod]
        public void GetItemDifferenceForAudit_When1stParamIsNull_DoNotAudit()
        {
            //arrange
            var auditLoggingModel = new AuditLoggingModel();
            var id = Guid.NewGuid();
            var afterChanges = new SampleAuditModel { Id = id, Name = "Sample" };

            //act
            var result = auditLoggingModel.GetItemDifferencesForAudit(null, afterChanges, new string[] { });

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetItemDifferenceForAudit_When2ndParamIsNull_DoNotAudit()
        {
            //arrange
            var auditLoggingModel = new AuditLoggingModel();
            var id = Guid.NewGuid();
            var beforeChanges = new SampleAuditModel { Id = id, Name = "SampleObject" };

            //act
            var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, null, new string[] { });

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        //[TestMethod]
        //public void GetItemDifferenceForAudit_When3rdParamIsNull_DoNotAudit()
        //{
        //    //arrange
        //    var auditLoggingModel = new AuditLoggingModel();
        //    var id = Guid.NewGuid();
        //    var beforeChanges = new SampleAuditModel { Id = id, Name = "SampleObject" };
        //    var afterChanges = new SampleAuditModel { Id = id, Name = "Sample" };

        //    //act
        //    var result = auditLoggingModel.GetItemDifferencesForAudit(beforeChanges, afterChanges, null);

        //    //assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(0, result.Count);
        //}

        //TODO: Add test for when property is not public
        //TODO: Add test for when property cannot be read
        //TODO: Add test for when property does not have an attribute attached
        //TODO: Add test for when property has the NotMappedAttribute attached
    }
}
