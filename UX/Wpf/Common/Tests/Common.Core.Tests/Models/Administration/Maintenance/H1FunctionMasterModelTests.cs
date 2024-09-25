using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class H1FunctionMasterModelTests
    {
        [TestMethod]
        public void get_FunctionName_ReturnsNull()
        {
            // arrange
            var h1FunctionMasterModel = new H1FunctionMasterModel();

            // act
            var result = h1FunctionMasterModel.FunctionName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_FunctionName_Returns_FunctionName()
        {
            // arrange
            var h1FunctionMasterModel = new H1FunctionMasterModel();
            h1FunctionMasterModel.FunctionName = "FunctionName";

            // act
            var result = h1FunctionMasterModel.FunctionName;

            // assert
            Assert.AreEqual("FunctionName", result);
        }

        [TestMethod]
        public void get_ActiveDirectoryName_ReturnsNull()
        {
            // arrange
            var h1FunctionMasterModel = new H1FunctionMasterModel();

            // act
            var result = h1FunctionMasterModel.ActiveDirectoryName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_ActiveDirectoryName_Returns_ActiveDirectoryName()
        {
            // arrange
            var h1FunctionMasterModel = new H1FunctionMasterModel();
            h1FunctionMasterModel.ActiveDirectoryName = "ActiveDirectoryName";

            // act
            var result = h1FunctionMasterModel.ActiveDirectoryName;

            // assert
            Assert.AreEqual("ActiveDirectoryName", result);
        }

    }
}