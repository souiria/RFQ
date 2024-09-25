using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class H1FieldMasterModelTests
    {
        [TestMethod]
        public void get_FieldName_ReturnsNull()
        {
            // arrange
            var h1FieldMasterModel = new H1FieldMasterModel();

            // act
            var result = h1FieldMasterModel.FieldName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_FieldName_ReturnsFieldName()
        {
            // arrange
            var fieldHierarchyModel = new FieldHierarchyModel();
            fieldHierarchyModel.FieldName = "FieldName";

            // act
            var result = fieldHierarchyModel.FieldName;

            // assert
            Assert.AreEqual("FieldName", result);
        }

        [TestMethod]
        public void get_FieldDescription_ReturnsNull()
        {
            // arrange
            var h1FieldMasterModel = new H1FieldMasterModel();

            // act
            var result = h1FieldMasterModel.FieldDescription;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_FieldDescription_ReturnsFieldDescription()
        {
            // arrange
            var fieldHierarchyModel = new FieldHierarchyModel();
            fieldHierarchyModel.FieldDescription = "FieldDescription";

            // act
            var result = fieldHierarchyModel.FieldDescription;

            // assert
            Assert.AreEqual("FieldDescription", result);
        }

        [TestMethod]
        public void get_VariableName_ReturnsVariableName()
        {
            // arrange
            var h1FieldMasterModel = new H1FieldMasterModel();
            h1FieldMasterModel.VariableName = "VariableName";

            // act
            var result = h1FieldMasterModel.VariableName;

            // assert
            Assert.AreEqual("VariableName", result);
        }

    }
}