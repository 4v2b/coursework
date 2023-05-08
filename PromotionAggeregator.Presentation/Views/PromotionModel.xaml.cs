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
                title.Text = promotion.Title;
                description.Text = promotion.Description;
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
    }
}
