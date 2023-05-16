using PromotionAggeregator.Presentation.Services;
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
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class PromotionGuestView : Page
    {
        private Promotion Promotion { get; set; }
        private Shop Shop { get; set; }

        public PromotionGuestView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Promotion)
            {
                Promotion = e.Parameter as Promotion;

               Shop = Context.Instance.Shops.Find(x => x.Id == Promotion.ShopId);
                shopLink.NavigateUri = new Uri(Shop.Url);
                shopName.Text = Shop.Name;
                SetActionType();
                comments.ItemsSource = Promotion.Comments;
                rating.InitialSetValue = (int)Math.Floor(Promotion.Rating);
                globalRating.Text = Math.Round(Promotion.Rating, 2).ToString();

                titleBlock.Text = Promotion.Title;
                descriptionBlock.Text = Promotion.Description;
                    rating.IsEnabled = false;
                    rating.Foreground = Application.Current.Resources["AccentColor"] as SolidColorBrush;


            }
            base.OnNavigatedTo(e);
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
            Frame.Navigate(typeof(GuestMainPage));
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
            Frame.Navigate(typeof(GuestMainPage), Promotion.ShopId);
            //Frame.Navigate(typeof())
        }


        private void SignInClick(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(AuthorisationPage));


        private void RegisterClick(object sender, RoutedEventArgs e)=>Frame.Navigate(typeof(RegistrationPage));
    }
}
