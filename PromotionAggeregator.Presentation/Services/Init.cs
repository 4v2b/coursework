using PromotionAggeregator.Presentation.ViewModels;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Automation.Peers;

namespace PromotionAggeregator.Presentation.Services
{
    public class Init
    {
        public List<PromotionModel> viewItems;
        private List<Promotion> promotions;

        public Init()
        {
            promotions = Context.Instance.Promotions;
            viewItems = new List<PromotionModel>();
            foreach(var item in promotions)
            {
                PromotionModel model = new PromotionModel();
                model.Description = item.Description;
                model.Title = item.Title;
                viewItems.Add(model);
            }
        }
    }
}
