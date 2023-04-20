using Newtonsoft.Json;
using System;

namespace PromotionAggregator.Logic.Models
{
    public class PromoСode : Promotion
    {
        [JsonProperty]
        private string code = string.Empty;

        [JsonIgnore]
        public string Code { get=>code;
             set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                code = value;
            } 
        }
    }
}
