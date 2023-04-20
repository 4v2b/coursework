using System;
using System.Collections.Generic;

namespace PromotionAggregator.Logic.Models
{
    public abstract class Promotion
    {
        private double rating;
        private int ratingCounter;
        private string title;
        private string description;

        public Promotion() {
            Id = Guid.NewGuid().ToString();
            Categories = new HashSet<Category>();
            Comments = new List<Comment>();
        }

        public string ShopId { get=> throw new NotImplementedException();
            set=> throw new NotImplementedException(); }

        public string Id { get=> throw new NotImplementedException(); 
            private set => throw new NotImplementedException(); }

        public string Title {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string Description {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public DateTime AddingDate { get; set; }
        public DateTime EndDate { get; set; }

        public double Rating {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public HashSet<Category> Categories { get; set; }
        public List<Comment> Comments{ get; set; }
    }
}
