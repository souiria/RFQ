using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class SecurityFilterTests
    {
        [TestMethod]
        public void GetFilterProperty_ReturnsNull()
        {
            //arrange
            var securityFilter = new SecurityFilter();

            //act
            var result = securityFilter.FilterProperty;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetFilterProperty_IsSuccessful()
        {
            //arrange
            var securityFilter = new SecurityFilter { FilterProperty = "FilterProperty" };

            //act
            var result = securityFilter.FilterProperty;

            //assert
            Assert.AreEqual("FilterProperty", result);
        }

        [TestMethod]
        public void GetFilterValue_ReturnsNull()
        {
            //arrange
            var securityFilter = new SecurityFilter();

            //act
            var result = securityFilter.FilterValue;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetFilterValue_IsSuccessful()
        {
            //arrange
            var securityFilter = new SecurityFilter { FilterValue = "FilterValue" };

            //act
            var result = securityFilter.FilterValue;

            //assert
            Assert.AreEqual("FilterValue", result);
        }

        [TestMethod]
        public void GetFilterType_ReturnsDefaultFilterType()
        {
            //arrange
            var securityFilter = new SecurityFilter();

            //act
            var result = securityFilter.FilterType;

            //assert
            Assert.AreEqual(default(FilterTypes), result);
        }

        [TestMethod]
        public void SetFilterType_IsSuccessful()
        {
            //arrange
            var securityFilter = new SecurityFilter { FilterType = FilterTypes.Contains };

            //act
            var result = securityFilter.FilterType;

            //assert
            Assert.AreEqual(FilterTypes.Contains, result);
        }

    }
}
