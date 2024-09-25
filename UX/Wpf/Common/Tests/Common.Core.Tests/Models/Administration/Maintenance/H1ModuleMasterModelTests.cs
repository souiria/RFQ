using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class H1ModuleMasterModelTests
    {


        [TestMethod]
        public void get_ModuleName_ReturnsNull()
        {
            // arrange
            var h1ModuleMasterModel = new H1ModuleMasterModel();

            // act
            var result = h1ModuleMasterModel.ModuleName;

            // assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void get_ModuleName_ReturnsModuleName()
        {
            // arrange
            var h1ModuleMasterModel = new H1ModuleMasterModel();
            h1ModuleMasterModel.ModuleName = "ModuleName";

            // act
            var result = h1ModuleMasterModel.ModuleName;

            // assert
            Assert.AreEqual("ModuleName", result);
        }
        [TestMethod]
        public void get_ActiveDirectoryName_ReturnsNull()
        {
            // arrange
            var h1ModuleMasterModel = new H1ModuleMasterModel();

            // act
            var result = h1ModuleMasterModel.ActiveDirectoryName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_ActiveDirectoryName_Returns_ActiveDirectoryName()
        {
            // arrange
            var h1ModuleMasterModel = new H1ModuleMasterModel();
            h1ModuleMasterModel.ActiveDirectoryName = "ActiveDirectoryName";

            // act
            var result = h1ModuleMasterModel.ActiveDirectoryName;

            // assert
            Assert.AreEqual("ActiveDirectoryName", result);
        }

    }
}