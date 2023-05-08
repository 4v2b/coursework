using PromotionAggeregator.Presentation.Services;
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
    public sealed partial class PromotionGuestView : Page
    {
        private Promotion Promotion { get; set; }

        public PromotionGuestView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Promotion)
            {
                Promotion = e.Parameter as Promotion;
            }
            comments.ItemsSource = Promotion.Comments;
            base.OnNavigatedTo(e);
        }

        private void Search(object sender, ArrayList e) => Frame.Navigate(typeof(GuestMainPage), e);

        private void SignInClick(object sender, RoutedEventArgs e) => Frame.Navigate(typeof(AuthorisationPage));


        private void RegisterClick(object sender, RoutedEventArgs e)=>Frame.Navigate(typeof(RegistrationPage));
    }
}
