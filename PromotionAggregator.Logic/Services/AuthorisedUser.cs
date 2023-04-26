using Newtonsoft.Json;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;

namespace PromotionAggregator.Logic.Services
{
    public class AuthorisedUser:User
    {
        public AuthorisedUser(string email, string password):
            base(email, password)
        {
            Wishlist = new Wishlist();
        }

        public AuthorisedUser() : base() { }

        [JsonProperty]
        public Wishlist Wishlist
        {
            get;
            private set;
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
            Wishlist.Add(promotionId);
        }

        public bool RemoveFromWishlist(string promotionId)
        {
            return Wishlist.Remove(promotionId);
        }

    }
}
