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
    public sealed partial class AddPromotionDialog : ContentDialog
    {
        private Promotion promotion;

        private Dictionary<string, Category> categoryMap;

        private List<Category> selectedCategories;

        public AddPromotionDialog()
        {
            categoryMap = CategoryResource.CategoryMap;
            this.InitializeComponent();
            offerCheck.IsChecked = true;
            shopBox.ItemsSource = Context.Instance.Shops;
            selectedCategories = new List<Category>();
        }

        public event EventHandler<Promotion> PromotionConfirmed;

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
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
                    promotion = new PromoCode();
                    ((PromoCode)promotion).Code = uniqueAtributeValue.Text;
                }
                promotion.Title = titleBox.Text;
                promotion.Description = descBox.Text;
                promotion.EndDate = datePick.Date.DateTime;

                if (selectedCategories.Count < 1)
                {
                    throw new Exception("Необхідно обрати щонайменше\nодну категорію");
                }
                else
                {
                    foreach (Category c in selectedCategories)
                    {
                        promotion.Categories.Add(c);
                    }
                }
                promotion.ShopId = (string)shopBox.SelectedValue;
                PromotionConfirmed(this, promotion);
                this.Hide();
            }
            catch (Exception ex)
            {
                errorMessage.Visibility = Visibility.Visible;
                errorMessage.Text = ex.Message;
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