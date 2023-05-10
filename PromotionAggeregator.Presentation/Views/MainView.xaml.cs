﻿using Google.Apis.Gmail.v1.Data;
using PromotionAggeregator.Presentation.Services;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections;
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
    public sealed partial class MainView : UserControl
    {
        public IdentityUser IdentityUser { get; set; }

        public string Message { get=>searchInfo.Text; set=>searchInfo.Text = value; }

        public event EventHandler<Promotion> PromotionTap;

        public void Search(object sender, List<Promotion> e)
        {
            listView.ItemsSource = e;
        }

        public MainView()
        {
            this.InitializeComponent();
            SetDefaultState(shops);
            listView.ItemsSource = Context.Instance.Promotions;
        }

        private void Filter_OnFilterClick(object sender, List<Promotion> e)
        {
            listView.ItemsSource = e;
        }

        private void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            PromotionTap?.Invoke(sender, e.ClickedItem as Promotion);
        }

        private void shops_ItemClick(object sender, ItemClickEventArgs e)
        {
            var promotions = IdentityUser.GetPromotionsOfShop((e.ClickedItem as Shop).Id);
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
        }

        private void moreBtn_Click(object sender, RoutedEventArgs e)
        {
            shops.ItemsSource = Context.Instance.Shops;
        }

        public void CountHandler(int count)
        {
            searchInfo.FontWeight = Windows.UI.Text.FontWeights.Bold;
            string text = string.Empty;
            searchInfo.TextAlignment = TextAlignment.Left;
            if (count != 0)
            {
                searchInfo.FontSize = 16;
                text = $"\nЗнайдено результатів: {count}\n";
            }
            else
            {
                searchInfo.FontSize = 20;
                text = "\nРезультатів не знайдено\n";
            }
            searchInfo.Text = text;
        }
    }
}
