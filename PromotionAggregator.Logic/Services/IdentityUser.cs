using PromotionAggregator.Logic.Interfaces;
using PromotionAggregator.Logic.Models;
using System.Collections.Generic;

namespace PromotionAggregator.Logic.Services
{
    internal class IdentityUser: IContent<Promotion>
    {
        private User user;

        public event SearchHandler Notify;

        public IdentityUser()
        {

        }

        public IdentityUser(User user)
        {

        }

        public User User
        {
            get
            {
                if (user == null)
                    throw new System.ArgumentNullException();
                return user;
            }
        }

        public delegate void SearchHandler(int matchCount);

        public List<Promotion> Search(string matching)
        {
            return new List<Promotion>();
        }

        public List<Promotion> Filter(bool onlyCode, int order)
        {
            return new List<Promotion>();
        }

    }
}