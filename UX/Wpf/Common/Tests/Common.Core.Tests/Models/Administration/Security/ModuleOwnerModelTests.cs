using System;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class ModuleOwnerModelTests
    {
        [TestMethod]
        public void GetUserGuid_ReturnsEmptyGuid()
        {
            //arrange
            var moduleOwnerModel = new ModuleOwnerModel();

            //act
            var result = moduleOwnerModel.UserGuid;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetUserGuid_IsSuccessful()
        {
            //arrange
            var userGuid = Guid.NewGuid();
            var moduleOwnerModel = new ModuleOwnerModel
            {
                UserGuid = userGuid
            };

            //act
            var result = moduleOwnerModel.UserGuid;

            //assert
            Assert.AreEqual(userGuid, result);
        }

        [TestMethod]
        public void GetH1ModuleGuid_ReturnsNull()
        {
            //arrange
            var moduleOwnerModel = new ModuleOwnerModel();

            //act
            var result = moduleOwnerModel.H1ModuleGuid;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetH1ModuleGuid_IsSuccessful()
        {
            //arrange
            var moduleGuid = Guid.NewGuid();
            var moduleOwnerModel = new ModuleOwnerModel
            {
                H1ModuleGuid = moduleGuid
            };

            //act
            var result = moduleOwnerModel.H1ModuleGuid;

            //assert
            Assert.AreEqual(moduleGuid, result);
        }


        [TestMethod]
        public void Constructor_Guid_Guid_Guid_IsSuccessful()
        {
            //arrange //act
            var moduleOwnerModel = new ModuleOwnerModel(Guid.Empty, Guid.Empty, Guid.Empty);

            //assert
            Assert.IsNotNull(moduleOwnerModel);
        }
        

        //[TestMethod]
        //public void CreatedDate_Is_Not_Null_In_Constructor()
        //{
        //    //arrange
        //    var moduleOwnerModel = new ModuleOwnerModel(Guid.Empty, Guid.Empty, Guid.Empty);

        //    //act
        //    var result = moduleOwnerModel.CreatedDate;

        //    //assert
        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void ModifiedDate_Is_Not_Null_In_Constructor()
        //{
        //    //arrange
        //    var moduleOwnerModel = new ModuleOwnerModel(Guid.Empty, Guid.Empty, Guid.Empty);

        //    //act
        //    var result = moduleOwnerModel.ModifiedDate;

        //    //assert
        //    Assert.IsNotNull(result);
        //}
    }
}