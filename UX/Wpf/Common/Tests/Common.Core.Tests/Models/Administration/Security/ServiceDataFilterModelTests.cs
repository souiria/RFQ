using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class ServiceDataFilterModelTests
    {
        [TestMethod]
        public void GetServiceUri_ReturnsNull()
        {
            //arrange
            var serviceDataFilterModel = new ServiceDataFilterModel();

            //act
            var result = serviceDataFilterModel.ServiceUri;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetServiceUri_IsSuccessful()
        {
            //arrange
            var serviceDataFilterModel = new ServiceDataFilterModel { ServiceUri = "ServiceUri" };

            //act
            var result = serviceDataFilterModel.ServiceUri;

            //assert
            Assert.AreEqual("ServiceUri", result);
        }

        [TestMethod]
        public void GetUserGuid_ReturnsEmptyGuid()
        {
            //arrange
            var serviceDataFilterModel = new ServiceDataFilterModel();

            //act
            var result = serviceDataFilterModel.UserGuid;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetUserGuid_IsSuccessful()
        {
            //arrange
            var userGuid = Guid.NewGuid();
            var serviceDataFilterModel = new ServiceDataFilterModel { UserGuid = userGuid };

            //act
            var result = serviceDataFilterModel.UserGuid;

            //assert
            Assert.AreEqual(userGuid, result);
        }

        [TestMethod]
        public void GetFilter_ReturnsNull()
        {
            //arrange
            var serviceDataFilterModel = new ServiceDataFilterModel();

            //act
            var result = serviceDataFilterModel.Filter;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetFilter_IsSuccessful()
        {
            //arrange
            var filter = new SecurityFilter { Id = Guid.NewGuid() };
            var serviceDataFilterModel = new ServiceDataFilterModel { Filter = filter };

            //act
            var result = serviceDataFilterModel.Filter;

            //assert
            Assert.AreEqual(filter, result);
        }
    }
}
