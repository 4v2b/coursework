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

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class GuestMainPage : Page
    {
        public GuestMainPage()
        {
            this.InitializeComponent();
            ArrayList list = Init.Convert(Context.Instance.Promotions);
            Init.BindClick(PromotionTap, list);
            listView.ItemsSource = list;
        }

        private void Search(object sender, ArrayList e)
        {
            Init.BindClick(PromotionTap, e);
            listView.ItemsSource = e;
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisationPage));
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationPage));
        }

        private void PromotionTap(object sender, Promotion promotion)
        {
            Frame.Navigate(typeof(PromotionGuestView), promotion);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ArrayList)
            {
                Init.BindClick(PromotionTap, (ArrayList)e.Parameter);
                listView.ItemsSource = e.Parameter;
            }
            base.OnNavigatedTo(e);
        }

    }
}
