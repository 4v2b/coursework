using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;

namespace PromotionAggregator.Logic.Context
{
    internal class Context
    {
        private static Context instance = null;

        private List<Promotion> promotions;
        private List<User> users;
        private List<Shop> shops;

        private Context()
        {

        }

        public static Context Instance
        {
            get
            {
                if (instance == null)
                    instance = new Context();
                return instance;
            }
        }

        public List<Promotion> Promotions {
            get => promotions;
            private set => promotions = value;
        }

        public List<User> Users
        {
            get => users;
            private set => users = value;
        }

        public List<Shop> Shops
        {
            get => shops;
            private set => shops = value;
        }

        public void SaveAll()
        {

        }

    }

}
