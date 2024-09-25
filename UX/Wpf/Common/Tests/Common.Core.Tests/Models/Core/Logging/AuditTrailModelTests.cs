using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Logging
{
    [TestClass]
    public class AuditTrailModelTests
    {
        [TestMethod]
        public void GetModelName_ReturnsNull()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel();

            //act
            var result = auditTrailModel.ModelName;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetModelName_IsSuccessful()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel { ModelName = "ModelName" };

            //act
            var result = auditTrailModel.ModelName;

            //assert
            Assert.AreEqual("ModelName", result);
        }
  
        [TestMethod]
        public void GetFieldName_ReturnsNull()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel();

            //act
            var result = auditTrailModel.FieldName;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetFieldName_IsSuccessful()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel { FieldName = "FieldName" };

            //act
            var result = auditTrailModel.FieldName;

            //assert
            Assert.AreEqual("FieldName", result);
        }
  
        [TestMethod]
        public void GetNewValue_ReturnsNull()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel();

            //act
            var result = auditTrailModel.NewValue;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetNewValue_IsSuccessful()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel { NewValue = "NewValue" };

            //act
            var result = auditTrailModel.NewValue;

            //assert
            Assert.AreEqual("NewValue", result);
        }
  
        [TestMethod]
        public void GetOldValue_ReturnsNull()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel();

            //act
            var result = auditTrailModel.OldValue;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetOldValue_IsSuccessful()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel { OldValue = "OldValue" };

            //act
            var result = auditTrailModel.OldValue;

            //assert
            Assert.AreEqual("OldValue", result);
        }
  
        [TestMethod]
        public void GetAction_ReturnsNull()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel();

            //act
            var result = auditTrailModel.Action;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetAction_IsSuccessful()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel { Action = "Action" };

            //act
            var result = auditTrailModel.Action;

            //assert
            Assert.AreEqual("Action", result);
        }
  
        [TestMethod]
        public void GetItemGuid_ReturnsEmptyGuid()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel();

            //act
            var result = auditTrailModel.ItemGuid;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetItemGuid_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var auditTrailModel = new AuditTrailModel { ItemGuid = id};

            //act
            var result = auditTrailModel.ItemGuid;

            //assert
            Assert.AreEqual(id, result);
        }
  
        [TestMethod]
        public void GetBatchGuid_ReturnsEmptyGuid()
        {
            //arrange
            var id = Guid.NewGuid();
            var auditTrailModel = new AuditTrailModel();

            //act
            var result = auditTrailModel.BatchGuid;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetBatchGuid_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var auditTrailModel = new AuditTrailModel { BatchGuid = id };

            //act
            var result = auditTrailModel.BatchGuid;

            //assert
            Assert.AreEqual(id, result);
        }
  
        [TestMethod]
        public void GetModifiedByUserName_ReturnsNull()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel();

            //act
            var result = auditTrailModel.ModifiedByUserName;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetModifiedByUserName_IsSuccessful()
        {
            //arrange
            var auditTrailModel = new AuditTrailModel { ModifiedByUserName = "ModifiedByUserName" };

            //act
            var result = auditTrailModel.ModifiedByUserName;

            //assert
            Assert.AreEqual("ModifiedByUserName", result);
        }
    }
}
