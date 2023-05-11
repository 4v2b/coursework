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
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AdminControl : Page
    {
        private IdentityUser manager;

        public AdminControl()
        {
            this.InitializeComponent();
            list.ItemsSource = Context.Instance.Promotions;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Admin)
            {
                manager = new IdentityUser((Admin)e.Parameter);
                list.ItemsSource = Context.Instance.Promotions;
            }
            base.OnNavigatedTo(e);
        }

        private void AdminPromotionView_OnDeleteClick(object sender, Promotion e)
        {
            (manager.User as Admin).RemovePromotion(e.Id);
            Context.Instance.SaveAll();
            Frame.Navigate(typeof(AdminControl), manager.User);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AdminMainPage), manager.User as Admin);
        }
    }
}
