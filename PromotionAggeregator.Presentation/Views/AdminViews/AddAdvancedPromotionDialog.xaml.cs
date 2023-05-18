using PromotionAggeregator.Presentation.Services;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class AddAdvancedPromotionDialog : ContentDialog
    {
        private Promotion promotion;

        private Dictionary<string, Category> categoryMap;

        private List<Category> selectedCategories;

        public AddAdvancedPromotionDialog()
        {
            categoryMap = CategoriesMap.CategoryMap;
            this.InitializeComponent();
            offerCheck.IsChecked = true;
            shopBox.ItemsSource = Context.Instance.Shops;
            selectedCategories = new List<Category>();
        }

        public event EventHandler<Promotion> PromotionConfirmed;

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
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

        private void OfferChecked(object sender, RoutedEventArgs e)
        {
            typeUniqueAtribute.Text = "Посилання на веб сторінку";
        }

        private void CodeChecked(object sender, RoutedEventArgs e)
        {
            typeUniqueAtribute.Text = "Промокод";
        }

        private void ChategoriesChecked(object sender, RoutedEventArgs e)
        {
            selectedCategories.Add((Category)(sender as CheckBox).CommandParameter);
        }

        private void CategoriesUnchecked(object sender, RoutedEventArgs e)
        {
            selectedCategories.Remove((Category)(sender as CheckBox).CommandParameter);
        }
    }
}