using System;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class RoleModelTests
    {
        [TestMethod]
        public void GetActiveDirectoryGroupName_ReturnsNull()
        {
            //arrange
            var roleModel = new RoleModel();

            //act
            var result = roleModel.ActiveDirectoryGroupName;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetActiveDirectoryGroupName_IsSuccessful()
        {
            //arrange
            var roleModel = new RoleModel { ActiveDirectoryGroupName = "ActiveDirectoryGroupName" };

            //act
            var result = roleModel.ActiveDirectoryGroupName;

            //assert
            Assert.AreEqual("ActiveDirectoryGroupName", result);
        }

        [TestMethod]
        public void GetDisplayName_ReturnsNull()
        {
            //arrange
            var roleModel = new RoleModel();

            //act
            var result = roleModel.DisplayName;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetDisplayName_IsSuccessful()
        {
            //arrange
            var roleModel = new RoleModel { DisplayName = "DisplayName" };

            //act
            var result = roleModel.DisplayName;

            //assert
            Assert.AreEqual("DisplayName", result);
        }

        [TestMethod]
        public void GetPermissionDescription_ReturnsNull()
        {
            //arrange
            var roleModel = new RoleModel();

            //act
            var result = roleModel.PermissionDescription;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetPermissionDescription_IsSuccessful()
        {
            //arrange
            var roleModel = new RoleModel { PermissionDescription = "PermissionDescription" };

            //act
            var result = roleModel.PermissionDescription;

            //assert
            Assert.AreEqual("PermissionDescription", result);
        }
    }
}
