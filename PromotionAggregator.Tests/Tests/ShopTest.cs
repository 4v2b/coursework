using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Models;
using System;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class ShopTest
    {
        [TestMethod]
        public void Name_throws_ArgumentException_when_input_string_is_empty()
        {

            //Arrange
            string test = string.Empty;
            Shop shop = new Shop();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => shop.Name = test);

        }

        [TestMethod]
        public void Name_sets_value_when_input_string_is_correct()
        {

            //Arrange
            string test = "name";
            Shop shop = new Shop();

            //Act
            shop.Name = test;

            //Assert
            Assert.AreEqual(test, shop.Name);

        }

        [TestMethod]
        public void Url_throws_ArgumentException_when_input_string_has_incorrect_format()
        {

            //Arrange
            string test = "url";
            Shop shop = new Shop();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => shop.Url = test);

        }

        [TestMethod]
        public void Url_sets_value_when_input_string_is_correct()
        {

            //Arrange
            string test = "http://localhost";
            Shop shop = new Shop();

            //Act
            shop.Url = test;

            //Assert
            Assert.AreEqual(test, shop.Url);

        }
    }
}
