using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class PromotionDetailsAuthorisedUserPage : Page
    {
        private Promotion Promotion { get; set; }
        private AuthorisedUser AuthorisedUser { get; set; }

        public PromotionDetailsAuthorisedUserPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Tuple<Promotion, AuthorisedUser> parameters)
            {
                Promotion = parameters.Item1;
                AuthorisedUser = parameters.Item2;
                details.ShopClicked += ShowShopClick;
                details.CurrentUser = AuthorisedUser;
                details.Promotion = Promotion;
            }
            base.OnNavigatedTo(e);
        }

        private void PublicateClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(commentField.Text))
            {
                AuthorisedUser.PostComment(commentField.Text, Promotion.Id);
                Context.Instance.SaveAll();
                var parameters = Tuple.Create(Promotion, AuthorisedUser);
                Frame.Navigate(typeof(PromotionDetailsAuthorisedUserPage), parameters);
            }
        }

        private void ShowShopClick(object sender, EventArgs e)
        {
            var parameters = Tuple.Create(Promotion.ShopId, AuthorisedUser);
            Frame.Navigate(typeof(AuthorisedUserMainPage), parameters);
        }

        private void GetWishlist(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WishListPage), AuthorisedUser);
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisedUserMainPage), AuthorisedUser);
        }
    }
}
