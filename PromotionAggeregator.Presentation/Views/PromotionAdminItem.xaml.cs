using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
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
    public sealed partial class AdminPromotionView : UserControl
    {
        private Promotion promotion;
        public Promotion Promotion {
            get => promotion;
            set
            {
                promotion = value;
                title.Text = promotion.Title;
                description.Text = promotion.Description;
                endDate.Text = "Дійсне до: "+ promotion.EndDate.ToShortDateString();
                startdate.Text = "Додано: "+promotion.AddingDate.ToShortDateString();
            }
        }

        public event EventHandler<Promotion> OnDeleteClick;

        public AdminPromotionView()
        {
            this.InitializeComponent();
            //Promotion = DataContext as Promotion;
            //title.Text = Promotion.Title;
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            OnDeleteClick?.Invoke(sender, Promotion);
        }

        private void HideClick(object sender, RoutedEventArgs e)
        { 
                myFlyout.Hide();
        }
    }
}
