using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections.Generic;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void AddPromotion_modify_Promotion_collection()
        {
            //Arrange
            User user = new Admin("example@gmail.com", "password");
            bool result;
            Promotion promotion = new SpecialOffer();

            List<Promotion> promotions = Context.Instance.Promotions;

            //Act
            user.AddPromotion(promotion);
            result = promotions.Contains(promotion);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddPromotion_throws_ArgumentNullException_when_promotion_is_null()
        {
            //Arrange
            User user = new Admin("example@gmail.com", "password");

            //Act+Assert
            Assert.ThrowsException<ArgumentNullException>(()=>user.AddPromotion(null));
        }

        [TestMethod]
        public void Email_throw_ArgumentException_when_input_string_has_incorrect_format()
        {
            //Arrange
            string email = "email";
            string password = "password";

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => new Admin(email, password));

        }


        [TestMethod]
        public void Email_sets_value_when_input_string_has_correct_format()
        {
            //Arrange
            string email = "example@gmail.com";
            string password = "password";
            User user;

            //Act
            user =  new Admin(email, password);

            //Assert
            Assert.AreEqual(email, user.Email);

        }

        [TestMethod]
        public void Password_throw_ArgumentException_when_input_string_is_too_short()
        {
            //Arrange
            string email = "example@gmail.com";
            string password = "pass";

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => new Admin(email, password));

        }


        [TestMethod]
        public void Password_sets_encoded_value_when_input_string_has_correct_format()
        {
            //Arrange
            string email = "example@gmail.com";
            string password = "password";
            User user;

            //Act
            user = new Admin(email, password);

            //Assert
            Assert.AreNotEqual(password, user.Password);

        }


        [TestMethod]
        public void CheckPassword_returns_true_when_passwords_match()
        {
            //Arrange
            string email = "example@gmail.com";
            string password = "password";
            User user = new Admin(email, password);
            bool result;

            //Act
            result = user.CheckPassword(password);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void CheckPassword_returns_false_when_passwords_do_not_match()
        {
            //Arrange
            string email = "example@gmail.com";
            string password = "password";
            User user = new Admin(email, password);
            bool result;

            //Act
            result = user.CheckPassword("somepassword");

            //Assert
            Assert.IsFalse(result);

        }

    }
}
