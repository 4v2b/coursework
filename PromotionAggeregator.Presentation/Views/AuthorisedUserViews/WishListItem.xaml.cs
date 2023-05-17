using PromotionAggregator.Logic.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class WishlistItem : UserControl
    {
        private Promotion promotion;

        public event EventHandler<string> PromotionRemoving;

        public Promotion Promotion
        {
            get => promotion; 
            set
            {
                promotion = value;
                if(promotion is PromoCode)
                {
                    type.Text = "Промокод";
                }
                else
                {
                    type.Text = "Акція";
                }
                if (promotion.Title.Length > 20)
                {
                    title.Text = promotion.Title.Substring(0, 19) + "...";

                }
                else
                {
                    title.Text = promotion.Title;
                }
                endDate.Text = "Діє до: " + promotion.EndDate.ToShortDateString();
            }
        }

        public WishlistItem()
        {
            this.InitializeComponent();
        }

        private void RemovePromotionClick(object sender, RoutedEventArgs e)
        {
            PromotionRemoving?.Invoke(sender, promotion.Id);
        }
    }
}
