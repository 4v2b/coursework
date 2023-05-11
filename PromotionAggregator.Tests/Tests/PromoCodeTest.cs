using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Models;
using System;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class PromoCodeTest
    {
        [TestMethod]
        public void Code_throws_ArgumentException_when_input_string_is_empty(){

            //Arrange
            string test = string.Empty;
            PromoCode promo = new PromoCode();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => promo.Code = test);

        }

        [TestMethod]
        public void Code_sets_value_when_input_string_is_correct()
        {

            //Arrange
            string test = "code";
            PromoCode promo = new PromoCode();

            //Act
            promo.Code = test;

            //Assert
            Assert.AreEqual(test, promo.Code);

        }

    }
}
