using PromotionAggregator.Logic.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class AuthorisationPage : Page
    {
        public AuthorisationPage()
        {
            this.InitializeComponent();
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = Authentication.SignIn(email.Text, password.Password);
                if (user is AuthorisedUser)
                {
                    Frame.Navigate(typeof(AuthorisedUserMainPage), user);
                }
                else Frame.Navigate(typeof(AdminMainPage), user);
            }
            catch(Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuestMainPage));
        }
    }
}
