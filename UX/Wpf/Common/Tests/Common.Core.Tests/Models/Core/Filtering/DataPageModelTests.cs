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
    public class DataPageModelTests
    {
        [TestMethod]
        public void GetPageSize_Returns10000()
        {
            //arrange
            var dataPageModel = new DataPageModel();

            //act
            var result = dataPageModel.PageSize;

            //assert
            Assert.AreEqual(10000, result);
        }

        [TestMethod]
        public void SetPageSize_IsSuccessful()
        {
            //arrange
            var dataPageModel = new DataPageModel { PageSize = 50 };

            //act
            var result = dataPageModel.PageSize;

            //assert
            Assert.AreEqual(50, result);
        }
        [TestMethod]
        public void GetPageNumber_Returns1()
        {
            //arrange
            var dataPageModel = new DataPageModel();

            //act
            var result = dataPageModel.PageNumber;

            //assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SetPageNumber_IsSuccessful()
        {
            //arrange
            var dataPageModel = new DataPageModel { PageNumber = 50 };

            //act
            var result = dataPageModel.PageNumber;

            //assert
            Assert.AreEqual(50, result);
        }
    }
}
