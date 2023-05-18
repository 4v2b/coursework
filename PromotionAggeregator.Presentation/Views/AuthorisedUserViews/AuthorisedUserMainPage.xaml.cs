using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class AuthorisedUserMainPage : Page
    {
        private IdentityUser identityUser;

        public AuthorisedUserMainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is AuthorisedUser || e.Parameter is Tuple<string, AuthorisedUser>)
            {
                string shopId = null;
                if(e.Parameter is AuthorisedUser)
                {
                    identityUser = new IdentityUser((AuthorisedUser)e.Parameter);
                }
                else
                {
                    var parameters = e.Parameter as Tuple<string, AuthorisedUser>;
                    identityUser = new IdentityUser(parameters.Item2);
                    shopId = parameters.Item1;
                }
                identityUser.Notify += view.GetNumberOfResults;
                view.IdentityUser = identityUser;
                searchField.Identity = identityUser;
                searchField.SearchClicked += view.Search;
                view.PromotionTap += PromotionTap;
                if (shopId != null)
                {
                    view.GetPromotionsInShop(shopId);
                }
            }
            base.OnNavigatedTo(e);
        }

        private void PromotionTap(object sender, Promotion promotion)
        {
            var parameters = Tuple.Create(promotion, identityUser.User as AuthorisedUser);
            Frame.Navigate(typeof(PromotionDetailsAuthorisedUserPage), parameters);
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }

        public void AddPromoCode(object sender, PromoCode p)
        {
            ((AuthorisedUser)identityUser.User).AddPromotion(p);
            Context.Instance.SaveAll();
            view.Refresh();
            Frame.Navigate(typeof(AuthorisedUserMainPage), identityUser.User as AuthorisedUser);
        }

        private async void CallDialog(object sender, RoutedEventArgs e)
        {
            AddPromoCodeDialog dialog = new AddPromoCodeDialog();
            dialog.PromoCodeConfirmed -= AddPromoCode;
            dialog.PromoCodeConfirmed += AddPromoCode;
             await dialog.ShowAsync();
        }

        private void GetWishlist(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WishListPage), identityUser.User as AuthorisedUser);
        }
    }
}
