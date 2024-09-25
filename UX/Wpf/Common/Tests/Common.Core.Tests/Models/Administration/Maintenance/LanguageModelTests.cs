using System;
using System.Collections.Generic;
using System.Linq;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class LanguageModelTests
    {
        [TestMethod]
        public void get_Language_ReturnsNull()
        {
            // arrange
            var labelModel = new LanguageModel();

            // act
            var result = labelModel.Language;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_Language_Returns_Language()
        {
            // arrange
            var labelModel = new LanguageModel();
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
            var labelModel = new LanguageModel();

            // act
            var result = labelModel.LanguageDescription;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_LanguageDescription_Returns_LanguageDescription()
        {
            // arrange
            var labelModel = new LanguageModel();
            labelModel.LanguageDescription = "LanguageDescription";

            // act
            var result = labelModel.LanguageDescription;

            // assert
            Assert.AreEqual("LanguageDescription", result);
        }

        [TestMethod]
        public void get_LabelIds_ReturnsNull()
        {
            // arrange
            var labelModel = new LanguageModel();

            // act
            var result = labelModel.LabelIds;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_LabelIds_Returns_LabelIds()
        {
            // arrange
            var labelModel = new LanguageModel();
            var testGuid = new Guid();
            labelModel.LabelIds = new List<Guid>();

            // act
            labelModel.LabelIds.Add(testGuid);
            var result = labelModel.LabelIds.First();

            // assert
            Assert.AreEqual(testGuid, result);
        }

    }
}