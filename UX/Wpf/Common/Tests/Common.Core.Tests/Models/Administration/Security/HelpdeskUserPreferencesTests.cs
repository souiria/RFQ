using System;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class HelpdeskUserPreferencesTests
    {
        [TestMethod]
        public void GetCn_ReturnsNull()
        {
            //arrange
            var helpdeskUserPreferences = new HelpdeskUserPreferences();

            //act
            var result = helpdeskUserPreferences.Cn;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetCn_IsSuccessful()
        {
            //arrange
            var helpdeskUserPreferences = new HelpdeskUserPreferences
            {
                Cn = "Cn"
            };

            //act
            var result = helpdeskUserPreferences.Cn;

            //assert
            Assert.AreEqual("Cn", result);
        }

        [TestMethod]
        public void GetPreferredApprover_ReturnsNull()
        {
            //arrange
            var helpdeskUserPreferences = new HelpdeskUserPreferences();
            
            //act
            var result = helpdeskUserPreferences.PreferredApprover;
            
            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetPreferredApprover_IsSuccessful()
        {
            //arrange
            var helpdeskUserPreferences = new HelpdeskUserPreferences
            {
                PreferredApprover = "PreferredApprover"
            };

            //act
            var result = helpdeskUserPreferences.PreferredApprover;

            //assert
            Assert.AreEqual("PreferredApprover", result);
        }
    }
}
