using PromotionAggeregator.Presentation.Services;
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

        private Dictionary<string, Category> categoryMap;

        private List<Category> selectedCategories;

        public AddPromoCodeDialog()
        {
            this.InitializeComponent();
            shopBox.ItemsSource = Context.Instance.Shops;
            categoryMap = Util.CategoryMap;
            selectedCategories = new List<Category>();
        }

        public event EventHandler<PromoСode> PromoCodeConfirmed;

        private void ContentDialog_CofirmClick(object sender, RoutedEventArgs e)
        {
            try
            {
                promoCode = new PromoСode();
                promoCode.Title = titleBox.Text;
                promoCode.Description = descBox.Text;
                promoCode.ShopId = (string)shopBox.SelectedValue;

                if (selectedCategories.Count < 1)
                {
                    throw new Exception("Необхідно обрати щонайменше\nодну категорію");
                }
                else
                {
                    foreach (Category c in selectedCategories)
                    {
                        promoCode.Categories.Add(c);
                    }
                }
                this.Hide();
                PromoCodeConfirmed?.Invoke(this, promoCode);
            }
            catch (Exception ex)
            {
                errorMessage.Visibility = Visibility.Visible;
                errorMessage.Text = ex.Message;
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            selectedCategories.Add((Category)(sender as CheckBox).CommandParameter);
        }

        private void UncheckBox_Checked(object sender, RoutedEventArgs e)
        {
            selectedCategories.Remove((Category)(sender as CheckBox).CommandParameter);
        }
    }
}
