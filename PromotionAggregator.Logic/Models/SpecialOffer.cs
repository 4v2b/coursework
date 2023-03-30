using System;

namespace PromotionAggregator.Logic.Models
{
    internal class SpecialOffer : Promotion
    {
        private string url;

        public SpecialOffer(string url)
        {
            Url = url;
        }

        public string Url 
        { 
            get=>url;
            private set
            {
                if (!value.Contains("http://") || !value.Contains("https://"))
                    throw new ArgumentException("Wrong address!");
            }
        }
    }
}
