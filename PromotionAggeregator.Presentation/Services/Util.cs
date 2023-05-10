using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionAggeregator.Presentation.Services
{
    public static class Util
    {
        private static readonly Dictionary<string, Category> categoryMap = new Dictionary<string, Category>()
            {
                { "Сад та город", Category.Garden} ,
                { "Мода", Category.Fashion} ,
                { "Електроніка", Category.Electronics } ,
                { "Книги", Category.Books } ,
                { "Здоров'я", Category.Health } ,
                { "Аксесуари", Category.Accesories } ,
                { "Дім", Category.House },
                { "Розваги", Category.Entertainment }
            };

        public static Dictionary<string, Category> CategoryMap { get=>categoryMap; }
    }
}
