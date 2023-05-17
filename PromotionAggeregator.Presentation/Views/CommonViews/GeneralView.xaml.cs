using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class GeneralView : UserControl
    {
        public IdentityUser IdentityUser { get; set; }

        public string Message { get=>searchInfo.Text; set=>searchInfo.Text = value; }

        public event EventHandler<Promotion> PromotionTap;

        public void Search(object sender, List<Promotion> e)
        {
            listView.ItemsSource = e;
        }

        public GeneralView()
        {
            this.InitializeComponent();
            SetDefaultState(shops);
           
            Refresh();
            searchInfo.Visibility = Visibility.Collapsed;
        }

        private void FilterClick(object sender, List<Promotion> e)
        {
            listView.ItemsSource = e;
        }

        private void ResetClick(object sender, EventArgs e)
        {
            searchInfo.Visibility = Visibility.Collapsed;
            Refresh();
        }

        private void PromotionClick(object sender, ItemClickEventArgs e)
        {
            PromotionTap?.Invoke(sender, e.ClickedItem as Promotion);
        }

        private void GetPromotionsInShop(object sender, ItemClickEventArgs e)
        {
            var promotions = IdentityUser.GetPromotionsOfShop((e.ClickedItem as Shop).Id);
            listView.ItemsSource = promotions;
        }

        public void GetPromotionsInShop(string shopId)
        {
            var promotions = IdentityUser.GetPromotionsOfShop(shopId);
            listView.ItemsSource = promotions;
        }

        private void SetDefaultState(ListView list)
        {
            List<Shop> firstChoise = Context.Instance.Shops;
            if (firstChoise.Count > 5)
            {
                list.ItemsSource = firstChoise.GetRange(0, 5);
                moreBtn.Visibility = Visibility.Visible;
            }
            else
            {
                list.ItemsSource = Context.Instance.Shops;
                moreBtn.Visibility = Visibility.Collapsed;
            }

            if (firstChoise.Count < 1)
            {
                shopsInfo.Visibility = Visibility.Visible;
            }
            else
            {
                shopsInfo.Visibility = Visibility.Collapsed;
            }
        }

        private void ExpandShopList(object sender, RoutedEventArgs e)
        {
            shops.ItemsSource = Context.Instance.Shops;
            moreBtn.Visibility = Visibility.Collapsed;
        }

        public void GetNumberOfResults(int count)
        {
            searchInfo.Visibility = Visibility.Visible;
            searchInfo.FontWeight = Windows.UI.Text.FontWeights.SemiBold;
            string text = string.Empty;
            if (count != 0)
            {
                searchInfo.FontWeight = Windows.UI.Text.FontWeights.Medium;
                searchInfo.FontSize = 14;
                text = $"\nЗнайдено результатів: {count}\n";
            }
            else
            {
                searchInfo.FontWeight = Windows.UI.Text.FontWeights.SemiBold;
                searchInfo.FontSize = 20;
                text = "\nРезультатів не знайдено\n";
            }
            searchInfo.Text = text;
        }

        private void PromotionClick(object sender, Promotion e)
        {
            PromotionTap?.Invoke(sender, e);
        }

        public void Refresh()
        {
            if (Context.Instance.Promotions.Count < 1)
            {
                searchInfo.FontWeight = Windows.UI.Text.FontWeights.SemiBold;
                searchInfo.FontSize = 20;
                searchInfo.Text = "\nСписок акційних пропозицій порожній\n";
                searchInfo.Visibility = Visibility.Visible;
            }
            else
            {
                searchInfo.Visibility = Visibility.Collapsed;
            }
            listView.ItemsSource = Context.Instance.Promotions.OrderByDescending(p=>p);
        }
    }
}
