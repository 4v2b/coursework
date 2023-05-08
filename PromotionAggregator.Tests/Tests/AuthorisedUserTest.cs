using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using PromotionAggregator.Logic.Context;
using System;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class AuthorisedUserTest
    {
        [TestMethod]
        public void PostComment_Modify_Comment_Collection()
        {
            //Arrange
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "12345678");
            var promotions = Context.Instance.Promotions;
            Promotion promotion = new SpecialOffer();
            bool result;

            //Act
            promotions.Add(promotion);
            user.PostComment("Temp", promotion.Id);
            result = promotion.Comments.Exists(x => x.UserId == user.Id && x.Text == "Temp");

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void PostComment_throws_ArgumentException_when_promotionId_is_invalid()
        {
            //Arrange
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "12345678");

            //Act+Assert
            Assert.ThrowsException<ArgumentException>(()=>user.PostComment("Temp", "some id"));

        }

        [TestMethod]
        public void AddToWishList_modify_Wishlist_when_input_string_is_correct()
        {
            //Arrange
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "12345678");
            string promotionId = "id";
            bool result;

            //Act
            user.AddToWishlist(promotionId);
            result = user.Wishlist.Exists(x => x.Equals(promotionId));

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void AddToWishList_throws_ArgumentException_when_input_string_is_null()
        {
            //Arrange
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "12345678");
            string promotionId = null;

            //Act + Assert
            Assert.ThrowsException<ArgumentException>(() => user.AddToWishlist(promotionId));

        }

        [TestMethod]
        public void RemoveFromWishList_returns_true_when_removing_is_successful()
        {
            //Arrange
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "12345678");
            string promotionId = "id";
            user.AddToWishlist(promotionId);
            bool result;

            //Act
            result = user.RemoveFromWishlist(promotionId);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void RemoveFromWishList_returns_false_when_Promotion_not_found()
        {
            //Arrange
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "12345678");
            string promotionId = "id";
            bool result;

            //Act
            result = user.RemoveFromWishlist(promotionId);

            //Assert
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void RatePromotion_returns_true_when_to_rate_Promotion_possible()
        {
            //Arrange
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "12345678");
            var promotions = Context.Instance.Promotions;
            Promotion promotion = new SpecialOffer();
            bool result;

            //Act
            promotions.Add(promotion);   
            result = user.RatePromotion(promotion.Id, 5);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RatePromotion_returns_false_when_to_rate_Promotion_second_time()
        {
            //Arrange
            AuthorisedUser user = new AuthorisedUser("example@gmail.com", "12345678");
            var promotions = Context.Instance.Promotions;
            Promotion promotion = new SpecialOffer();
            bool result;

            //Act
            promotions.Add(promotion);
            user.RatePromotion(promotion.Id, 5);
            result = user.RatePromotion(promotion.Id, 5);

            //Assert
            Assert.IsTrue(result);
        }

    }
}
