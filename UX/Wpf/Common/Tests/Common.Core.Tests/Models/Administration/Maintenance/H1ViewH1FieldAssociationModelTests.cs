using System;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class H1ViewH1FieldAssociationModelTests
    {
        [TestMethod]
        public void get_H1ViewGuid_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var h1ViewH1FieldAssociationModel = new H1ViewH1FieldAssociationModel();

            // act
            var result = h1ViewH1FieldAssociationModel.H1ViewGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_H1ViewGuid_Returns_H1ViewGuid()
        {
            // arrange
            var h1ViewH1FieldAssociationModel = new H1ViewH1FieldAssociationModel();
            var testGuid = new Guid();

            // act
            h1ViewH1FieldAssociationModel.H1ViewGuid = testGuid;
            var result = h1ViewH1FieldAssociationModel.H1ViewGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void get_H1FieldGuid_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var h1ViewH1FieldAssociationModel = new H1ViewH1FieldAssociationModel();

            // act
            var result = h1ViewH1FieldAssociationModel.H1FieldGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_H1FieldGuid_Returns_H1FieldGuid()
        {
            // arrange
            var h1ViewH1FieldAssociationModel = new H1ViewH1FieldAssociationModel();
            var testGuid = new Guid();

            // act
            h1ViewH1FieldAssociationModel.H1FieldGuid = testGuid;
            var result = h1ViewH1FieldAssociationModel.H1FieldGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }
    }
}