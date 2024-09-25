using System;
using System.Text;
using Common.Core.Infrastructure.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Infrastructure.Helpers
{
    [TestClass]
    public class CompressorTest
    {
        [TestMethod]
        public void When_Compressed_A_String_Should_Become_A_Byte()
        {
            //Arrange
            var testString = "I am a string!";

            //Act
            var testCompressed = testString.Compress();

            //Assert
            Assert.IsTrue(testCompressed.GetType() == typeof(byte[]));
        }

        [TestMethod]
        public void When_DeCompressed_A_Byte_Should_Become_A_String()
        {
            //Arrange
            var testString ="I am a string!";

            //Act
            var testCompressed = testString.Compress();
            var testDeCompressed = testCompressed.Decompress();

            //Assert
            Assert.AreEqual(testDeCompressed, testString);
        }

        [TestMethod]
        public void When_Compressed_A_String_Should_Become_A_Base64()
        {
            //Arrange
            var testString = "I am a string!";

            //Act
            var testCompressed = testString.CompressBase64();

            //Assert
            Assert.IsTrue(testCompressed.GetType() == typeof(string));
            Assert.IsTrue(testCompressed != testString);
        }

        [TestMethod]
        public void When_DeCompressed_A_Base64_Should_Become_A_String()
        {
            //Arrange
            var testString = "I am a string!";

            //Act
            var testCompressed = testString.CompressBase64();
            var testDeCompressed = testCompressed.DecompressBase64();

            //Assert
            Assert.AreEqual(testDeCompressed, testString);
        }

        [TestMethod]
        public void When_DeCompressed_An_Empty_Base64_Should_Return_An_Empty_Base64()
        {
            //Arrange
            string testString = "";

            //Act
            var testDeCompressed = testString.DecompressBase64();

            //Assert
            Assert.AreEqual(testDeCompressed, testString);
        }
    }
}
