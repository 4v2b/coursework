using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class SpecialOfferTest
    {
        [TestMethod]
        public void Url_throws_ArgumentException_when_input_string_has_incorrect_format()
        {

            //Arrange
            string test = "url";
            SpecialOffer offer = new SpecialOffer();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => offer.Url = test);

        }

        [TestMethod]
        public void Url_sets_value_when_input_string_is_correct()
        {

            //Arrange
            string test = "http://localhost";
            SpecialOffer offer = new SpecialOffer();

            //Act
            offer.Url = test;

            //Assert
            Assert.AreEqual(test, offer.Url);

        }
    }
}
