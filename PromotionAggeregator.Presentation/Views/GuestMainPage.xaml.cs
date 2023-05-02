using PromotionAggeregator.Presentation.Services;
using PromotionAggeregator.Presentation.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class GuestMainPage : Page
    {
        private IdentityUser manager;
        private TextBlock resultIndicator;

        public GuestMainPage()
        {       
            this.InitializeComponent();
            searchField.OnSearchClick += Search;
            manager = new IdentityUser();
            listView.ItemsSource = Init.Convert(Context.Instance.Promotions);
            manager.Notify += ShowCount;
        }

        private void Search(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(searchField.Text))
            {
                ArrayList array = new ArrayList();
                List<PromotionModel> list = Init.Convert(manager.Search(searchField.Text));
                array.Add(resultIndicator);
                array.AddRange(list);
                listView.ItemsSource = array;
            }
            else listView.ItemsSource = Init.Convert(Context.Instance.Promotions);
          
        }

        private void ShowCount(int count)
        {
            resultIndicator = new TextBlock();
            resultIndicator.FontWeight = Windows.UI.Text.FontWeights.Bold;
            string text = string.Empty;
            resultIndicator.TextAlignment = TextAlignment.Left;
            if (count != 0)
            {
                resultIndicator.FontSize = 16;
                text = $"\nЗнайдено результатів: {count}\n";
            }
            else
            {
                resultIndicator.FontSize = 20;
                text = "\nРезультатів не знайдено\n";
            }
           resultIndicator.Text = text;
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisationPage));
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationPage));

        }
    }
}
