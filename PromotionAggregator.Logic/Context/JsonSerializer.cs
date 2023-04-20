using System.Collections.Generic;
using Windows.Storage;
using System.IO;
using Newtonsoft.Json;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;

namespace PromotionAggregator.Logic.Context
{
    public class JsonSerializer<T>
    {
        private static readonly string localFolder = ApplicationData.Current.LocalFolder.Path;

        public static void Serialize(string file, List<T> items)
        {
            if (items == null || !file.Contains(".json"))
                throw new ArgumentException();
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText($"{localFolder}/{file}", json);
        }

        public static List<T> Deserialize(string file)
        {
            string json = File.ReadAllText($"{localFolder}/{file}");
            Type type = typeof(T);
            if(type == typeof(Promotion))
                return JsonConvert.DeserializeObject<List<T>>(json, 
                    new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new PromotionConverter() }
                    });
            else if(type == typeof(User))
                return JsonConvert.DeserializeObject<List<T>>(json, 
                    new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new UserConverter() }
                    });
            else return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
