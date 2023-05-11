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
    public sealed partial class PromotionAdminView : Page
    {
        private Promotion Promotion { get; set; }
        private Admin Admin { get; set; }

        public PromotionAdminView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Tuple<Promotion, Admin> parameters)
            {
                Promotion = parameters.Item1;
                Admin = parameters.Item2;
            }
            comments.ItemsSource = Promotion.Comments;
            base.OnNavigatedTo(e);
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuthorisationPage));
        }

        private void Search(object sender, ArrayList e) => Frame.Navigate(typeof(GuestMainPage), e);

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var userId = (sender as Button)?.CommandParameter as string;
            if (userId != null)
            {
                Admin.RemoveComment(userId, Promotion.Id);
                Context.Instance.SaveAll();
                var parameters = Tuple.Create(Promotion, Admin);
                Frame.Navigate(typeof(PromotionAdminView), parameters);

            }
        }

        private void HideClick(object sender, RoutedEventArgs e)
        {
            Flyout flyout = (sender as Button)?.CommandParameter as Flyout;
            if (flyout != null)
            {
                flyout.Hide();
            }
        }
    }
}
