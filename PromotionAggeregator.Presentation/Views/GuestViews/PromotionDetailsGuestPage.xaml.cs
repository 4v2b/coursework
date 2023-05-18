using PromotionAggregator.Logic.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class PromotionDetailsGuestPage : Page
    {
        private Promotion Promotion { get; set; }

        public PromotionDetailsGuestPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Promotion)
            {
                Promotion = e.Parameter as Promotion;

                details.ShopClicked += ShowShopClick;

                if (Promotion.Comments.Count < 1)
                {
                    commentsInfo.Visibility = Visibility.Visible;
                }
                else
                {
                    commentsInfo.Visibility = Visibility.Collapsed;
                }
            }
            base.OnNavigatedTo(e);
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }

        private void ShowShopClick(object sender, EventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage), Promotion.ShopId);
        }

        private void SignInClick(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(AuthorisationPage));

        private void RegisterClick(object sender, RoutedEventArgs e)=>Frame.Navigate(typeof(RegistrationPage));
    }
}
