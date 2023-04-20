using PromotionAggregator.Logic.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Context;

namespace PromotionAggregator.Tests.Tests
{
    [TestClass]
    public class IdentityUserTest
    {
        [TestMethod]
        public void User_throws_ArgumentNullException_when_field_is_null()
        {
            //Arrange
            IdentityUser identity = new IdentityUser();

            //Act + Assert
            Assert.ThrowsException<ArgumentNullException>(()=>identity.User);
        }

        [TestMethod]
        public void Filter_returns_empty_collection_when_no_one_promotion_match()
        {
            //Arrange
            IdentityUser identity = new IdentityUser();
            PromoСode promoСode = new PromoСode();
            Context.Instance.Promotions.Clear();
            new Admin().AddPromotion(promoСode);
            int expected = 0;

            //Act
            int actual = identity.Filter(FilterMode.OnlyOffer).Count;

            //Act + Assert
            Assert.AreEqual(expected,actual );
        }

        [TestMethod]
        public void Filter_returns_collection_when_match_found()
        {
            //Arrange
            IdentityUser identity = new IdentityUser();
            PromoСode promoСode = new PromoСode();
            Context.Instance.Promotions.Clear();
            new Admin().AddPromotion(promoСode);
            int expected = 1;

            //Act
            int actual = identity.Filter(FilterMode.OnlyCode).Count;

            //Act + Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPromotionsInCategory_returns_empty_collection_when_no_one_promotion_match()
        {
            //Arrange
            IdentityUser identity = new IdentityUser();
            PromoСode promoСode = new PromoСode();
            promoСode.Categories.Add(Category.Fashion);
            Context.Instance.Promotions.Clear();
            new Admin().AddPromotion(promoСode);
            int expected = 0;

            //Act
            int actual = identity.GetPromotionsInCategory(Category.Garden).Count;

            //Act + Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPromotionsInCategory_returns_collection_when_match_found()
        {
            //Arrange
            IdentityUser identity = new IdentityUser();
            PromoСode promoСode = new PromoСode();
            promoСode.Categories.Add(Category.Garden);
            Context.Instance.Promotions.Clear();
            new Admin().AddPromotion(promoСode);
            int expected = 1;

            //Act
            int actual = identity.GetPromotionsInCategory(Category.Garden).Count;

            //Act + Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Search_returns_empty_collection_when_no_one_promotion_match()
        {
            //Arrange
            IdentityUser identity = new IdentityUser();
            PromoСode promoСode = new PromoСode()
            {
                Title ="Discount 50%"
            };
            Context.Instance.Promotions.Clear();
            new Admin().AddPromotion(promoСode);
            string match = "Sells";
            int expected = 0;

            //Act
            int actual = identity.Search(match).Count;

            //Act + Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Search_returns_collection_when_match_found()
        {
            //Arrange
            IdentityUser identity = new IdentityUser();
            PromoСode promoСode = new PromoСode()
            {
                Title = "Discount 50%"
            };
            Context.Instance.Promotions.Clear();
            new Admin().AddPromotion(promoСode);
            string match = "50%";
            int expected = 1;

            //Act
            int actual = identity.Search(match).Count;

            //Act + Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
