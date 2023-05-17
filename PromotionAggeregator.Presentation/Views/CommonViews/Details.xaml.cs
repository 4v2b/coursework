using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using User = PromotionAggregator.Logic.Services.User;

namespace PromotionAggeregator.Presentation.Views.CommonViews
{
    public sealed partial class Details : UserControl
    {
        private Promotion promotion;

        public Promotion Promotion
        {
            get => promotion;
            set
            {
                promotion = value;
                Initialize();
            }
        }
        public User CurrentUser { get; set; }
        private Shop Shop { get; set; }

        public Details()
        {
            this.InitializeComponent();
        }

        private void Initialize()
        {
            Shop = Context.Instance.Shops.Find(x => x.Id == promotion.ShopId);
            shopLink.NavigateUri = new Uri(Shop.Url);
            shopName.Text = Shop.Name;
            SetActionType();
            rating.InitialSetValue = (int)Math.Floor(promotion.Rating);
            date.Text = "Діє до:\n" + promotion.EndDate.ToShortDateString();

            rating.Caption = $"{Math.Round(promotion.Rating, 2)} / 5";

            titleBlock.Text = promotion.Title;
            descriptionBlock.Text = promotion.Description;


            if ((CurrentUser != null && (CurrentUser is AuthorisedUser)))
            {
                wishBtn.Click -= RemoveWish;
                wishBtn.Click -= AddWish;
                SwapButton();
                wishBtn.Visibility = Visibility.Visible;
            }
            else
            {
                wishBtn.Visibility = Visibility.Collapsed;
            }


            if (CurrentUser is AuthorisedUser && !(CurrentUser as AuthorisedUser).RatedPromotions.Contains(Promotion.Id))
            {
                rating.IsEnabled = true;
            }
            else
            {
                rating.IsEnabled = false;
                if (promotion.Rating != 0)
                {
                    rating.Value = Math.Round(promotion.Rating, 2);
                }
            }
        }

        private void SwapButton()
        {
            if ((CurrentUser as AuthorisedUser).WishlistContains(Promotion.Id))
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
            (CurrentUser as AuthorisedUser).AddToWishlist(Promotion.Id);
            SwapButton();
        }

        private void RemoveWish(object sender, RoutedEventArgs e)
        {
            (CurrentUser as AuthorisedUser).RemoveFromWishlist(Promotion.Id);
            SwapButton();
        }

        public event EventHandler ShopClicked;

        private void RatingValueChanged(RatingControl sender, object args)
        {
            (CurrentUser as AuthorisedUser).RatePromotion(Promotion.Id, sender.Value);
            rating.IsEnabled = false;

            rating.Caption = $"{Math.Round(Promotion.Rating, 2).ToString()} / 5";

            Context.Instance.SaveAll();
        }

        private void ShowShopPromotions(object sender, RoutedEventArgs e)
        {
            ShopClicked?.Invoke(this, null);
        }

        private async void SpecialOfferActionClickAsync(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri((Promotion as SpecialOffer).Url);
            await Launcher.LaunchUriAsync(uri);
        }

        private void PromoCodeActionClick(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText(((Promotion as PromoCode).Code));
            Clipboard.SetContent(package);
            (sender as Button).Style = Application.Current.Resources["AuthButton"] as Style;
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
    }
}
