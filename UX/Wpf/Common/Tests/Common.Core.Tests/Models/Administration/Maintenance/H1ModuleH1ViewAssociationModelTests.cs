using System;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class H1ModuleH1ViewAssociationModelTests
    {
        [TestMethod]
        public void get_H1ModuleGuid_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var h1ModuleH1ViewAssociationModel = new H1ModuleH1ViewAssociationModel();

            // act
            var result = h1ModuleH1ViewAssociationModel.H1ModuleGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_H1ModuleGuid_Returns_H1ModuleGuid()
        {
            // arrange
            var h1ModuleH1ViewAssociationModel = new H1ModuleH1ViewAssociationModel();
            var testGuid = new Guid();

            // act
            h1ModuleH1ViewAssociationModel.H1ModuleGuid = testGuid;
            var result = h1ModuleH1ViewAssociationModel.H1ModuleGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void get_H1ViewGuid_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var h1ModuleH1ViewAssociationModel = new H1ModuleH1ViewAssociationModel();

            // act
            var result = h1ModuleH1ViewAssociationModel.H1ViewGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_H1ViewGuid_Returns_H1ViewGuid()
        {
            // arrange
            var h1ModuleH1ViewAssociationModel = new H1ModuleH1ViewAssociationModel();
            var testGuid = new Guid();

            // act
            h1ModuleH1ViewAssociationModel.H1ViewGuid = testGuid;
            var result = h1ModuleH1ViewAssociationModel.H1ViewGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }   
    }
}