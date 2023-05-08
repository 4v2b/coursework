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
    public sealed partial class AddPromotionDialog : ContentDialog
    {
        private Promotion promotion;

        public AddPromotionDialog()
        {
            this.InitializeComponent();
            offerCheck.IsChecked = true;
            shopBox.ItemsSource = Context.Instance.Shops;
        }

        public event EventHandler<Promotion> PromotionConfirmed;

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            PromotionConfirmed(this, getNewPromotion().Result);
        }

        private async Task<Promotion> getNewPromotion()
        {
            try
            {
                if (offerCheck.IsChecked.GetValueOrDefault(false))
                {
                    promotion = new SpecialOffer();
                     ((SpecialOffer)promotion).Url = uniqueAtributeValue.Text;
                }
                else if (codeCheck.IsChecked.GetValueOrDefault(false))
                {
                    promotion = new PromoСode();
                    ((PromoСode)promotion).Code = uniqueAtributeValue.Text;
                }
                promotion.Title = titleBox.Text;
                promotion.Description = descBox.Text;
                promotion.EndDate = datePick.Date.DateTime;
                promotion.ShopId = (string)shopBox.SelectedValue;
                return promotion;
            }
            catch(Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
                return null;
            }
            
        }

        private void offerCheck_Checked(object sender, RoutedEventArgs e)
        {
            typeUniqueAtribute.Text = "Посилання на веб сторінку";
        }

        private void codeCheck_Checked(object sender, RoutedEventArgs e)
        {
            typeUniqueAtribute.Text = "Промокод";
        }
    }
}
