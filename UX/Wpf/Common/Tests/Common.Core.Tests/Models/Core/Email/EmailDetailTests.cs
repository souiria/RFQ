using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Email;
using Common.Core.Infrastructure.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Email
{
    [TestClass]
    public class EmailDetailTests
    {
        [TestMethod]
        public void GetId_ReturnsNotEmptyGuid()
        {
            //arrange
            var emailDetail = new EmailDetail();

            //act
            var result = emailDetail.Id;

            //assert
            Assert.AreNotEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetId_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var emailDetail = new EmailDetail { Id = id };

            //act
            var result = emailDetail.Id;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetRecipients_ReturnsNotNull()
        {
            //arrange
            var emailDetail = new EmailDetail();

            //act
            var result = emailDetail.Recipients;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetRecipients_IsSuccessful()
        {
            //arrange
            var recipients = new List<string> { "recipient1", "recipient2" };
            var emailDetail = new EmailDetail { Recipients = recipients };

            //act
            var result = emailDetail.Recipients;

            //assert
            CollectionAssert.AreEqual(recipients, result);
        }

        [TestMethod]
        public void GetSubject_ReturnsNull()
        {
            //arrange
            var emailDetail = new EmailDetail();

            //act
            var result = emailDetail.Subject;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetSubject_IsSuccessful()
        {
            //arrange
            var emailDetail = new EmailDetail { Subject = "subject" };

            //act
            var result = emailDetail.Subject;

            //assert
            Assert.AreEqual("subject", result);
        }

        [TestMethod]
        public void GetBody_ReturnsNull()
        {
            //arrange
            var emailDetail = new EmailDetail();

            //act
            var result = emailDetail.Body;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetBody_IsSuccessful()
        {
            //arrange
            var emailDetail = new EmailDetail { Body = "body" };

            //act
            var result = emailDetail.Body;

            //assert
            Assert.AreEqual("body", result);
        }

        [TestMethod]
        public void GetSendDate_ReturnsDefaultDateTime()
        {
            //arrange
            var emailDetail = new EmailDetail();

            //act
            var result = emailDetail.SendDate;

            //assert
            Assert.AreEqual(default(DateTime), result);
        }

        [TestMethod]
        public void SetSendDate_IsSuccessful()
        {
            //arrange
            var sendDate = DateTime.UtcNow;
            var emailDetail = new EmailDetail { SendDate = sendDate };

            //act
            var result = emailDetail.SendDate;

            //assert
            Assert.AreEqual(sendDate, result);
        }

        [TestMethod]
        public void GetTemplate_ReturnsDefaultTemplate()
        {
            //arrange
            var emailDetail = new EmailDetail();

            //act
            var result = emailDetail.Template;

            //assert
            Assert.AreEqual(default(Template), result);
        }

        [TestMethod]
        public void SetTemplate_IsSuccessful()
        {
            //arrange
            var emailDetail = new EmailDetail { Template = Template.Snapshot };

            //act
            var result = emailDetail.Template;

            //assert
            Assert.AreEqual(Template.Snapshot, result);
        }

        [TestMethod]
        public void GetSnapShot_ReturnsNull()
        {
            //arrange
            var emailDetail = new EmailDetail();

            //act
            var result = emailDetail.SnapShot;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetSnapShot_IsSuccessful()
        {
            //arrange
            var objectData = "abcdef1234567890".Compress();
            var emailDetail = new EmailDetail { SnapShot = objectData };

            //act
            var result = emailDetail.SnapShot;

            //assert
            Assert.AreEqual(objectData, result);
        }

        [TestMethod]
        public void Constructor_String_String_String_IsSuccessful()
        {
            //arrange //act
            var emailDetail = new EmailDetail("recipient", null, null);

            //assert
            Assert.IsNotNull(emailDetail);
        }
    }
}
