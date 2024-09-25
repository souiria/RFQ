using System;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Notifications
{
    [TestClass]
    public class SubscriptionChannelTests
    {
        [TestMethod]
        public void GetChannel_ReturnsAssignedValue()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test";
            subscriptionChannel.Channel = data;
            Assert.AreEqual(data, subscriptionChannel.Channel);
        }

        [TestMethod]
        public void GetChannel_ReturnsAssignedValue2()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test2";
            subscriptionChannel.Channel = data;
            Assert.AreEqual(data, subscriptionChannel.Channel);
        }

        [TestMethod]
        public void GetFunctionName_ReturnsAssignedValue()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test";
            subscriptionChannel.FunctionName = data;
            Assert.AreEqual(data, subscriptionChannel.FunctionName);
        }

        [TestMethod]
        public void GetFunctionName_ReturnsAssignedValue2()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test2";
            subscriptionChannel.FunctionName = data;
            Assert.AreEqual(data, subscriptionChannel.FunctionName);
        }

        [TestMethod]
        public void GetServiceName_ReturnsAssignedValue()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test";
            subscriptionChannel.ServiceName = data;
            Assert.AreEqual(data, subscriptionChannel.ServiceName);
        }

        [TestMethod]
        public void GetServiceName_ReturnsAssignedValue2()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test2";
            subscriptionChannel.ServiceName = data;
            Assert.AreEqual(data, subscriptionChannel.ServiceName);
        }

        [TestMethod]
        public void GetDescription_ReturnsAssignedValue()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test";
            subscriptionChannel.Description = data;
            Assert.AreEqual(data, subscriptionChannel.Description);
        }

        [TestMethod]
        public void GetDescription_ReturnsAssignedValue2()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test2";
            subscriptionChannel.Description = data;
            Assert.AreEqual(data, subscriptionChannel.Description);
        }

        [TestMethod]
        public void GetEventType_ReturnsAssignedValue()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test";
            subscriptionChannel.EventType = data;
            Assert.AreEqual(data, subscriptionChannel.EventType);
        }

        [TestMethod]
        public void GetEventType_ReturnsAssignedValue2()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = "Test2";
            subscriptionChannel.EventType = data;
            Assert.AreEqual(data, subscriptionChannel.EventType);
        }

        [TestMethod]
        public void GetIsActive_ReturnsAssignedValue()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = false;
            subscriptionChannel.IsActive = data;
            Assert.AreEqual(data, subscriptionChannel.IsActive);
        }

        [TestMethod]
        public void GetIsActive_ReturnsAssignedValue2()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = true;
            subscriptionChannel.IsActive = data;
            Assert.AreEqual(data, subscriptionChannel.IsActive);
        }

        [TestMethod]
        public void GetIsChecked_ReturnsAssignedValue()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = false;
            subscriptionChannel.IsChecked = data;
            Assert.AreEqual(data, subscriptionChannel.IsChecked);
        }

        [TestMethod]
        public void GetIsChecked_ReturnsAssignedValue2()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = true;
            subscriptionChannel.IsChecked = data;
            Assert.AreEqual(data, subscriptionChannel.IsChecked);
        }

        [TestMethod]
        public void GetCrudOperationType_ReturnsAssignedValue()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = CrudOperationType.Create;
            subscriptionChannel.CrudOperationType = data;
            Assert.AreEqual(data, subscriptionChannel.CrudOperationType);
        }

        [TestMethod]
        public void GetCrudOperationType_ReturnsAssignedValue2()
        {
            var subscriptionChannel = new SubscriptionChannel();
            var data = CrudOperationType.Delete;
            subscriptionChannel.CrudOperationType = data;
            Assert.AreEqual(data, subscriptionChannel.CrudOperationType);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsNull_ReturnsFalse()
        {
            var subscriptionChannel1 = new SubscriptionChannel { Channel = "Channel1" };

            var result = subscriptionChannel1.Equals((object)null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_WithSubscriptionChannel_ReturnsTrue()
        {
            var subscriptionChannel1 = new SubscriptionChannel { Channel = "Channel1" };
            object subscriptionChannel2 = new SubscriptionChannel { Channel = "Channel1" };

            var result = subscriptionChannel1.Equals(subscriptionChannel2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Object_WithSubscriptionChannel_ReturnsFalse()
        {
            var subscriptionChannel1 = new SubscriptionChannel { Channel = "Channel1" };
            object subscriptionChannel2 = new SubscriptionChannel { Channel = "Channel2" };

            var result = subscriptionChannel1.Equals(subscriptionChannel2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_WithString_ReturnsTrue()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            object subscriptionChannel2 = "Channel1";

            var result = subscriptionChannel.Equals(subscriptionChannel2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Object_WithString_ReturnsFalse()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            object subscriptionChannel2 = "Channel2";

            var result = subscriptionChannel.Equals(subscriptionChannel2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_WithUnacceptedType_ReturnsFalse()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            object subscriptionChannel2 = 35;

            var result = subscriptionChannel.Equals(subscriptionChannel2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_WithUnacceptedType_ReturnsFalse2()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            object subscriptionChannel2 = null;

            var result = subscriptionChannel.Equals(subscriptionChannel2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SubscriptionChannel_When1stParamIsNull_ReturnsFalse()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var result = subscriptionChannel.Equals((SubscriptionChannel)null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SubscriptionChannel_ReturnsFalse()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var subscriptionChannel2 = new SubscriptionChannel { Channel = "Channel2" };

            var result = subscriptionChannel.Equals(subscriptionChannel2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_SubscriptionChannel_ReturnsTrue()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var subscriptionChannel2 = new SubscriptionChannel { Channel = "Channel1" };

            var result = subscriptionChannel.Equals(subscriptionChannel2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_String_When1stParamIsNull_ReturnsFalse()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };

            var result = subscriptionChannel.Equals((string)null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_String_ReturnsFalse()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            const string subscriptionChannel2 = "Channel2";

            var result = subscriptionChannel.Equals(subscriptionChannel2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_String_ReturnsTrue()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            const string subscriptionChannel2 = "Channel1";

            var result = subscriptionChannel.Equals(subscriptionChannel2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHashCode_WhenChannelIsNull_ThrowsException()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = null };
            subscriptionChannel.GetHashCode();

            Assert.Fail();
        }

        [TestMethod]
        public void GetHashCode_ReturnsChannelHashCode()
        {
            var stringHashCode = "Channel1".GetHashCode();
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var result = subscriptionChannel.GetHashCode();

            Assert.AreEqual(stringHashCode, result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsChannelHashCode2()
        {
            var stringHashCode = "Channel2".GetHashCode();
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel2" };
            var result = subscriptionChannel.GetHashCode();

            Assert.AreEqual(stringHashCode, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareTo_SubscriptionChannel_When1stParamIsNull_ThrowsException()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            subscriptionChannel.CompareTo((SubscriptionChannel)null);

            Assert.Fail();
        }

        [TestMethod]
        public void CompareTo_SubscriptionChannel_WhenChannel1IsNull_ReturnsLessThanZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = null };
            var subscriptionChannel2 = new SubscriptionChannel { Channel = "Channel1" };
            var result = subscriptionChannel.CompareTo(subscriptionChannel2);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_SubscriptionChannel_WhenChannel2IsNull_ReturnsMoreThanZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var subscriptionChannel2 = new SubscriptionChannel { Channel = null };
            var result = subscriptionChannel.CompareTo(subscriptionChannel2);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_SubscriptionChannel_WhenBothChannelsAreNull_ReturnsZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = null };
            var subscriptionChannel2 = new SubscriptionChannel { Channel = null };
            var result = subscriptionChannel.CompareTo(subscriptionChannel2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareTo_SubscriptionChannel_ReturnsMoreThanZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var subscriptionChannel2 = new SubscriptionChannel { Channel = "ABCDEFG" };

            var result = subscriptionChannel.CompareTo(subscriptionChannel2);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_SubscriptionChannel_ReturnsLessThanZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var subscriptionChannel2 = new SubscriptionChannel { Channel = "SomethingChannel" };

            var result = subscriptionChannel.CompareTo(subscriptionChannel2);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_SubscriptionChannel_ReturnsZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var subscriptionChannel2 = new SubscriptionChannel { Channel = "Channel1" };

            var result = subscriptionChannel.CompareTo(subscriptionChannel2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareTo_String_When1stParamIsNull_ReturnsMoreThanZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "Channel1" };
            var result = subscriptionChannel.CompareTo((string)null);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_String_ReturnsLessThanZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "ChannelA" };
            var result = subscriptionChannel.CompareTo("ZetaChannel");

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_String_ReturnsMoreThanZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "GoodChannel" };
            var result = subscriptionChannel.CompareTo("AmazingChannel");

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_String_ReturnsZero()
        {
            var subscriptionChannel = new SubscriptionChannel { Channel = "666" };
            var result = subscriptionChannel.CompareTo("666");

            Assert.AreEqual(0, result);
        }
    }
}
