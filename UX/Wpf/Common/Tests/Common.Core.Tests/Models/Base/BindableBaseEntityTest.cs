using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Common.Core.Contracts.Models.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Base
{
    public class NewBindableBaseModel : BaseModel<Guid>
    {
        public string TestProperty { get; set; }

        public void OnPropertyChangedTest(string propertyName = null)
        {
            OnPropertyChanged(propertyName);
        }

        public void OnPropertyChangedTest(Expression<Func<string>> propertyExpression)
        {
            OnPropertyChanged(propertyExpression);
        }

        public void OnPropertyChangedTest(PropertyChangedEventArgs args)
        {
            OnPropertyChanged(args);
        }

        public void RaisePropertyChangedTest(string propertyName = null)
        {
            RaisePropertyChanged(propertyName);
        }

        public bool SetPropertyTest<T>(ref T storage, T value, string propertyName = null)
        {
            return SetProperty(ref storage, value, propertyName);
        }

        public bool SetPropertyTest<T>(ref T storage, T value, Action onChanged, string propertyName = null)
        {
            return SetProperty(ref storage, value, onChanged, propertyName);
        }
    }

    [TestClass]
    public class BindableBaseEntityTest
    {
        [TestMethod]
        public void OnPropertyChanged_String_WithNull1stParam_RaisesPropertyChanged()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var isRaised = false;

            baseModel.PropertyChanged += delegate
            {
                isRaised = true;
            };

            //Act
            baseModel.OnPropertyChangedTest();

            //Assert
            Assert.IsTrue(isRaised);
        }

        [TestMethod]
        public void OnPropertyChanged_String_RaisesPropertyChanged()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = string.Empty;

            baseModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyRaised = e.PropertyName;
            };

            //Act
            baseModel.OnPropertyChangedTest("TestProperty");

            //Assert
            Assert.AreEqual("TestProperty", propertyRaised);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OnPropertyChanged_Lambda_WithNull1stParam_ThrowsException()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();

            //Act //Assert
            baseModel.OnPropertyChangedTest((Expression<Func<string>>)null);

            Assert.Fail();
        }

        [TestMethod]
        public void OnPropertyChanged_Lambda_RaisesPropertyChanged()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = string.Empty;

            baseModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyRaised = e.PropertyName;
            };

            //Act
            baseModel.OnPropertyChangedTest(() => baseModel.TestProperty);

            //Assert
            Assert.AreEqual("TestProperty", propertyRaised);
        }

        [TestMethod]
        public void OnPropertyChanged_PropertyChangedEventArgs_WithNull1stParam_RaiseNullPropertyChangedEventArgs()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var eventArgsIsNull = false;

            baseModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
                {
                    eventArgsIsNull = e == null;
                };

            //Act //Assert
            baseModel.OnPropertyChangedTest((PropertyChangedEventArgs)null);

            Assert.IsTrue(eventArgsIsNull);
        }

        [TestMethod]
        public void OnPropertyChanged_PropertyChangedEventArgs_RaisesPropertyChanged()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = string.Empty;

            baseModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyRaised = e.PropertyName;
            };

            //Act
            baseModel.OnPropertyChangedTest(new PropertyChangedEventArgs("TestProperty"));

            //Assert
            Assert.AreEqual("TestProperty", propertyRaised);
        }

        [TestMethod]
        public void RaisePropertyChanged_String_WithNull1stParam_RaisesPropertyChanged()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var isRaised = false;

            baseModel.PropertyChanged += delegate
            {
                isRaised = true;
            };

            //Act
            baseModel.RaisePropertyChangedTest();

            //Assert
            Assert.IsTrue(isRaised);
        }

        [TestMethod]
        public void RaisePropertyChanged_String_RaisesPropertyChanged()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = string.Empty;

            baseModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyRaised = e.PropertyName;
            };

            //Act
            baseModel.RaisePropertyChangedTest("TestProperty");

            //Assert
            Assert.AreEqual("TestProperty", propertyRaised);
        }

        [TestMethod]
        public void SetProperty_RefT_T_String_IsSuccessful()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = string.Empty;
            string property = null;

            baseModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyRaised = e.PropertyName;
            };

            //Act 
            var result = baseModel.SetPropertyTest(ref property, "test", nameof(property));

            //assert
            Assert.IsTrue(result);
            Assert.AreEqual("property", propertyRaised);
            Assert.AreEqual("test", property);
        }

        [TestMethod]
        public void SetProperty_RefT_T_String_WhenValueHasNotBeenChanged_DoesNotRaisePropertyChanged()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = false;
            string property = "test";

            baseModel.PropertyChanged += delegate
            {
                propertyRaised = true;
            };

            //Act 
            var result = baseModel.SetPropertyTest(ref property, "test", nameof(property));

            //assert
            Assert.IsFalse(result);
            Assert.IsFalse(propertyRaised);
        }

        [TestMethod]
        public void SetProperty_RefT_T_Action_String_IsSuccessful()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = string.Empty;
            string property = null;
            var actionPerformed = false;

            baseModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyRaised = e.PropertyName;
            };

            //Act 
            baseModel.SetPropertyTest(ref property, "test", () => { actionPerformed = true; }, nameof(property));

            //assert
            Assert.AreEqual("property", propertyRaised);
            Assert.AreEqual("test", property);
            Assert.IsTrue(actionPerformed);
        }

        [TestMethod]
        public void SetProperty_RefT_T_Action_String_WhenValueHasNotBeenChanged_DoesNotRaisePropertyChanged()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = false;
            var property = "test";
            var actionPerformed = false;

            baseModel.PropertyChanged += delegate { propertyRaised = true; };

            //Act 
            var result = baseModel.SetPropertyTest(ref property, "test", () => { actionPerformed = true; }, nameof(property));

            //assert
            Assert.IsFalse(result);
            Assert.IsFalse(propertyRaised);
            Assert.IsFalse(actionPerformed);
        }

        [TestMethod]
        public void SetProperty_RefT_T_Action_String_WithNull3rdParam_IsSuccessful()
        {
            //Arrange
            var baseModel = new NewBindableBaseModel();
            var propertyRaised = string.Empty;
            string property = null;

            baseModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                propertyRaised = e.PropertyName;
            };

            //Act 
            var result = baseModel.SetPropertyTest(ref property, "test", null, nameof(property));

            //assert
            Assert.IsTrue(result);
            Assert.AreEqual("property", propertyRaised);
            Assert.AreEqual("test", property);
        }
    }
}
