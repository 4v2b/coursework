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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PromotionAggeregator.Presentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminMainPage : Page
    {
        private IdentityUser manager;
        private TextBlock resultIndicator;
        private AddPromotionDialog dialog;


        private void PromotionTap(object sender, Promotion promotion)
        {
            var parameters = Tuple.Create(promotion, manager.User as Admin);
            Frame.Navigate(typeof(PromotionAdminView), parameters);
        }

        public AdminMainPage()
        {
            this.InitializeComponent();
            manager = new IdentityUser();
            ArrayList list = Init.Convert(Context.Instance.Promotions);
            Init.BindClick(PromotionTap, list);
            listView.ItemsSource = list;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisationPage));
        }

        private void Search(object sender, ArrayList e)
        {
            Init.BindClick(PromotionTap, e);
            listView.ItemsSource = e;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Admin)
            {
                manager = new IdentityUser((Admin)e.Parameter);
            }
            if (e.Parameter is ArrayList)
            {
                Init.BindClick(PromotionTap, (ArrayList)e.Parameter);
                listView.ItemsSource = e.Parameter;
            }
            base.OnNavigatedTo(e);
        }

        private void GetPromotion(object sender, Promotion p)
        {
            try
            {
                ((Admin)manager.User).AddPromotion(p);
                listView.ItemsSource = Init.Convert(Context.Instance.Promotions);
            }
            catch(Exception e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            dialog = new AddPromotionDialog();
            dialog.PromotionConfirmed += GetPromotion;
            await dialog.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AdminControl), manager.User);
        }
    }
}
