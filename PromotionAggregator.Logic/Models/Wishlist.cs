using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Models
{
    internal class Wishlist
    {
        public List<int> Promotions { get; set; }
        public string UserId { get; set; }
    }
}
