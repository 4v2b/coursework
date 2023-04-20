using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;

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
            if (shop != null)
                Context.Context.Instance.Shops.Add(shop);
            else throw new ArgumentNullException();
        }

        public bool RemoveComment(string userId, string promotionId)
        {
            List<Comment> comments = Context.Context.Instance.Promotions.Find(x => x.Id.Equals(promotionId))?.Comments;
            if (comments != null)
                return comments.Remove(comments.Find(x => x.UserId.Equals(userId)));
            return false;
        }

        public bool RemovePromotion(string promotionId)
        {
            List<Promotion> promotions = Context.Context.Instance.Promotions;
            return promotions.Remove(promotions.Find(x => x.Id.Equals(promotionId)));
        }

        public void UpdateCategories(string promotionId, Category category)
        {
            var temp = Context.Context.Instance.Promotions.Find(x => x.Id.Equals(promotionId));
            if (temp != null)
            {
                if (temp.Categories.Add(category))
                    return;
            }
            throw new ArgumentException();
        }

        public bool RemoveShop(string shopId)
        {
            List<Shop> shops = Context.Context.Instance.Shops;
            return shops.Remove(shops.Find(x => x.Id.Equals(shopId)));
        }

        public bool GrantUser(string email)
        {
            var users = Context.Context.Instance.Users;
            User oldUser = users.Find(x => x.Email.Equals(email));
            if (oldUser != null && !(oldUser is Admin) 
                && Context.Context.Instance.Users.Remove(oldUser))
                {
                    Context.Context.Instance.Users.Add(new Admin(oldUser));
                    return true;
                }
            return false;
        }
    }
}
