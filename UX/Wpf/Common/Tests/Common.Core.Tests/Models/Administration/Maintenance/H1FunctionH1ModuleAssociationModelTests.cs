using System;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class H1FunctionH1ModuleAssociationModelTests
    {

        [TestMethod]
        public void get_H1FunctionGuid_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var h1FunctionH1ModuleAssociationModel = new H1FunctionH1ModuleAssociationModel();

            // act
            var result = h1FunctionH1ModuleAssociationModel.H1FunctionGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_H1FunctionGuid_Returns_H1FunctionGuid()
        {
            // arrange
            var h1FunctionH1ModuleAssociationModel = new H1FunctionH1ModuleAssociationModel();
            var testGuid = new Guid();

            // act
            h1FunctionH1ModuleAssociationModel.H1FunctionGuid = testGuid;
            var result = h1FunctionH1ModuleAssociationModel.H1FunctionGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }


        [TestMethod]
        public void get_H1ModuleGuid_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var h1FunctionH1ModuleAssociationModel = new H1FunctionH1ModuleAssociationModel();

            // act
            var result = h1FunctionH1ModuleAssociationModel.H1ModuleGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_H1ModuleGuid_Returns_H1ModuleGuid()
        {
            // arrange
            var h1FunctionH1ModuleAssociationModel = new H1FunctionH1ModuleAssociationModel();
            var testGuid = new Guid();

            // act
            h1FunctionH1ModuleAssociationModel.H1ModuleGuid = testGuid;
            var result = h1FunctionH1ModuleAssociationModel.H1ModuleGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }

    }
}