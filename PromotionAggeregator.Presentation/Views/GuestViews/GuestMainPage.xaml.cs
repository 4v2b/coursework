using PromotionAggregator.Logic.Models;
using PromotionAggregator.Logic.Services;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class GuestMainPage : Page
    {
        public GuestMainPage()
        {
            this.InitializeComponent();
            IdentityUser identityUser = new IdentityUser();
            identityUser.Notify += view.GetNumberOfResults;
            view.IdentityUser = identityUser;
            searchField.Identity = identityUser;
            searchField.SearchClicked += view.Search;
            view.PromotionTap += PromotionTap;
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            DataPackage package = new DataPackage();
            package.SetText("text");
            Clipboard.SetContent(package);
            Frame.Navigate(typeof(AuthorisationPage));
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationPage));
        }

        private void PromotionTap(object sender, Promotion promotion)
        {
            Frame.Navigate(typeof(PromotionDetailsGuestView), promotion);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string && !string.IsNullOrEmpty(e.Parameter as string))
            {
                view.GetPromotionsInShop((string)e.Parameter);
            }
            base.OnNavigatedTo(e);
        }
    }
}
