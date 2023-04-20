using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using PromotionAggregator.Logic.Models;

namespace PromotionAggregator.Logic.Context
{
    public class PromotionConverter: JsonConverter
    {  
            public override bool CanConvert(Type objectType)=>typeof(Promotion).IsAssignableFrom(objectType);

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jo = JObject.Load(reader);
                var url = jo["url"];

                Promotion item;
                if (url == null)
                    item = new PromoСode();
                else
                    item = new SpecialOffer();
                serializer.Populate(jo.CreateReader(), item);
                return item;
            }

            public override bool CanWrite { get => false;}
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                =>throw new NotImplementedException();     
    }
}
