using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Services
{
    internal class Admin: User
    {
        public Admin(string id) : base(id)
        {

        }

        public void AddShop(Shop shop)
        {

        }

        public bool RemoveComment(string userId, string promotionId)
        {
            return true;
        }

        public bool RemovePromotion(string promotionId)
        {
            return true;
        }
        public bool RemoveShop(string shopId)
        {
            return true;
        }
    }
}
