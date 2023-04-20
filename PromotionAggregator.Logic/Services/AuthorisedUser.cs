using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PromotionAggregator.Logic.Services
{
    public class AuthorisedUser:User
    {
        [JsonInclude]
        private Wishlist wishlist;

        public AuthorisedUser(string email, string password):
            base(email, password)
        {
            wishlist = new Wishlist();
        }

        public AuthorisedUser() : base() { }

        [JsonIgnore]
        public Wishlist Wishlist
        {
            get => wishlist;
        }

        public void PostComment(string text, string promotionId)
        {
            var comments = Context.Context.Instance.Promotions.Find(x => x.Id.Equals(promotionId))?.Comments;
            if (comments == null)
                throw new ArgumentException();
            else
                comments.Add(new Comment(text, DateTime.Now, Id));
        }

        public void AddToWishlist(string promotionId)
        {
            if (string.IsNullOrEmpty(promotionId))
                throw new ArgumentException();
            wishlist.Add(promotionId);
        }

        public bool RemoveFromWishlist(string promotionId)
        {
            return wishlist.Remove(promotionId);
        }

    }
}
