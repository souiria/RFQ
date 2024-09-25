using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Filtering
{
    [TestClass]
    public class InternalFilterModelTests
    {
        [TestMethod]
        public void GetFilterProperty_ReturnsNull()
        {
            //arrange
            var internalFilterModel = new InternalFilterModel();

            //act
            var result = internalFilterModel.FilterProperty;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetFilterProperty_IsSuccessful()
        {
            //arrange
            var internalFilterModel = new InternalFilterModel { FilterProperty = "FilterProperty" };

            //act
            var result = internalFilterModel.FilterProperty;

            //assert
            Assert.AreEqual("FilterProperty", result);
        }

        [TestMethod]
        public void GetFilterValue_ReturnsNull()
        {
            //arrange
            var internalFilterModel = new InternalFilterModel();

            //act
            var result = internalFilterModel.FilterValue;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetFilterValue_IsSuccessful()
        {
            //arrange
            var internalFilterModel = new InternalFilterModel { FilterValue = "FilterValue" };

            //act
            var result = internalFilterModel.FilterValue;

            //assert
            Assert.AreEqual("FilterValue", result);
        }

        [TestMethod]
        public void GetIsAnd_ReturnsFalse()
        {
            //arrange
            var internalFilterModel = new InternalFilterModel();

            //act
            var result = internalFilterModel.IsAnd;

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetIsAnd_IsSuccessful()
        {
            //arrange
            var internalFilterModel = new InternalFilterModel { IsAnd = true };

            //act
            var result = internalFilterModel.IsAnd;

            //assert
            Assert.AreEqual(true, result);
        }
    }
}
