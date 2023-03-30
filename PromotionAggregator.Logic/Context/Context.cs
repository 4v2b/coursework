using System.Collections;
using System.Collections.Generic;
using PromotionAggregator.Logic.Models;

namespace PromotionAggregator.Logic.Contexts
{
    internal class Context
    {
        private List<Promotion> promotionList;
        private List<User> userList;
        private List<Shop> shopList;

        public Context(List<Promotion> promotionList, List<User> userList, List<Shop> shopList)
        {
            PromotionList = promotionList;
            UserList = userList;
            ShopList = shopList;
            
        }

        public List<Promotion> PromotionList {
            get => promotionList;
            private set => promotionList = value;
        }
        public List<User> UserList
        {
            get => userList;
            private set => userList = value;
        }
        public List<Shop> ShopList
        {
            get => shopList;
            private set => shopList = value;
        }
    }

}
