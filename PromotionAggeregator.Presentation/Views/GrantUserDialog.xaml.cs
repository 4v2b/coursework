using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Services;
using System;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class GrantUserDialog : ContentDialog
    {
        private Admin Admin { get; set; }

        public GrantUserDialog()
        {
            this.InitializeComponent();
            var users = Context.Instance.Users.FindAll(x => x is AuthorisedUser);
            userBox.ItemsSource = users;
        }

        public GrantUserDialog(Admin admin):this()
        {
            Admin = admin;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Admin.GrantUser(userBox.SelectedValue as string);

                this.Hide();
                errorMessage.Visibility = Visibility.Collapsed;
            }
            catch(Exception ex)
            {
                errorMessage.Text = ex.Message;
                errorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
