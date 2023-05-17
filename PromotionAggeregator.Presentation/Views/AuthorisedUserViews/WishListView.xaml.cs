using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class WishListView : Page
    {
        public AuthorisedUser CurrentUser { get; set; }

        public WishListView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter is AuthorisedUser)
            {
                CurrentUser = e.Parameter as AuthorisedUser;
                message.Visibility = Visibility.Collapsed;
                var list = Context.Instance.Promotions.FindAll(x => CurrentUser.WishlistContains(x.Id));
                if(list?.Count < 1)
                {
                    message.Visibility = Visibility.Visible;
                }
                wishList.ItemsSource = list;
            }
            base.OnNavigatedTo(e);
        }

        private void GetPromotionDetailsClick(object sender, ItemClickEventArgs e)
        {
            var parameters = Tuple.Create(e.ClickedItem as Promotion, CurrentUser);
            Frame.Navigate(typeof(PromotionDetailsAuthorisedUserView), parameters);
        }

        private void RemovePromotionClick(object sender, string e)
        {
            CurrentUser.RemoveFromWishlist(e);
            Frame.Navigate(typeof(WishListView), CurrentUser);
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisedUserMainPage), CurrentUser);
        }
    }
}
