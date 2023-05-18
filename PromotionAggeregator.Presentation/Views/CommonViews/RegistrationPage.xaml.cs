using PromotionAggeregator.Presentation.Services;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = Authentication.Register(email.Text, password.Password, repeatPassword.Password);
                Context.Instance.SaveAll();
                errorMessage.Text = "";
                if (user is AuthorisedUser)
                {
                    Frame.Navigate(typeof(AuthorisedUserMainPage), user);
                }
                else
                {
                    Frame.Navigate(typeof(AdminMainPage), user);
                }
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
