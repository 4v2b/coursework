using Newtonsoft.Json;
using System;
using System.Net.Mail;

namespace PromotionAggregator.Logic.Models
{
    public class Shop
    {
        [JsonProperty]
        private string name = string.Empty;

        [JsonProperty]
        private string url = string.Empty;

        public Shop()
        {
            Id = Guid.NewGuid().ToString();
        }

        [JsonProperty]
        public string Id { get; private set; }

        [JsonIgnore]
        public string Name { get=>name;
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                name = value;
            } }

        [JsonIgnore]
        public string Url { get=>url; 
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                    throw new ArgumentException();
                url = value;
            }
        }
    }
}
