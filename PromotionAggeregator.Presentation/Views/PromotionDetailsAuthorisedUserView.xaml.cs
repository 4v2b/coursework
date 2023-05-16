using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class PromotionDetailsAuthorisedUserView : Page
    {
        private Promotion Promotion { get; set; }
        private AuthorisedUser AuthorisedUser { get; set; }
        private Shop Shop { get; set; }

        public PromotionDetailsAuthorisedUserView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Tuple<Promotion, AuthorisedUser> parameters)
            {
                Promotion = parameters.Item1;
                AuthorisedUser = parameters.Item2;
                wishBtn.Click -= RemoveWish;
                wishBtn.Click -= AddWish;
                Shop = Context.Instance.Shops.Find(x => x.Id == Promotion.ShopId);
                shopLink.NavigateUri = new Uri(Shop.Url);
                shopName.Text = Shop.Name;
                SwapButton();
                SetActionType();
                comments.ItemsSource = Promotion.Comments;
                rating.InitialSetValue = (int)Math.Floor(Promotion.Rating);
                globalRating.Text = Math.Round(Promotion.Rating, 2).ToString();

                titleBlock.Text = Promotion.Title;
                descriptionBlock.Text = Promotion.Description;
                if (AuthorisedUser.RatedPromotions.Contains(Promotion.Id))
                {
                    rating.IsEnabled = false;
                    rating.Foreground = Application.Current.Resources["AccentColor"] as SolidColorBrush;
                }
            }
            base.OnNavigatedTo(e);
        }

        private void SetActionType()
        {
            action.Click -= PromoCodeActionClick;
            action.Click -= SpecialOfferActionClickAsync;
            if (Promotion is PromoCode)
            {
                action.Click += PromoCodeActionClick;
                action.Content = (Promotion as PromoCode).Code;
                promoType.Text = "Промокод";
            }
            else
            {
                action.Click += SpecialOfferActionClickAsync;
                action.Content = "Перейти на сайт";
                promoType.Text = "Акція";
            }
        }

        private void SignOutClick(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(GuestMainPage));

        private void PublicateClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(commentField.Text))
            {
                AuthorisedUser.PostComment(commentField.Text, Promotion.Id);
            }
            Context.Instance.SaveAll();
            var parameters = Tuple.Create(Promotion, AuthorisedUser);
            Frame.Navigate(typeof(PromotionDetailsAuthorisedUserView), parameters);
        }

        private void SwapButton()
        {
            if (AuthorisedUser.WishlistContains(Promotion.Id))
            {
                wishIcon.Glyph = "\xEB52";
                wishBtn.Click -= AddWish;
                wishBtn.Click += RemoveWish;
            }
            else
            {
                wishIcon.Glyph = "\xEB51";
                wishBtn.Click -= RemoveWish;
                wishBtn.Click += AddWish;
            }
            Context.Instance.SaveAll();
        }

        private void AddWish(object sender, RoutedEventArgs e)
        {
            AuthorisedUser.AddToWishlist(Promotion.Id);
            SwapButton();
        }

        private void RemoveWish(object sender, RoutedEventArgs e)
        {
            AuthorisedUser.RemoveFromWishlist(Promotion.Id);
            SwapButton();
        }

        private void PromoCodeActionClick(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText(((Promotion as PromoCode).Code));
            Clipboard.SetContent(package);
            (sender as Button).Style = Application.Current.Resources["AuthButton"] as Style;
        }

        private async void SpecialOfferActionClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri uri = new Uri((Promotion as SpecialOffer).Url);
                await Launcher.LaunchUriAsync(uri);
            }
            catch
            {

            }
        }

        private void ShowShopPromotions(object sender, RoutedEventArgs e)
        {
            var parameters = Tuple.Create(Promotion.ShopId, AuthorisedUser);
            Frame.Navigate(typeof(AuthorisedUserMainPage), parameters);
            //Frame.Navigate(typeof())
        }

        private void rating_ValueChanged(RatingControl sender, object args)
        {
            AuthorisedUser.RatePromotion(Promotion.Id, sender.Value);
            sender.IsEnabled = false;
            globalRating.Text = Math.Round(Promotion.Rating, 2).ToString();
            Context.Instance.SaveAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WishListView), AuthorisedUser);
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
            AuthorisedUser.AddPromotion(p);
            //listView.ItemsSource = Init.Convert(Context.Instance.Promotions);
            Context.Instance.SaveAll();
        }

        private void action_Click(object sender, RoutedEventArgs e)
        {
            action.Click -= PromoCodeActionClick;
            action.Click -= SpecialOfferActionClickAsync;
            if (Promotion is PromoCode)
            {
                action.Click += PromoCodeActionClick;
                btnContent.Text = (Promotion as PromoCode).Code;
                promoType.Text = "Промокод";
            }
            else
            {
                action.Click += SpecialOfferActionClickAsync;
                btnContent.Text = "Перейти на сайт";
                promoType.Text = "Акція";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisedUserMainPage), AuthorisedUser);
        }
    }
}
