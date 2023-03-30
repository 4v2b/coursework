using System;
using System.Collections.Generic;
namespace PromotionAggregator.Logic.Models
{
    internal abstract class Promotion
    {
        private double rating;
        private int ratingCounter;

        private string shopId;
        private string title;
        private string description;
        private List<Category> categories;

        public Promotion()
        {
            Id = Guid.NewGuid().ToString();
            categories = new List<Category>();
            rating = 0;
            ratingCounter = 1;
        }

        public string Id { get; private set; }
        public string Title { get=>title; set=> title = value; }
        public string Description { get=>description; set=>description = value; }
        public DateTime AddingDate { get; set; }
        public DateTime EndDate { get; set; }

        public double Rating {
            get 
            {
                return rating;
            }
            set 
            {
                if (value > 0 && value <= 5)
                    rating += value / ratingCounter++;
                else throw new ArgumentException();
            } 
        }
        public List<Category> Categories { get; private set; }
    }
}
