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
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class AdminMainPage : Page
    {
        private IdentityUser identityUser;
        private AddPromotionDialog dialog;


        private void PromotionTap(object sender, Promotion promotion)
        {
            var parameters = Tuple.Create(promotion, identityUser.User as Admin);
            Frame.Navigate(typeof(PromotionAdminView), parameters);
        }

        public AdminMainPage()
        {
            this.InitializeComponent();
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Admin || e.Parameter is Tuple<string, Admin>)
            {
                string shopId = null;
                if (e.Parameter is Admin)
                {
                    identityUser = new IdentityUser((Admin)e.Parameter);
                }
                else
                {
                    var parameters = e.Parameter as Tuple<string, Admin>;
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

        private void GetPromotion(object sender, Promotion p)
        {

                ((Admin)identityUser.User).AddPromotion(p);
            Context.Instance.SaveAll();
            view.Refresh();
            Frame.Navigate(typeof(AdminMainPage), identityUser.User as Admin);
        }

        private async void CallPromotionDialog(object sender, RoutedEventArgs e)
        {
            dialog = new AddPromotionDialog();
            dialog.PromotionConfirmed -= GetPromotion;
            dialog.PromotionConfirmed += GetPromotion;
            await dialog.ShowAsync();
        }

        private void NavigateToAdminControlClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AdminControl), identityUser.User);
        }

        private async void CallUserDialog(object sender, RoutedEventArgs e)
        {
            await new GrantUserDialog(identityUser.User as Admin).ShowAsync();
        }

        private void GetShop(object sender, Shop p)
        {

            ((Admin)identityUser.User).AddShop(p);
            Context.Instance.SaveAll();
            view.Refresh();
        }

        private async void CallShopDialog(object sender, RoutedEventArgs e)
        {
            AddShopDialog dialog = new AddShopDialog();
            dialog.ShopConfirmed -= GetShop;
            dialog.ShopConfirmed += GetShop;
            await dialog.ShowAsync();
        }
    }
}
