using PromotionAggregator.Logic.Models;
using System;

namespace PromotionAggregator.Logic.Services
{
    public class AuthorisedUser:User
    {
        private Wishlist wishlist;

        public AuthorisedUser(string email, string password):
            base(email, password)
        {
            wishlist = new Wishlist();
        }

        public AuthorisedUser() : base() { }

        public Wishlist Wishlist
        {
            get => throw new NotImplementedException();
        }

        public void PostComment(string text, string promotionId)
        {
           throw new NotImplementedException();
        }

        public void AddToWishlist(string promotionId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromWishlist(string promotionId)
        {
            throw new NotImplementedException();
        }
    }
}
