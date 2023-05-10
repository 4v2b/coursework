using Newtonsoft.Json;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;

namespace PromotionAggregator.Logic.Services
{
    public class AuthorisedUser : User
    {
        [JsonProperty]
        private HashSet<string> RatedPromotions { get; set; }

        public AuthorisedUser(string email, string password) :
            base(email, password)
        {
            Wishlist = new Wishlist();
            RatedPromotions = new HashSet<string>();
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
            {
                throw new ArgumentException();
            }
            else
            {
                comments.Add(new Comment(text, DateTime.Now, Id));
                RatedPromotions.Add(promotionId);
            }
        }

        public void AddToWishlist(string promotionId)
        {
            if (string.IsNullOrEmpty(promotionId) || Wishlist.Contains(promotionId))
                throw new ArgumentException();
            Wishlist.Add(promotionId);
        }

        public bool RemoveFromWishlist(string promotionId)
        {
            return Wishlist.Remove(promotionId);
        }

        public bool RatePromotion(string promotionId, double rating)
        {
            if (!RatedPromotions.Contains(promotionId))
            {
                var promotion = Context.Context.Instance.Promotions?.Find(x => x.Id.Equals(promotionId));
                if (promotion != null)
                {
                    promotion.Rating = rating;
                    return true;
                }
            }
            return false;
        }

        public bool WishlistContains(string promotionId)
        {
            return Wishlist.Contains(promotionId);
        }

    }
}
