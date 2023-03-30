using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Models
{
    internal class Shop
    {
        private string name;
        private string url;

        public Shop(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Url { get; private set; }
    }
}
