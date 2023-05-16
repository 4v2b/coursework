using PromotionAggeregator.Presentation.Services;
using PromotionAggeregator.Presentation.ViewModels;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class AuthorisedUserMainPage : Page
    {
        private IdentityUser identityUser;
        private AddPromoCodeDialog dialog;


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
                    shopId = (string)parameters.Item1;
                }
                identityUser.Notify += view.CountHandler;
                view.IdentityUser = identityUser;
                searchField.Identity = identityUser;
                searchField.OnSearchClick += view.Search;
                view.PromotionTap += PromotionTap;
                if (shopId != null)
                {
                    view.ShowAllInShop(shopId);
                }
            }
            base.OnNavigatedTo(e);
        }

        private void PromotionTap(object sender, Promotion promotion)
        {
            var parameters = Tuple.Create(promotion, identityUser.User as AuthorisedUser);
            Frame.Navigate(typeof(PromotionDetailsAuthorisedUserView), parameters);
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisationPage));
        }

        public void AddPromoCode(object sender, PromoCode p)
        {
            ((AuthorisedUser)identityUser.User).AddPromotion(p);
            //listView.ItemsSource = Init.Convert(Context.Instance.Promotions);
            Context.Instance.SaveAll();
            view.Refresh();
            Frame.Navigate(typeof(AuthorisedUserMainPage), identityUser.User as AuthorisedUser);
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialog = new AddPromoCodeDialog();
            dialog.PromoCodeConfirmed -= AddPromoCode;
            dialog.PromoCodeConfirmed += AddPromoCode;
            dialog.ShowAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WishListView), identityUser.User as AuthorisedUser);
        }
    }
}
