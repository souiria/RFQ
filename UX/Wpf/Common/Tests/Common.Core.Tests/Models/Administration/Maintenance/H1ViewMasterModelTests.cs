using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class H1ViewMasterModelTests
    {
        [TestMethod]
        public void get_FunctionName_ReturnsNull()
        {
            // arrange
            var h1ViewMasterModel = new H1ViewMasterModel();

            // act
            var result = h1ViewMasterModel.ViewName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_FunctionName_Returns_FunctionName()
        {
            // arrange
            var h1ViewMasterModel = new H1ViewMasterModel();
            h1ViewMasterModel.ViewName = "ViewName";

            // act
            var result = h1ViewMasterModel.ViewName;

            // assert
            Assert.AreEqual("ViewName", result);
        }

        [TestMethod]
        public void get_ActiveDirectoryName_ReturnsNull()
        {
            // arrange
            var h1FunctionMasterModel = new H1ViewMasterModel();

            // act
            var result = h1FunctionMasterModel.ActiveDirectoryName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_ActiveDirectoryName_Returns_ActiveDirectoryName()
        {
            // arrange
            var h1FunctionMasterModel = new H1ViewMasterModel();
            h1FunctionMasterModel.ActiveDirectoryName = "ActiveDirectoryName";

            // act
            var result = h1FunctionMasterModel.ActiveDirectoryName;

            // assert
            Assert.AreEqual("ActiveDirectoryName", result);
        }
    }
}