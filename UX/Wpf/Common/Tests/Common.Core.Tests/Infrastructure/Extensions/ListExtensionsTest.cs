using System;
using System.Collections.Generic;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.Core.Infrastructure.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Infrastructure.Extensions
{
    [TestClass]
    public class ListExtensionsTest
    {
        // TODO: Figure out how to make ExtensionDataObject serializable to allow this test to run
        //[TestMethod]
        //public void Is_ClonedList_And_OriginalList_The_Same()
        //{
        //    //Arrange
        //    var originalList = new List<CountryModel>{ new CountryModel{ CountryName = "MyCountry", ExtensionData = null}};

        //    //Act
        //    var clonedList = originalList.CloneList();

        //    //Assert
        //    Assert.AreEqual(originalList, clonedList);
        //}
    }
}
