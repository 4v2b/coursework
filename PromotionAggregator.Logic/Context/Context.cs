using System.Collections.Generic;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;

namespace PromotionAggregator.Logic.Context
{
    public class Context
    {
        private static Context instance ;

        private Context()
        {
            SetCollections();
        }

        public void SetCollections()
        {
            throw new NotImplementedException();
        }

        public static Context Instance
        {
            get => throw new NotImplementedException();
        }

        public List<Promotion> Promotions
        {
           get =>throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public List<User> Users
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public List<Shop> Shops
        {
            get => throw new NotImplementedException();
            private set => throw new NotImplementedException();
        }

        public bool SaveAll()
        {
             throw new NotImplementedException();
        }
    }
}
