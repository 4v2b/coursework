using PromotionAggregator.Logic.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace PromotionAggeregator.Presentation.ViewModels
{
    public sealed partial class PromotionModel : UserControl
    {
        private Promotion promotion;

        public Promotion Promotion
        {
            get => promotion;
            set
            {
                promotion = value;
                if (promotion.Description.Length > 30)
                {
                    description.Text = promotion.Description.Substring(0, 30) + "...";
                }
                else
                {
                    description.Text = promotion.Description;
                }

                if (promotion.Title.Length > 20)
                {
                    title.Text = promotion.Title.Substring(0, 19) + "...";
                }
                else
                {
                    title.Text = promotion.Title;
                }
                if(Promotion is PromoCode)
                {
                    type.Text = "Промокод";
                }
                else
                {
                    type.Text = "Акція";
                }
            }
        }

        public event EventHandler<Promotion> PromotionClicked;


        public PromotionModel()
        {
            this.InitializeComponent();
        }

        public void PromotionTap(object sender, TappedRoutedEventArgs e)
        {
            PromotionClicked?.Invoke(this, Promotion);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            PromotionClicked?.Invoke(this, Promotion);
        }
    }
}
