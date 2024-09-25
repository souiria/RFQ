using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class LabelModelTests
    {
        [TestMethod]
        public void get_Code_ReturnsNull()
        {
            // arrange
            var labelModel = new LabelModel();

            // act
            var result = labelModel.Code;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_Code_Returns_Code()
        {
            // arrange
            var labelModel = new LabelModel();
            labelModel.Code = "Code";

            // act
            var result = labelModel.Code;

            // assert
            Assert.AreEqual("Code", result);
        }

        [TestMethod]
        public void get_Value_ReturnsNull()
        {
            // arrange
            var labelModel = new LabelModel();

            // act
            var result = labelModel.Value;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_Value_Returns_Value()
        {
            // arrange
            var labelModel = new LabelModel();
            labelModel.Value = "Value";

            // act
            var result = labelModel.Value;

            // assert
            Assert.AreEqual("Value", result);
        }

        [TestMethod]
        public void get_Purpose_ReturnsNull()
        {
            // arrange
            var labelModel = new LabelModel();

            // act
            var result = labelModel.Purpose;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_Purpose_Returns_Purpose()
        {
            // arrange
            var labelModel = new LabelModel();
            labelModel.Purpose = "Purpose";

            // act
            var result = labelModel.Purpose;

            // assert
            Assert.AreEqual("Purpose", result);
        }

    }
}