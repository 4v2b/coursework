using System.Collections.Generic;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using Windows.Networking.Connectivity;
using System;
using Newtonsoft.Json;

namespace PromotionAggregator.Logic.Context
{
    public class Context
    {
        private static Context instance = null;

        private Context()
        {
            Initialize();
        }

        public void Initialize()
        {
            
            try{ Promotions = JsonSerializer<Promotion>.Deserialize("promotions.json");}
            catch{Promotions = new List<Promotion>();}

            try{ Users = JsonSerializer<User>.Deserialize("users.json");}
            catch{ Users = new List<User>();}

            try{Shops = JsonSerializer<Shop>.Deserialize("shops.json"); }
            catch{ Shops = new List<Shop>();}
           
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
