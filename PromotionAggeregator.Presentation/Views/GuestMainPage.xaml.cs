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
using Windows.ApplicationModel.DataTransfer;
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
            IdentityUser identityUser = new IdentityUser();
            identityUser.Notify += view.CountHandler;
            view.IdentityUser = identityUser;
            searchField.Identity = identityUser;
            searchField.OnSearchClick += view.Search;
            view.PromotionTap += PromotionTap;
            
            //listView.ItemsSource = list;
            //SetDefaultState(shops);

        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText("text");
            Clipboard.SetContent(package);
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
            //var parameters = Tuple.Create(promotion, identityUser.User as Admin);
           // Frame.Navigate(typeof(PromotionAdminView), parameters);

            if (e.Parameter is string && !string.IsNullOrEmpty(e.Parameter as string))
            {
                view.ShowAllInShop((string)e.Parameter);
            }
            base.OnNavigatedTo(e);
        }
    }
}
