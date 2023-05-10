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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class AddShopDialog : ContentDialog
    {
        public AddShopDialog()
        {
            this.InitializeComponent();
        }

        public event EventHandler<Shop> ShopConfirmed;


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ContentDialog_CofirmClick(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop();
            try
            {
                shop.Name = titleBox.Text;
                shop.Url = linkBox.Text;
                errorMessage.Visibility = Visibility.Collapsed;
                ShopConfirmed?.Invoke(sender, shop);
            }
            catch(Exception ex)
            {
                errorMessage.Visibility = Visibility.Visible;
                errorMessage.Text = ex.Message;
            }
        }
    }
}
