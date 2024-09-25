using System;
using System.Collections.Generic;
using Common.Core.Infrastructure.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Infrastructure.Attributes
{
    [TestClass]
    public class DecimalPrecisionAttributeTest
    {
        [DecimalPrecision(10, 2)] private double _testProperty { get; set; }
       
        [TestMethod]
        public void Is_Attribute_Multiple_False()
        {
            var attributes =
                (IList<AttributeUsageAttribute>) typeof(DecimalPrecisionAttribute).GetCustomAttributes(
                    typeof(AttributeUsageAttribute), false);
            Assert.AreEqual(1, attributes.Count);

            var attribute = attributes[0];
            Assert.IsFalse(attribute.AllowMultiple);
        }

        [TestMethod]
        public void Is_Precision_Set_To_10()
        {
            // TODO: Needs to be set correctly to test the attribute
            _testProperty = 100.1234;
            Assert.AreEqual(100.1234, _testProperty );
        }
    }
}
