using PromotionAggregator.Logic.Interfaces;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggregator.Logic.Services
{
    internal class User: IAddition<Promotion>
    {
        private string id;

        public User(string id)
        {

        }

        public string Id { get; private set; }

        public void Add(Promotion promotion)
        {

        }

    }
}
