using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class AddPromoCodeDialog : ContentDialog
    {
        PromoСode promoCode;

        public AddPromoCodeDialog()
        {
            this.InitializeComponent();
            shopBox.ItemsSource = Context.Instance.Shops;
        }

        public event EventHandler<PromoСode> PromoCodeConfirmed;

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            PromoCodeConfirmed(this, getNewPromotion().Result);
        }

        private async Task<PromoСode> getNewPromotion()
        {
            try
            {
                promoCode = new PromoСode();
                promoCode.Title = titleBox.Text;
                promoCode.Description = descBox.Text;
                promoCode.ShopId = (string)shopBox.SelectedValue;
                return promoCode;
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
                return null;
            }

        }

    }
}
