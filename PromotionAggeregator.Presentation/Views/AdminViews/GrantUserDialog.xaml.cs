using PromotionAggregator.Logic.Context;
using PromotionAggregator.Logic.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
                if(!Admin.GrantUser(userBox.SelectedValue as string))
                {
                    throw new Exception("Оберіть електронну пошту користувача");
                }

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
