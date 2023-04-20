using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PromotionAggregator.Logic.Services;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Context;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void AddShop_modify_shops_collection()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;
            Shop shop = new Shop();
            List<Shop> shops = Context.Instance.Shops;

            //Act
            admin.AddShop(shop);
            result = shops.Contains(shop);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddShop_throws_ArgumentNullException_when_shop_is_null()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();

            //Act + Assert
            Assert.ThrowsException<ArgumentNullException>(() => admin.AddShop(null));
        }

        [TestMethod]
        public void RemovePromotion_returns_true_when_Promotion_exists()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;
            Promotion promotion = new SpecialOffer();
            admin.AddPromotion(promotion);

            //Act
            result = admin.RemovePromotion(promotion.Id);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemovePromotion_returns_false_when_Promotion_does_not_exist()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;
            Promotion promotion = new SpecialOffer();

            //Act
            result = admin.RemovePromotion(promotion.Id);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveShop_returns_true_when_Shop_exists()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;
            Shop shop = new Shop();
            admin.AddShop(shop);

            //Act
            result = admin.RemoveShop(shop.Id);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveShop_returns_false_when_shop_does_not_exist_in_collection()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;
            Shop shop = new Shop();

            //Act
            result = admin.RemoveShop(shop.Id);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveCommment_returns_true_when_Comment_exists()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "password");
            Context.Instance.Users.Add(user);
            Promotion promotion = new SpecialOffer();
            admin.AddPromotion(promotion);
            user.PostComment("Temp", promotion.Id);

            //Act
            result = admin.RemoveComment(user.Id, promotion.Id);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveComment_returns_false_when_AuthorizedUser_does_not_exist()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;
            Promotion promotion = new SpecialOffer();
            admin.AddPromotion(promotion);

            //Act
            result = admin.RemoveComment("id", promotion.Id);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveComment_returns_false_when_Comment_does_not_exist()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "password");
            Context.Instance.Users.Add(user);
            Promotion promotion = new SpecialOffer();

            //Act
            result = admin.RemoveComment(user.Id, promotion.Id);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateCategories_throws_ArgumentException_when_same_Categoty_exists()
        {
            //Arrange
            var promotions = Context.Instance.Promotions;
            Promotion promotion = new PromoСode();
            promotions.Add(promotion);
            promotion.Categories.Add(Category.Books);
            Admin admin = GetDefaultAdmin();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => admin.UpdateCategories(promotion.Id, Category.Books));
        }

        [TestMethod]
        public void UpdateCategories_throws_ArgumentException_when_PromotionId_is_invalid()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => admin.UpdateCategories("id", Category.Electronics));
        }

        [TestMethod]
        public void GrantUser_returns_true_when_added_new_admin_succesfully()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            User user = Authentication.Register($"example{new Random().Next(10000)}@gmail.com", "password", "password");
            bool result;

            //Act
            result = admin.GrantUser(user.Email);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void GrantUser_returns_false_when_email_invalid()
        {
            //Arrange
            Admin admin = GetDefaultAdmin();
            bool result;

            //Act
            result = admin.GrantUser($"example{new Random().Next(10000)}@gmail.com");

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void GrantUser_returns_false_when_user_is_already_admin()
        {

            //Arrange
            Admin admin = GetDefaultAdmin();
            User user = Authentication.Register($"example{new Random().Next(10000)}@gmail.com", "password", "password");
            admin.GrantUser(user.Email);
            bool result;

            //Act
            result = admin.GrantUser(user.Email);

            //Assert
            Assert.IsFalse(result);

        }

        public Admin GetDefaultAdmin()
        {
            return new Admin("email@gmail.com", "password");
        }

    }
}
