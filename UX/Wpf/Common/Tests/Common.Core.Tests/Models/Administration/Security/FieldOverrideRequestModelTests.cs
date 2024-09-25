using System;
using System.Collections.Generic;
using System.Linq;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class FieldOverrideRequestModelTests
    {
        [TestMethod]
        public void get_UserGuid_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var fieldOverrideRequestModel = new FieldOverrideRequestModel();

            // act
            var result = fieldOverrideRequestModel.UserGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void set_UserGuid_Returns_UserGuid()
        {
            // arrange
            var fieldOverrideRequestModel = new FieldOverrideRequestModel();
            var testGuid = new Guid();

            // act
            fieldOverrideRequestModel.UserGuid = testGuid;
            var result = fieldOverrideRequestModel.UserGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void get_GroupGuids_ReturnsNull()
        {
            // arrange
            var fieldOverrideRequestModel = new FieldOverrideRequestModel();

            // act
            var result = fieldOverrideRequestModel.GroupGuids;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_GroupGuids_Returns_GroupGuids()
        {
            // arrange
            var fieldOverrideRequestModel = new FieldOverrideRequestModel();
            var testGuid = new Guid();
            fieldOverrideRequestModel.GroupGuids = new List<Guid>();

            // act
            fieldOverrideRequestModel.GroupGuids.Add(testGuid);
            var result = fieldOverrideRequestModel.GroupGuids.First();


            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void get_VariableName_ReturnsNull()
        {
            // arrange
            var fieldOverrideRequestModel = new FieldOverrideRequestModel();

            // act
            var result = fieldOverrideRequestModel.ViewName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_VariableName_Returns_VariableName()
        {
            // arrange
            var fieldOverrideRequestModel = new FieldOverrideRequestModel();
            fieldOverrideRequestModel.ViewName = "ViewName";

            // act
            var result = fieldOverrideRequestModel.ViewName;

            // assert
            Assert.AreEqual("ViewName", result);
        }
    }
}
