using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PromotionAggregator.Logic.Services
{
    public class Admin: User
    {
        public Admin(string email, string password) : base(email, password)
        {
        }

        public Admin(User user):base(user.Email, user.Password, true)
        {
        }

        public Admin():base() { }

        public void AddShop(Shop shop)
        {
            throw new NotImplementedException();
        }

        public bool RemoveComment(string userId, string promotionId)
        {
           throw new NotImplementedException();
        }

        public bool RemovePromotion(string promotionId)
        {
           throw new NotImplementedException();
        }

        public void UpdateCategories(string promotionId, Category category)
        {
            throw new NotImplementedException();
        }

        public bool RemoveShop(string shopId)
        {
           throw new NotImplementedException();
        }

        public bool GrantUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}
