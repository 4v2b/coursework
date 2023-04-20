using System;

namespace PromotionAggregator.Logic.Models
{
    public class Shop
    {
        private string name;
        private string url;

        public Shop()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        public string Name {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Url {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
