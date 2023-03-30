using System;
using System.Collections;
using System.Collections.Generic;

namespace PromotionAggregator.Logic.Models
{
    internal class Wishlist : IEnumerable
    {
        private List<string> promotion;

        public List<string> Promotions { get; set; }

        public Wishlist()
        {

        }

        public IEnumerator GetEnumerator()
        {
            return promotion.GetEnumerator();
        }
    }
}
