using PromotionAggeregator.Presentation.Views;
using PromotionAggregator.Logic.Context;
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

        public event EventHandler<Promotion> OnPromotionClick;


        public PromotionModel()
        {
            this.InitializeComponent();
        }

        public void PromotionTapped(object sender, TappedRoutedEventArgs e)
        {
            OnPromotionClick?.Invoke(this, Promotion);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnPromotionClick?.Invoke(this, Promotion);
        }
    }
}
