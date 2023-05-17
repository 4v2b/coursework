using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class AdminControl : Page
    {
        private Admin admin;

        public AdminControl()
        {
            this.InitializeComponent();
            list.ItemsSource = Context.Instance.Promotions;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Admin)
            {
                admin = e.Parameter as Admin;
                list.ItemsSource = Context.Instance.Promotions.OrderByDescending(x=>x);
            }
            base.OnNavigatedTo(e);
        }

        private void DeletePromotionClick(object sender, Promotion e)
        {
            admin.RemovePromotion(e.Id);
            Context.Instance.SaveAll();
            Frame.Navigate(typeof(AdminControl), admin);
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AdminMainPage), admin);
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }
    }
}
