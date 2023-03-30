using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Services
{
    internal class AuthorisedUser:User
    {
        private Wishlist wishlist;
        private List<Comment> comments;

        public AuthorisedUser(string id):base(id)
        {

        }

        public List<Comment> Comments
        {
            get => comments;
        }

        public void PostComment(string text, string promotionId)
        {

        }

        public void AddToWishlist(string promotionId)
        {

        }

        public void RemoveFromWishlist(string promotionId)
        {

        }
    }
}
