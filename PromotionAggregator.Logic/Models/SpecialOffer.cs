using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PromotionAggregator.Logic.Models
{
    public class SpecialOffer : Promotion
    {
        [JsonProperty]
        private string url = string.Empty;

        [JsonIgnore]
        public string Url 
        { 
            get=>url;
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                    throw new ArgumentException();
                url = value;
            }
        }
    }
}
