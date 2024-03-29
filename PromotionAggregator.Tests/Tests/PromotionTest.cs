﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Tests.Tests
{ 

    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void Title_throws_ArgumentException_when_input_string_is_empty()
        {

            //Arrange
            string test = string.Empty;
           Promotion promo = new PromoСode();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => promo.Title = test);

        }

        [TestMethod]
        public void Title_sets_value_when_input_string_is_correct()
        {

            //Arrange
            string test = "title";
            Promotion promo = new PromoСode();

            //Act
            promo.Title = test;

            //Assert
            Assert.AreEqual(test, promo.Title);

        }

        [TestMethod]
        public void Description_throws_ArgumentException_when_input_string_is_empty()
        {

            //Arrange
            string test = string.Empty;
            Promotion promo = new PromoСode();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => promo.Description = test);

        }

        [TestMethod]
        public void Description_sets_value_when_input_string_is_correct()
        {

            //Arrange
            string test = "deccription";
            Promotion promo = new PromoСode();

            //Act
            promo.Description = test;

            //Assert
            Assert.AreEqual(test, promo.Description);

        }

        [TestMethod]
        public void Rating_throws_ArgumentException_when_input_number_is_out_of_range()
        {

            //Arrange
            double test = -15;
            Promotion promo = new PromoСode();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => promo.Rating = test);

        }

        [TestMethod]
        public void Rating_update_value_when_input_number_is_correct()
        {

            //Arrange
            Promotion promo = new PromoСode();
            double expected = 3.5;
            double actual;

            //Act
            promo.Rating = 4.5;
            promo.Rating = 2.5;
            actual = promo.Rating;

            //Assert
            Assert.AreEqual(expected,actual);

        }
    }
}
