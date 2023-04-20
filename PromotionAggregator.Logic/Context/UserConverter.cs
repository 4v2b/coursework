using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using PromotionAggregator.Logic.Services;

namespace PromotionAggregator.Logic.Context
{
    public class UserConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => typeof(User).IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var wishlist = jo["wishlist"];

            User item;
            if (wishlist == null)
                item = new Admin();
            else
                item = new AuthorisedUser();
            serializer.Populate(jo.CreateReader(), item);
            return item;
        }

        public override bool CanWrite{ get => false;}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
