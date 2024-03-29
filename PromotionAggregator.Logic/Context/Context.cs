﻿using System.Collections.Generic;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using Newtonsoft.Json;

namespace PromotionAggregator.Logic.Context
{
    public class Context
    {
        private static Context instance = null;

        private Context()
        {
            SetCollections();
        }

        public void SetCollections()
        {
            
            try{ Promotions = JsonSerializer<Promotion>.Deserialize("promotions.json");}
            catch{Promotions = new List<Promotion>();}

            try{ Users = JsonSerializer<User>.Deserialize("users.json");}
            catch{ Users = new List<User>();}

            try{Shops = JsonSerializer<Shop>.Deserialize("shops.json"); }
            catch{ Shops = new List<Shop>();}

            Promotions.RemoveAll(x => x.EndDate.Date.CompareTo(DateTime.Now.Date) < 0);
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

        [JsonConverter(typeof(PromotionConverter))]
        public List<Promotion> Promotions {
            get;
            private set;
        }

        public List<User> Users
        {
            get;
            private set;
        }

        public List<Shop> Shops
        {
            get;
            private set;
        }

        public bool SaveAll()
        {
            try
            {
                JsonSerializer<Promotion>.Serialize("promotions.json", Promotions);
                JsonSerializer<User>.Serialize("users.json", Users);
                JsonSerializer<Shop>.Serialize("shops.json", Shops);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
