using PromotionAggeregator.Presentation.Services;
using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
