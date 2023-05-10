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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PromotionAggeregator.Presentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PromotionView : Page
    {
        private Promotion Promotion { get; set; }
        private AuthorisedUser AuthorisedUser { get; set; }

        public PromotionView()
        {
            this.InitializeComponent();
            SetActionType();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Tuple<Promotion, AuthorisedUser> parameters)
            {
                Promotion = parameters.Item1;
                AuthorisedUser = parameters.Item2;
                SwapButton();
                SetActionType();
                comments.ItemsSource = Promotion.Comments;
            }
            base.OnNavigatedTo(e);
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
        }

        private void SetActionType()
        {
            action.Click -= PromoCodeActionClick;
            action.Click -= SpecialOfferActionClickAsync;
            if (Promotion is PromoСode)
            {
                action.Click += PromoCodeActionClick;
                action.Content = (Promotion as PromoСode).Code;
                promoType.Text = "Промокод";

            }
            else
            {
                action.Click += SpecialOfferActionClickAsync;
                action.Content = "Перейти на сайт";
                promoType.Text = "Акція";
               // new SolidColorBrush(new Windows.UI.Color() { }); ;
            }
        }

        private void Search(object sender, ArrayList e) => Frame.Navigate(typeof(UserMainPage), e);

        private void SignInClick(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(AuthorisationPage));

        private void PublicateClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(commentField.Text))
            {
                AuthorisedUser.PostComment(commentField.Text, Promotion.Id);
            }
            Context.Instance.SaveAll();
            var parameters = Tuple.Create(Promotion, AuthorisedUser);
            Frame.Navigate(typeof(PromotionView), parameters);
        }

        private void AddWish(object sender, RoutedEventArgs e)
        {
            try
            {
                AuthorisedUser.AddToWishlist(Promotion.Id);
                SwapButton();
            }
            catch
            {

            }
        }

        private void RemoveWish(object sender, RoutedEventArgs e)
        {
            try
            {
                AuthorisedUser.RemoveFromWishlist(Promotion.Id);
                SwapButton();
            }
            catch
            {

            }
        }


        private void PromoCodeActionClick(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText(((Promotion as PromoСode).Code));
            Clipboard.SetContent(package);
        }

        private void SpecialOfferActionClickAsync(object sender, RoutedEventArgs e)
        {
            GetWebPage();
        }

        private async Task GetWebPage()
        {
            Uri uri = new Uri((Promotion as SpecialOffer).Url);

            await Launcher.LaunchUriAsync(uri);
        }
    }
}
