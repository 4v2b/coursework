using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class PromotionDetailsAdminPage : Page
    {
        private Promotion Promotion { get; set; }
        private Admin Admin { get; set; }

        public PromotionDetailsAdminPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Tuple<Promotion, Admin> parameters)
            {
                Promotion = parameters.Item1;
                Admin = parameters.Item2;
                details.CurrentUser = Admin;
                details.Promotion = Promotion;
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
            comments.ItemsSource = Promotion.Comments;
            base.OnNavigatedTo(e);
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var userId = (sender as Button)?.CommandParameter as string;
            if (userId != null)
            {
                Admin.RemoveComment(userId, Promotion.Id);
                Context.Instance.SaveAll();
                var parameters = Tuple.Create(Promotion, Admin);
                Frame.Navigate(typeof(PromotionDetailsAdminPage), parameters);
            }
        }

        private void HideFlyoutClick(object sender, RoutedEventArgs e)
        {
            Flyout flyout = (sender as Button)?.CommandParameter as Flyout;
            if (flyout != null)
            {
                flyout.Hide();
            }
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AdminMainPage), Admin);
        }

        private void ShowShopClick(object sender, EventArgs e)
        {
            Frame.Navigate(typeof(AdminMainPage), Promotion.ShopId);
        }
    }
}
