using PromotionAggregator.Logic.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class PromotionAdminItem : UserControl
    {
        private Promotion promotion;
        public Promotion Promotion
        {
            get => promotion;
            set
            {
                promotion = value;
                type.Text = promotion is PromoCode ? "Промокод" : "Акція";
                title.Text = promotion.Title;
                description.Text = promotion.Description;
                endDate.Text = "Діє до:\n" + promotion.EndDate.ToShortDateString();
                startdate.Text = "Додано:\n" + promotion.AddingDate.ToShortDateString();
            }
        }

        public event EventHandler<Promotion> PromotionDeleting;

        public PromotionAdminItem()
        {
            this.InitializeComponent();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            PromotionDeleting?.Invoke(sender, Promotion);
        }

        private void HideClick(object sender, RoutedEventArgs e)
        {
            myFlyout.Hide();
        }
    }
}
