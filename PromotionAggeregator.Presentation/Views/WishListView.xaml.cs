using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
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
    public sealed partial class WishListView : Page
    {
        //public Promotion Promotion { get; set; }
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

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var parameters = Tuple.Create(e.ClickedItem as Promotion, CurrentUser);
            Frame.Navigate(typeof(PromotionDetailsAuthorisedUserView), parameters);
        }

        private void WishlistItem_OnRemoveClick(object sender, string e)
        {
            CurrentUser.RemoveFromWishlist(e);
            Frame.Navigate(typeof(WishListView), CurrentUser);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WishListView), CurrentUser);
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddPromoCodeDialog dialog = new AddPromoCodeDialog();
            dialog.ShowAsync();
            dialog.PromoCodeConfirmed += AddPromoCode;
        }

        public void AddPromoCode(object sender, PromoCode p)
        {
            CurrentUser.AddPromotion(p);
            //listView.ItemsSource = Init.Convert(Context.Instance.Promotions);
            Context.Instance.SaveAll();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisedUserMainPage), CurrentUser);
        }
    }
}
