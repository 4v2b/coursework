using Newtonsoft.Json;
using System;

namespace PromotionAggregator.Logic.Models
{
    public class Comment
    {
        [JsonProperty]
        private string text;

        [JsonProperty]
        private string userId;

        public Comment(string text, DateTime date, string userId)
        {
            PublicationDate = date;
            Text = text;
            UserId = userId;
        }

        public DateTime PublicationDate { get; private set;}

        [JsonIgnore]
        public string Text
        {
            get => text;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                text = value;
            }
        }

        [JsonIgnore]
        public string UserId
        {
            get=>userId; 
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                userId = value;
            }
        }

    }
}
