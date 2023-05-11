using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class WishlistItem : UserControl
    {
        private Promotion promotion;

        public event EventHandler<string> OnRemoveClick;

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
                title.Text = promotion.Title;
                endDate.Text = "Дійсне до: " + promotion.EndDate.ToShortDateString();
            }
        }

        public WishlistItem()
        {
            this.InitializeComponent();
        }

        private void wishBtn_Click(object sender, RoutedEventArgs e)
        {
            OnRemoveClick?.Invoke(sender, promotion.Id);
        }
    }
}
