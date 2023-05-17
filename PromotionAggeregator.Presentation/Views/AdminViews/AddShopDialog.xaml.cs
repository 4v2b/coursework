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

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class AddShopDialog : ContentDialog
    {
        public AddShopDialog()
        {
            this.InitializeComponent();
        }

        public event EventHandler<Shop> ShopConfirmed;

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop();
            try
            {
                shop.Name = titleBox.Text;
                shop.Url = linkBox.Text;
                errorMessage.Visibility = Visibility.Collapsed;
                ShopConfirmed?.Invoke(sender, shop);
                this.Hide();
            }
            catch(Exception ex)
            {
                errorMessage.Visibility = Visibility.Visible;
                errorMessage.Text = ex.Message;
            }
        }
    }
}
