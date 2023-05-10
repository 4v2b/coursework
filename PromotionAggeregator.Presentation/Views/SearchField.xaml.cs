using PromotionAggeregator.Presentation.Services;
using PromotionAggeregator.Presentation.ViewModels;
using PromotionAggregator.Logic.Context;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PromotionAggeregator.Presentation.Views
{
    public sealed partial class SearchField : UserControl
    {
        private Dictionary<string, Category> categories;

        public IdentityUser Identity { get; set; }

        public SearchField()
        {
            categories = Util.CategoryMap;
            this.InitializeComponent();
        }

        public event EventHandler<List<Promotion>> OnSearchClick;

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            this.OnSearchClick?.Invoke(sender, Identity.Search(searchField.Text));
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var pair = (KeyValuePair<string, Category>)e.ClickedItem;
            this.OnSearchClick?.Invoke(sender, Identity.GetPromotionsInCategory(pair.Value));
        }
    }
}
