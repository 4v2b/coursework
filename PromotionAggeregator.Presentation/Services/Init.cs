using PromotionAggeregator.Presentation.ViewModels;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition.Interactions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace PromotionAggeregator.Presentation.Services
{
    public class Init
    {
        //public List<PromotionModel> viewItems;
        //private List<Promotion> promotions;

        public static void BindClick(Action<object, Promotion> action, ArrayList arrayList)
        {
            foreach(var i in arrayList)
            {
                if(i is PromotionModel)
                {
                    (i as PromotionModel).OnPromotionClick += action.Invoke;
                }
            }
        }

        public static ArrayList Convert(List<Promotion> promotions)
        {
            ArrayList viewItems = new ArrayList();
            foreach (var item in promotions)
            {
                PromotionModel model = new PromotionModel();
                model.Promotion = item;
                viewItems.Add(model);
            }
            return viewItems;
        }

        public static TextBlock GetMessageButton(int count)
        {
            TextBlock resultIndicator = new TextBlock();
            resultIndicator.FontWeight = Windows.UI.Text.FontWeights.Bold;
            string text = string.Empty;
            resultIndicator.TextAlignment = TextAlignment.Left;
            if (count != 0)
            {
                resultIndicator.FontSize = 16;
                text = $"\nЗнайдено результатів: {count}\n";
            }
            else
            {
                resultIndicator.FontSize = 20;
                text = "\nРезультатів не знайдено\n";
            }
            resultIndicator.Text = text;
            return resultIndicator;
        }

    }
}
