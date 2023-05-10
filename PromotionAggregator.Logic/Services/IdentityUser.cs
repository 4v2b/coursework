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
            get
            {
                if (user == null)
                    throw new ArgumentNullException();
                if(user is AuthorisedUser)
                    return (AuthorisedUser)user;
                return (Admin)user;
            }
        }

        public delegate void SearchHandler(int matchCount);

        public List<Promotion> Search(string matching)
        {
            List<Promotion> list = Context.Context.Instance.Promotions;

            list = list.Where(x => x.Title.Contains(matching) || x.Description.Contains(matching))
                .OrderBy(x => x.AddingDate)
                .OrderBy(x => x.Rating).ToList<Promotion>();
            Notify?.Invoke(list.Count);
            return list;
        }

        public List<Promotion> Filter(FilterMode mode, double ratingLowerConstraint = -1, int periodInDays = 0)
        {
            List<Promotion> promotions = Context.Context.Instance.Promotions;
            IEnumerable<Promotion> temp;
            if (mode == FilterMode.OnlyCode)
            {
                temp = promotions.Where(x => x is PromoСode);
            }
            else if(mode == FilterMode.OnlyOffer)
            {
                temp = promotions.Where(x => x is SpecialOffer);
            }
            else
            {
                temp = promotions;
            }
            temp = temp.Where(x => x.Rating.CompareTo(ratingLowerConstraint) > -1);

            if (periodInDays > 0)
            {
                temp = temp.Where(x => x.AddingDate.CompareTo(DateTime.Now.AddDays(-periodInDays)) >=0);
            }
            Notify?.Invoke(temp.Count());
            return new List<Promotion>(temp);
        }

        public List<Promotion> GetPromotionsInCategory(Category category)
        {
            List<Promotion> promotions = Context.Context.Instance.Promotions;
            var list = from p in promotions 
                       where p.Categories.Contains(category) 
                       orderby p.Rating 
                       select p;
            Notify?.Invoke(list.Count());
            return list.ToList<Promotion>();
        }

        public List<Promotion> GetPromotionsOfShop(string shopId)
        {
            List<Promotion> promotions = Context.Context.Instance.Promotions;
            var list = from p in promotions
                       where p.ShopId.Equals(shopId)
                       orderby p
                       orderby p.Rating
                       select p;
            Notify?.Invoke(list.Count());
            return list.ToList<Promotion>();
        }

    }
}