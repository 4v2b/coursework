using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Services;
using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PromotionAggeregator.Presentation.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = Authentication.Register(email.Text, password.Password, repeatPassword.Password);
                Context.Instance.SaveAll();

               if (user is AuthorisedUser)
                {
                    Frame.Navigate(typeof(UserMainPage), user);
                }
                else Frame.Navigate(typeof(AdminMainPage), user);
            }
            catch(Exception ex)
            {
                message.Text = ex.Message;
            }
        }
    }
}
