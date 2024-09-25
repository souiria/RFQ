using System;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class FieldOverrideModelTests
    {
        [TestMethod]
        public void get_ViewId_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var fieldHierarchyModel = new FieldOverrideModel();

            // act
            var result = fieldHierarchyModel.ViewId;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_ViewId_Returns_ViewId()
        {
            // arrange
            var fieldHierarchyModel = new FieldOverrideModel();
            var testGuid = new Guid();

            // act
            fieldHierarchyModel.ViewId = testGuid;
            var result = fieldHierarchyModel.ViewId;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void get_FieldId_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var fieldHierarchyModel = new FieldOverrideModel();

            // act
            var result = fieldHierarchyModel.FieldId;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_FieldId_Returns_FieldId()
        {
            // arrange
            var fieldHierarchyModel = new FieldOverrideModel();
            var testGuid = new Guid();

            // act
            fieldHierarchyModel.FieldId = testGuid;
            var result = fieldHierarchyModel.FieldId;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void GetUserGuid_OnNewObject_ReturnsEmptyGuid()
        {
            // arrange
            var fieldHierarchyModel = new FieldOverrideModel();

            // act
            var result = fieldHierarchyModel.UserGuid;

            // assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void GetUserGuid_AfterAssigning_ReturnsAssignedValue()
        {
            // arrange
            var fieldHierarchyModel = new FieldOverrideModel();
            var testGuid = new Guid();

            // act
            fieldHierarchyModel.UserGuid = testGuid;
            var result = fieldHierarchyModel.UserGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void GetFieldValue_OnNewObject_ReturnsFalse()
        {
            // arrange
            var fieldHierarchyModel = new FieldOverrideModel();

            // act
            var result = fieldHierarchyModel.FieldValue;

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetFieldValue_AfterAssigning_ReturnsAssignedValue()
        {
            // arrange
            var fieldHierarchyModel = new FieldOverrideModel { FieldValue = true };

            // act
            var result = fieldHierarchyModel.FieldValue;

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetVariableName_OnNewObject_ReturnsNull()
        {
            // arrange
            var fieldOverrideModel = new FieldOverrideModel();

            // act
            var result = fieldOverrideModel.VariableName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetVariableName_AfterAssigning_ReturnsAssignedValue()
        {
            // arrange
            var fieldOverrideModel = new FieldOverrideModel { VariableName = "VariableName" };

            // act
            var result = fieldOverrideModel.VariableName;

            // assert
            Assert.AreEqual("VariableName", result);
        }

        [TestMethod]
        public void Constructor_WithGuidParam_IsSuccessful()
        {
            //arrange //act
            var fieldOverrideModel = new FieldOverrideModel(Guid.NewGuid());

            //assert
            Assert.IsNotNull(fieldOverrideModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithFieldHierarchyModelAndGuidParams_WithFieldHierarchyModelParam_BeingNull_ThrowsException()
        {
            //arrange //act
            var fieldOverrideModel = new FieldOverrideModel(null, Guid.Empty);

            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_WithFieldHierarchyModelAndGuidParams_IsSuccessful()
        {
            //arrange //act
            var fieldOverrideModel = new FieldOverrideModel(new FieldHierarchyModel(), Guid.NewGuid());

            //assert
            Assert.IsNotNull(fieldOverrideModel);
        }
    }
}
