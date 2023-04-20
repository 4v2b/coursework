using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PromotionAggregator.Logic.Models
{
    public abstract class Promotion
    {
        [JsonProperty]
        private double rating = default;

        [JsonProperty]
        private int ratingCounter = default;

        [JsonProperty]
        private string title = string.Empty;

        [JsonProperty]
        private string description = string.Empty;

        public Promotion() {
            Id = Guid.NewGuid().ToString();
            Categories = new HashSet<Category>();
            Comments = new List<Comment>();
        }

        public string ShopId { get; set; } = string.Empty;

        [JsonProperty]
        public string Id { get; private set; }

        [JsonIgnore]
        public string Title { get=>title; set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                title = value;
            }
            }

        [JsonIgnore]
        public string Description { get=>description; set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(); 
                description = value; 
            } }

        public DateTime AddingDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public double Rating {
            get 
            {
                return rating;
            }
            set 
            {
                if (value > 0 && value <= 5)
                    rating = (value + Rating) / ++ratingCounter;
                else throw new ArgumentException();
            } 
        }

        [JsonProperty]
        public HashSet<Category> Categories { get; private set; }

        [JsonProperty]
        public List<Comment> Comments{ get; private set; }


    }
}
