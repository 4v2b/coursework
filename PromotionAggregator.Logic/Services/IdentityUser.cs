using PromotionAggregator.Logic.Interfaces;
using PromotionAggregator.Logic.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PromotionAggregator.Logic.Services
{
    public class IdentityUser: IContent<Promotion>
    {
        private User user;

        public event SearchHandler Notify;

        public IdentityUser()
        {
        }

        public IdentityUser(User user)
        {
           this.user = user;
        }

        public User User
        {
            get => throw new NotImplementedException();
        }

        public delegate void SearchHandler(int matchCount);

        public List<Promotion> Search(string matching)
        {
            throw new NotImplementedException();
        }

        public List<Promotion> Filter(FilterMode mode, double ratingLowerConstraint = -1, int periodInDays = 0)
        {
            throw new NotImplementedException();
        }

        public List<Promotion> GetPromotionsInCategory(Category category)
        {
            throw new NotImplementedException();
        }

    }
}