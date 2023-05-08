using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public sealed partial class PromotionView : Page
    {
        private Promotion Promotion { get; set; }
        private AuthorisedUser AuthorisedUser { get; set; }

        public PromotionView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter is Tuple<Promotion, AuthorisedUser> parameters)
                {
                    Promotion = parameters.Item1;
                    AuthorisedUser = parameters.Item2;
                }
            comments.ItemsSource = Promotion.Comments;
            base.OnNavigatedTo(e);
        }

        private void Search(object sender, ArrayList e) => Frame.Navigate(typeof(GuestMainPage), e);

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
    }
}
