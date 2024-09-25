using System;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class FieldHierarchyModelTests
    {
        [TestMethod]
        public void Get_IsSelected_ReturnsNull()
        {
            // arrange
            var fieldHierarchyModel = new FieldHierarchyModel();
            fieldHierarchyModel.IsSelected = null;

            // act
            var result = fieldHierarchyModel.IsSelected;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_IsSelected_Returns_IsSelected()
        {
            // arrange
            var fieldHierarchyModel = new FieldHierarchyModel();
            fieldHierarchyModel.IsSelected = true;

            // act
            var result = fieldHierarchyModel.IsSelected;

            // assert
            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        public void Get_ViewId_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var fieldHierarchyModel = new FieldHierarchyModel();

            // act
            var result = fieldHierarchyModel.ViewId;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_ViewId_Returns_ViewId()
        {
            // arrange
            var fieldHierarchyModel = new FieldHierarchyModel();
            var testGuid = new Guid();

            // act
            fieldHierarchyModel.ViewId = testGuid;
            var result = fieldHierarchyModel.ViewId;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void Get_FieldSecurityGuid_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var fieldHierarchyModel = new FieldHierarchyModel();

            // act
            var result = fieldHierarchyModel.FieldSecurityGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void Set_FieldSecurityGuid_Returns_FieldSecurityGuid()
        {
            // arrange
            var fieldHierarchyModel = new FieldHierarchyModel();
            var testGuid = new Guid();

            // act
            fieldHierarchyModel.FieldSecurityGuid = testGuid;
            var result = fieldHierarchyModel.FieldSecurityGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void H1FieldMasterModel_Null_In_Constructor_Throws_Exception()
        {
            new FieldHierarchyModel(null);

            Assert.Fail();
        }

        [TestMethod]
        public void H1FieldMasterModel_Constructor_Is_Successful()
        {
            //arrange
            var masterModel = new H1FieldMasterModel
            {
                Id = Guid.NewGuid(),
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                CrudOperationType = CrudOperationType.Create,
                FieldName = "FieldName",
                FieldDescription = "FieldDescription",
                VariableName = "VariableName",
                IsActive = false,
                IsRowChecked = null,
                ModifiedBy = Guid.NewGuid(),
                ModifiedDate = DateTime.UtcNow
            };

            //act
            var fieldHierarchyModel = new FieldHierarchyModel(masterModel);

            //assert
            Assert.AreEqual(masterModel.Id, fieldHierarchyModel.Id);
            Assert.AreEqual(masterModel.CreatedBy, fieldHierarchyModel.CreatedBy);
            Assert.AreEqual(masterModel.CreatedDate, fieldHierarchyModel.CreatedDate);
            Assert.AreEqual(masterModel.CrudOperationType, fieldHierarchyModel.CrudOperationType);
            Assert.AreEqual(masterModel.FieldName, fieldHierarchyModel.FieldName);
            Assert.AreEqual(masterModel.FieldDescription, fieldHierarchyModel.FieldDescription);
            Assert.AreEqual(masterModel.VariableName, fieldHierarchyModel.VariableName);
            Assert.AreEqual(masterModel.IsActive, fieldHierarchyModel.IsActive);
            Assert.AreEqual(masterModel.IsRowChecked, fieldHierarchyModel.IsRowChecked);
            Assert.AreEqual(masterModel.ModifiedBy, fieldHierarchyModel.ModifiedBy);
            Assert.AreEqual(masterModel.ModifiedDate, fieldHierarchyModel.ModifiedDate);
        }
    }
}
