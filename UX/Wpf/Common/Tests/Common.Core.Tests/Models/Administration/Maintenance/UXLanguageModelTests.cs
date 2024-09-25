using System;
using System.Collections.Generic;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class UXLanguageModelTests
    {
        [TestMethod]
        public void get_Language_ReturnsNull()
        {
            // arrange
            var labelModel = new UXLanguageModel();

            // act
            var result = labelModel.Language;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_Language_Returns_Language()
        {
            // arrange
            var labelModel = new UXLanguageModel();
            labelModel.Language = "Language";

            // act
            var result = labelModel.Language;

            // assert
            Assert.AreEqual("Language", result);
        }

        [TestMethod]
        public void get_LanguageDescription_ReturnsNull()
        {
            // arrange
            var labelModel = new UXLanguageModel();

            // act
            var result = labelModel.LanguageDescription;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_LanguageDescription_Returns_LanguageDescription()
        {
            // arrange
            var labelModel = new UXLanguageModel();
            labelModel.LanguageDescription = "LanguageDescription";

            // act
            var result = labelModel.LanguageDescription;

            // assert
            Assert.AreEqual("LanguageDescription", result);
        }

        [TestMethod]
        public void get_IsActive_Returns_IsActive()
        {
            // arrange
            var labelModel = new UXLanguageModel();
            labelModel.IsActive = true;

            // act
            var result = labelModel.IsActive;

            // assert
            Assert.IsTrue(result);
        }
    
    }
}
