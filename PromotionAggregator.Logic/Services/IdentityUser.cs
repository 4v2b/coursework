using PromotionAggregator.Logic.Interfaces;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Context;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls.Maps;

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
           this.user = user;
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
            Dictionary<Category, List<string>> pairs = new Dictionary<Category, List<string>>();



            return new List<Promotion>();
        }

        public List<Promotion> Filter(int promoCodeFilter = 0, int order = 0)
        {
            List<Promotion> promotions = Context.Context.Instance.Promotions;
            List<Promotion> filteredList = new List<Promotion>();
            if (promoCodeFilter < 0)
            {
               filteredList.AddRange(promotions.FindAll(x => x is PromoСode));
            }
            else if(promoCodeFilter > 0)
            {
                filteredList.AddRange(promotions.FindAll(x => x is SpecialOffer));
            }
            else
            {
                filteredList.AddRange(promotions);
            }



            return new List<Promotion>();
        }

    }
}